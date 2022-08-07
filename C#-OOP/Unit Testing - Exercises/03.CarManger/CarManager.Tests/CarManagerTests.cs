namespace CarManager.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;
    using System.Reflection;

    [TestFixture]
    public class CarManagerTests
    {
        private Car car;
        [SetUp]
        public void SetUp()
        {
            car = new Car("Audi", "A3", 15.3, 60.4);
        }
        [TestCase("Audi", "A3", 15.3, 60.4)]
        public void ConstructorShouldMakeCorectCar(string make, string model, double fuelConsumption, double fuelCapacity)
        {
            var car = new Car(make, model, fuelConsumption, fuelCapacity);

            var expectedMake = make;
            var expectedModel = model;
            var expectedFuelConsumption = fuelConsumption;
            var expectedFuelCapacity = fuelCapacity;
            var expectedFuelAmount = 0;

            var actualMake = car.Make;
            var actualModel = car.Model;
            var actualFuelConsumption = car.FuelConsumption;
            var actualFuelCapacity = car.FuelCapacity;
            var actualFuelAmount = car.FuelAmount;

            Assert.AreEqual(expectedMake, actualMake);
            Assert.AreEqual(expectedModel, actualModel);
            Assert.AreEqual(expectedFuelConsumption, actualFuelConsumption);
            Assert.AreEqual(expectedFuelCapacity, actualFuelCapacity);
            Assert.AreEqual(expectedFuelAmount, actualFuelAmount);
        }

        [TestCase("", "A3", 15.3, 60.4)]
        [TestCase(null, "A3", 15.3, 60.4)]
        public void MakeSetterShouldThrowArgumentExceptionWithInvalidData(string make, string model, double fuelConsumption, double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(
                () => new Car(make, model, fuelConsumption, fuelCapacity));
        }
        [TestCase("Audi", "", 15.3, 60.4)]
        [TestCase("Audi", null, 15.3, 60.4)]
        public void ModelSetterShouldThrowArgumentExceptionWithInvalidData(string make, string model, double fuelConsumption, double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(
                () => new Car(make, model, fuelConsumption, fuelCapacity));
        }
        [Test]
        public void FuelConsumptionSetterShouldThrowArgumentExceptionWithInvalidData()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car newCar = new Car("Audi", "A4", -3, 300);
            });
        }
        [Test]
        public void FuelCapacitySetterShouldThrowArgumentExceptionWithInvalidData()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car newCar = new Car("Audi", "A4", 3, -300);
            });
        }

        [Test]
        public void FuelAmountSetterShouldThrowArgumentExceptionWithInvalidData()
        {
            Type type = car.GetType();
            PropertyInfo[] props = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var prop = props.First(p => p.Name == "FuelAmount");
            Assert.Throws <TargetInvocationException> (
                () => prop.SetValue(car, -1));

        }

        [TestCase(12.3)]
        [TestCase(60.4)]
        public void RefuelShouldIncreseFuelAmountWithFuelToRefuel(double fuelToRefuel)
        {
            var expectedFuelAmount = car.FuelAmount + fuelToRefuel;

            car.Refuel(fuelToRefuel);

            var actualFuelAmount = car.FuelAmount;

            Assert.AreEqual(expectedFuelAmount, actualFuelAmount);

        }

        [TestCase(60.5)]
        [TestCase(65.5)]
        public void RefuelShouldIncreseFuelAmountToFuelCapcity(double fuelToRefuel)
        {
            var expectedFuelAmount = car.FuelCapacity;

            car.Refuel(fuelToRefuel);

            var actualFuelAmount = car.FuelAmount;

            Assert.AreEqual(expectedFuelAmount, actualFuelAmount);

        }

        [TestCase(0)]
        [TestCase(-5)]
        public void RefuelShouldThrowArgumentExeptionIfFuelToRefuelIsLessThenZero(double fuelToRefuel)
        {
            Assert.Throws<ArgumentException>(
                () => car.Refuel(fuelToRefuel));
        }

        [TestCase(100)]
        public void DriveShouldDecreaseFuelAmountCorrectly(double distance)
        {
            double currentFuelAmount = 60;
            car.Refuel(currentFuelAmount);
            double fuelNeeded = (distance / 100) * car.FuelConsumption;
            var expectedFuelAmount = currentFuelAmount - fuelNeeded;
            car.Drive(distance);
            var actualFuelAmount = car.FuelAmount;
            Assert.AreEqual(expectedFuelAmount, actualFuelAmount);
        }
        [Test]
        public void DriveShouldThrowInvalidOperationExceptionIfFuelNeededIsBigerThanFuelAmount() 
        {
            car.Refuel(60.5);
            Assert.Throws<InvalidOperationException>(
                ()=>car.Drive(100000000));
        }
        //public void Drive(double distance)
        //{
        //    double fuelNeeded = (distance / 100) * this.FuelConsumption;

        //    if (fuelNeeded > this.FuelAmount)
        //    {
        //        throw new InvalidOperationException("You don't have enough fuel to drive!");
        //    }

        //    this.FuelAmount -= fuelNeeded;
        //}
    }
}