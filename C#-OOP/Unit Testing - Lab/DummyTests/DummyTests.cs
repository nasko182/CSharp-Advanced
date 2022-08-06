using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        [TestCase(1)]
        [TestCase(5)]
        public void IsDeadShouldReturnFalseIfHealthIsBiggerThanZero(int health)
        {
            var dummy = new Dummy(health,5);
            var result = dummy.IsDead();
            Assert.IsFalse(result);
        }
        [TestCase(0)]
        [TestCase(-5)]
        public void IsDeadShouldReturnTrueIfHealthIsLessOrEqualToZero(int health)
        {
            var dummy = new Dummy(health,experience:5);
            var result = dummy.IsDead();
            Assert.IsTrue(result);
        }

        [TestCase(1,5)]
        [TestCase(5,5)]
        [TestCase(6,5)]
        public void TakeAttackShouldIncreseHealthIfAttacked(int health,int attack)
        {
            var dummy = new Dummy(health, experience: 5);
            dummy.TakeAttack(attack);
            Assert.AreEqual(health-attack, dummy.Health);
        }
        [TestCase(0,5)]
        [TestCase(-1,5)]
        public void TakeAttackShouldThrowsInvalidOperationException(int health,int attack)
        {
            var dummy = new Dummy(health, experience: 5);
            Assert.Throws<InvalidOperationException>(
                ()=>dummy.TakeAttack(attack));
        }

        [Test]
        public void GiveExperienceShouldReturnXP()
        {
            int health = 0;
            int experiance = 5;
            var dummy = new Dummy(health, experiance);
            var result = dummy.GiveExperience();
            Assert.AreEqual(result, 5);
        }
        [Test]
        public void GiveExperienceShouldThrowInvalidOperationException()
        {
            int health = 1;
            int experiance = 5;
            var dummy = new Dummy(health, experiance);
            Assert.Throws<InvalidOperationException>(
                () => dummy.GiveExperience());
        }



    }
}