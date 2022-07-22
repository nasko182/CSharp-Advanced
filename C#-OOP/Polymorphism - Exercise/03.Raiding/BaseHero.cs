﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public abstract class BaseHero
    {
        public BaseHero(string name, int power)
        {
            this.Name = name;
            this.Power = power;
        }
        public string Name { get; protected set; }

        public abstract int Power { get; protected set; }

        public virtual string CastAbility()
        {
            return $"{GetType().Name} - {Name} healed for {Power}";
        }


    }
}
