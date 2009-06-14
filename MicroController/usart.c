#include <avr/interrupt.h>

#include "usart.h"
#include "TelescopeControl.h"
#include "motor.h"
#include "keys.h"
#include "Version.h"

static uint8_t writeBuffer[4];
static uint8_t writeIdx = 0;

static uint8_t dataBuffer[4];
static uint8_t dataIdx = 0;

static int32_t GetLong();
static void SendLong(uint32_t value);
#define BUFSIZE 20

static uint8_t buffer[BUFSIZE];
static uint8_t readIdx = 0;
static uint8_t nextIdx = 0;

/**
 * @brief 
 * Add a byte to the buffer
 *
 * @param The byte to store
 *
 * @note
 * There is no error checking! The buffer is oversized for its expected
 * usage. If we have a buffer overrun, something is seriously wrong in
 * the program anyway.
 */
void addByte(uint8_t aByte)
{
	buffer[nextIdx] = aByte;
	if (++nextIdx >= BUFSIZE)
	{
		nextIdx = 0;
	}
}

/**
 * @brief
 * Read the next byte from the buffer
 *
 * @return The next byte in the buffer
 */
uint8_t readByte()
{
	if (readIdx == nextIdx)
	{
		// No data in the buffer
		return 0;
	}

	uint8_t result = buffer[readIdx++];
	if (readIdx >= BUFSIZE)
	{
		readIdx = 0;
	}
	return result;
}

/**
 * @brief 
 * Check the number of entries in the buffer
 *
 * @return
 * The number of entries
 */
uint8_t bufferEntries()
{
	if (nextIdx >= readIdx)
	{
		return nextIdx - readIdx;
	}
	else
	{
		return BUFSIZE + nextIdx - readIdx;
	}
}



/**
 * \brief Interrupt routine for reception of a character on the UART
 */
ISR(USART_RXC_vect)
{

	addByte(UDR);

	SetEvent(usart_rx);

}

/**
 * \brief Handle Data Register Empty
 */
ISR(USART_UDRE_vect)
{
	if (writeIdx == 0)
	{
		// This should never happen. Make sure the interrupt
		// is off
		UCSRB &= ~(_BV(UDRIE));
		return;
	}

	--writeIdx;
	UDR = writeBuffer[writeIdx];

	if (writeIdx == 0)
	{
		// disable the interrupt
		UCSRB &= ~(_BV(UDRIE));
	}
}


/**
 * \brief Check if the UART is available for sending data
 *
 */
int UartSendingFree()
{
	if (writeIdx)
	{
		return 0;
	}

	if (bit_is_clear(UCSRA, UDRIE))
	{
		return 0;
	}

	return 1;
}


int32_t GetLong()
{
	uint32_t value = 0;
	int i;
	for (i = 3; i >= 0; i--)
	{
		value <<= 8;
		value |= dataBuffer[i];
	}
	return (int32_t)value;
}
/**
 * \brief Send a long (4 byte) value over the UART
 *
 * \param value
 * value to send
 */
void SendLong(uint32_t value)
{
	int i;

	// Check if the UART out is available
	if (!UartSendingFree())
	{
		return;
	}

	// Copy the data to the write buffer
	for (i = 0; i <= 3; i++)
	{
		writeBuffer[i] = value & 0xff;
		value >>= 8;
	}

	writeIdx = 3;

	// Start the transmission
	UDR = writeBuffer[writeIdx];

	// Enable the Dataregister Empty interrupt
	UCSRB |= _BV(UDRIE);
}

void UsartInit()
{
	UCSRA = _BV(U2X);
	UCSRB = _BV(TXEN) | _BV(RXEN) | _BV(RXCIE);
	UBRRL = (F_CPU / (8 * 9600UL)) - 1;
}

        
#define readRALimit 0xDE
#define writeRALimit 0xBE
#define writeLeftOn 0xA8
#define writeLeftOff 0xA9
#define writeRightOn 0xAA
#define writeRightOff 0xAB
#define writeOnOn 0xAE
#define writeOnOff 0xAF
#define readRaAcceleration 0xD5
#define writeRaAcceleration 0xD6
#define readRaAccelerationUpdate 0xDA
#define writeRaAccelerationUpdate 0xDB
#define readRaCurrentSpeed 0xD9
#define writeFastOn 0xB0
#define writeFastOff 0xB1
#define getVersion 0xD7
#define writeRaAccelerationLowerLimit 0xD1
#define readRaAccelerationLowerLimit 0xD2
#define readRaTargetPosition 0xB2
#define writeRaTargetPosition 0xB3
#define writeRaGotoStart 0xB4
#define writeRaGotoStop 0xB5
#define resetRaCurrentPos 0xB8
#define writeRaBacklash 0x11
#define readRaBacklash 0x12


void HandleCommand()
{
	uint8_t command;
	cli();
	
	while(bufferEntries() != 0)
	{
		command = readByte();
		sei();
		if ((command & 0xf0) == 0x80)
		{
			dataBuffer[dataIdx] = (command & 0x0f) << 4;
		}
		else if ((command & 0xf0) == 0x90)
		{
			dataBuffer[dataIdx] |= (command & 0x0f);
			if (++dataIdx >= 4)
			{
				dataIdx = 0;
			}
		}
		else
		{
			if (dataIdx != 0)
			{
				// Something is wrong in the protocol. There is only
				// a partly filled dataBuffer available, while we are
				// receiving a command. Ignore the command and reset the buffer
				dataIdx = 0;
				cli();
				continue; // handle next byte
			}
			switch(command)
			{
			case 0xA3:	// Reset dataBuffer
				dataIdx = 0;
				break;
			case 0xB7:	// Return RA position
				SendLong(GetRaPos());
				break;
			case resetRaCurrentPos:
				ResetRaPos();
				break;
			case readRALimit:
				SendLong(GetRaFast());
				break;
			case writeRALimit:
				SetRaFast(GetLong());
				break;
			case readRaTargetPosition:
				SendLong(GetRaTargetPos());
				break;
			case writeRaGotoStart:
				StartRaGoto();
				break;
			case writeRaGotoStop:
				StopRaGoto();
				break;
			case writeRaTargetPosition:
				SetRaTargetPos(GetLong());
				break;
			case readRaAcceleration:
				SendLong(GetRaAcceleration());
				break;
			case writeRaAcceleration:
				SetRaAcceleration(GetLong());
				break;
			case readRaAccelerationUpdate:
				SendLong(GetRaUpdatePeriod());
				break;
			case writeRaAccelerationUpdate:
				SetRaUpdatePeriod(GetLong());
				break;
			case writeRaAccelerationLowerLimit:
				SetRaAccLL(GetLong());
				break;
			case readRaAccelerationLowerLimit:
				SendLong(GetRaAccLL());
				break;
			case readRaCurrentSpeed:
				SendLong(GetRaCurrentSpeed());
				break;
			case writeRaBacklash:
				SetRaBacklash(GetLong());
				break;
			case readRaBacklash:
				SendLong(GetRaBacklash());
				break;
			case writeLeftOn:
				SetPcBit(BUTTON_LEFT);
				break;
			case writeLeftOff:
				ClearPcBit(BUTTON_LEFT);
				break;
			case writeRightOn:
				SetPcBit(BUTTON_RIGHT);
				break;
			case writeRightOff:
				ClearPcBit(BUTTON_RIGHT);
				break;
			case writeOnOn:
				SetPcBit(RA_TRACKING);
				break;
			case writeOnOff:
				ClearPcBit(RA_TRACKING);
				break;
			case writeFastOn:
				SetPcBit(TOGGLE_FAST);
				break;
			case writeFastOff:
				ClearPcBit(TOGGLE_FAST);
				break;
			case getVersion:
				SendLong(Version);
				break;
	
			default:
				break;
			}
		}
		cli();
	}
	sei();
}
