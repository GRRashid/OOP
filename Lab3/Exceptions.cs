using System;

namespace Race
{
    class AlreadyARacerException : Exception
    {
        public AlreadyARacerException(Transport tr) :
            base (tr.ToString() + " already a racer in this race") {}
    }

    class ZeroRacersOnStartException : Exception
    {
        public ZeroRacersOnStartException() :
            base("No one stands at the start")
        { }
    }

    class NegativeDistanceException : Exception
    {
        public NegativeDistanceException(double distance) :
            base("Distance cann't be negative but now it is " + distance + "km")
        { }
    }
}
