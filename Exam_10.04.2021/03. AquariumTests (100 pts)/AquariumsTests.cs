namespace Aquariums.Tests
{
    using NUnit.Framework;
    using System;

    public class AquariumsTests
    {
        private Aquarium aquarium;


        [SetUp]
        public void SetUp()
        {
            this.aquarium = new Aquarium("Name", 20);
        }

        //Count
        [Test]
        public void Count_ShouldReturn_ValidCount()
        {
            Fish fish = new Fish("Zako");
            this.aquarium.Add(fish);

            Assert.AreEqual(1, this.aquarium.Count);
        }


        [Test]
        public void Name_ShouldThrowExceptionIf_IsNull()
        {
            Assert.Throws<ArgumentNullException>(() => this.aquarium = new Aquarium(null, 20)); 
        }

        [Test]
        public void Name_ShouldThrowExceptionIf_IsEmpty()
        {
            Assert.Throws<ArgumentNullException>(() => this.aquarium = new Aquarium("", 20)); 
        }

        [Test]
        public void Name_ValidationWorksCorrect()
        {
            this.aquarium = new Aquarium("Name", 20);

            Assert.AreEqual("Name", this.aquarium.Name);
        }

        //Capacity
        [Test]
        public void Capacity_ShouldThrowExceptionIf_Is_Less_ThanZero()
        {
            Assert.Throws<ArgumentException>(() => this.aquarium = new Aquarium("Name", -20));
        }

        [Test]
        public void Capacity_ValidationWorksCorrect()
        {
            this.aquarium = new Aquarium("Name", 20);

            Assert.AreEqual(20, this.aquarium.Capacity);
        }

        //Add:
        
        [Test]
        public void Add_ShouldThrowException_If_FishCount_Equal_ToCapacity()
        {
            Aquarium limitAquarium = new Aquarium("TestName", 1);
            Fish fish = new Fish("Zako");
            limitAquarium.Add(fish);

            Assert.Throws<InvalidOperationException>(() => limitAquarium.Add(fish));
        }

        [Test]
        public void Add_Should_WorksCorrect()
        {
            Aquarium aqua = new Aquarium("TestName", 1);
            Fish fish = new Fish("Zako");
            aqua.Add(fish);

            Assert.AreEqual(1, aqua.Count);
        }

        //Remove part:

        [Test]
        public void Rwmove_ShouldThrowException_If_Fish_NotExist()
        {
            Aquarium aqua = new Aquarium("TestName", 1);
            Assert.Throws<InvalidOperationException>(() => aqua.RemoveFish("Berta"));
        }

        [Test]
        public void Remove_Should_WorksCorrect()
        {
            Aquarium aqua = new Aquarium("TestName", 1);
            Fish fish = new Fish("Zako");
            aqua.Add(fish);
            aqua.RemoveFish("Zako");

            Assert.AreEqual(0, aqua.Count);
        }


        //SelFish:

        [Test]
        public void SelFish_ShouldThrowException_If_Fish_NotExist()
        {
            Aquarium aqua = new Aquarium("TestName", 1);
            Assert.Throws<InvalidOperationException>(() => aqua.SellFish("Berta"));
        }

        [Test]
        public void SelFish_Should_WorksCorrect()
        {
            Aquarium aqua = new Aquarium("TestName", 1);
            Fish fish = new Fish("Zako");
            aqua.Add(fish);
            var reqFish = aqua.SellFish("Zako");

            Assert.That(fish.Name == reqFish.Name);
        }

        //Report:


        [Test]
        public void Report_Should_WorksCorrect()
        {
            Aquarium aqua = new Aquarium("TestName", 3);
            Fish fish = new Fish("Zako");
            Fish fishTwo = new Fish("Bako");
            aqua.Add(fish);
            aqua.Add(fishTwo);

            var result = aqua.Report();
            string expectedResult = $"Fish available at TestName: Zako, Bako";

            Assert.AreEqual(expectedResult, aqua.Report());
        }




    }
}
