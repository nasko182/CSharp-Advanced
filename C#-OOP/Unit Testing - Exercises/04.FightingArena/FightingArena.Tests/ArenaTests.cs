namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [TestFixture]
    public class ArenaTests
    {
        private Arena arena;
        [SetUp]
        public void SetUp()
        {
            this.arena = new Arena();
        }
        [Test]
        public void ConstructorShouldReturnEmptyCollection()
        {
            List<Warrior> actualData = arena.Warriors.ToList();
            List<Warrior> expectedData = new List<Warrior>();

            CollectionAssert.AreEqual(actualData, expectedData);
        }

        [Test]
        public void EnrollShouldAddWarriorToArenaAndCoutrShouldReturnCorectAmountOfWoorriors()
        {
            var nasko = new Warrior("Nasko", 100, 100);
            var desi = new Warrior("Desi", 30, 30);

            arena.Enroll(nasko);
            arena.Enroll(desi);

            var expectedCount = 2;
            var actualCount = arena.Count;

            Assert.True(expectedCount==actualCount);
        }

        [Test]
        public void EnrollShouldThrowInvalidOperationExceptionWhenOneWarriorAddetTwice()
        {
            Warrior warrior = new Warrior("Nasko", 100, 100);
            arena.Enroll(warrior);
            Assert.Throws<InvalidOperationException>(
                () => arena.Enroll(warrior));
        }
        [Test]
        public void FightShouldAttackDefender()
        {
            var actualAttacker = new Warrior("Nasko", 35, 34);
            var actualDeffender = new Warrior("Desi", 31, 37);
            
            var expectedAttacker = new Warrior("Nasko", 35, 34);
            var expecteDeffender = new Warrior("Desi", 31, 37);

            arena.Enroll(actualAttacker);
            arena.Enroll(actualDeffender);

            arena.Fight("Nasko", "Desi");

            expectedAttacker.Attack(expecteDeffender);
            Assert.AreEqual(expectedAttacker.HP, actualAttacker.HP);
            Assert.AreEqual(expecteDeffender.HP, actualDeffender.HP);
            
        }
        [Test]
        public void FightShouldThrowInvalidOperationExceptionIfAttackerIsNotEnrolled()
        {
            var actualAttacker = new Warrior("Nasko", 35, 34);
            var actualDeffender = new Warrior("Desi", 31, 37);

            arena.Enroll(actualAttacker);
            arena.Enroll(actualDeffender);

            Assert.Throws<InvalidOperationException>(
                () => arena.Fight("Naskoo", "Desi"));
        }
        [Test]
        public void FightShouldThrowInvalidOperationExceptionIfDeffenderIsNotEnrolled()
        {
            var actualAttacker = new Warrior("Nasko", 35, 34);
            var actualDeffender = new Warrior("Desi", 31, 37);

            arena.Enroll(actualAttacker);
            arena.Enroll(actualDeffender);

            Assert.Throws<InvalidOperationException>(
                () => arena.Fight("Nasko", "Desii"));
        }






    }
}
