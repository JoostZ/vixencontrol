/**
 * \file ModbufCB.c
 * Modbuf Call back functions
 *
 * \page modbuf The modbuf protocol
 * Modbus is a communication protocol between a Master and (possibly multiple) slave(s).
 * For our project we will use the PC (e.g., ASCOM driver) as the master and the controller as slave.
 *
 * In a Modbus communication the master will always initiate a request and will always expect a single response.
 * The request and response are packed in a single PDU that consists of a function code followed by, possibly 0, data bytes.
 *
 *  This PDU is then wrapped in a so-called ADU that contains address information (to allow communication with multiple slaves)
 *  and a CRC to allow validation of the PDU. The Modbus definition defines several types of data that can be accessed
 *  through the protocol
 *  	- Input Discrete. These are single bit read-only entities
 *  	- Coils. These are single bit read-write entities.
 *   	  They are logically arranged in a Coil Address space, i.e., each coil has a unique address.
 *   	- Input Registers. These are 16-bit read-write entities.
 *   	- Holding Registers. These are 16-bit read-write entities.
 *  Each of these entities can be accessed with its own logical address.
 *  Which entity is addressed is defined by the function code.
 *
 *  All of the logic is handled in general Modbus functionality. The tie in to
 *  the Telescope functionality is through a few call back functions that are defined
 *  in \ref ModbufCB.c
 */
#include "mb.h"
#include "TelescopeControl.h"
#include "keys.h"
#include "motor.h"
#include "Version.h"

/**
 * \brief
 * Base addresses for the different ranges
 */
enum AddressOffsets {
	GeneralData = 0, ///< General axis-independent data
	RaData = 1000,   ///< Data associated with RA axis
	DecData = 2000   ///< Data associated with Dec axis
};

/**
 * \brief General Input Registers
 */
enum GeneralStatus {
	Version ///< Current Software Version
};

/**
 * \brief Axis-dependent Input Registers
 */
enum AxisStatus {
	Speed	///< Speed of an axis (in multiples of tracking speed)
};

eMBErrorCode eMBRegInputCB(UCHAR * pucRegBuffer, USHORT usAddress,
		USHORT usNRegs) {
	int i;
	UCHAR* bufferP;
	USHORT value;

	for (i = 0, bufferP = pucRegBuffer; i < usNRegs; usAddress++, i++) {
		if (usAddress >= DecData) {
			switch (usAddress - DecData) {
			case Speed:
				*bufferP++ = 0;
				*bufferP++ = 0;
				break;
			default:
				return MB_ENOREG;
			}
		} else if (usAddress >= RaData) {
			switch (usAddress - RaData) {
			case Speed:
				value = (USHORT)GetRaCurrentSpeed();
				*bufferP++ = value >> 8;
				*bufferP++ = value & 0xFF;
				break;
			default:
				return MB_ENOREG;
			}
		} else {
			switch (usAddress - GeneralData) {
			case Version:
				*bufferP++ = SoftwareVersion >> 8;
				*bufferP++ = SoftwareVersion & 0xff;
				break;
			default:
				return MB_ENOREG;
			}
		}
	}

	return MB_ENOERR;
}

eMBErrorCode eMBRegHoldingCB(UCHAR * pucRegBuffer, USHORT usAddress,
		USHORT usNRegs, eMBRegisterMode eMode) {
	return MB_ENOERR;
}
/**
 * \brief Axis-independent coils
 */
enum GeneralCoils {
	Tracking, ///< Tracking on or off
	Fast	  ///< Fast on or off
};

/**
 * \brief Axis-dependent coils
 */
enum AxisCoils {
	Forward,	///< Clock-wise motion
	Backward	///< Anti clockwise motion
};

inline
void ChangeKey(uint8_t key, BOOL value) {
	if (value) {
		SetPcBit(key);
	} else {
		ClearPcBit(key);
	}
}

eMBErrorCode eMBRegCoilsCB(UCHAR * pucRegBuffer, USHORT usAddress,
		USHORT usNCoils, eMBRegisterMode eMode) {

	if (usNCoils == 0 ) {
		return MB_EINVAL;
	}

	if (eMode == MB_REG_READ) {
		int i;
		for (i = 0; i < usNCoils; usAddress++, i++) {
			UCHAR buffer = 0;
			if (i % 8 == 0) {
				buffer = *(pucRegBuffer++);
			}

			BOOL value = buffer & 1;
			buffer >>= 1;
			if (usAddress >= DecData) {
				switch (usAddress - DecData) {
				case Forward:
					ChangeKey(BUTTON_UP, value);
					break;
				case Backward:
					ChangeKey(BUTTON_DOWN, value);
					break;
				default:
					return MB_ENOREG;
				}
			} else if (usAddress >= RaData) {
				switch (usAddress - RaData) {
				case Forward:
					ChangeKey(BUTTON_RIGHT, value);
					break;
				case Backward:
					ChangeKey(BUTTON_LEFT, value);
					break;
				default:
					return MB_ENOREG;
				}
			} else {
				switch (usAddress - GeneralData) {
				case Tracking:
					ChangeKey(RA_TRACKING, value);
					break;
				case Fast:
					ChangeKey(TOGGLE_FAST, value);
					break;
				default:
					return MB_ENOREG;
				}
			}
		}
	} else {
		// Read the coils
		int i;
		UCHAR mask = 0;
		UCHAR *bufferP = 0;

		for (i = 0; i < usNCoils; usAddress++, i++) {
			if (i % 8 == 0) {
				bufferP = pucRegBuffer++;
				mask = 0x01;
			}

			BOOL value = FALSE;
			if (usAddress >= DecData) {
				switch (usAddress - DecData) {
				case Forward:
					break;
				case Backward:
					break;
				default:
					return MB_ENOREG;
				}
			} else if (usAddress >= RaData) {
				switch (usAddress - RaData) {
				case Forward:
					value = ButtonRight();
					break;
				case Backward:
					value = ButtonLeft();
					break;
				default:
					return MB_ENOREG;
				}
			} else {
				switch (usAddress - GeneralData) {
				case Tracking:
					value = IsTracking();
					break;
				case Fast:
					value = FastOn();
					break;
				default:
					return MB_ENOREG;
				}
			}
			if (value) {
				*bufferP |= mask;
			}
			mask <<= 1;
		}
	}
	return MB_ENOERR;
}

