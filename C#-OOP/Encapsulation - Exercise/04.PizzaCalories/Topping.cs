using System;
using System.Collections.Generic;
using System.Text;

namespace _04.PizzaCalories
{
    public class Topping
    { 
        private int baseCals = 2;
        private string type;
        private int weight;
        private string originalType;
        private IReadOnlyDictionary<string,double> topingCals = new Dictionary<string, double>
        {
            {"meat",1.2 },
            {"veggies",0.8 },
            {"cheese",1.1 },
            {"sauce",0.9 }
        };
        private double calories;
        public Topping(string type, int weight)
        {
            this.originalType=type;
            this.Type=type.ToLower();
            this.Weight=weight;
            this.Calories=0;
        }
        public string Type
        {
            get { return type; }
            private set 
            {
                if (topingCals.ContainsKey(value.ToLower()))
                {
                    type = value;
                }
                else
                {
                    throw new Exception($"Cannot place {originalType} on top of your pizza.");
                }
            }
        }


        public int Weight
        {
            get { return weight; }
            private set 
            {
                if (value>0&&value<51)
                {
                    weight = value;
                }
                else
                {
                    throw new Exception($"{this.originalType} weight should be in the range [1..50].");
                }
            }
        }

        public double Calories
        {
            get
            {
                return calories;
            }
            private set
            {
                calories = (baseCals*weight) * topingCals[this.Type];
            }
        }

    }
}
