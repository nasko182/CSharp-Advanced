using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Trainer> trainers = new List<Trainer>();
            string command;
            while ((command = Console.ReadLine()) != "Tournament")
            {
                string[] cmdArgs = command.Split();
                string trainerName = cmdArgs[0];
                string pokemonName = cmdArgs[1];
                string pokemonElement = cmdArgs[2];
                int pokemonHealth = int.Parse(cmdArgs[3]);
                if (!trainers.Any(t=>t.Name==trainerName))
                {
                    trainers.Add(new Trainer(trainerName, new Pokemon(pokemonName, pokemonElement, pokemonHealth)));
                }
                else
                {
                    Trainer trainer = trainers.Find(t => t.Name==trainerName);
                    trainer.Add(new Pokemon(pokemonName, pokemonElement, pokemonHealth));
                }
            }

            string inputType;
            while ((inputType = Console.ReadLine()) != "End")
            {
                foreach (Trainer trainer in trainers)
                {
                    if (trainer.Pokemons.Any(p => p.Element == inputType))
                    {
                        trainer.NumberOfBadges++;
                    }
                    else
                    {
                        foreach (var pokemon in trainer.Pokemons)
                        {
                            pokemon.Health -= 10;
                        }
                    }
                    trainer.Pokemons= trainer.Pokemons.Where(p => p.Health>0).ToList();
                }
            }

            foreach (Trainer trainer in trainers.OrderByDescending(t => t.NumberOfBadges))
            {
                Console.WriteLine($"{trainer.Name} {trainer.NumberOfBadges} {trainer.Pokemons.Count}");
            }

        }
    }
}
