using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models.Fish
{
    public class FreshwaterFish : Fish
    {
        private const int INITIAL_SIZE = 3;
        private const int INCREASE_SIZE = 3;
        public FreshwaterFish(string name, string species, decimal price) 
            : base(name, species, price, INITIAL_SIZE)
        {
        }

        public override void Eat()
        {
            this.Size += INCREASE_SIZE;
        }
    }
}
