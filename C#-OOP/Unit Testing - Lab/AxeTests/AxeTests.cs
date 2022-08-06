using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        [TestCase(1)]
        [TestCase(5)]
        public void AttackShouldIncreseDurabilByOne(int durability)
        {
            var axe = new Axe(5,durability);
            axe.Attack(new Dummy(6, 12));
            Assert.AreEqual(durability-1, axe.DurabilityPoints);
        }
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-10)]
        public void AttackShouldReturnExeptionWithInvalidDurability(int durability)
        {
            var axe = new Axe(5, durability);
            Assert.Throws<InvalidOperationException>(
                ()=> axe.Attack(new Dummy(6, 12)));
        }


    }
}