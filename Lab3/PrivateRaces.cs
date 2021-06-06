using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Race
{

    class AllRace : IRace
    {
        public AllRace(double distance) : base(distance) { }
        public void AddRacer(Transport transport)
        {
            if (transports.ContainsKey(transport.ToString()))
                throw new AlreadyARacerException(transport);
            transports.Add(transport.ToString(), transport);
        }
    }

    class GroundRace : IRace
    {
        public GroundRace(double distance) : base(distance) { }

        public void AddRacer(GroundTransport transport)
        {
            if (transports.ContainsKey(transport.ToString()))
                throw new AlreadyARacerException(transport);
            transports.Add(transport.ToString(), transport);
        }
    }

    class AirRace : IRace
    {
        public AirRace(double distance) : base(distance) { }

        public void AddRacer(AirTransport transport)
        {
            if (transports.ContainsKey(transport.ToString()))
                throw new AlreadyARacerException(transport);
            transports.Add(transport.ToString(), transport);
        }
    }
}
