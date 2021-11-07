//using CarManager;
using NUnit.Framework;
using System;

namespace Tests
{
    public class CarTests
    {

        private Car car;

        [SetUp]
        public void Setup()
        {
            this.car = new Car("Ferrari", "Testarosa", 4.0, 45.0);
        }

        //------------------------------------Constructor-------------------------------

        [Test]
        [TestCase("", "model", 5.5, 5.3)]
        [TestCase(null, "model", 5.5, 5.3)]
        [TestCase("make", "", 5.5, 5.3)]
        [TestCase("make", null, 5.5, 5.3)]
        [TestCase("make", "model", 0, 5.3)]
        [TestCase("make", "model", -1, 5.3)]
        [TestCase("make", "model", 4.4, 0)]
        [TestCase("make", "model", 4.4, -4)]

        public void Ctor_Should_ThrowException_When_PassedDataIsInvalid(
            string make, string model, double fuelConsumtion, double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() => new Car(make, model,
                fuelConsumtion, fuelCapacity));
        }


        //------------------------------------Refuel()-------------------------------
        [Test]
        [TestCase(0)]
        [TestCase(-20)]
        public void Refuel_ShoudThrowsException_WhenFuelIsZeroOrNegative(double fuel)
        {
            Assert.Throws<ArgumentException>(() => car.Refuel(fuel));
        }

        [Test]
        public void Refuel_ShoudIncreaseFuelAmount_WhenFuelAmountIsValid()
        {
            double refuelAmount = this.car.FuelCapacity / 2;
            this.car.Refuel(refuelAmount);

            Assert.That(car.FuelAmount, Is.EqualTo(refuelAmount));
        }

        [Test]
        public void Refuel_SetFuelAmount_WhenCapacityIsExceeded()
        {
            this.car.Refuel(car.FuelCapacity * 1.2);

            Assert.That(car.FuelAmount, Is.EqualTo(car.FuelCapacity));
        }


        //------------------------------------Drive()-------------------------------

        [Test]
        public void Drive_ShouldThrowException_When_TankIsEmpty()
        {
            Car emptycar = new Car("Ferrari", "Testarosa", 4.0, 1);

            Assert.Throws<InvalidOperationException>(() => car.Drive(100));
        }


    }
}