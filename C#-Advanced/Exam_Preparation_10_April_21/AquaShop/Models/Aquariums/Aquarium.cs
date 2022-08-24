
namespace AquaShop.Models.Aquariums
{
    using AquaShop.Models.Decorations.Contracts;
    using AquaShop.Models.Fish.Contracts;
    using Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public abstract class Aquarium : IAquarium
    {
        private string name;
        protected Aquarium(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            Decorations = new HashSet<IDecoration>();
            Fish = new HashSet<IFish>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Aquarium name cannot be null or empty.");
                }
                this.name = value;
            }
        }

        public int Capacity { get; }
        public int Comfort => Decorations.Sum(d => d.Comfort);


        public ICollection<IDecoration> Decorations
        {
            get;
        }

        public ICollection<IFish> Fish
        {
            get;
        }


        public void AddFish(IFish fish)
        {
            if (Fish.Count() != this.Capacity)
            {
                Fish.Add(fish);
            }
            else
            {
                throw new InvalidOperationException("Not enough capacity.");
            }
        }

        public bool RemoveFish(IFish fish)
        {
            return Fish.Remove(fish);
        }
        public void AddDecoration(IDecoration decoration)
        {
            Decorations.Add(decoration);
        }
        public void Feed()
        {
            foreach (var fish in Fish)
            {
                fish.Eat();
            }
        }

        public string GetInfo()
        {
            var sb = new StringBuilder();

            var fishesNames = "none";
            if (this.Fish.Count()!=0)
            {
                fishesNames = string.Join(", ", Fish.Select(f => f.Name));
            }

            sb.AppendLine($"{this.Name} ({this.GetType().Name}):");
            sb.AppendLine($"Fish: {fishesNames}");
            sb.AppendLine($"Decorations: {this.Decorations.Count()}");
            sb.AppendLine($"Comfort: {this.Comfort}");

            return sb.ToString().Trim();
        }

    }
}
