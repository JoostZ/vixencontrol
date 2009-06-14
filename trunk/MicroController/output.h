/**
 * \file output.h
 */
#ifndef _JZ_OUTPUT_H_
#define _JZ_OUTPUT_H_

/**
 * \brief
 * Status of an output pin used to drive an LED.
 */
typedef enum {
	LedOn,
	LedOff
} LedStatus;

/**
 * \brief
 * Status of an output pin.
 */
typedef enum {
	PinHigh,
	PinLow
} PinStatus;

typedef enum {
	DirectionCCW,
	DirectionCW
} Direction;

/**
 * \brief
 * Set the LED simulating the RA motor
 *
 * \param aStatus
 * Value to set the LED to.
 */ 
extern void SetRALed(LedStatus aStatus);

extern void ToggleRaLed();

extern void OutputInit();

extern void SetRADirection(Direction aDir);

extern void UpdateRaDirection();

extern void SetDEDirection(Direction aDir);

#endif
