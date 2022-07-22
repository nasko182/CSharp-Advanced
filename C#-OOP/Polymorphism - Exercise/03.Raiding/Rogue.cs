using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public class Rogue : BaseHero
    {
        private int power;
        public Rogue(string name)
            : base(name, 80)
        {
            this.Power = power;
        }

        public override int Power
        {
            get { return power; }
            protected set => this.power = value;
        }

        public override string CastAbility()
        {
            return $"{GetType().Name} - {Name} hit for {Power} damage";
        }
    }
}
