using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Car
    {
        public Car(string model, double fuelAmount, double fuelConsumptionPerKilometer)
        {
            this.Model=model;
            this.FuelAmount=fuelAmount;
            this.FuelConsumptionPerKilometer=fuelConsumptionPerKilometer;
        }
        public string Model { get; set; }

        public double FuelAmount { get; set; }

        public double FuelConsumptionPerKilometer { get; set; }

        public double TraveledDistance { get; set; } = 0;

        public void Drive(double amountOfKm)
        {
            if (FuelAmount>=FuelConsumptionPerKilometer*amountOfKm)
            {
                FuelAmount -= FuelConsumptionPerKilometer * amountOfKm;
                TraveledDistance+=amountOfKm;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }
    }

}
