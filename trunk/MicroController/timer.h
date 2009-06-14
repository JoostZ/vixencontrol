/**
 * \file timer.h
 */
#ifndef _JZ_TIMER_H_
#define _JZ_TIMER_H_

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
