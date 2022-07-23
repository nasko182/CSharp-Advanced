using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Models.Animals.Mammals.Feline
{
    public class Cat : Feline
    {
        public Cat(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
        {
            foodOverweight = 0.30; 
            EatenTypeOfFoods.Add("Vegetable");
            EatenTypeOfFoods.Add("Meat");
        }

        public override string ProduceSound()
        {
            return "Meow";
        }
    }
}
