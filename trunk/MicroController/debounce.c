/**
 * \file debounce.c
 *
 * Implementation of a port wide debonce of input pins.
 */

#include "debounce.h"

static uint8_t clock_A = 0;
static uint8_t clock_B = 0;
static uint8_t debounced_state = 0;

void debounceInit(uint8_t state)
{
	clock_A = 0;
	clock_B = 0;
	debounced_state = state;
}

/**
 * \brief Determine button states with debouncing
 * 
 * \param new_sample
 * A byte with the current input states of input pins
 *
 * \returns
 * A byte containing the debounced current state of each input pin
 *
 * This function should be called repeatedly from an interrupt routine
 * The function returns the current state of each input pin if it hase
 * the same value as the last three times this function was called.
 */
uint8_t debounce(uint8_t new_sample)
{
  uint8_t delta;
  uint8_t changes;

  delta = new_sample ^ debounced_state;   //Find all of the changes

  clock_A ^= clock_B;                     //Increment the counters
  clock_B  = ~clock_B;

  clock_A &= delta;                       //Reset the counters if no changes
  clock_B &= delta;                       //were detected.

  changes = ~(~delta | clock_A | clock_B);
  debounced_state ^= changes;

  return debounced_state;
}
