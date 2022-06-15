using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();

                string model = input[0];
                int engineSpeed = int.Parse(input[1]);
                int enginePower = int.Parse(input[2]);
                int cargoWeight = int.Parse(input[3]);
                string cargoType = input[4];
                double tire1Pressure = double.Parse(input[5]);
                int tire1Age = int.Parse(input[6]);
                double tire2Pressure = double.Parse(input[7]);
                int tire2Age = int.Parse(input[8]);
                double tire3Pressure = double.Parse(input[9]);
                int tire3Age = int.Parse(input[10]);
                double tire4Pressure = double.Parse(input[11]);
                int tire4Age = int.Parse(input[12]);

                Tire[] tires = new Tire[4]
                {
                    new Tire(tire1Age,tire1Pressure),
                    new Tire(tire2Age,tire2Pressure),
                    new Tire(tire3Age,tire3Pressure),
                    new Tire(tire4Age,tire4Pressure)
                };
                Engine engine = new Engine(engineSpeed, enginePower);
                Cargo cargo = new Cargo(cargoWeight, cargoType);
                Car car = new Car(model, engine, cargo, tires);
                cars.Add(car);

            }

            string command = Console.ReadLine();

            GetCarsByType(command,cars);



        }

        public static void GetCarsByType(string command, List<Car> cars)
        {
            if (command == "fragile")
            {
                var fragileCars = cars.Where(c => c.Cargo.Type == "fragile" && c.Tires.Any(t => t.Pressure < 1)).ToList();
                foreach (var fragileCar in fragileCars)
                {
                    Console.WriteLine(fragileCar.Model);
                }
            }
            else
            {
                var fragileCars = cars.Where(c => c.Engine.Power > 250).ToList();
                foreach (var fragileCar in fragileCars)
                {
                    Console.WriteLine(fragileCar.Model);
                }
            }
        }
    }
}
