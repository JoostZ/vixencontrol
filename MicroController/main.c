/**
 * \file main.c
 *
 * \mainpage
 * Telescopecontrol is a software set for an ATMEL microcontroller
 * that is intended to control a telescope mount
 */

#include <math.h>
#include <stdlib.h>
#include <assert.h>

#include <avr/interrupt.h>
#include <avr/sleep.h>

#include "TelescopeControl.h"
#include "debounce.h"
#include "keys.h"
#include "motor.h"
#include "output.h"
#include "timer.h"


volatile uint8_t intflags = 0;
volatile uint8_t lastCommand = 0;


void SetEvent(Event aEvent)
{
	set_bit(intflags, aEvent);
}

void ResetEvent(Event aEvent)
{
	cli();
	clear_bit(intflags, aEvent);
	sei();
}

/**
 * \brief Initialization of IO
 */
static void ioinit(void)
{
	intflags = 0;

//	UsartInit();

	sei();
}

/**
 * \brief main entry
 */
int main(void)
{

	ioinit();

	KeysInit();
	OutputInit();
	TimerInit();
	MotorInit();

	for (;;)
	{
		if (intflags == 0)
		{
			sleep_mode();
		}

//		if (bit_is_set(intflags, usart_rx))
//		{
//			ResetEvent(usart_rx);
//			HandleCommand();
//		}

		if (bit_is_set(intflags, tmr0))
		{
			ResetEvent(tmr0);
			CheckKeys();
		}

		if (bit_is_set(intflags, tmr1))
		{
			ResetEvent(tmr1);
			cli();
			int nPulses = T1Interrupts;
			T1Interrupts = nPulses % 2;
			sei();

			// OC1A has just been toggled. If bit is now
			// 1, it means the stepper motor has made a step
			
			
			if (nPulses  >= 2)
			{
				SteppedRA(nPulses / 2);
			}
			
		}

	}
	
	return 0;
}

