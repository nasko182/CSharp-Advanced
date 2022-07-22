using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public class Druid : BaseHero
    {
        private int power;
        public Druid(string name)
            : base(name,80)
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
