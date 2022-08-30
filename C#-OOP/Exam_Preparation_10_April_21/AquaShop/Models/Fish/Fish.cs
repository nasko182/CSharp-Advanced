﻿namespace AquaShop.Models.Fish
{
    using AquaShop.Utilities.Messages;
    using Contracts;
    using System;

    public abstract class Fish : IFish
    {
        private string name;
        private string species;
        private decimal price;

        protected Fish(string name, string species, decimal price, int size)
        {
            this.Name = name;
            this.Species = species;
            this.Price = price;
            this.Size = size;
        }
        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidFishName);
                }
                this.name = value;
            }
        }
        public string Species
        {
            get => this.species; 
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Fish species cannot be null or empty.");
                }
                this.species = value;
            }
        }
        public int Size { get; protected set; }
        public decimal Price
        {
            get => this.price;
            private set
            {
                if (value<=0)
                {
                    throw new ArgumentException("Fish price cannot be below or equal to 0.");
                }
                this.price = value;
            }
        }

        public abstract void Eat();
    }
}
