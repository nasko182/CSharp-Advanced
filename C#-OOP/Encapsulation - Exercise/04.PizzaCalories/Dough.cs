using System;
using System.Collections.Generic;
using System.Text;

namespace _04.PizzaCalories
{
    public class Dough
    {
        private IReadOnlyDictionary<string, double> flourTypes = new Dictionary<string, double>
        {
            {"white",1.5},
            {"wholegrain",1 }
        };

        private IReadOnlyDictionary<string, double> bakingTehniques = new Dictionary<string, double>
        {
            {"crispy",0.9 },
            {"chewy", 1.1 },
            {"homemade",1 }
        };
        private string flourType;
        private string bakingTehnique;
        private int weight;
        private double calories;
        private int baseCals = 2;

        public Dough(string flourType, string bakingTehnique, int weight)
        {
            this.FlourType = flourType.ToLower();
            this.BakingTehnique = bakingTehnique.ToLower();
            this.Weight = weight;
            this.Calories = 0;
        }

        public string FlourType
        {
            get => flourType;
            private set
            {
                if (flourTypes.ContainsKey(value.ToLower()))
                {
                    flourType = value;
                }
                else
                {
                    throw new Exception("Invalid type of dough.");
                }
            }
        }

        public string BakingTehnique
        {
            get => bakingTehnique;
            private set
            {
                if (bakingTehniques.ContainsKey(value.ToLower()))
                {
                    bakingTehnique = value;
                }
                else
                {
                    throw new Exception("Invalid type of dough.");
                }
            }
        }

        public int Weight
        {
            get => weight;
            private set
            {
                if (value>0&&value<201)
                {
                    weight = value;
                }
                else
                {
                    throw new Exception("Dough weight should be in the range [1..200].");
                }
            }
        }


        public double Calories
        {
            get { return calories; }
            private set 
            { 
                calories = (baseCals * weight) * flourTypes[FlourType] * bakingTehniques[bakingTehnique]; 
            }
        }

    }
}
