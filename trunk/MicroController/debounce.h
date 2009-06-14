#ifndef __DEBOUNCE_H__
#define __DEBOUNCE_H__

#include <inttypes.h>

void debounceInit(uint8_t state);
uint8_t debounce(uint8_t new_sample);

#endif // __DEBOUNCE_H__
