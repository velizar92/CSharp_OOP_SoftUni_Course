using NUnit.Framework;
using System;
using System.Linq;

namespace Tests
{
    public class DatabaseTests
    {

        private Database database;
        int[] array;


        [SetUp]
        public void Setup()
        {
            this.database = new Database();
            this.array = new int[3] { 1, 2, 4 };
        }

        //Add() part:

        [Test]
        public void Add_Should_ThrowException_When_CapacityExceeded()
        {
            for (int i = 0; i < 16; i++)
            {
                database.Add(i);
            }

            Assert.Throws<InvalidOperationException>(() => database.Add(17));
        }


        [Test]

        public void Add_Should_IncreasesCDatabaseCounter_When_IsValidOperation()
        {
            int n = 16;
            for (int i = 0; i < n; i++)
            {
                database.Add(i);
            }

            Assert.AreEqual(n, database.Count);
        }


        [Test]

        public void Add_ShouldAddElementToDatabase()
        {

            int elementOne = 104;
            int elementTwo = 111;

            this.database.Add(elementOne);
            this.database.Add(elementTwo);
                 
            int[] fetchedArr = database.Fetch();

            Assert.IsTrue(fetchedArr.Contains(111), "Database doesn't contains this element! ");
        }


        //Remove() part:

        [Test]
        public void Remove_Should_ThrowException_When_CountIsZero()
        {
            int[] emptyArr = new int[0];
            Database emptyDatabase = new Database(emptyArr);

            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }

        [Test]
        public void Remove_ShouldDecreaseDatabaseCounter_When_CountIsValid()

        {           
            Database database = new Database(this.array);

            database.Remove();
            int expectedCount = 2;

            Assert.AreEqual(expectedCount, database.Count);
        }

        [Test]

        public void Remove_Should_RemoveElementFromCollection()
        {           
            Database database = new Database(this.array);
            int lastArrayElement = 4;

            database.Remove();

            int[] newArr = database.Fetch();

            Assert.IsFalse(newArr.Contains(lastArrayElement));

        }


        [Test]

        public void Fetch_Should_ReturnArrayByValue()
        {

            int n = 10;
            for (int i = 0; i < n; i++)
            {
                database.Add(i);
            }

            int[] firstArray = database.Fetch();

            database.Remove();
            int[] secondArray = database.Fetch();

            Assert.That(firstArray, Is.Not.EqualTo(secondArray));

        }


    }
}