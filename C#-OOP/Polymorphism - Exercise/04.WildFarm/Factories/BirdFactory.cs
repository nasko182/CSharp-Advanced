using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Animals;
using WildFarm.Models.Animals.Birds;

namespace WildFarm.Factories
{
    public class BirdFactory
    {
        public Bird CreateBird(string type,string name, double weight,double wingSize)
        {
            Bird bird = new Hen(name, weight, wingSize);
            if (type=="Owl")
            {
                bird = new Owl(name, weight, wingSize);
            }
            return bird;
        }
    }
}
