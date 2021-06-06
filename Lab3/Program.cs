using System;

namespace Race
{
    class Program
    {
        static void Main(string[] args)
        {
            AllRace race = new AllRace(1000);
            race.AddRacer(new BactriaCamel());
            race.AddRacer(new SpeedCamel());
            race.AddRacer(new Centaur());
            race.AddRacer(new KoverPlane());

            Console.WriteLine("Результаты: ");
            foreach (var line in race.GetResult())
            {
                Console.WriteLine(line.Key + " with " + line.Value + "s");
            }    

            Console.WriteLine("\n"+race.GetWinner());


            GroundRace groundRace = new GroundRace(1000);
            groundRace.AddRacer(new BactriaCamel());
            groundRace.AddRacer(new SpeedCamel());
            groundRace.AddRacer(new Centaur());
            //groundRace.AddRacer(new KoverPlane());

            Console.WriteLine(groundRace.GetWinner());

            AirRace airRace = new AirRace(1000);
            //airRace.AddRacer(new Centaur());
            airRace.AddRacer(new KoverPlane());
            airRace.AddRacer(new Stupa());
            airRace.AddRacer(new Broom());

            Console.WriteLine(airRace.GetWinner());

            Console.Write("\nВведите расстояние: ");
            double dist = Convert.ToDouble(Console.ReadLine());

            race.SetDistance(dist);
            //race.SetDistance(-1000);


            Console.WriteLine(race.GetWinner());
            Console.ReadKey();
        }
    }
}
