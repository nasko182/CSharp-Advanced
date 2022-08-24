using AquaShop.Core.Contracts;
using AquaShop.Models.Aquariums;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Core
{
    public class Controller : IController
    {
        private readonly DecorationRepository decorations;
        private readonly ICollection<IAquarium> aquariums;

        public Controller()
        {
            decorations = new DecorationRepository();
            aquariums = new HashSet<IAquarium>();
        }
        public string AddAquarium(string aquariumType, string aquariumName)
        {
            IAquarium aquarium;
            if (aquariumType == "FreshwaterAquarium")
            {
                aquarium = new FreshwaterAquarium(aquariumName);
            }
            else if (aquariumType == "SaltwaterAquarium")
            {
                aquarium = new SaltwaterAquarium(aquariumName);
            }
            else
            {
                throw new InvalidOperationException("Invalid aquarium type.");
            }

            aquariums.Add(aquarium);
            return $"Successfully added {aquariumType}.";
        }

        public string AddDecoration(string decorationType)
        {
            IDecoration decoration;
            if (decorationType == "Plant")
            {
                decoration = new Plant();
            }
            else if (decorationType == "Ornament")
            {
                decoration = new Ornament();
            }
            else
            {
                throw new InvalidOperationException("Invalid decoration type.");
            }

            decorations.Add(decoration);
            return $"Successfully added {decorationType}.";
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            var currentAquarium = aquariums.FirstOrDefault(a=>a.Name==aquariumName);
            var currentDecoration = decorations.FindByType(decorationType);

            if (currentDecoration==null)
            {
                throw new InvalidOperationException($"There isn't a decoration of type {decorationType}.");
            }

            currentAquarium?.AddDecoration(currentDecoration);
            decorations.Remove(currentDecoration);

            return $"Successfully added {decorationType} to {aquariumName}.";
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            var currentAquarium = aquariums.FirstOrDefault(a => a.Name == aquariumName);
            IFish fish;
            if (fishType== "SaltwaterFish")
            {
                fish = new SaltwaterFish(fishName, fishSpecies, price);
            }
            else if ( fishType=="FreshwaterFish")
            {
                fish = new FreshwaterFish(fishName, fishSpecies, price);
            }
            else
            {
                throw new InvalidOperationException("Invalid fish type.");
            }

            string aquariumType = currentAquarium?.GetType()
                .Name
                .Replace("Aquarium",string.Empty);
            string fishTypeStr = fishType.Replace("Fish",string.Empty);

            if (aquariumType == fishTypeStr)
            {
                currentAquarium?.AddFish(fish);
                return $"Successfully added {fishType} to {aquariumName}.";
            }

                return $"Water not suitable.";
        }

        public string FeedFish(string aquariumName)
        {
            var currentAquarium = aquariums.FirstOrDefault(a=>a.Name==aquariumName);

            currentAquarium?.Feed();

            return $"Fish fed: {currentAquarium.Fish.Count}";
        }

        public string CalculateValue(string aquariumName)
        {
            var currentAquarium = aquariums.FirstOrDefault(a => a.Name == aquariumName);
            var sum = 0m;
            foreach (var fish in currentAquarium?.Fish)
            {
                sum += fish.Price;
            }
            foreach (var decoration in currentAquarium?.Decorations)
            {
                sum += decoration.Price;
            }
            return $"The value of Aquarium {aquariumName} is {sum:f2}.";
        }



        public string Report()
        {
            var sb = new StringBuilder();
            foreach (var aquarium in aquariums)
            {
                sb.AppendLine(aquarium.GetInfo());
            }
            return sb.ToString().Trim();
        }
    }
}
