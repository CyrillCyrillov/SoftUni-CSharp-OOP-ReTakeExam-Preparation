using NUnit.Framework;
using System;
using TheRace;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        UnitCar testCar;

        RaceEntry testEntry;

        UnitDriver testDriver;

        [SetUp]
        public void Setup()
        {
            testCar = new UnitCar("Testy", 100, 250.50);

            testDriver = new UnitDriver("Bo", testCar);

            testEntry = new RaceEntry();
        }

        [Test]
        public void UnitCar_Set_Corectly()
        {

            Assert.AreEqual(testCar.Model, "Testy");
            Assert.AreEqual(testCar.HorsePower, 100);
            Assert.AreEqual(testCar.CubicCentimeters, 250.50);
        }

        [Test]
        public void UnitCar_Set_With_Incorrect_Values_NO_Throw()
        {
            UnitCar testIncorrect = new UnitCar("   ", -5000, 0);

            Assert.AreEqual(testIncorrect.Model, "   ");
            Assert.AreEqual(testIncorrect.HorsePower, -5000);
            Assert.AreEqual(testIncorrect.CubicCentimeters, 0);
        }

        [Test]
        public void UnitDriver_Set_Corectly()
        {

            Assert.AreEqual(testDriver.Name, "Bo");

            Assert.AreEqual(testDriver.Car.Model, "Testy");
            Assert.AreEqual(testDriver.Car.HorsePower, 100);
            Assert.AreEqual(testDriver.Car.CubicCentimeters, 250.50);

        }

        [Test]
        public void UnitDriver_Set_With_Null_Name_Throe_Message()
        {
            string name = null;

            ArgumentNullException ex = Assert.Throws<ArgumentNullException>(() =>
            {
                UnitDriver nullNameDriver = new UnitDriver(name, testCar);
                
            });

            Assert.AreEqual(ex.Message, "Name cannot be null! (Parameter 'Name')");
        }

        [Test]
        public void RaceEntry_Set_Corectly()
        {
            RaceEntry testEntry = new RaceEntry();

            Assert.AreEqual(testEntry.Counter, 0);
        }

        [Test]
        public void RaceEntry_Couter_Increece()
        {

            testEntry.AddDriver(testDriver);

            Assert.AreEqual(testEntry.Counter, 1);
        }

        [Test]
        public void RaceEntry_Couter_Message()
        {

            string message = testEntry.AddDriver(testDriver);

            Assert.AreEqual(message, "Driver Bo added in race.");
        }

        [Test]
        public void RaceEntry_Add_UnitDriver_With_Same_Name_Throe_And_Message()
        {
            
            testEntry.AddDriver(testDriver);
            UnitCar testCarTwo = new UnitCar("Testy", 1, 1);

            UnitDriver sameNameDriver = new UnitDriver("Bo", testCarTwo);

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() =>
            {
                testEntry.AddDriver(sameNameDriver);

            });

            Assert.AreEqual(ex.Message, "Driver Bo is already added.");
        }

        [Test]
        public void RaceEntry_Add_UnitDriver_With_Null_Driver_Throe_And_Message()
        {

            UnitDriver nullDriver = null;

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() =>
            {
                
            testEntry.AddDriver(nullDriver);

            });

            Assert.AreEqual(ex.Message, "Driver cannot be null.");
        }

        [Test]
        public void Calcul_Avarage_Horse_Power_less_Then_Two_Drivers_Throw_Message()
        {

            testEntry.AddDriver(testDriver);
            //UnitCar testCarTwo = new UnitCar("Testy", 1, 1);

            //UnitDriver secondDriver = new UnitDriver("Bo", testCarTwo);

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() =>
            {
                testEntry.CalculateAverageHorsePower();

            });

            Assert.AreEqual(ex.Message, "The race cannot start with less than 2 participants.");
        }

        [Test]
        public void Calcul_Avarage_Horse_Power()
        {

            testEntry.AddDriver(testDriver);
            
            UnitCar testCarTwo = new UnitCar("Testy", 300, 1);
            UnitDriver secondDriver = new UnitDriver("John", testCarTwo);

            testEntry.AddDriver(secondDriver);



            double AvarageHorsePower = testEntry.CalculateAverageHorsePower();

            Assert.AreEqual(AvarageHorsePower, 200);
        }
    }
}