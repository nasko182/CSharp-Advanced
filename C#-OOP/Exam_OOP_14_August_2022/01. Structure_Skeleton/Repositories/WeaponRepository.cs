using PlanetWars.Models.Weapons;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetWars.Repositories
{
    public class WeaponRepository : IRepository<IWeapon>
    {
        private readonly Dictionary<string, IWeapon> weapons;

        public WeaponRepository()
        {
            this.weapons = new Dictionary<string,IWeapon>();
        }

        public IReadOnlyCollection<IWeapon> Models => this.weapons.Values;

        public void AddItem(IWeapon model)
        {
            var type = model.GetType().Name;
            weapons[type] = model;
        }

        public IWeapon FindByName(string name)
        {
            if (weapons.ContainsKey(name))
            {
                return weapons[name];
            }
            return null;
        }

        public bool RemoveItem(string name)=> weapons.Remove(name);
    }
}
