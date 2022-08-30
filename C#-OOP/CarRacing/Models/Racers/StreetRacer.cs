using CarRacing.Models.Cars.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Racers
{
    public class StreetRacer : Racer
    {
        private const int DRIVER_EXPERIANCE_INCREASE = 5;
        private const int DRIVER_EXPERIANCE = 10;
        private const string RACING_BEHAVIOR = "aggressive";
        public StreetRacer(string username, ICar car) : base(username, RACING_BEHAVIOR, DRIVER_EXPERIANCE, car, DRIVER_EXPERIANCE_INCREASE)
        {
        }
    }
}
