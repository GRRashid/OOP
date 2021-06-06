using System;

namespace Race
{
    class KoverPlane : AirTransport
    {
        public KoverPlane() :
            base(10, "Ковер-самолёт")
        { }
        protected override double GetNewDistance(double distance)
        {
            if (distance < 1000)
                return distance;
            if (distance < 5000)
                return distance * 0.03;
            if (distance < 10000)
                return distance * 0.1;
            return distance * 0.05;
        }
    }

    class Stupa : AirTransport
    {
        public Stupa() :
            base(8, "Ступа")
        { }
        protected override double GetNewDistance(double distance)
        {
            return distance * 0.06;
        }
    }

    class Broom : AirTransport
    {
        public Broom() :
            base(20, "Метла")
        { }
        protected override double GetNewDistance(double distance)
        {
            return distance * Math.Truncate(distance / 1000) * 0.01;
        }
    }
}
