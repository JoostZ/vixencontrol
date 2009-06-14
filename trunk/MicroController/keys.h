#ifndef _JZ_KEYS_H
#define _JZ_KEYS_H

#include <stdint.h>

void KeysInit();


extern void SetPcBit(uint8_t aBit);
extern void ClearPcBit(uint8_t aBit);

void CheckKeys();

uint8_t IsTracking();

uint8_t FastOn();

uint8_t ButtonLeft();

uint8_t ButtonRight();

#endif
