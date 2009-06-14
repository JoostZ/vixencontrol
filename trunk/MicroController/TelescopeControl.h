/**
 * \file TelescopeControl.h
 */

/**
 * \brief This is the clock frequency of the chip
 */
#define F_CPU (1000000L)

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

/** \name Settings for timer 0 
@{*/
/**
 * \brief Required frequency of generated T0 interrupts
 *
 * 100 means 10 msec between interrupts
 */
#define F_T0 100 ///< 100 Hz means 10msec

/**
 * \brief prescaler for timer 0
 *
 * The prescaler must be calculated to ensure that
 * the number of pulses needed to reach the F_T0 frequency
 * is between 0 and 255.
 *
 * Calculate Prescaler = F_CPU / (F_T0 * 256) and choose the 
 * next higher value from {1, 8, 64, 256, 1024}.
 */
#define T0_PRESCALER 64

/**
 * \brief
 * The value to select the timer 0 prescaler to T0_PRESCALER
 */
#define T0_PRESCALE_SELECT 3

/**
 * \brief
 * Value for OCR0 to generate the required interrupt rate
 */
#define OCR0_VAL (((F_CPU / T0_PRESCALER +  (F_T0 >> 2)) / F_T0) - 1)
/*@}*/

/** \name Settings for timer 1 
@{*/
/**
 * \brief CS12:0 bits
 * 
 * Selection of prescaler. Must be selected to give roughly 1 MHz
 * input frequency for Timer1
 */
#define PRESCALE1_SELECT 1

/**
 * \brief Prescaler for Timer 1
 *
 * Must match what is specified in PRESCALE1_SELECT
 */
#define T1_PRESCALER 1

/**
 * \brief
 * Input clock for timer 1.
 *
 * This must be around 1MHz
 */
#define T1_CLOCK  (F_CPU / T1_PRESCALER)
#define T1_FREQUENCY 20
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
