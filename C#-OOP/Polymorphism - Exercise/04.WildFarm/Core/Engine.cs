using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.IO.Interfaces;
using WildFarm.Models.Animals;
using WildFarm.Models.Animals.Birds;
using WildFarm.Models.Animals.Mammals;
using WildFarm.Models.Animals.Mammals.Feline;

namespace WildFarm.Core
{
    public class Engine : IEngine
    {
        public Engine(IWriter writer, IReader reader)
        {
            this.writer = writer;
            this.reader = reader;
        }
        private readonly IWriter writer;
        private readonly IReader reader;

        public void Start ()
        {
            List<Animal> animals = new List<Animal>();
            string command;
            while ((command=reader.ReadLine())!="End")
            {
                string[] animalArgs = command.Split(' ');
                string animaltype = animalArgs[0];
                string name = animalArgs[1];
                double weight = double.Parse(animalArgs[2]);
                Animal animal = new Owl("x", 1, 2);

                string[] foodArgs = reader.ReadLine().Split(' ');
                string foodType = foodArgs[0];
                int foodQuantity = int.Parse(foodArgs[1]);
                if (animaltype=="Owl")
                {
                    animal= new Owl(name,weight,double.Parse(animalArgs[3]));
                }
                else if (animaltype == "Hen")
                {
                    animal=new Hen(name, weight, double.Parse(animalArgs[3]));
                }
                else if (animaltype=="Dog")
                {
                    animal = new Dog(name, weight, animalArgs[3]);
                }
                else if (animaltype == "Mouse")
                {
                    animal = new Mouse(name, weight, animalArgs[3]);
                }
                else if (animaltype == "Cat")
                {
                    animal = new Cat(name,weight, animalArgs[3], animalArgs[4]);
                }
                else if (animaltype == "Tiger")
                {
                    animal = new Tiger(name, weight, animalArgs[3], animalArgs[4]);
                }
                writer.WriteLine(animal.ProduceSound());
                writer.Write(animal.EatFood(foodType, foodQuantity));
                animals.Add(animal);
            }
            foreach (var animal in animals)
            {
                writer.WriteLine(animal.ToString());
            }

        }
    }
}
