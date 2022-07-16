using System;

namespace _04.PizzaCalories
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            try
            {
                string[] pizzaNameInput = Console.ReadLine().Split(' ');
                string pizzaName = pizzaNameInput[1];
                var pizza = new Pizza(pizzaName);

                string[] doughInput = Console.ReadLine().Split(' ');
                string doughtFlourType = doughInput[1];
                string doughtBakingTehnique = doughInput[2];
                int doughWeight = int.Parse(doughInput[3]);
                pizza.Dough = new Dough(doughtFlourType, doughtBakingTehnique, doughWeight);

                string command;
                while ((command = Console.ReadLine()) != "END")
                {
                    string[] toppingInput = command.Split();
                    string topingType = toppingInput[1];
                    int topingWeight = int.Parse(toppingInput[2]);

                    pizza.AddToping(new Topping(topingType, topingWeight));
                }
            Console.WriteLine(pizza.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
             

        }
    }
}
