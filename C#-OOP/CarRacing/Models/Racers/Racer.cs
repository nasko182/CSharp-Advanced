using CarRacing.Models.Cars;
using CarRacing.Models.Cars.Contracts;
using CarRacing.Models.Racers.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Racers
{
    public abstract class Racer : IRacer
    {
        private string username;
        private string racingBehavior;
        private int drivingExperience;
        private ICar car;
        int drivingExperianceIncrease;

        protected Racer(string username, string racingBehavior, int drivingExperience, ICar car,int drivingExperianceIncrease)
        {
           this.Username = username;
           this.RacingBehavior = racingBehavior;
           this.DrivingExperience = drivingExperience;
           this.Car = car;
            this.drivingExperianceIncrease = drivingExperianceIncrease;
        }

        public string Username
        {
            get => username;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Username cannot be null or empty.");
                }
                username = value;
            }
        }
        public string RacingBehavior
        {
            get => racingBehavior;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Racing behavior cannot be null or empty.");
                }
                racingBehavior = value;
            }
        }
        public int DrivingExperience
        {
            get => drivingExperience;
            private set
            {
                if (value<0 || value>100)
                {
                    throw new ArgumentException("Racer driving experience must be between 0 and 100.");
                }
                drivingExperience = value;
            }
        }
        public ICar Car
        {
            get => car;
            private set
            {
                if (value==null)
                {
                    throw new ArgumentException("Car cannot be null or empty.");
                }
                car = value;
            }
        }

        public bool IsAvailable()=> 
            this.Car.FuelAvailable >= this.Car.FuelConsumptionPerRace;
        

        public void Race()
        {
            this.Car.Drive();
            this.DrivingExperience += drivingExperianceIncrease;
        }
    }
}
