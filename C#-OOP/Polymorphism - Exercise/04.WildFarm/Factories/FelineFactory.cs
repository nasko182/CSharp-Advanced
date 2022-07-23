using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Animals.Mammals.Feline;

namespace WildFarm.Factories
{
    public class FelineFactory
    {
        public Feline CreateBird(string type, string name, double weight, string livingRegion,string breed)
        {
            Feline bird = new Tiger(name, weight, livingRegion,breed);
            if (type == "Dog")
            {
                bird = new Cat(name, weight, livingRegion,breed);
            }
            return bird;
        }
    }
}
