using System;
using System.Collections.Generic;
using System.Text;

namespace _04.PizzaCalories
{
    public class Pizza
    {

        private string name;
        private List<Topping> toppings;
        private Dough dough;
        private double totalCalories;

        public Pizza(string name)
        {
            this.Name = name;
            toppings = new List<Topping>();
            totalCalories = 0;
        }
        public string Name
        {
            get { return name; }
            private set 
            {
                if (value.Length>15||string.IsNullOrEmpty(value))
                {
                    throw new Exception("Pizza name should be between 1 and 15 symbols.");
                }
                else
                {
                    name = value;
                }
            }
        }


        public IReadOnlyList<Topping> Toppings => toppings;


        public Dough Dough
        {
            get { return dough; }
            set { dough = value; }
        }


        public double TotalCalories => totalCalories;

        private double CalcCalories()
        {
            totalCalories = 0;
            foreach (var topping in toppings)
            {
                totalCalories += topping.Calories;
            }
            totalCalories += Dough.Calories;
            return totalCalories;
        }

        public void AddToping(Topping topping)
        {
            if (toppings.Count<10)
            {
                toppings.Add(topping);
            }
            else
            {
                throw new Exception("Number of toppings should be in range [0..10].");
            }
        }
        public override string ToString()
        {
            CalcCalories();
            return $"{this.Name} - {this.totalCalories:f2} Calories.";
        }







    }
}
