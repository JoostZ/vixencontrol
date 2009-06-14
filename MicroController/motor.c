/**
 * \file motor.c
 */

#include <math.h>

#include "motor.h"
#include "keys.h"
#include "output.h"
#include "timer.h"
#include "stdlib.h"

//#define NEWACCELERATION 1

/**
 * \brief
 * Data about the status of a motor
 */
struct MotorStatus {
	int8_t	lastDirection;	  ///< 
	int8_t	currentDirection; ///< Direction motor is currently turning
	float	currentFrequency; ///< Currently used frequency for the motor

	int8_t	targetDirection;  ///< Direction the motor should be turning
	float	targetFrequency;  ///< Frequency the motor should be turning

	int32_t	targetPosition;	  ///< Position to move to
	int8_t  inGoto;			  ///< True if GOTO is active
	int8_t  inGotoFinal;	  ///< True if decelerating to the final target position
	float	gotoDistanceLimit;///< The distance from target when deceleration needs to start

	int32_t backlash;		  ///< The number of steps in a backlash
	int32_t backlashOffset;	  ///< The number of steps executed in the current backlash correction

	float 	limitFrequency;	  ///< Frequency below which no ramping is required

	uint8_t ramping;	///< True if target frequency not yet reached

	uint16_t rampSteps;	///< Number of steps still required to ramp up or down to the target frequency
	float	rampStep;	///< Multiplaction step for frequency during ramp;
	uint16_t	rampUpdate;	///< Counter used to delay ramping
	uint16_t rampDelay;
	float   acceleration;
};

void SetRaFrequency(float frequency, int8_t direction);

static struct MotorStatus raMotorStatus;

static float slowFrequency = 19.252588;
static float fastFrequency = 600.0414;

static float nRampSteps = 100; ///< Number of steps to go from 0 to fast
static float rampUpStep;
static float rampDownStep;


static int32_t RAPos = 0;

static int32_t raFastMultiplier = 80; ///< How much faster fast speed is then tracking speed
static int32_t raAcceleration = 2500; ///< x 100 * tracking speed / second

void MotorInit()
{
	fastFrequency = raFastMultiplier * slowFrequency;
	float upStep = 0.01 * 0.01 * raAcceleration * slowFrequency;

	rampUpStep = upStep / nRampSteps;
	rampDownStep = -upStep / nRampSteps;

	raMotorStatus.lastDirection = 0;
	raMotorStatus.currentDirection = 0;
	raMotorStatus.currentFrequency = 0.0;
	
	raMotorStatus.targetDirection = 0;
	raMotorStatus.targetFrequency = 0.0;

	raMotorStatus.targetPosition = 0;
	raMotorStatus.inGoto = 0;
	raMotorStatus.inGotoFinal = 0;
	raMotorStatus.gotoDistanceLimit = 0.0;

	raMotorStatus.backlash = 600;
	raMotorStatus.backlashOffset = 0;

	raMotorStatus.limitFrequency = 20 * slowFrequency;
	raMotorStatus.rampUpdate = 20;
	raMotorStatus.rampDelay = 20;

	raMotorStatus.rampStep = 0.01 * 0.01 * raMotorStatus.rampUpdate * raAcceleration * slowFrequency;
	raMotorStatus.ramping = 0;

	raMotorStatus.acceleration = 0.0;
	
	CalculateAndSetRaFrequency();
}

static void SetRaTimer()
{
	if (raMotorStatus.inGoto)
	{
		if (raMotorStatus.currentFrequency < raMotorStatus.limitFrequency)
		{
			raMotorStatus.gotoDistanceLimit = 0.0;
		}
		else
		{
			float v02 = raMotorStatus.currentFrequency * raMotorStatus.currentFrequency;
			float vlim2 = raMotorStatus.limitFrequency * raMotorStatus.limitFrequency;
			raMotorStatus.gotoDistanceLimit = (v02 - vlim2) / (2 * raAcceleration * 0.01 * slowFrequency) + 500;
		}
	}
	if (raMotorStatus.lastDirection != 0 && raMotorStatus.lastDirection != raMotorStatus.currentDirection)
	{
		// Changingdirection
		raMotorStatus.backlashOffset = raMotorStatus.backlash - raMotorStatus.backlashOffset;
		raMotorStatus.currentFrequency = raMotorStatus.limitFrequency;
		raMotorStatus.ramping = 0;
	}
	raMotorStatus.lastDirection = raMotorStatus.currentDirection;
	SetFrequencyRA(raMotorStatus.currentFrequency);
	SetRADirection(raMotorStatus.currentDirection >= 0 ? DirectionCW : DirectionCCW);
	StartTimerRA();
}

/**
 * \brief Do administration when a step has occurred
 */
 void SteppedRA(uint8_t nSteps)
 {
 	if (nSteps == 0)
	{
		return;
	}

	if (raMotorStatus.backlashOffset)
	{
		raMotorStatus.backlashOffset -= nSteps;
		if (raMotorStatus.backlashOffset <= 0)
		{
			raMotorStatus.backlashOffset = 0;
			if (raMotorStatus.inGoto)
			{
				StartRaGoto();
			}
			else
			{
				CalculateAndSetRaFrequency();
			}
		}
		return;
	}

 	if (raMotorStatus.currentDirection > 0)
	{
 		RAPos += nSteps;;
	}
	else 
	{
		RAPos -= nSteps;
	}

	if (raMotorStatus.inGoto)
	{
 		uint8_t isFinished = 0;
		if (!raMotorStatus.inGotoFinal)
		{
			int32_t deltaS = labs(raMotorStatus.targetPosition - RAPos);
			if (deltaS <= raMotorStatus.gotoDistanceLimit)
			{
				raMotorStatus.inGotoFinal = 1;
				SetRaFrequency(raMotorStatus.limitFrequency, raMotorStatus.targetDirection);
			}
		}

		if (raMotorStatus.targetDirection > 0)
		{
			isFinished = RAPos >= raMotorStatus.targetPosition;
		}
		else
		{
			isFinished = RAPos <= raMotorStatus.targetPosition;
		}

		if (isFinished)
		{
			raMotorStatus.currentFrequency = 0.0;
			raMotorStatus.currentDirection = 0;
			StopTimerRA();
			raMotorStatus.inGoto = 0;
			raMotorStatus.ramping = 0;
			CalculateAndSetRaFrequency();
		}
	}
 }

 int32_t GetRaPos()
 {
 	return RAPos;
 }

void ResetRaPos()
{
	RAPos = 0;
}
 
int32_t GetRaFast()
{
	return raFastMultiplier;
}

int32_t GetRaTargetPos()
 {
 	return raMotorStatus.targetPosition;
 }

 
void SetRaTargetPos(int32_t aRaTarget)
{
	raMotorStatus.targetPosition = aRaTarget;
}

void StartRaGoto()
{
	int8_t direction;

	if (raMotorStatus.targetPosition == RAPos)
	{
		return;
	}
	raMotorStatus.inGoto = 1;
	raMotorStatus.inGotoFinal = 0;

	if (raMotorStatus.targetPosition > RAPos)
	{
		direction = +1;
	}
	else
	{
		direction = -1;
	}
	SetRaFrequency(fastFrequency, direction);
}

void StopRaGoto()
{
	raMotorStatus.inGoto = 0;
	CalculateAndSetRaFrequency();
}

void SetRaFast(uint32_t raFast)
{
	raFastMultiplier = raFast;
	fastFrequency = slowFrequency * raFast;
	CalculateAndSetRaFrequency();
}

int32_t GetRaAcceleration()
{
	return raAcceleration;
}

void SetRaAcceleration (uint32_t raAccel)
{
	raAcceleration = raAccel;
	float upStep = 0.01 * 0.01 * raAcceleration * slowFrequency;
	raMotorStatus.rampStep = 0.01 * raMotorStatus.rampUpdate * 0.01 * raAcceleration * slowFrequency;

	rampUpStep = upStep / nRampSteps;
	rampDownStep = -upStep / nRampSteps;

}

int32_t GetRaCurrentSpeed()
{
	int32_t result = (int32_t)(10 * raMotorStatus.currentFrequency / slowFrequency + 0.5);
	
	return result;
}


uint32_t GetRaUpdatePeriod()
{
	return raMotorStatus.rampUpdate;
}

void SetRaUpdatePeriod(uint32_t aRaUpdatePeriod)
{
	raMotorStatus.rampUpdate = (int16_t) aRaUpdatePeriod;
	raMotorStatus.rampStep = 0.01 * raMotorStatus.rampUpdate * 0.01 * raAcceleration * slowFrequency;
	raMotorStatus.rampDelay = 1;
}

uint32_t GetRaAccLL()
{
	uint32_t result = (uint32_t)(raMotorStatus.limitFrequency / slowFrequency + 0.5);
	
	return result;
}

void SetRaAccLL(uint32_t aRaAccLL)
{
	raMotorStatus.limitFrequency = aRaAccLL * slowFrequency;
}

uint32_t GetRaBacklash()
{
	return raMotorStatus.backlash;
}

void SetRaBacklash(uint32_t aRaBacklash)
{
	raMotorStatus.backlash = aRaBacklash;
}

 /**
  * \brief
  * Ramp RA frequency up or down
  */
void RampRA()
{
	if (!raMotorStatus.ramping)
	{
		// No change required
		return;
	}

	if (raMotorStatus.rampDelay < raMotorStatus.rampUpdate)
	{
		raMotorStatus.rampDelay++;
		return;
	}

	raMotorStatus.rampDelay = 0;


	float rampStep = raMotorStatus.rampStep;
	float targetFrequency = raMotorStatus.targetFrequency;
	uint8_t targetDirection = raMotorStatus.targetDirection;
	uint8_t switching = 0;
	uint8_t done = 0;

	if ( (raMotorStatus.currentDirection == -1 && raMotorStatus.targetDirection == +1) ||
		 (raMotorStatus.currentDirection == +1 && raMotorStatus.targetDirection == -1) )
	{
		// We need to change direction. Decelarate first to stop
		targetFrequency = 0.0;
		switching = 1;
	}
	else if (raMotorStatus.currentDirection == 0)
	{
		raMotorStatus.currentDirection = raMotorStatus.targetDirection;
	}

	if (fabs(raMotorStatus.currentFrequency - targetFrequency) < fabs(rampStep))
	{
		raMotorStatus.currentFrequency = targetFrequency;
		done = 1;
	}
	else if (raMotorStatus.currentFrequency < targetFrequency)
	{
		// Accelerating
		if (targetFrequency <= raMotorStatus.limitFrequency)
		{
			// We can jump directly to the correct frequency
			raMotorStatus.currentFrequency = targetFrequency;
			done = 1;
		}
		else if (raMotorStatus.currentFrequency < raMotorStatus.limitFrequency)
		{
			raMotorStatus.currentFrequency = raMotorStatus.limitFrequency;
		}
		else
		{
			raMotorStatus.currentFrequency += rampStep;
		}
	}
	else
	{
		// Decelarating
		if (raMotorStatus.currentFrequency < raMotorStatus.limitFrequency)
		{
			raMotorStatus.currentFrequency = targetFrequency;
			done = 1;
		}
		else 
		{
			raMotorStatus.currentFrequency -= rampStep;
		}
	}
	
	if (done)
	{
		if (!switching)
		{
			raMotorStatus.currentDirection = targetDirection;
			raMotorStatus.ramping = 0;
		}
		else
		{
			raMotorStatus.currentDirection = 0;
		}
		
	}

	if (raMotorStatus.currentDirection == 0)
	{
		StopTimerRA();
	}
	else
	{
		SetRaTimer();
	}
}



void SetRaFrequency(float frequency, int8_t direction)
{
	raMotorStatus.targetDirection = direction;
	raMotorStatus.targetFrequency = frequency;
	
	raMotorStatus.ramping = 1;
	if (raMotorStatus.currentDirection == 0)
	{
		raMotorStatus.currentDirection = raMotorStatus.targetDirection;
	}
	RampRA();
}
 
 /**
  * \brief
  * Calculate and set the RA frequency
  *
  * This function calculates the required frequency for the RA
  * stepper motor based on the current value of buttons. Then if required,it changes the 
  * the frequency of timer 1.
  */
 void CalculateAndSetRaFrequency()
 {
 	if (FastOn())
	{
		// For fast mode is not important if we are tracking
		if(ButtonRight())
		{
			SetRaFrequency(fastFrequency, +1);
		}
		else if (ButtonLeft())
		{
			SetRaFrequency(fastFrequency, -1);
		}
		else
		{
			if (IsTracking())
			{
				SetRaFrequency(slowFrequency, +1);
			}
			else
			{
				SetRaFrequency(0., 0);
			}
		}
	}
	else 
	{
		if (IsTracking())
		{
			if (ButtonRight())
			{
				SetRaFrequency(slowFrequency * 1.5, +1);
			}
			else if (ButtonLeft())
			{
				SetRaFrequency(slowFrequency * 0.5, +1);
			}
			else 
			{
				SetRaFrequency(slowFrequency, +1);
			}
		}
		else
		{
			if (ButtonRight())
			{
				SetRaFrequency(slowFrequency, +1);
			}
			else if (ButtonLeft())
			{
				SetRaFrequency(slowFrequency, -1);
			}
			else
			{
				SetRaFrequency(0.0, 0);
			}
		}
	}
 } 


void RampMotors()
{
	RampRA();
}


