using Easter.Models.Eggs.Contracts;
using Easter.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Easter.Models.Eggs
{
    public class Egg : IEgg
    {
        private string name;
        private int energyRequired;
        private const int ENERGY_DECREASE = 10;

        public Egg(string name, int energyRequired)
        {
            this.Name = name;
            this.EnergyRequired = energyRequired;
        }
        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.InvalidEggName);
                }
                name = value;
            }
        }
        public int EnergyRequired
        {
            get => energyRequired;
            private set
            {
                if (value<0)
                {
                    value = 0;
                }
                energyRequired = value;
            }
        }

        public void GetColored() => energyRequired -= ENERGY_DECREASE;

        public bool IsDone() => energyRequired == 0;
    }
}
