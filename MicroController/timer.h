/**
 * \file timer.h
 *
 * \addtogroup timers The timers
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
 * T0 is continuously increasing TCNT0 until it reaches OCR0. Then an interrupt is generated and
 * a new value of OCR0 is loaded.
 *
 * The
 *
 * \section t1 Timer 1
 *
 * \section t2 Timer 2
 *
 */
#ifndef _JZ_TIMER_H_
#define _JZ_TIMER_H_

/*@{*/
/** \name Settings for timer 0
 */
/**
 * \ingroup timers
 * \brief Required frequency of generated T0 interrupts
 *
 * 100 means 10 msec between interrupts
 */
#define F_T0 100 ///< 100 Hz means 10msec

/**
 * \ingroup timers
 * \brief prescaler for timer 0
 *
 * The prescaler must be calculated to ensure that
 * the number of pulses needed to reach the F_T0 frequency
 * is between 0 and 255.
 *
 * Calculate Prescaler = F_CPU / (F_T0 * 256) and choose the
 * next higher value from {1, 8, 64, 256, 1024}.
 */
#define T0_PRESCALER 1024

/**
 * \ingroup timers
 * \brief
 * The value to select the timer 0 prescaler to T0_PRESCALER
 */
#define T0_PRESCALE_SELECT 5

/**
 * \ingroup timers
 * \brief
 * Clock frequency for timer 0
 */
#define T0_CLOCK (F_CPU / T0_PRESCALER)

/*@}*/

/** \name Settings for timer 1
@{*/
/**
 * \ingroup timers
 * \brief CS12:0 bits
 *
 * Selection of prescaler. Must be selected to give roughly 1 MHz
 * input frequency for Timer1
 */
#define PRESCALE1_SELECT 1

/**
 * \ingroup timers
 * \brief Prescaler for Timer 1
 *
 * Must match what is specified in PRESCALE1_SELECT
 */
#define T1_PRESCALER 1

/**
 * \ingroup timers
 * \brief
 * Input clock for timer 1.
 *
 * This must be around 1MHz
 */
#define T1_CLOCK  (F_CPU / T1_PRESCALER)

/**
 * \ingroup timers
 * Start frequency for timer 1
 * */
#define T1_FREQUENCY 20

/**
 * \ingroup timers
 * OCR value for timer 1
 */
#define OCR1_VAL ( (uint16_t)(T1_CLOCK / (2 * T1_FREQUENCY) + 0.5))
/*@}*/

extern void TimerInit();
extern volatile uint8_t T1Interrupts;

/**
 * \brief 
 * Start the timer controlling the RA motor
 */
void StartTimerRA();

/**
 * \brief
 * Stop the timer controlling the RA motor
 */
void StopTimerRA();

uint16_t GetT1Interval();

/**
 * \brief
 * Set the frequency for the timer controlling the RA motor
 *
 * \param aFrequency
 * The frequency for the RA motor
 */
void SetFrequencyRA(float aFrequency);

#endif
