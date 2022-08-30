using System;
using System.Collections.Generic;
using System.Text;

namespace Easter.Models.Bunnies
{
    public class SleepyBunny : Bunny
    {
        private const int INITIAL_ENERGY = 50;
        private const int ENERGY_DECREASES = 15;
        public SleepyBunny(string name) : base(name, INITIAL_ENERGY)
        {
        }

        public override void Work()
        {
            this.Energy -= ENERGY_DECREASES;
        }
    }
}
