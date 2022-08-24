using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlanetWars.Repositories
{
    public class UnitRepository : IRepository<IMilitaryUnit>
    {
        private readonly Dictionary<string, IMilitaryUnit> units;

        public UnitRepository()
        {
            this.units = new Dictionary<string, IMilitaryUnit>();
        }

        public IReadOnlyCollection<IMilitaryUnit> Models => this.units.Values;

        public void AddItem(IMilitaryUnit model)
        {
            var type = model.GetType().Name;
            units[type] = model;
        }

        public IMilitaryUnit FindByName(string name)
        {
            if (units.ContainsKey(name))
            {
                return units[name];
            }
            return null;
        }

        public bool RemoveItem(string name) => units.Remove(name);
    }
}
