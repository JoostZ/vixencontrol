/**
 * \file keys.c Handling of keys (buttons)
 *
 * This file contains all functionality to work with the keys (buttons) in the
 * Telescope Control project
 */
#include "keys.h"
#include "motor.h"
#include "timer.h"
#include "TelescopeControl.h"
#include "debounce.h"
#include "output.h"

static uint8_t trackingOn = 0;
static uint8_t currentState; ///< Current state of the keys
static uint8_t pcState = 0xff; ///< State as set by the PC

uint8_t ActiveState()
{
	return currentState & pcState;
}

void KeysInit()
{		
	// Enable pull-ups for push buttons
	INPUT_CONTROL_PORT = 0xff;
	INPUT_CONTROL_DDR = 0;

	currentState = INPUT_PIN;
	debounceInit(currentState);
}

void ToggleTracking()
{
	
	trackingOn ^= 1;
	if (trackingOn)
	{
		SetRALed(LedOn);

	} else {
		SetRALed(LedOff);
	}
}

uint8_t IsTracking()
{
	uint8_t theState = ActiveState();
	return bit_is_clear(theState, RA_TRACKING);
}

uint8_t FastOn()
{
	uint8_t theState = ActiveState();
	return bit_is_clear(theState, TOGGLE_FAST);
}

uint8_t ButtonLeft()
{

	uint8_t theState = ActiveState();
	return bit_is_clear(theState, BUTTON_LEFT);
}

uint8_t ButtonRight()
{
	uint8_t theState = ActiveState();
	return bit_is_clear(theState, BUTTON_RIGHT);
}

void SetPcBit(uint8_t aBit)
{
	clear_bit(pcState, aBit);

	if (pcState & MASK_RA_BUTTONS)
	{
		// One of the buttons that could change RA frequency has changed
		// state. Calculate and set the required frequency for RA.
		CalculateAndSetRaFrequency();
	}

	RampMotors();
}


void ClearPcBit(uint8_t aBit)
{
	set_bit(pcState, aBit);

	if (pcState & MASK_RA_BUTTONS)
	{
		// One of the buttons that could change RA frequency has changed
		// state. Calculate and set the required frequency for RA.
		CalculateAndSetRaFrequency();
	}

	RampMotors();

}

void CheckKeys()
{
	uint8_t newState = debounce(INPUT_PIN);
	uint8_t changeInState = newState ^ currentState;
	currentState = newState;

#if 0
	if (bit_is_set(changeInState, TOGGLE_RA_TRACKING))
	{
		if (bit_is_clear(theState, TOGGLE_RA_TRACKING))
		{
			ToggleTracking();
		}
	}
#endif

	if (changeInState & MASK_RA_BUTTONS)
	{
		// One of the buttons that could change RA frequency has changed
		// state. Calculate and set the required frequency for RA.
		CalculateAndSetRaFrequency();
	}

	RampMotors();
}
