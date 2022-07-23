using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Models.Animals.Mammals.Feline
{
    public class Tiger : Feline
    {
        public Tiger(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
        {
            foodOverweight = 1;
            EatenTypeOfFoods.Add("Meat");
        }

        public override string ProduceSound()
        {
            return "ROAR!!!";
        }
    }
}
