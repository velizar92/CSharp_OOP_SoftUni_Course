//using FightingArena;
using NUnit.Framework;
using System;

namespace Tests
{
    public class WarriorTests
    {
        private Warrior warrior;

        [SetUp]
        public void Setup()
        {
            this.warrior = new Warrior("WarriorName", 40, 15);
        }


        //------------------------------------Constructor-------------------------------
        //string name, int damage, int hp
        [Test]
        [TestCase("", 23, 50)]
        [TestCase(null, 23, 50)]
        [TestCase(" ", 23, 50)]
        [TestCase("Hero", 0, 50)]
        [TestCase("Hero", -2, 50)]
        [TestCase("Hero", 23, -4)]


        public void Ctor_Should_ThrowException_When_PassedDataIsInvalid(
            string name, int damage, int hp)
        {
            Assert.Throws<ArgumentException>(() => new Warrior(name, damage, hp));
        }


        [Test]
        [TestCase(30, 55)]
        [TestCase(15, 55)]
        [TestCase(55, 30)]
        [TestCase(55, 15)]
        public void Attack_Should_ThrowException_When_Hp_Is_Less_Than_Minimum(int attackerHp, int warriorHp)
        {
            var attacker = new Warrior("Attacker", 50, attackerHp);
            var warrior = new Warrior("Warrior", 10, warriorHp);
            Assert.Throws<InvalidOperationException>(() => attacker.Attack(warrior));
        }


        [Test]
        public void Attack_Should_ThrowException_When_WarriorKillsAttacker()
        {
            var attacker = new Warrior("Attacker", 50, 100);
            var warrior = new Warrior("Warrior", attacker.HP + 1, 100);

            Assert.Throws<InvalidOperationException>(() => attacker.Attack(warrior));

        }


        [Test]
        public void Attack_Should_DecreaseHP_With_ThePassedWarriorDamage()
        {
            int initialHP = 100;
            Warrior attacker = new Warrior("WarriorName", 50, initialHP);
            Warrior warrior = new Warrior("WarriorName", 30, 100);
            
            attacker.Attack(warrior);

            Assert.AreEqual(initialHP - warrior.Damage, attacker.HP);

        }

        [Test]
        public void Attack_Should_SetPassedWarriorHPtoZero_When_AttackerDamageIsBiggerThanPassedWarrirorHp()
        {
            Warrior attacker = new Warrior("WarriorName", 50, 100);
            Warrior warrior = new Warrior("WarriorName", 30, 40);
            int expectedHP = 0;

            attacker.Attack(warrior);

            Assert.AreEqual(expectedHP, warrior.HP);

        }

        [Test]
        public void Attack_Should_DecreasePassedWarriorHp_When_AttackerDamageIsBiggerThanPassedWarrirorHp()
        {
            int worriorInitalHp = 100;
            Warrior attacker = new Warrior("Attacker", 50, 100);
            Warrior warrior = new Warrior("Warrior", 30, worriorInitalHp);
           

            attacker.Attack(warrior);

            Assert.That(warrior.HP, Is.EqualTo(worriorInitalHp - attacker.Damage));

        }


    }
}