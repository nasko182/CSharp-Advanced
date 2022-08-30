using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Cars
{
    public class TunedCar : Car
    {
        private const double AVAILABLE_FUEL = 65;
        private const double FUEL_PER_RACE = 7.5;
        public TunedCar(string make, string model, string vin, int horesePower)
            : base(make, model, vin, horesePower, AVAILABLE_FUEL, FUEL_PER_RACE)
        {
        }

        public override void Drive()
        {
            base.Drive();
            HorsePower = (int)Math.Round((double)HorsePower - (double)HorsePower * 0.03);
        }
    }
}
