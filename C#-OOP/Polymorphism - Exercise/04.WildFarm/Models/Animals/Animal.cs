using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals
{
    public abstract class Animal
    {

        public Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
            this.EatenTypeOfFoods = new List<string>();
        }

        public string Name { get; protected set; }

        public double Weight { get; protected set; }

        public int FoodEaten { get; protected set; }

        protected List<string> EatenTypeOfFoods;

        protected double foodOverweight;

        public abstract string ProduceSound();

        public string EatFood(string foodType,int quantity)
        {
            Food food = new Fruit(quantity);
            if (foodType == "Vegetable")
            {
                food = new Vegetable(quantity);
            }
            else if (foodType=="Meat")
            {
                food=new Meat(quantity);
            }
            else if (foodType== "Seeds")
            {
                food = new Seads(quantity);
            }
            if (!EatenTypeOfFoods.Contains(foodType))
            {
                return $"{this.GetType().Name} does not eat {food.GetType().Name}!"+Environment.NewLine;
            }
            else
            {
                FoodEaten += quantity;
                Weight += quantity * foodOverweight;
                return "";
            }
        }
    }

}
