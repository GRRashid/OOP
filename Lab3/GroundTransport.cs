using System;

namespace Race
{
    class BactriaCamel : GroundTransport
    {
        public BactriaCamel() :
            base(10, "двугорбый верблюд", 30)
        { }
        protected override double TimeFromRest(double time)
        {
            int countOfRest = (int)Math.Truncate(time / restInterval_);

            if (countOfRest > 0)
            {
                time += 5;
            }
            if (countOfRest > 1)
            {
                time += 8 * (countOfRest - 1);
            }

            return time;
        }
    }

    class SpeedCamel : GroundTransport
    {
        public SpeedCamel() :
            base(40, "верблюд-быстроход", 10)
        { }
        protected override double TimeFromRest(double time)
        {
            int countOfRest = (int)Math.Truncate(time / restInterval_);

            if (countOfRest > 0)
            {
                time += 5;
            }
            if (countOfRest > 1)
            {
                time += 6.5;
            }
            if (countOfRest > 2)
            {
                time += 8 * (countOfRest - 2);
            }

            return time;
        }
    }
    
    class Centaur : GroundTransport
    {
        public Centaur() :
            base(15, "Кентавр", 9)
        { }
        protected override double TimeFromRest(double time)
        {
            int countOfRest = (int)Math.Truncate(time / restInterval_);

            time += 2 * countOfRest;

            return time;
        }
    }
    
    class SpeedBoots : GroundTransport
    {
        public SpeedBoots() :
            base(6, "Сапоги-скороходы", 60)
        { }
        protected override double TimeFromRest(double time)
        {
            int countOfRest = (int)Math.Truncate(time / restInterval_);

            if (countOfRest > 0)
            {
                time += 10;
            }
            if (countOfRest > 1)
            {
                time += 5 * (countOfRest - 1);
            }

            return time;
        }
    }
    
    
}
