/**
 * \file TelescopeControl.h
 */

#include <avr/io.h>

/** \name User friendly names of the physical ports
@{*/
#define INPUT_CONTROL_PORT PORTB ///< Control of the input ports
#define INPUT_CONTROL_DDR DDRB   ///< Direction setting of input ports
#define INPUT_PIN PINB			 ///< PIN register of input ports

#define RA_TRACKING  		PB0	///< Use Bit 1 of port B to toggle tracking on/off
#define TOGGLE_FAST			PB1	///< Toggle between fast and slow mode
#define BUTTON_RIGHT		PB2	///< Forward in RA
#define BUTTON_LEFT			PB3	///< Backwards in RA
#define BUTTON_UP			PB4 ///< Up in DE
#define BUTTON_DOWN			PB5	///< Down in DE



#define OC1A_PORT 			PORTD ///< Control of the Timer 1 output
#define OC1A_DDR 			DDRD  ///< Direction setting of the Timer1 output
#define OC1A_PINPORT 		PIND
#define OC1A_PIN 			PD5

/**
 * \brief
 * Definition of buttons that can lead to an update of the RA frequency
 */
#define MASK_RA_BUTTONS (_BV(RA_TRACKING) | \
						 _BV(TOGGLE_FAST) | \
						 _BV(BUTTON_RIGHT) | \
						 _BV(BUTTON_LEFT))
/*@}*/

/**
 * \name Internal events
 *
 * To keep the work in an interrupt routine to a minimum, each 
 * interrupt routines will generate an event by setting individual bits in intflags. 
 * The bits will be checked in the main loop of the program and action will be taken there. 
@{*/

/**
 * \brief The different events
 */
typedef enum {
	tmr0 = 1, ///< Timer0 has reached TOP
	tmr1,	  ///< Timer1 has reached TOP
	usart_rx  ///< Command has been received over the UART
} Event;

extern void SetEvent(Event aEvent);
/**
 * \brief 
 * Set a bit
 *
 * \param byte
 * The byte in which to set the bit
 *
 * \param bit
 * The bit number to be set. Must be in the range 1 <= bit <= 8
 */
#define set_bit(byte, bit) (byte) |= _BV(bit)

/**
 * \brief Clear a bit
 *
 * \param byte
 * The byte in which to clear the bit
 *
 * \param bit
 * The bit number to be set. Must be in the range 1 <= bit <= 8
 */
#define clear_bit(byte, bit) (byte) &= ~(_BV(bit))
/*@}*/

extern volatile uint8_t lastCommand;

extern int32_t RAPos;
