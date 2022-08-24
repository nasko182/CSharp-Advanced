using PlanetWars.Models.MilitaryUnits.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlanetWars.Models.MilitaryUnits
{
    public abstract class MilitaryUnit : IMilitaryUnit
    {
        private const int ENDURANCE_LEVEL = 1;
        private int enduranceLevel;
        public MilitaryUnit(double cost)
        {
            this.Cost = cost;
            this.enduranceLevel = ENDURANCE_LEVEL;
            this.EnduranceLevel = enduranceLevel;
        }
        public double Cost { get;}

        public int EnduranceLevel 
        {
            get
            {
                return this.enduranceLevel;
            }
            private set 
            { 
                this.enduranceLevel = value;
            }
        }

        public void IncreaseEndurance()
        {
            EnduranceLevel++;
            if (EnduranceLevel>20)
            {
                EnduranceLevel = 20;
                throw new ArgumentException("Endurance level cannot exceed 20 power points.");
            }
        }
    }
}
