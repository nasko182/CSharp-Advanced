using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Models.Animals.Birds
{
    public class Owl : Bird
    {
        public Owl(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
            foodOverweight = 0.25;
            EatenTypeOfFoods.Add("Meat");
        }

        public override string ProduceSound()
        {
            return "Hoot Hoot";
        }
    }
}
