using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Cars
{
    public class SuperCar : Car
    {
        private const double AVAILABLE_FUEL = 80;
        private const double FUEL_PER_RACE = 10;
        public SuperCar(string make, string model, string vin, int horesePower) 
            : base(make, model, vin, horesePower,AVAILABLE_FUEL,FUEL_PER_RACE )
        {
        }
    }
}
