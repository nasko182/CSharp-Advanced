using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes.Contracts;
using Easter.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easter.Models.Bunnies
{
    public class Bunny : IBunny
    {
        private string name;
        private int energy;
        private const int ENERGY_DECREASES = 10;

        protected Bunny(string name, int energy)
        {
            this.Name = name;
            this.Energy = energy;
            this.Dyes = new List<IDye>();
        }
        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidBunnyName);
                }
                this.name = value;
            }

        }

        public int Energy
        {
            get
            {
                return this.energy;
            }
            protected set
            {
                if (value<0)
                {
                    value = 0;
                }
                this.energy = value;
            }

        }

        public ICollection<IDye> Dyes { get; }

        public void AddDye(IDye dye)
        {
            this.Dyes.Add(dye);
        }

        public virtual void Work()
        {
            this.Energy -= ENERGY_DECREASES;
        }
    }
}
