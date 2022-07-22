using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public class Paladin:BaseHero
    {
        private int power;
        public Paladin(string name)
            : base(name, 100)
        {
            this.Power = power;
        }

        public override int Power
        {
            get { return power; }
            protected set => this.power = value;
        }
    }
}
