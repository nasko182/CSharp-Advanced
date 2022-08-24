using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PlanetWars.Tests
{
    public class Tests
    {
        [TestFixture]
        public class PlanetWarsTests
        {
            [Test]
            public void ConstructorShouldCreatePlanet()
            {
                var planet = new Planet("Earth", 200);

                var expectedName = "Earth";
                var expectedBudget = 200;
                var expectedWeapons = new List<Weapon>();

                var actualName = planet.Name;
                var actualBudget = planet.Budget;
                var actualWeapons = planet.Weapons;

                Assert.AreEqual(expectedName, actualName);
                Assert.AreEqual(expectedBudget, actualBudget);
                Assert.AreEqual(expectedWeapons, actualWeapons);
            }
            //public string Name

            [TestCase(null,200)]
            [TestCase("",200)]
            public void NameGetterShouldThrowArgumentExeptionWhenInvalid(string name , int budget)
            {
                Assert.Throws<ArgumentException>(
                    ()=> new Planet(name, budget));
            }

            //public double Budget
            //{
            //    get
            //    {
            //        return this.budget;
            //    }
            //    private set
            //    {
            //        if (value < 0)
            //        {
            //            throw new ArgumentException("Budget cannot drop below Zero!");
            //        }
            //        this.budget = value;
            //    }
            //}
            [TestCase("Earth", -1)]
            public void BudgetGetterShouldThrowArgumentExeptionWhenInvalid(string name, int budget)
            {
                Assert.Throws<ArgumentException>(
                    () => new Planet(name, budget));
            }

            //public IReadOnlyCollection<Weapon> Weapons => this.weapons;


            //public double MilitaryPowerRatio => this.weapons.Sum(d => d.DestructionLevel);
            [TestCase("Earth", 200,"pushka",50,12)]
            public void MilitaryPowerRatioShouldReturnCorrectInfo(string name,int budget,string weaponNAme, int price,int destructionLevel)
            {
                var planet = new Planet(name, budget);
                var weapon = new Weapon(weaponNAme,price, destructionLevel);

                planet.AddWeapon(weapon);

                var expectedRatio = 12;
                var actualRatio = planet.MilitaryPowerRatio;
                Assert.AreEqual(expectedRatio, actualRatio);
            }

            //public void Profit(double amount)

            [TestCase("Earth", 200,12)]
            public void ProfitShuldReturnCorrectInfo(string name, int budget,int price)
            {
                var planet = new Planet(name, budget);

                planet.Profit(price);

                var expectedRatio = 212;
                var actualRatio = planet.Budget;
                Assert.AreEqual(expectedRatio, actualRatio);
            }

            //public void SpendFunds(double amount)
            [TestCase("Earth", 200, 12)]
            public void SpendFundsShouldReturnCorrectInfo(string name, int budget, int price)
            {
                var planet = new Planet(name, budget);

                planet.SpendFunds(price);

                var expectedRatio = 188;
                var actualRatio = planet.Budget;
                Assert.AreEqual(expectedRatio, actualRatio);
            }

            [TestCase("Earth", 200, 212)]
            public void SpendFundsShouldThrowExeption(string name, int budget, int price)
            {
                var planet = new Planet(name, budget);

                Assert.Throws<InvalidOperationException>(() => planet.SpendFunds(price));
            }

            //public void AddWeapon(Weapon weapon)
            //{
            //    if (this.Weapons.Any(x => x.Name == weapon.Name))
            //    {
            //        throw new InvalidOperationException($"There is already a {weapon.Name} weapon.");
            //    }
            //    this.weapons.Add(weapon);
            //}
            [TestCase("Earth", 200, "pushka", 50, 12)]
            public void AddWeaponShouldThrowExeption(string name, int budget, string weaponNAme, int price, int destructionLevel)
            {
                var planet = new Planet(name, budget);

                var weapon = new Weapon(weaponNAme, price, destructionLevel);
                planet.AddWeapon(weapon);

                Assert.Throws<InvalidOperationException>(() => planet.AddWeapon(weapon));
            }

            //public void RemoveWeapon(string weaponName)
            //{
            //    Weapon weapon = this.weapons.FirstOrDefault(x => x.Name == weaponName);
            //    this.weapons.Remove(weapon);
            //}

            [TestCase("Earth", 200, "pushka", 50, 12)]
            public void RemoveShouldRemoveWeapon(string name, int budget, string weaponNAme, int price, int destructionLevel)
            {
                var planet = new Planet(name, budget);
                var weapon = new Weapon(weaponNAme, price, destructionLevel);

                planet.AddWeapon(weapon);
                planet.RemoveWeapon(weaponNAme);

                var expectedRatio = new List<Weapon>() ;
                var actualRatio = planet.Weapons;
                CollectionAssert.AreEqual(expectedRatio, actualRatio);
            }


            //public void UpgradeWeapon(string weaponName)
            //{
            //    if (!this.Weapons.Any(x => x.Name == weaponName))
            //    {
            //        throw new InvalidOperationException($"{weaponName} does not exist in the weapon repository of {this.Name}");
            //    }

            //    else
            //    {
            //        Weapon weapon = this.Weapons.FirstOrDefault(x => x.Name == weaponName);
            //        weapon.IncreaseDestructionLevel();
            //    }
            //}
            [TestCase("Earth", 200, "pushka", 50, 12)]
            public void UpgrateWeaponShouldThrowExeption(string name, int budget, string weaponNAme, int price, int destructionLevel)
            {
                var planet = new Planet(name, budget);

                Assert.Throws<InvalidOperationException>(
                    () => planet.UpgradeWeapon(weaponNAme));
            }
            [TestCase("Earth", 200, "pushka", 50, 12)]
            public void UpgrateWeaponShouldReturnCorrectInfo(string name, int budget, string weaponNAme, int price, int destructionLevel)
            {
                var planet = new Planet(name, budget);
                var weapon = new Weapon(weaponNAme, price, destructionLevel);

                planet.AddWeapon(weapon);
                planet.UpgradeWeapon(weaponNAme);

                var expectedDestrictinLevel = 13;
                var actualDestrictinLevel = planet.Weapons.First(w => w.Name == weaponNAme).DestructionLevel;

                Assert.AreEqual(expectedDestrictinLevel, actualDestrictinLevel);
            }


            //public string DestructOpponent(Planet opponent)
            //{
            //    if (opponent.MilitaryPowerRatio >= this.MilitaryPowerRatio)
            //    {
            //        throw new InvalidOperationException($"{opponent.Name} is too strong to declare war to!");
            //    }

            //    return $"{opponent.Name} is destructed!";
            //}


            [TestCase("Earth", 200, "pushka", 50, 13, "Mars", 200, "pompa", 50, 12)]
            public void DestructOponentShouldReturnCorrectInfo(string name, int budget, string weaponNAme, int price, int destructionLevel, string Oponentname, int Oponentbudget, string OponentweaponNAme, int Oponentprice, int OponentdestructionLevel)
            {
                var planet = new Planet(name, budget);
                var weapon = new Weapon(weaponNAme, price, destructionLevel);

                var oponent = new Planet(Oponentname, Oponentbudget);
                var oponentWeapon = new Weapon(OponentweaponNAme, Oponentprice, OponentdestructionLevel);

                planet.AddWeapon(weapon);
                oponent.AddWeapon(oponentWeapon);

                var expectedMessage = $"{oponent.Name} is destructed!";
                var actualMessage = planet.DestructOpponent(oponent);

                Assert.AreEqual(expectedMessage, actualMessage);
            }

            [TestCase("Earth", 200, "pushka", 50, 11, "Mars", 200, "pompa", 50, 12)]
            public void DestructOponentShouldthrowExeprion(string name, int budget, string weaponNAme, int price, int destructionLevel, string Oponentname, int Oponentbudget, string OponentweaponNAme, int Oponentprice, int OponentdestructionLevel)
            {
                var planet = new Planet(name, budget);
                var weapon = new Weapon(weaponNAme, price, destructionLevel);

                var oponent = new Planet(Oponentname, Oponentbudget);
                var oponentWeapon = new Weapon(OponentweaponNAme, Oponentprice, OponentdestructionLevel);

                planet.AddWeapon(weapon);
                oponent.AddWeapon(oponentWeapon);

                Assert.Throws<InvalidOperationException>(() => planet.DestructOpponent(oponent));
            }

            //    public Weapon(string name, double price, int destructionLevel)
            //    {
            //        Name = name;
            //        Price = price;
            //        DestructionLevel = destructionLevel;
            //    }

            [TestCase("pushka", 50, 11)]
            public void WeaponPriceGetterShouldworckCorrect(string weaponNAme, int price, int destructionLevel)
            {
                var weapon = new Weapon(weaponNAme, price, destructionLevel);

                Assert.AreEqual(price, weapon.Price);
            }

            [TestCase("pushka", -1, 11)]
            public void WeaponPriceGetterShouldThrowExeption(string weaponNAme, int price, int destructionLevel)
            {

                Assert.Throws<ArgumentException>(() => new Weapon(weaponNAme, price, destructionLevel));
            }

            //    public string Name { get; set; }
            //    public double Price
            //    {
            //        get => price;
            //        set
            //        {
            //            if (value < 0)
            //            {
            //                throw new ArgumentException("Price cannot be negative.");
            //            }
            //            price = value;
            //        }
            //    }
            //    public int DestructionLevel { get; set; }

            //    public void IncreaseDestructionLevel()
            //    {
            //        DestructionLevel++;
            //    }

            //    public bool IsNuclear => this.DestructionLevel >= 10;
            //}
            [TestCase("pushka", 50, 11)]
            public void IsNuclearShouldworckCorrect(string weaponNAme, int price, int destructionLevel)
            {
                var weapon = new Weapon(weaponNAme, price, destructionLevel);

                Assert.True(weapon.IsNuclear);
            }
        }
    }
}
