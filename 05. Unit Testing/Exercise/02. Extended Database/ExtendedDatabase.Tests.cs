//using ExtendedDatabase;
using NUnit.Framework;
using System;

namespace Tests
{
    public class ExtendedDatabaseTests
    {

        private ExtendedDatabase extendedDatabase;


        [SetUp]
        public void Setup()
        {
            this.extendedDatabase = new ExtendedDatabase();
        }

        //----------------------------------------------------Constructor part:-------------------------------------------------
        [Test]
        public void Ctor_Should_AssignPassedLength()
        {
            Person[] persons = new Person[3] { new Person(1, "Zak"), new Person(2, "Mich"), new Person(3, "Nik") };
            ExtendedDatabase database = new ExtendedDatabase(persons);

            int expectedLength = 3;

            Assert.AreEqual(expectedLength, database.Count);

        }

        [Test]
        public void Ctor_Should_ThrowException_When_PassedLengthIsMoreThanDatabaseCapacity()
        {
            Person[] fullPersons = new Person[17]
                {
                    new Person(1, "Zak"), new Person(2, "Mich"), new Person(3, "Nik"),
                    new Person(1, "Zak"), new Person(2, "Mich"), new Person(3, "Nik"),
                    new Person(1, "Zak"), new Person(2, "Mich"), new Person(3, "Nik"),
                    new Person(1, "Zak"), new Person(2, "Mich"), new Person(3, "Nik"),
                    new Person(1, "Zak"), new Person(2, "Mich"), new Person(3, "Nik"),
                    new Person(1, "Zak"),  new Person(1, "Zak")
                };

            var exception = Assert.Throws<ArgumentException>(() => new ExtendedDatabase(fullPersons));
            Assert.That(exception.Message, Is.EqualTo("Provided data length should be in range [0..16]!"));
        }



        //-------------------------------------------------------------Add() part:-------------------------------------------
        [Test]
        public void Add_Should_ThrowException_IfDatabaseCapacityExceeded()
        {
            int dbCapacity = 16;
            for (int i = 0; i < dbCapacity; i++)
            {
                extendedDatabase.Add(new Person(i, $"Zako{i}"));
            }

            var exception = Assert.Throws<InvalidOperationException>(() => extendedDatabase.Add(new Person(2, "Goshi")));
            Assert.That(exception.Message, Is.EqualTo("Array's capacity must be exactly 16 integers!"));
        }


        [Test]
        public void Add_Should_ThrowException_IfUserWithTheSameUserNameAlreadyExists()
        {
            int dbCapacity = 3;
            for (int i = 0; i < dbCapacity; i++)
            {
                extendedDatabase.Add(new Person(i, $"Zako{i}"));
            }

            var exception = Assert.Throws<InvalidOperationException>(() => extendedDatabase.Add(new Person(4, $"Zako1")));
            Assert.That(exception.Message, Is.EqualTo("There is already user with this username!"));
        }


        [Test]
        public void Add_Should_ThrowException_IfUserWithTheSameUserIdAlreadyExists()
        {
            int dbCapacity = 3;
            for (int i = 0; i < dbCapacity; i++)
            {
                extendedDatabase.Add(new Person(i, $"Zako{i}"));
            }

            var exception = Assert.Throws<InvalidOperationException>(() => extendedDatabase.Add(new Person(1, $"Zako555")));
            Assert.That(exception.Message, Is.EqualTo("There is already user with this Id!"));
        }

        [Test]
        public void Add_Should_IncreaseTheCounterOfDatabasePersons()
        {
            int dbCapacity = 3;
            for (int i = 0; i < dbCapacity; i++)
            {
                extendedDatabase.Add(new Person(i, $"Zako{i}"));
            }

            int expected = 3;

            Assert.AreEqual(expected, extendedDatabase.Count);
        }


        //----------------------------------------------------Remove() part:-----------------------------------------
        [Test]
        public void Remove_ShouldThrowException_When_CountIsZero()
        {
            Assert.Throws<InvalidOperationException>(() => extendedDatabase.Remove());
        }

        [Test]

        public void Remove_ShouldDecreaseCounterOfDatabasePersons()
        {
            int dbCapacity = 3;
            for (int i = 0; i < dbCapacity; i++)
            {
                extendedDatabase.Add(new Person(i, $"Zako{i}"));
            }

            extendedDatabase.Remove();
            int expectedCount = 2;

            Assert.AreEqual(expectedCount, extendedDatabase.Count);
        }



        //-------------------------------------FindByUserName() part:-----------------------------------
        [Test]
        public void FindByUserName_Should_ThrowException_When_InputParameterNameIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => extendedDatabase.FindByUsername(null));
            Assert.Throws<ArgumentNullException>(() => extendedDatabase.FindByUsername(""));
        }

        [Test]
        public void FindByUserName_Should_ThrowException_When_UserWithThisUserNameDoesntExists()
        {
            int dbCapacity = 3;
            for (int i = 0; i < dbCapacity; i++)
            {
                extendedDatabase.Add(new Person(i, $"Zako{i}"));
            }

            Assert.Throws<InvalidOperationException>(() => extendedDatabase.FindByUsername("Petko"));
        }

        [Test]
        public void FindByUserName_Should_ReturnExpectedUser()
        {
            Person person = new Person(3, "Zako");
            extendedDatabase.Add(person);
            var foundPerson = extendedDatabase.FindByUsername("Zako");

            Assert.That(person, Is.EqualTo(foundPerson));

        }

        //-----------------------------------------FindById() part:-------------------------------------------
        [Test]
        public void Should_ThrowException_WhenInputIdIsNegative()
        {
            int negativeId = -1;
            Assert.Throws<ArgumentOutOfRangeException>(() => extendedDatabase.FindById(negativeId));
        }

        [Test]
        public void Should_ThrowException_WhenUserWithThisUserIdDoesntExists()
        {
            int dbCapacity = 3;
            for (int i = 0; i < dbCapacity; i++)
            {
                extendedDatabase.Add(new Person(i, $"Zako{i}"));
            }

            int wrongId = 4;
            Assert.Throws<InvalidOperationException>(() => extendedDatabase.FindById(wrongId));
        }

        [Test]
        public void FindById_Should_ReturnExpectedUser_WhenExistsSuchUser()
        {
            Person person = new Person(2, "Zako");
            extendedDatabase.Add(person);
            var foundPerson = extendedDatabase.FindById(2);

            Assert.That(person, Is.EqualTo(foundPerson));

        }



    }
}