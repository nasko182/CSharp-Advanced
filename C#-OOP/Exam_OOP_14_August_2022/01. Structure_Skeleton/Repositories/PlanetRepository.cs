using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlanetWars.Repositories
{
    public class PlanetRepository :IRepository<IPlanet>
    {
        private readonly Dictionary<string, IPlanet> planets;

        public PlanetRepository()
        {
            this.planets = new Dictionary<string, IPlanet>();
        }

        public IReadOnlyCollection<IPlanet> Models => this.planets.Values;

        public void AddItem(IPlanet model)
        {
            var name = model.Name;
            planets[name] = model;
        }

        public IPlanet FindByName(string name)
        {
            if (planets.ContainsKey(name))
            {
                return planets[name];
            }
            return null;
        }

        public bool RemoveItem(string name) => planets.Remove(name);
    }
}
