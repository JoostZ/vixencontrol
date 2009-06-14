/**
 * \file motor.h
 */
#ifndef _JZ_MOTOR_H_
#define _JZ_MOTOR_H_

#include <stdint.h>

extern void MotorInit();

/**
 * \brief Do administration when a step for RA has occurred
 */
extern void SteppedRA(uint8_t nSteps);

/**
 * \brief
 * Change frequency of the motors, if necessary.
 */
extern void RampMotors();

/**
 * \brief
 * Calculate and set the RA frequency
 *
 * This function calculates the required frequency for the RA
 * stepper motor based on the current value of buttons. Then if required,it changes the 
 * the frequency of timer 1.
 */
extern void CalculateAndSetRaFrequency();

extern int32_t GetRaTargetPos();
extern void SetRaTargetPos(int32_t aRaTarget);

extern int32_t GetRaFast();

extern void SetRaFast(uint32_t raFast);


extern int32_t GetRaAcceleration();
extern void SetRaAcceleration (uint32_t raAccel);

extern uint32_t GetRaUpdatePeriod();
extern void SetRaUpdatePeriod(uint32_t aRaUpdatePeriod);

extern uint32_t GetRaAccLL();
extern void SetRaAccLL(uint32_t aRaAccLL);

extern int32_t GetRaCurrentSpeed();

extern int32_t GetRaPos();
extern void ResetRaPos();

extern void StartRaGoto();
extern void StopRaGoto();

extern uint32_t GetRaBacklash();
extern void SetRaBacklash(uint32_t aRaBacklash);



#endif
