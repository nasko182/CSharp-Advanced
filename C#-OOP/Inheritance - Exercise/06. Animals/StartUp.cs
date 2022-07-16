using System;
using System.Collections.Generic;

namespace Animals
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();
            string command;
            while ((command = Console.ReadLine())!="Beast!")
            {
                string[] input = Console.ReadLine().Split(' ');
                string name = input[0];
                int age = int.Parse(input[1]);
                string gender = input[2];
                if (age<0)
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }
                if (gender!="Male" && gender!="Female" )
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }
                if (command == "Cat")
                {
                    var animal = new Cat(name, age, gender);
                    animals.Add(animal);
                }
                else if (command == "Dog")
                {
                    var animal = new Dog(name, age, gender);
                    animals.Add(animal);
                }
                else if (command == "Frog")
                {
                    var animal = new Frog(name, age, gender);
                    animals.Add(animal);
                }
                else if (command == "Kitten")
                {
                    var animal = new Kitten(name, age);
                    animals.Add(animal);
                }
                else if (command == "Tomcat")
                {
                    var animal = new Tomcat(name, age);
                    animals.Add(animal);
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }


            }

                foreach(var animal in animals)
                {
                    Console.WriteLine(animal.ToString());
                }

        }
    }
}
