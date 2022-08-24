using System;
using System.Collections.Generic;
using System.Text;

namespace PlanetWars.Models.MilitaryUnits
{
    public class StormTroopers : MilitaryUnit
    {
        public const double COST = 2.5;
        public StormTroopers() : base(COST)
        {
        }
    }
}
