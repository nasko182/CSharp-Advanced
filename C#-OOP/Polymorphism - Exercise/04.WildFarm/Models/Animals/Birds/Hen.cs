using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Models.Animals.Birds
{
    public class Hen : Bird
    {
        public Hen(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
            foodOverweight = 0.35;
            EatenTypeOfFoods.Add("Vegetable");
            EatenTypeOfFoods.Add("Fruit");
            EatenTypeOfFoods.Add("Meat");
            EatenTypeOfFoods.Add("Seeds");
        }

        public override string ProduceSound()
        {
            return "Cluck";
        }
    }
}
