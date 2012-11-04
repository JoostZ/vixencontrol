
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


enum Direction {
	Forward = +1,
	Backward = -1
};


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
	int32_t currentPosition;
	int8_t  inGoto;			  ///< True if GOTO is active
	int8_t  inGotoFinal;	  ///< True if decelerating to the final target position
	float	gotoDistanceLimit;///< The distance from target when deceleration needs to start

	int16_t backlash;		  ///< The number of steps in a backlash
	int16_t backlashOffset;	  ///< The number of steps executed in the current backlash correction

	float 	limitFrequency;	  ///< Frequency below which no ramping is required
	uint16_t maxAcc;	  	  ///< Acceleration x 100 * tracking speed / second
	//uint16_t fastMultiplier;  ///< Fast frequency in multiple of tracking speed
	float   fastFrequency;	  ///< Step frequency in Hz

	uint8_t ramping;	///< True if target frequency not yet reached

	uint16_t rampSteps;	///< Number of steps still required to ramp up or down to the target frequency
	float	rampStep;	///< Multiplication step for frequency during ramp;
	uint16_t	rampUpdate;	///< Counter used to delay ramping
	uint16_t rampDelay;
	float   acceleration;

	void (*StartTimer)();
	void (*StopTimer)();
	void (*SetTimer)(float);

	void (*SetDirection)(Direction);

	uint8_t (*ButtonForward)();
	uint8_t (*ButtonBackward)();
};

void SetAxisFrequency(struct MotorStatus* pStatus, float frequency, Direction direction);
void Ramp(struct MotorStatus* pStatus);
void StartGoto(struct MotorStatus* pStatus);

struct MotorStatus raMotorStatus;
struct MotorStatus decMotorStatus;


struct MotorStatus* raMotorStatusP;
struct MotorStatus* decMotorStatusP;

static float trackingFrequency = 19.252588;
//static float fastFrequency = 600.0414;

//static float nRampSteps = 100; ///< Number of steps to go from 0 to fast
//static float rampUpStep;
//static float rampDownStep;


//static int32_t raFastMultiplier = 80; ///< How much faster fast speed is then tracking speed
//static int32_t raAcceleration = 2500; ///< x 100 * tracking speed / second

void MotorInit()
{
	decMotorStatus.lastDirection = 0;

	raMotorStatus.acceleration = 0.0;
	raMotorStatus.fastFrequency = 600.0414;
	raMotorStatus.maxAcc= 2500;

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

	raMotorStatus.limitFrequency = 20 * trackingFrequency;
	raMotorStatus.rampUpdate = 20;
	raMotorStatus.rampDelay = 20;

	raMotorStatus.rampStep = 0.01 * 0.01 * raMotorStatus.rampUpdate * raMotorStatus.maxAcc * trackingFrequency;
	raMotorStatus.ramping = 0;
	
	raMotorStatus.SetTimer = &SetFrequencyRA;
	raMotorStatus.StartTimer = &StartTimerRA;
	raMotorStatus.StopTimer = &StopTimerRA;

	raMotorStatus.SetDirection= &SetRADirection;

	raMotorStatus.ButtonForward = &ButtonRight;
	raMotorStatus.ButtonBackward = &ButtonLeft;

	raMotorStatusP = &raMotorStatus;



	CalculateAndSetFrequency(raMotorStatusP);
}

static void SetTimer(struct MotorStatus* pStatus)
{
	if (pStatus->inGoto)
	{
		if (pStatus->currentFrequency < pStatus->limitFrequency)
		{
			pStatus->gotoDistanceLimit = 0.0;
		}
		else
		{
			float v02 = pStatus->currentFrequency * pStatus->currentFrequency;
			float vlim2 = pStatus->limitFrequency * pStatus->limitFrequency;
			pStatus->gotoDistanceLimit = (v02 - vlim2) / (2 * pStatus->maxAcc * 0.01 * trackingFrequency) + 500;
		}
	}
	if (pStatus->lastDirection != 0 && pStatus->lastDirection != pStatus->currentDirection)
	{
		// Changing direction
		pStatus->backlashOffset = pStatus->backlash - pStatus->backlashOffset;
		pStatus->currentFrequency = pStatus->limitFrequency;
		pStatus->ramping = 0;
	}
	pStatus->lastDirection = pStatus->currentDirection;
	pStatus->SetTimer(pStatus->currentFrequency);
	pStatus->SetDirection(pStatus->currentDirection >= 0 ? DirectionCW : DirectionCCW);
	pStatus->StartTimer();
}

/**
 * \brief Do administration when a step has occurred
 */
 void SteppedAxis(struct MotorStatus *pStatus, uint8_t nSteps)
 {
 	if (nSteps == 0)
	{
		return;
	}

	if (pStatus->backlashOffset)
	{
		pStatus->backlashOffset -= nSteps;
		if (pStatus->backlashOffset <= 0)
		{
			pStatus->backlashOffset = 0;
			if (pStatus->inGoto)
			{
				StartGoto(pStatus);
			}
			else
			{
				CalculateAndSetFrequency();
			}
		}
		return;
	}

 	if (pStatus->currentDirection > 0)
	{
 		pStatus->currentPosition += nSteps;;
	}
	else 
	{
		pStatus->currentPosition -= nSteps;
	}

	if (pStatus->inGoto)
	{
 		uint8_t isFinished = 0;
		if (!pStatus->inGotoFinal)
		{
			int32_t deltaS = labs(pStatus->targetPosition - pStatus->currentPosition);
			if (deltaS <= pStatus->gotoDistanceLimit)
			{
				pStatus->inGotoFinal = 1;
				SetAxisFrequency(pStatus, pStatus->limitFrequency, pStatus->targetDirection);
			}
		}

		if (pStatus->targetDirection > 0)
		{
			isFinished = pStatus->currentPosition >= pStatus->targetPosition;
		}
		else
		{
			isFinished = pStatus->currentPosition <= pStatus->targetPosition;
		}

		if (isFinished)
		{
			pStatus->currentFrequency = 0.0;
			pStatus->currentDirection = 0;
			StopTimerRA();
			pStatus->inGoto = 0;
			pStatus->ramping = 0;
			CalculateAndSetFrequency();
		}
	}
 }

 int32_t GetCurrentPosition(struct MotorStatus *pStatus)
 {
 	return pStatus->currentPosition;
 }


int32_t GetTargetPos(struct MotorStatus* status)
 {
 	return status->targetPosition;
 }


void SetTargetPos(struct MotorStatus* status, int32_t aRaTarget)
{
	status->targetPosition = aRaTarget;
}

void StartGoto(struct MotorStatus* pStatus)
{
	int8_t direction;

	if (pStatus->targetPosition == pStatus->currentPosition)
	{
		return;
	}
	pStatus->inGoto = 1;
	pStatus->inGotoFinal = 0;

	if (pStatus->targetPosition > pStatus->currentPosition)
	{
		direction = +1;
	}
	else
	{
		direction = -1;
	}
	SetAxisFrequency(pStatus, pStatus->fastFrequency, direction);
}

void StopRaGoto()
{
	raMotorStatus.inGoto = 0;
	CalculateAndSetFrequency();
}



int32_t GetRaCurrentSpeed()
{
	int32_t result = (int32_t)(10 * raMotorStatus.currentFrequency / trackingFrequency + 0.5);
	
	return result;
}


uint16_t GetAccLL(struct MotorStatus* pStatus)
{
	return (uint16_t)(pStatus->limitFrequency / trackingFrequency + 0.5);
}

void SetAccLL(struct MotorStatus* pStatus, uint16_t aAccLL)
{
	pStatus->limitFrequency = aAccLL * trackingFrequency;
}

void SetFastFrequency(struct MotorStatus* pStatus, uint16_t value)
{
	pStatus->fastFrequency = value * trackingFrequency;
}

uint16_t  GetFastFrequency(struct MotorStatus* pStatus)
{
	return pStatus->fastFrequency / trackingFrequency;
}
uint16_t GetUpdatePeriod(struct MotorStatus* pStatus)
{
	return pStatus->rampUpdate;
}

void SetUpdatePeriod(struct MotorStatus* pStatus, uint16_t aRaUpdatePeriod)
{
	pStatus->rampUpdate = (int16_t) aRaUpdatePeriod;
	pStatus->rampStep = 0.01 * pStatus->rampUpdate * 0.01 * pStatus->maxAcc * trackingFrequency;
	pStatus->rampDelay = 1;
}

uint16_t GetAcceleration(struct MotorStatus* pStatus)
{
	return pStatus->maxAcc;
}

void SetAcceleration(struct MotorStatus* pStatus, uint16_t acc)
{
	pStatus->maxAcc = acc;
		pStatus->rampStep = 0.01 * pStatus->rampUpdate * 0.01 * acc * trackingFrequency;
}
uint16_t GetBacklash(struct MotorStatus* pStatus)
{
	return pStatus->backlash;
}

void SetBacklash(struct MotorStatus* pStatus, uint16_t value)
{
	pStatus->backlash = value;
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
void Ramp(struct MotorStatus* pStatus)
{
	if (!pStatus->ramping)
	{
		// No change required
		return;
	}

	if (pStatus->rampDelay < pStatus->rampUpdate)
	{
		pStatus->rampDelay++;
		return;
	}

	pStatus->rampDelay = 0;


	float rampStep = pStatus->rampStep;
	float targetFrequency = pStatus->targetFrequency;
	uint8_t targetDirection = pStatus->targetDirection;
	uint8_t switching = 0;
	uint8_t done = 0;

	if ( (pStatus->currentDirection == -1 && pStatus->targetDirection == +1) ||
		 (pStatus->currentDirection == +1 && pStatus->targetDirection == -1) )
	{
		// We need to change direction. Decelarate first to stop
		targetFrequency = 0.0;
		switching = 1;
	}
	else if (pStatus->currentDirection == 0)
	{
		pStatus->currentDirection = pStatus->targetDirection;
	}

	if (fabs(pStatus->currentFrequency - targetFrequency) < fabs(rampStep))
	{
		pStatus->currentFrequency = targetFrequency;
		done = 1;
	}
	else if (pStatus->currentFrequency < targetFrequency)
	{
		// Accelerating
		if (targetFrequency <= pStatus->limitFrequency)
		{
			// We can jump directly to the correct frequency
			pStatus->currentFrequency = targetFrequency;
			done = 1;
		}
		else if (pStatus->currentFrequency < pStatus->limitFrequency)
		{
			pStatus->currentFrequency = pStatus->limitFrequency;
		}
		else
		{
			pStatus->currentFrequency += rampStep;
		}
	}
	else
	{
		// Decelerating
		if (pStatus->currentFrequency < pStatus->limitFrequency)
		{
			pStatus->currentFrequency = targetFrequency;
			done = 1;
		}
		else 
		{
			pStatus->currentFrequency -= rampStep;
		}
	}
	
	if (done)
	{
		if (!switching)
		{
			pStatus->currentDirection = targetDirection;
			pStatus->ramping = 0;
		}
		else
		{
			pStatus->currentDirection = 0;
		}
		
	}

	if (pStatus->currentDirection == 0)
	{
		pStatus->StopTimer();
	}
	else
	{
		SetTimer(pStatus);
	}
}



void SetAxisFrequency(struct MotorStatus* pStatus, float frequency, Direction direction)
{
	pStatus->targetDirection = direction;
	pStatus->targetFrequency = frequency;
	
	pStatus->ramping = 1;
	if (pStatus->currentDirection == 0)
	{
		pStatus->currentDirection = pStatus->targetDirection;
	}
	Ramp(pStatus);
}
 
 /**
  * \brief
  * Calculate and set the RA frequency
  *
  * This function calculates the required frequency for the RA
  * stepper motor based on the current value of buttons. Then if required, it changes
  * the frequency of timer 1.
  */
 void CalculateAndSetFrequency(struct MotorStatus* pStatus)
 {
 	if (FastOn())
	{
		// For fast mode it is not important if we are tracking
		if(pStatus->ButtonForward())
		{
			SetAxisFrequency(pStatus, pStatus->fastFrequency, +1);
		}
		else if (pStatus->ButtonBackward())
		{
			SetAxisFrequency(pStatus, pStatus->fastFrequency, -1);
		}
		else
		{
			if (IsTracking())
			{
				SetAxisFrequency(pStatus, trackingFrequency, +1);
			}
			else
			{
				SetAxisFrequency(pStatus, 0., 0);
			}
		}
	}
	else 
	{
		if (IsTracking())
		{
			if (pStatus->ButtonForward())
			{
				SetAxisFrequency(pStatus, trackingFrequency * 1.5, +1);
			}
			else if (pStatus->ButtonBackward())
			{
				SetAxisFrequency(pStatus, trackingFrequency * 0.5, +1);
			}
			else 
			{
				SetAxisFrequency(pStatus, trackingFrequency, +1);
			}
		}
		else
		{
			if (pStatus->ButtonForward())
			{
				SetAxisFrequency(pStatus, trackingFrequency, +1);
			}
			else if (pStatus->ButtonBackward())
			{
				SetAxisFrequency(pStatus, trackingFrequency, -1);
			}
			else
			{
				SetAxisFrequency(pStatus, 0.0, 0);
			}
		}
	}
 } 


void RampMotors()
{
	Ramp(raMotorStatusP);
}


