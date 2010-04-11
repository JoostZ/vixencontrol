/**
 * \file timer.c
 *
 * \page timerpage The timers
 *
 * The TelescopeControl uses several timers. This page describes how the
 * hardware timers in the micro controller are used.
 *
 * Two timers are used to control the frequency with which the motors are stepped.
 * T1 is used to control the RA motor and T2 is used to control the declination motor.
 *
 * Besides these two timers we also need a periodic timer that triggers the checking of
 * pressed keys (and in ramping the speed of the motors) and a timer that is used in the
 * modbus protocol. Since we don't have two more hardware timers we use a software solution
 * around T0
 *
 * \section t0 Timer 0
 *
 * \section t1 Timer 1
 *
 * \section t2 Timer 2
 *
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

static uint8_t mbTimerValue; ///< The OCR value for the modbus timer
/**
 * \brief Initialize the modbus timer
 *
 * \param usTim1Timerout50us
 * The timer value in units of 50 micro seconds
 * This unit is used to work seamlessly with the modbus module that calls this function.
 *
 * We need to translate the parameter to the OCR value for timer 0
 */
BOOL
xMBPortTimersInit( USHORT usTim1Timerout50us )
{
    /* Calculate overflow counter an OCR values for Timer0. */
	/*
	 * The required length is usTim1Timerout50us * 50 / 1000000
	 * The time between clock pulses is  T0_PRESCALER / F_CPU
	 */
	mbTimerValue = (usTim1Timerout50us * F_CPU) / (TO_PRESCALER * 200000);

    vMBPortTimersDisable(  );

    return TRUE;
}

uint8_t nextTimerValue = 0;
enum {
	periodic,
	T35
} activeTimer;

inline void
vMBPortTimersEnable(  )
{

}

inline void
vMBPortTimersDisable(  )
{
	cli();
    if (activeTimer == periodic) {
    	nextTimerValue = 0;
    } else {
    	uint8_t timeLeft = OCR0 - TCNT0 + nextTimerValue;
    	TCNT0 = 0;
    	OCR0 = timeLeft;
    	activeTimer = periodic;
    }
    sei();
}
/**
 * \brief Interrupt routine for Timer 0 output compare
 */
ISR(TIMER0_COMP_vect)
{
	if (activeTimer == periodic) {
		SetEvent(tmr0);
		if (nextTimerValue) {
			OCR0 = nextTimerValue;
			activeTimer = T35;
			nextTimerValue = 0;
		}
		else {
			OCR0 = OCR0_VAL;
		}
	}
	else {
		if (nextTimerValue) {
			OCR0 = nextTimerValue;
			nextTimerValue = 0;
		}
		else {
			OCR0 = OCR0_VAL;
		}
		pxMBPortCBTimerExpired();
		activeTimer = periodic;
	}
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
	// Setup Timer 0. This timer is used for a periodic 10msec timer
	// which is running continuously and the t3.5 timer used in modbus
	// RTU communication
	TCCR0 = _BV(WGM01); // CTC mode
	TCCR0 |= (T0_PRESCALE_SELECT << CS00); // select prescale

	OCR0 = OCR0_VAL;
	TIMSK = _BV(OCIE0);
	activeTimer = periodic;

	// Setup timer 1. This is the timer that controls the RA motor
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
