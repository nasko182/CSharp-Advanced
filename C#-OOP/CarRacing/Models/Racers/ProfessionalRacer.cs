using CarRacing.Models.Cars.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Racers
{
    public class ProfessionalRacer : Racer
    {
        private const int DRIVER_EXPERIANCE_INCREASE = 10;
        private const int DRIVER_EXPERIANCE = 30;
        private const string RACING_BEHAVIOR = "strict";
        public ProfessionalRacer(string username, ICar car) : base(username, RACING_BEHAVIOR, DRIVER_EXPERIANCE, car, DRIVER_EXPERIANCE_INCREASE)
        {
        }
    }
}
