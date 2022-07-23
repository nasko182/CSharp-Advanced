using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Animals.Mammals;

namespace WildFarm.Factories
{
    public class MammalFactory
    {
        public Mammal CreateMammal(string type, string name, double weight, string livingRegion)
        {
            Mammal bird = new Mouse(name, weight, livingRegion);
            if (type == "Dog")
            {
                bird = new Dog(name, weight, livingRegion);
            }
            return bird;
        }
    }
}
