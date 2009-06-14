/**
 * \file output.c
 */
#include "output.h"
#include "TelescopeControl.h"


#define OUTPUT_CONTROL_PORT PORTD ///< Control of the output ports
#define OUTPUT_CONTROL_DDR 	DDRD  ///< Direction settings of output ports

#define TRACKING_LED 		PD2	///< Showing if tracking is active
#define FLASH_LED 			PD3 ///< Flashing led to show progress
#define RA_DIRECTION		PD4 ///< Direction control for RA motor
#define DE_DIRECTION		PD6	///< Direction control for DE motor

void SetRALed(LedStatus aStatus)
{
	if (aStatus == LedOn)
	{
		OUTPUT_CONTROL_PORT &= ~_BV(TRACKING_LED);
	}
	else
	{
		OUTPUT_CONTROL_PORT |= _BV(TRACKING_LED);
	}
}

void ToggleRaLed()
{
	OUTPUT_CONTROL_PORT ^= _BV(FLASH_LED);
}

static Direction currentDaDirection = DirectionCW;
static Direction nextDaDirection = DirectionCW;

void SetRADirection(Direction aDir)
{
	nextDaDirection = aDir;
	UpdateRaDirection();
}

void UpdateRaDirection()
{
	if (currentDaDirection == nextDaDirection)
	{
		return;
	}

	if (currentDaDirection == DirectionCCW)
	{
		OUTPUT_CONTROL_PORT |= _BV(RA_DIRECTION);
	}
	else
	{
		OUTPUT_CONTROL_PORT &= ~_BV(RA_DIRECTION);
	}
	currentDaDirection = nextDaDirection;
}

void SetDEDirection(Direction aDir)
{
	if (aDir == DirectionCCW)
	{
		OUTPUT_CONTROL_PORT |= _BV(DE_DIRECTION);
	}
	else
	{
		OUTPUT_CONTROL_PORT &= ~_BV(DE_DIRECTION);
	}
}

void OutputInit()
{
	
	// Enable outputs for the LEDS
	DDRD = _BV(TRACKING_LED) | _BV(FLASH_LED) | _BV(RA_DIRECTION) | _BV(DE_DIRECTION);
	PORTD = _BV(TRACKING_LED) | _BV(FLASH_LED) | _BV(RA_DIRECTION) | _BV(DE_DIRECTION);

	currentDaDirection = DirectionCCW;
}
