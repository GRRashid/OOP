using System.Collections.Generic;
using System.Linq;

namespace Race
{
    class IRace
    {
        protected double distance_ = 0;
        protected Dictionary<string, Transport> transports = new Dictionary<string, Transport>();
        public IRace(double distance)
        {
            distance_ = distance;
        }

        public void SetDistance(double distance)
        {
            distance_ = distance;
        }
        public double GetDistance()
        {
            return distance_;
        }

        public List<Transport> GetRacers()
        {
            List<Transport> res = new List<Transport>();

            foreach (var key in transports)
            {
                res.Add(key.Value);
            }

            return res;
        }

        public void RemoveRacer(int position)
        {
            transports.Remove(transports.Keys.ElementAt(position));
        }

        private int Compresion(KeyValuePair<Transport, double> first, KeyValuePair<Transport, double> second)
        {
            return first.Value > second.Value ? 1 : -1;
        }

        public List<KeyValuePair<Transport, double>> GetResult()
        {
            List<KeyValuePair<Transport, double>> result = new List<KeyValuePair<Transport, double>>();
            if (transports.Count < 1)
                throw new ZeroRacersOnStartException();
            if (distance_ < 0)
                throw new NegativeDistanceException(distance_);
            foreach (var transport in transports)
            {
                result.Add(new KeyValuePair<Transport, double>(transport.Value, transport.Value.TimeFromDistance(distance_)));
            }

            result.Sort(Compresion);

            return result;
        }

        public Transport GetWinner()
        {
            return GetResult()[0].Key;
        }
    }
}
