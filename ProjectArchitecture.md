#High-level architecture of the project.

# Introduction #

This page gives an overview of the different components that make up the control of the Vixen Telescope mount project.

# Details #
The following diagram shows the different components in out project.

<wiki:gadget url="http://creately.com/player/gadget/createlyplayer.xml" height="500" width="500" border="0" up\_did="geo2su701" up\_dlogo="true" up\_dtitle="Embedding in Google Code" up\_bgcolor="#EEEEEE" />

Starting at the bottom, the Controller is responsible for sending pulses to the hardware drivers that connect to the stepper motors. On each (rising) flank of these pulses the associated stepper motor will perform a single step.

Generating the steps can be done through hardware switches and push buttons that are connected to the micro controller. In addition these switches can be _simulated_ through the serial interface to the ASCOM driver. (_Need to describe here what happens if the hardware and simulated switches are used simultaneously)._

Based on these controls the Controller can
  * Move each axis in both directions, using slow (= tracking) or fast speed
  * Accelerate up and down to the required speed
  * Correct for backlash
  * Correct for periodic error (not yet implemented)
  * Perform an automatic goto