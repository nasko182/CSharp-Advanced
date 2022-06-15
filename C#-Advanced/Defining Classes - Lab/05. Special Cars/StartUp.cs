using System;
using System.Collections.Generic;
using System.Linq;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            //string make = Console.ReadLine();
            //string model = Console.ReadLine();
            //int year = int.Parse(Console.ReadLine());
            //double fuelQuantity = double.Parse(Console.ReadLine());
            //double fuelConsumption = double.Parse(Console.ReadLine());
            List<Tire[]> tires = new List<Tire[]>();
            List<Engine> engines = new List<Engine>();
            List<Car> cars = new List<Car>();
            string inputTires;
            while ((inputTires = Console.ReadLine()) != "No more tires")
            {
                double[] cmdArgs = inputTires
                    .Split()
                    .Select(double.Parse)
                    .ToArray();
                Tire[] currentTires = new Tire[4];
                for (int i = 0; i < cmdArgs.Length; i += 2)
                {
                    currentTires[i / 2] = new Tire((int)cmdArgs[i], cmdArgs[i + 1]);
                }
                tires.Add(currentTires);
            }
            string inputEngines;
            while ((inputEngines = Console.ReadLine()) != "Engines done")
            {
                double[] cmdArgs = inputEngines
                     .Split()
                     .Select(double.Parse)
                     .ToArray();

                for (int i = 0; i < cmdArgs.Length; i += 2)
                {
                    Engine currentEngine = new Engine((int)cmdArgs[i], cmdArgs[i + 1]);
                    engines.Add(currentEngine);
                }
            }
            string command;
            while ((command = Console.ReadLine()) != "Show special")
            {
                string[] cmdArgs = command.Split();
                string make = cmdArgs[0];
                string model = cmdArgs[1];
                int year = int.Parse(cmdArgs[2]);
                double fuelQuantity = double.Parse(cmdArgs[3]);
                double fuelConsumption = double.Parse(cmdArgs[4]);
                int enginIndex = int.Parse(cmdArgs[5]);
                int tiresIndex = int.Parse(cmdArgs[6]);

                Car currentCar = new Car(make, model, year, fuelQuantity, fuelConsumption, engines[enginIndex], tires[tiresIndex]);
                cars.Add(currentCar);
            }

            List<Tire[]> tiresToStay = new List<Tire[]>();
            foreach (var tire in tires)
            {
                double sum = 0;
                foreach (var tir in tire)
                {
                    sum += tir.Pressure;
                }
                if (sum <= 10 && sum >= 9)
                {
                    tiresToStay.Add(tire);
                }
            }
            cars = cars.Where(car=> car.Year >= 2017 && car.Engine.HorsePower > 300 && tiresToStay.Contains(car.Tires)).ToList();
            foreach (Car car in cars)
            {
                car.Drive(20);
            }

            foreach (var car in cars)
            {
                //Console.WriteLine($"Make: {car.Make}");
                //Console.WriteLine($"Model: {car.Model}");
                //Console.WriteLine($"Yaer: {car.Year}");
                //Console.WriteLine($"HorsePowers: {car.Engine.HorsePower}");
                //Console.WriteLine($"FuelQuantity: {car.FuelQuantity}");
                car.WhoAmI();
            }


        }
    }
}
