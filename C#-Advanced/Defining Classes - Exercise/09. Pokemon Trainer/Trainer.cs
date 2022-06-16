using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Trainer
    {
        public Trainer(string name, Pokemon pokemon)
        {
            this.Name = name;
            this.Pokemons.Add(pokemon);
        }

        public string Name { get; set; }

        public int NumberOfBadges { get; set; } = 0;

        public List<Pokemon> Pokemons { get; set; } = new List<Pokemon>();

        public void Add(Pokemon pokemon)
        {
            Pokemons.Add(pokemon);
        }
    }
}
