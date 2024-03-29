/**
 * \file timer.c
 */

#include <avr/interrupt.h>

#include "port.h"
#include "mbport.h"

#include "TelescopeControl.h"
#include "timer.h"
/*
 * Value for OCR0 to generate the required interrupt rate
 */
#define OCR0_VAL (((T0_CLOCK +  (F_T0 >> 2)) / F_T0) - 1)

/*
 * OCR1A value
 *
 * This is the value that will be loaded in OCR1A.
 * Timer1 will continuously count from 0 to this value
 * and then reset to 0 again.
 */
static uint16_t T1OCValue = OCR1_VAL;

/*
 * Indication if T1OCValue has been changed.
 */
static uint8_t T1OCChanged = 0;

static uint8_t timer1Running = 0;

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

uint16_t GetT1Interval()
{
	return T1OCValue;
}


uint8_t mbTimerValue; ///< The OCR value for the modbus timer


uint8_t nextTimerValue = 0;
enum {
	periodic,
	T35
} activeTimer;

void
vMBPortTimersEnable(  )
{
	int timeLeft;
	if (activeTimer == periodic) {
    	timeLeft = OCR0 - TCNT0;
		if (mbTimerValue > timeLeft) {
			nextTimerValue = mbTimerValue - timeLeft;
		}
		else {
			nextTimerValue = timeLeft - mbTimerValue;
			TCNT0 = 0;
			OCR0 = mbTimerValue;
			activeTimer = T35;
		}
	}
	else {
		// Calculate the time till the next periodic timeout
		timeLeft = OCR0 - TCNT0 + nextTimerValue;

		if (mbTimerValue > timeLeft) {
			// The periodic time out comes first. Put the timeout value
			// in the hardware timer and remember the rest
			TCNT0 = 0;
			OCR0 = timeLeft;
			nextTimerValue = mbTimerValue - timeLeft;
		    activeTimer = periodic;
		}
		else {
			TCNT0 = 0;
			OCR0 = mbTimerValue;
			nextTimerValue = timeLeft - mbTimerValue;
			activeTimer = T35;
		}
	}
}

inline void
vMBPortTimersDisable(  )
{
//	cli();
    if (activeTimer == periodic) {
    	nextTimerValue = 0;
    } else {
    	uint8_t timeLeft = OCR0 - TCNT0 + nextTimerValue;
    	TCNT0 = 0;
    	OCR0 = timeLeft;
    	nextTimerValue = 0;
    	activeTimer = periodic;
    }
//    sei();
}

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
	uint8_t value;
    /* Calculate overflow counter an OCR values for Timer0. */
	/*
	 * The required length is usTim1Timerout50us * 50 / 1000000
	 * The time between clock pulses is  T0_PRESCALER / F_CPU
	 */
	mbTimerValue = (usTim1Timerout50us * F_CPU) / (T0_PRESCALER * 20000UL);
	value = mbTimerValue;


    //vMBPortTimersDisable(  );

    return TRUE;
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
		SetEvent(t35Expired);
		activeTimer = periodic;
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

