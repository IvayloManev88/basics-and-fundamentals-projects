namespace CarManager.Tests
{
    using NUnit.Framework;
    using System;
    using System.Transactions;

    [TestFixture]
    public class CarManagerTests
    {
        private string _make, _model;
        private double _fuelConsumption, _fuelCapacity;
        [SetUp]
        public void SetUp()
        {
            this._make = GenerateRandomString();
            this._model = GenerateRandomString();
            this._fuelConsumption = GenerateRandomDouble(4, 10);
            this._fuelCapacity = GenerateRandomDouble(60, 120);
        }

        [Test]
        public void CarShouldBeInstatntiatedProperly()
        {
           

            Car car = new Car(this._make, this._model, this._fuelConsumption, this._fuelCapacity);
            Assert.That(car.Make, Is.EqualTo(this._make));
            Assert.That(car.Model, Is.EqualTo(this._model));
            Assert.That(car.FuelConsumption, Is.EqualTo(this._fuelConsumption));
            Assert.That(car.FuelCapacity, Is.EqualTo(this._fuelCapacity));
            Assert.That(car.FuelAmount, Is.Zero);

        }
        [TestCase (""), TestCase(null)]
        public void CarShouldNotBeInstatntiatedProperlyWithInvalidMake(string invalidArg)
        {
            Assert.Throws<ArgumentException>(() => new Car(invalidArg, this._model, this._fuelConsumption, this._fuelCapacity), "Make cannot be null or empty!");
            

        }


        [TestCase(""), TestCase(null)]
        public void CarShouldNotBeInstatntiatedProperlyWithInvalidModel(string invalidArg)
        {
            Assert.Throws<ArgumentException>(() => new Car(this._make, invalidArg, this._fuelConsumption, this._fuelCapacity), "Model cannot be null or empty!");


        }


        [TestCase(0), TestCase(-1), TestCase(-3)]
        public void CarShouldNotBeInstatntiatedProperlyWithInvalidFuelConsumption(double invalidArg)
        {
            Assert.Throws<ArgumentException>(() => new Car(this._make, this._model, invalidArg, this._fuelCapacity), "Fuel consumption cannot be zero or negative!");


        }

        [TestCase(0), TestCase(-1), TestCase(-3)]
        public void CarShouldNotBeInstatntiatedProperlyWithInvalidFuelCapacity(double invalidArg)
        {
            Assert.Throws<ArgumentException>(() => new Car(this._make, this._model, this._fuelConsumption, invalidArg), "Fuel capacity cannot be zero or negative!");


        }

        [TestCase(0), TestCase(-1), TestCase(-3)]

        public void RefuelShouldThrowExceptionIfInvalidArguments(double invalidArg)
        {
            Car car = new Car(this._make, this._model, this._fuelConsumption, this._fuelCapacity);
            Assert.Throws<ArgumentException>(() => car.Refuel(invalidArg), "Fuel amount cannot be zero or negative!");
        }


        [Test]
        public void RefuelShouldWorkCorrectly()
        {
            Car car = new Car(this._make, this._model, this._fuelConsumption, this._fuelCapacity);
            double refuelQuantity = GenerateRandomDouble(2, this._fuelCapacity);
            car.Refuel(refuelQuantity);
            Assert.That(car.FuelAmount, Is.EqualTo(refuelQuantity));
           
        }


        [Test]
        public void RefuelShouldBeBoundedWithMaximumCapacity()
        {
            Car car = new Car(this._make, this._model, this._fuelConsumption, this._fuelCapacity);
            double refuelQuantity = this._fuelCapacity*1000;
            car.Refuel(refuelQuantity);
            Assert.That(car.FuelAmount, Is.EqualTo(this._fuelCapacity));

        }

        [Test]
        public void RefuelShouldWorkCorrectlyWithMaximumCapacity()
        {
            Car car = new Car(this._make, this._model, this._fuelConsumption, this._fuelCapacity);
            double refuelQuantity = this._fuelCapacity;
            car.Refuel(refuelQuantity);
            Assert.That(car.FuelAmount, Is.EqualTo(refuelQuantity));
        }


        [Test]
        public void DriveShouldThrowAnExceptionIfFuelAmountIsNotEngough()
        {
            Car car = new Car(this._make, this._model, this._fuelConsumption, this._fuelCapacity);
            car.Refuel(GenerateRandomDouble(5, 10));
            Assert.Throws<InvalidOperationException>(() =>car.Drive(GenerateRandomDouble(3000,10000)) , "You don't have enough fuel to drive!");
        }

        [Test]
        public void DriveShouldWorkCorrectly()

        {

            Car car = new Car(this._make, this._model, 10, 150);
            double fuelQuantity =100;
            car.Refuel(fuelQuantity);
            
            car.Drive(100);
            Assert.That(car.FuelAmount, Is.EqualTo(fuelQuantity - 10));
        }


        [Test]
        public void DriveShouldThrowAnExceptionIfFuelAmountIsZero()
        {
            Car car = new Car(this._make, this._model, this._fuelConsumption, this._fuelCapacity);
            Assert.Throws<InvalidOperationException>(() => car.Drive(GenerateRandomDouble(1, 100)), "You don't have enough fuel to drive!");
        }

        private static readonly char[] _symbols = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789".ToCharArray();
        private static string GenerateRandomString()
        {
            int lenght = Random.Shared.Next(5, 30);
            char[] randomSymbols = new char[lenght];
            for (int i = 0; i < lenght; i++)
            {
                randomSymbols[i] = _symbols[Random.Shared.Next(_symbols.Length)];
            }
            return new string(randomSymbols);
        }

        private static double GenerateRandomDouble(double min, double max)
        {
            Assert.That(min, Is.LessThanOrEqualTo(max));

            return min + Random.Shared.NextDouble() *( max - min);
        }
    }
}