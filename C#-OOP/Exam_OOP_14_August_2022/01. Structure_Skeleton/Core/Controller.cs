using PlanetWars.Core.Contracts;
using PlanetWars.Models.MilitaryUnits;
using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories;
using PlanetWars.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetWars.Core
{
    public class Controller : IController
    {
        private IRepository<IPlanet> planets;

        public Controller()
        {
            planets = new PlanetRepository();
        }

        public string CreatePlanet(string name, double budget)
        {
            if (planets.FindByName(name) != null)
            {
                return $"Planet {name} is already added!";
            }
            var planet = new Planet(name, budget);
            planets.AddItem(planet);
            return $"Successfully added Planet: {name}";
        }
        public string AddUnit(string unitTypeName, string planetName)
        {
            if (planets.FindByName(planetName)==null)
            {
                throw new InvalidOperationException($"Planet {planetName} does not exist!");
            }
            var planet = planets.FindByName(planetName);
            IMilitaryUnit unit;
            if (unitTypeName == nameof(SpaceForces))
            {
                unit = new SpaceForces();
            }
            else if (unitTypeName == nameof(AnonymousImpactUnit))
            {
                unit = new AnonymousImpactUnit();
            }
            else if (unitTypeName == nameof(StormTroopers))
            {
                unit = new StormTroopers();
            }
            else
            {
                throw new InvalidOperationException($"{unitTypeName} still not available!");
            }
            if (planet.Army.Any(u => u.GetType().Name == unitTypeName))
            {
                throw new InvalidOperationException($"{unitTypeName} already added to the Army of {planetName}!");
            }
            
            planet.AddUnit(unit);
            planet.Spend(unit.Cost);
            return $"{unitTypeName} added successfully to the Army of {planetName}!";
        }

        public string AddWeapon(string planetName, string weaponTypeName, int destructionLevel)
        {
            if (planets.FindByName(planetName) == null)
            {
                throw new InvalidOperationException($"Planet {planetName} does not exist!");
            }
            var planet = planets.FindByName(planetName);
            if (planet.Weapons.Any(w => w.GetType().Name == weaponTypeName))
            {
                throw new InvalidOperationException($"{weaponTypeName} already added to the Weapons of {planetName}!");
            }
            IWeapon weapon;
            if (weaponTypeName == nameof(NuclearWeapon))
            {
                weapon = new NuclearWeapon(destructionLevel);
            }
            else if (weaponTypeName == nameof(BioChemicalWeapon))
            {
                weapon = new BioChemicalWeapon(destructionLevel);
            }
            else if (weaponTypeName == nameof(SpaceMissiles))
            {
                weapon = new SpaceMissiles(destructionLevel);
            }
            else
            {
                throw new InvalidOperationException($"{weaponTypeName} still not available!");
            }

            planet.AddWeapon(weapon);
            planet.Spend(weapon.Price);
            return $"{planetName} purchased {weaponTypeName}!";
        }

        public string SpecializeForces(string planetName)
        {
            var planet = planets.FindByName(planetName);
            if (planet ==null)
            {
                throw new InvalidOperationException($"Planet {planetName} does not exist!");
            }
            if (!planet.Army.Any())
            {
                throw new InvalidOperationException("No units available for upgrade!");
            }
            planet.Spend(1.25);
            planet.TrainArmy();
            return $"{planetName} has upgraded its forces!";
        }

        public string ForcesReport()
        {
            var sb = new StringBuilder();
            sb.AppendLine("***UNIVERSE PLANET MILITARY REPORT***");
            foreach (var planet in planets.Models.OrderByDescending(p=>p.MilitaryPower).ThenBy(p=>p.Name))
            {
                sb.AppendLine(planet.PlanetInfo());
            }
            return sb.ToString().Trim();
        }

        public string SpaceCombat(string planetOne, string planetTwo)
        {
            var attacker = planets.FindByName(planetOne);
            var deffender = planets.FindByName(planetTwo);

            var attackerPower = attacker.MilitaryPower;
            var deffenderPower = deffender.MilitaryPower;

            IPlanet winner;

            if (attackerPower==deffenderPower)
            {
                if (attacker.Weapons.Any(w=>w.GetType().Name== "NuclearWeapon")
                    && deffender.Weapons.Any(w => w.GetType().Name == "NuclearWeapon"))
                {
                    attacker.Spend(attacker.Budget/2);
                    deffender.Spend(deffender.Budget/2);
                    return "The only winners from the war are the ones who supply the bullets and the bandages!";
                }
                else if (!attacker.Weapons.Any(w=>w.GetType().Name== "NuclearWeapon")
                    &&! deffender.Weapons.Any(w => w.GetType().Name == "NuclearWeapon"))
                {
                    attacker.Spend(attacker.Budget/2);
                    deffender.Spend(deffender.Budget/2);
                    return "The only winners from the war are the ones who supply the bullets and the bandages!";
                }
                else if (attacker.Weapons.Any(w=>w.GetType().Name== "NuclearWeapon"))
                {
                    winner = attacker;
                }
                else
                {
                    winner= deffender;
                }

            }
            else if (attackerPower>deffenderPower)
            {
                winner = attacker;
            }
            else
            {
                winner = deffender;
            }

            winner.Spend(winner.Budget/2);
            var loser = attacker; ;
            string loserName;
            if (winner == attacker)
            {
                deffender.Spend(deffender.Budget/2);
                winner.Profit(deffender.Budget/2);
                loser = deffender;
                loserName = loser.Name;
                planets.RemoveItem(deffender.Name);
            }
            else
            {
                attacker.Spend(attacker.Budget/2);
                winner.Profit(attacker.Budget / 2);
                winner.Profit(loser.Army.Sum(s => s.Cost) + loser.Weapons.Sum(w => w.Price));
                loserName = attacker.Name;
                planets.RemoveItem(attacker.Name);
            }
            return $"{winner.Name} destructed {loser.Name}!";
        }

    }
}
