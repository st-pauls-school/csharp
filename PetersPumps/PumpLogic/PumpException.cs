using System;

namespace PumpLogic
{

    public class PumpException : Exception
    {
        public PumpException(string msg) : base(msg) { }
    }
}
