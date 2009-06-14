namespace TestConfig
{
    namespace Boxdorfer
    {
        /**
         * @brief 
         * Handle the transmission of the added speed
         */
        public class RaAddFrequency : BoxdorferLong
        {
            public RaAddFrequency() : base(0xD8, 0) { }
        }
    }
}
