using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManufacturer
{
    public class Car
    {
        private string make;
        private string mode;
        private int year;
        private double fuelQuantity;
        private double fuelConsumption;
        public string Make { get; set; }

        public string Model { get; set; }

        public int Year { get; set; }

        public double FuelQuantity { get; set; }

        public double FuelConsumption { get; set; }

        public void Drive(int distance)
        {
            if (fuelQuantity-(distance/fuelConsumption)>0)
            {
                fuelQuantity -= distance / fuelConsumption;
            }
            else
            {
                Console.WriteLine("Not enough fuel to perform this trip!");
            }
        }

        public void WhoAmI()
        {
            Console.WriteLine($"Make: {this.Make}");
            Console.WriteLine($"Model: {this.Model}");
            Console.WriteLine($"Year: {this.Year}");
            Console.WriteLine($"Fuel: {this.fuelQuantity:f2}");
        }
    }
}
