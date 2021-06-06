namespace Race
{
    public class Transport
    {
        protected double speed_ = 0;
        protected string name_ = "";
        public Transport(double speed, string name)
        {
            speed_ = speed;
            name_ = name;
        }
        public virtual double TimeFromDistance(double distance) => 0;
        public override string ToString()
        {
            return name_ + "["+speed_+"km/h]";
        }
    }

    public class AirTransport : Transport
    {
        public AirTransport(double speed, string name) : base(speed, name)
        { }
        protected virtual double GetNewDistance(double distance) => 0;
        public override double TimeFromDistance(double distance)
        {
            return GetNewDistance(distance) / speed_;
        }
    }

    public class GroundTransport : Transport
    {
        public GroundTransport(double speed, string name, double restInterval) : base(speed, name)
        {
            restInterval = restInterval_;
        }
        protected virtual double TimeFromRest(double time) => 0;
        public override double TimeFromDistance(double distance)
        {
            double time = distance / speed_;
            
            time += TimeFromRest(time);

            return time;
        }
        protected double restInterval_ = 0;
    }
}
