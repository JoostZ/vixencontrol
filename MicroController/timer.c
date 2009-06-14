/**
 * \file timer.c
 */

#include <avr/interrupt.h>

#include "TelescopeControl.h"
#include "timer.h"

/**
 * \brief OCR1A value
 *
 * This is the value that will be loaded in OCR1A.
 * Timer1 will continuously count from 0 to this value
 * and then reset to 0 again.
 */
uint16_t T1OCValue = (uint16_t)(T1_CLOCK / (2 * T1_FREQUENCY) + 0.5);

/**
 * Indication if T1OCValue has been changed.
 */
uint8_t T1OCChanged = 0;

static uint8_t timer1Running = 0;

/**
 * \brief Interrupt routine for Timer 0 overflow
 */
ISR(TIMER0_COMP_vect)
{
	SetEvent(tmr0);
}


volatile uint8_t T1Interrupts = 0;

/**
 * \brief Interrupt for Timer1 Output Compare
 */
ISR(TIMER1_COMPA_vect)
{
	T1Interrupts++;
	SetEvent(tmr1);

	if (T1OCChanged)
	{
		OCR1A = T1OCValue;
		T1OCChanged = 0;
	}
}

void TimerInit()
{
	// Setup Timer 0
	TCCR0 = _BV(WGM01); // CTC mode
	TCCR0 |= (T0_PRESCALE_SELECT << CS00); // select prescale

	OCR0 = OCR0_VAL;
	TIMSK = _BV(OCIE0);

	OC1A_DDR |= _BV(OC1A_PIN);
	OC1A_PORT &= ~_BV(OC1A_PIN); // Start with pin == 0

}

void StartTimerRA()
{
	// Select CTC mode, i.e., WGM10, 11 and 13 are 0, WGM12 = 1
	TCCR1A = 0;
	TCCR1B = _BV(WGM12);

	// Reset Timer count value and TOP value
	TCNT1 = 0;
	OCR1A = T1OCValue;

	// Set toggle mode of OC1A
	TCCR1A |= (0x1 << COM1A0);

	// Select clock source to required prescaler
	TCCR1B |= PRESCALE1_SELECT << CS10; 

	timer1Running = 1;

	// Enable the T1 interrupt
	TIMSK |= _BV(OCIE1A);	
}

void StopTimerRA()
{
	TCCR1B &= ~(0x3 << CS10);
	TIMSK &= ~_BV(OCIE1A);

	// Set OC1A mode to normal output and PIN low
	TCCR1A &= ~(0x3 << COM1A0);
	OC1A_PORT &= ~_BV(OC1A_PIN);

	timer1Running = 0;
}

static const uint32_t periodLimit = (1l << 16) - 1;

void SetFrequencyRA(float aFrequency)
{
	if (0 == aFrequency)
	{
		StopTimerRA();
	}
	else
	{
		// Calculate the OC1 value from the current Frequency
		uint16_t timval = (uint16_t)(T1_CLOCK / (2 * aFrequency) + 0.5);
		if (timval > periodLimit)
		{
			StopTimerRA();
			return;
		}
		
		// Disable interrupts to allow the change of T1OCValue
		cli();
		T1OCValue = timval;
		T1OCChanged = 1;

		if (!timer1Running)
		{
			StartTimerRA();
		}
	}

}

uint16_t GetT1Interval()
{
	return T1OCValue;
}
