namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class WarriorTests
    {
        [TestCase("Nasko", 18, 20)]
        [TestCase("Nasko", 1, 20)]
        [TestCase("Nasko", 18, 0)]
        public void ConstructorShouldCreateCorrectWarior(string expectedName, int expectedDamage, int expectedHp)
        {
            var warrior = new Warrior(expectedName, expectedDamage, expectedHp);

            var actualName = warrior.Name;
            var actualDamage = warrior.Damage;
            var actualHp = warrior.HP;

            Assert.AreEqual(expectedName, actualName);
            Assert.AreEqual(expectedDamage, actualDamage);
            Assert.AreEqual(expectedHp, actualHp);
        }
        [Test]
        public void ConstructorShouldThrowArgumentExceptionIfNameIsNullOrEmpty()
        {
            string expectedName = "";
            int expectedDamage = 18;
            int expectedHp = 20;

            Assert.Throws<ArgumentException>(
                () => new Warrior(expectedName, expectedDamage, expectedHp));
        }
        [Test]
        public void ConstructorShouldThrowArgumentExceptionIfDamageIsLessThanOrEqualToZero()
        {
            string expectedName = "Nasko";
            int expectedDamage = 0;
            int expectedHp = 20;

            Assert.Throws<ArgumentException>(
                () => new Warrior(expectedName, expectedDamage, expectedHp));
        }
        [Test]
        public void ConstructorShouldThrowArgumentExceptionIfHPIsLessenoZero()
        {
            Assert.Throws<ArgumentException>(
                () => new Warrior("Nasko", 18, -15));
        }

        [TestCase("Warrior",35,34,"Enemy",31,32)]
        [TestCase("Warrior",35,34,"Enemy",31,37)]
        [TestCase("Warrior",35,34,"Enemy",31,35)]
        public void AttackShouldDecreseWariorsHP(string warriorName,int warriorDemage, int warriorHP,string enemyName,int enemyDemage, int enemyHP)
        {
            var warrior = new Warrior(warriorName, warriorDemage, warriorHP);
            var enemy = new Warrior(enemyName, enemyDemage, enemyHP);

            var expectedWarriorHP = warriorHP - enemyDemage;
            var expectedEnemyHp =0;
            if (warrior.Damage > enemy.HP)
            {
                expectedEnemyHp = 0;
            }
            else
            {
                expectedEnemyHp =  enemyHP - warrior.Damage;
            }

            warrior.Attack(enemy);

            var actualWarriorHP = warrior.HP;
            var actualEnemyHP = enemy.HP;

            Assert.AreEqual(expectedWarriorHP, actualWarriorHP);
            Assert.AreEqual(expectedEnemyHp, actualEnemyHP);

        }

        [TestCase("Warrior", 35, 30, "Enemy", 31, 32)]
        [TestCase("Warrior", 35, 29, "Enemy", 31, 37)]
        [TestCase("Warrior", 35, 31, "Enemy", 37, 37)]
        [TestCase("Warrior", 35, 34, "Enemy", 31, 30)]
        [TestCase("Warrior", 35, 34, "Enemy", 31, 29)]
        [TestCase("Warrior", 35, 34, "Enemy", 35, 29)]
        public void AttackShouldThrowInvalidOperationExceptionWithInvalidData(string warriorName, int warriorDemage, int warriorHP, string enemyName, int enemyDemage, int enemyHP)
        {
            var warrior = new Warrior(warriorName, warriorDemage, warriorHP);
            var enemy = new Warrior(enemyName, enemyDemage, enemyHP);

            Assert.Throws<InvalidOperationException>(
                ()=>warrior.Attack(enemy));

        }

        
    }
}