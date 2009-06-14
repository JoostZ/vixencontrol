using System;
using System.Collections.Generic;
using System.Text;

namespace TelescopeControl
{
    namespace Boxdorfer
    {
        class BoxdorferButton : IBoxdorferCommand, ISynchronizable
        {

            private bool _checked;

            public bool Check
            {
                get
                {
                    return _checked;
                }
                set
                {
                    _checked = value;
                }
            }

            private byte iOnCommand;
            private byte iOffCommand;

            public BoxdorferButton(byte aOnCommand, byte aOffCommand)
            {
                iOnCommand = aOnCommand;
                iOffCommand = aOffCommand;
            }

            public void Write(BoxdorferSerial theChannel)
            {
                if (theChannel != null)
                {
                    theChannel.AddCommand(this);
                }
            }

            public void Read(BoxdorferSerial theChannel)
            {
                // Do nothing
            }

            public bool Done
            {
                get
                {
                    return true;
                }
            }

            public void HandleReceived(byte[] aByte)
            {
                // Nothing to do
            }

            public int RequiredReturnBytes
            {
                get
                {
                    return 0;
                }
            }

            public void SendCommand(BoxdorferSerial aPort)
            {
                if (Check)
                {
                    aPort.SendByte(iOnCommand);
                }
                else
                {
                    aPort.SendByte(iOffCommand);
                }
            }

        }
    }
}
