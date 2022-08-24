using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories;
using PlanetWars.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetWars.Models.Planets
{
    public class Planet : IPlanet
    {
        private string name;
        private double budget;
        private double militaryPower;
        private IRepository<IMilitaryUnit> units;
        private IRepository<IWeapon> weapons;

        public Planet(string name, double budget)
        {
            this.Name = name;
            this.Budget = budget;
            this.units = new UnitRepository();
            this.weapons = new WeaponRepository();
        }
        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Planet name cannot be null or empty.");
                }
                this.name = value;
            }
        }

        public double Budget
        {
            get
            {
                return this.budget;
            }
            private set
            {
                if (value<0)
                {
                    throw new ArgumentException("Budget's amount cannot be negative.");
                }
                this.budget = value;
            }
        }

        public double MilitaryPower
        {
            get
            {
                this.MilitaryPower = militaryPower;
               return this.militaryPower;
            }
            private set 
            {
                var unitEndurance = units.Models.Sum(u => u.EnduranceLevel);
                var weaponDestruction = weapons.Models.Sum(w=>w.DestructionLevel);

                double power = unitEndurance + weaponDestruction;
                if (units.FindByName("AnonymousImpactUnit")!=null)
                {
                    power = power + (power * 0.30);
                }
                if (weapons.FindByName("NuclearWeapon")!=null)
                {
                    power = power + (power * 0.45);
                }
                this.militaryPower = Math.Round(power,3); 
            }
        }

        public IReadOnlyCollection<IMilitaryUnit> Army => this.units.Models;

        public IReadOnlyCollection<IWeapon> Weapons => this.weapons.Models;

        public void AddUnit(IMilitaryUnit unit)
        {
            units.AddItem(unit);
            if (budget<=unit.Cost)
            {
                units.RemoveItem(unit.GetType().Name);
            }
        }

        public void AddWeapon(IWeapon weapon)
        {
            weapons.AddItem(weapon);
            if (budget <= weapon.Price)
            {
                weapons.RemoveItem(weapon.GetType().Name);
            }
        }

        public string PlanetInfo()
        {
            var sb = new StringBuilder();
            this.MilitaryPower = militaryPower;
            string forces = "No units";
            if (Army.Any())
            {
                forces = string.Join(", ",Army.Select(u=>u.GetType().Name));
            }
             string weapons = "No weapons";
            if (Weapons.Any())
            {
                weapons = string.Join(", ",Weapons.Select(w=>w.GetType().Name));
            }

            sb.AppendLine($"Planet: {this.Name}");
            sb.AppendLine($"--Budget: {this.Budget} billion QUID");
            sb.AppendLine($"--Forces: {forces}");
            sb.AppendLine($"--Combat equipment: {weapons}");
            sb.AppendLine($"--Military Power: {MilitaryPower}");

            return sb.ToString().Trim();
        }

        public void Profit(double amount)=>this.Budget+=amount;

        public void Spend(double amount)
        {
            if (Budget>=amount)
            {
                Budget -= amount;
            }
            else
            {
                throw new InvalidOperationException("Budget too low!");
            }
        }

        public void TrainArmy()
        {
            foreach (var unit in Army)
            {
                unit.IncreaseEndurance();
            }
        }
    }
}
