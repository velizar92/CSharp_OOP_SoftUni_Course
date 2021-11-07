//using FightingArena;
using NUnit.Framework;
using System;
using System.Linq;

namespace Tests
{
    public class ArenaTests
    {

        private Warrior warrior;
        private Arena arena;

        [SetUp]
        public void Setup()
        {
            this.warrior = new Warrior("WarriorName", 20, 20);
            this.arena = new Arena();
        }


        [Test]
        public void Ctor_Should_InitiliazeTheCollectionOfWarriors()
        {
            Assert.That(arena.Warriors != null);
        }


        [Test]
        public void Count_Should_Return_TheValidCountOfCollection()
        {
           int expectedWarriorsCount = 0;
           Assert.AreEqual(expectedWarriorsCount, arena.Count); 
        }



        [Test]
        public void Enroll_Should_ThrowException_When_WarriorIsAlreadyEnrolled()
        {
            Warrior passedWarrior = new Warrior("WarriorName", 20, 20);
            arena.Enroll(passedWarrior);

            Assert.Throws<InvalidOperationException>(() => arena.Enroll(passedWarrior));
        }

       
        [Test]
        public void Enroll_Should_AddPassedWarrior_ToTheArena()
        {
            Warrior passedWarrior = new Warrior("WarriorName", 20, 20);
            arena.Enroll(passedWarrior);
            int countEnrolledWarriors = 1;

            Assert.AreEqual(countEnrolledWarriors, arena.Count);
        }

        [Test]
        public void Enroll_Should_AddWarrior_ToCollectionOfWorriors()
        {
            string name = "WarriorName";
            Warrior warrior = new Warrior(name, 20, 20);
            arena.Enroll(warrior);

            //Assert.That(arena.Warriors.Contains(warrior));
            Assert.That(this.arena.Warriors.Any(w => w.Name == name));
        }


        //here
        [Test]
        public void Fight_Should_ThrowException_When_Attacker_DoesNotExists()
        {
           
            string defenderName = "DefenderName";
            Warrior defender = new Warrior(defenderName, 20, 20);
            arena.Enroll(defender);
            
            Assert.Throws<InvalidOperationException>(() => arena.Fight("AttackerName", defenderName));
        }

       
        [Test]
        public void Fight_Should_ThrowException_When_Defender_DoesNotExists()
        {
            string attackerName = "AttackerName";
            Warrior attacker = new Warrior(attackerName, 20, 20);
            arena.Enroll(attacker);

            Assert.Throws<InvalidOperationException>(() => arena.Fight(attackerName, "DefenderName"));
        }

        //here
        [Test]
        public void Fight_Should_ThrowException_When_Both_WarriorsDoesNotExist()
        {
            string attackerName = "AttackerName";
            string defenderName = "DefenderName";        

            Assert.Throws<InvalidOperationException>(() => arena.Fight("AttackerName", "DefenderName"));
        }



        [Test]
        public void Fight_BothWarriorsLooseHealthInFight()
        {
            int initialHp = 100;

            var attacker = new Warrior("Attacker", 50, initialHp);
            var defender = new Warrior("Defender", 50, initialHp);

            arena.Enroll(attacker);
            arena.Enroll(defender);

            this.arena.Fight(attacker.Name, defender.Name);

            Assert.That(attacker.HP,Is.EqualTo(initialHp - defender.Damage));
            Assert.That(defender.HP,Is.EqualTo(initialHp - attacker.Damage));
        }

       

       


    }
}
