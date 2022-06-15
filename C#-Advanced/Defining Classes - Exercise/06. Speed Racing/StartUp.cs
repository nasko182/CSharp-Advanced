using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();

                string model = input[0];
                double fuelAmount = double.Parse(input[1]);
                double fuelConsumptionPerKilometer=double.Parse(input[2]);
                cars.Add(new Car(model, fuelAmount, fuelConsumptionPerKilometer));
            }
            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] cmdArgs = command.Split();
                string model = cmdArgs[1];
                double amountOfKm = double.Parse(cmdArgs[2]);
                if (cars.Any(c=>c.Model==model))
                {
                    Car currentCar = cars.First(c=>c.Model==model);
                    currentCar.Drive(amountOfKm);
                }
            }
            foreach (Car car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.TraveledDistance}");
            }
        }
    }
}
