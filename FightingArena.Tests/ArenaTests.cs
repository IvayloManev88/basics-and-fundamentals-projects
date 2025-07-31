namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System.Collections.Generic;
    using System;

    [TestFixture]
    public class ArenaTests
    {
        private Arena arena;
        private Warrior warrior1;
        private Warrior warrior2;

        [SetUp]
        public void SetUp()
        {
            arena = new Arena();
            warrior1 = new Warrior("Thor", 50, 100);
            warrior2 = new Warrior("Loki", 40, 80);
        }

        [Test]
        public void Arena_Constructor_ShouldInitializeEmptyList()
        {
            Assert.IsNotNull(arena.Warriors);
            Assert.AreEqual(0, arena.Count);
        }

        [Test]
        public void Enroll_ShouldAddWarriorToList()
        {
            arena.Enroll(warrior1);
            Assert.AreEqual(1, arena.Count);
            Assert.That(arena.Warriors, Does.Contain(warrior1));
        }

        [Test]
        public void Enroll_SameNameWarrior_ShouldThrowException()
        {
            arena.Enroll(warrior1);
            var duplicate = new Warrior("Thor", 45, 90);

            var ex = Assert.Throws<InvalidOperationException>(() => arena.Enroll(duplicate));
            Assert.AreEqual("Warrior is already enrolled for the fights!", ex.Message);
        }

        [Test]
        public void Fight_NonExistentAttacker_ShouldThrowException()
        {
            arena.Enroll(warrior2); // only defender enrolled

            var ex = Assert.Throws<InvalidOperationException>(() => arena.Fight("Thor", "Loki"));
            Assert.AreEqual("There is no fighter with name Thor enrolled for the fights!", ex.Message);
        }

        [Test]
        public void Fight_NonExistentDefender_ShouldThrowException()
        {
            arena.Enroll(warrior1); // only attacker enrolled

            var ex = Assert.Throws<InvalidOperationException>(() => arena.Fight("Thor", "Loki"));
            Assert.AreEqual("There is no fighter with name Loki enrolled for the fights!", ex.Message);
        }

        [Test]
        public void Fight_BothExist_ShouldInvokeAttack()
        {
            arena.Enroll(warrior1);
            arena.Enroll(warrior2);

            int initialDefenderHP = warrior2.HP;
            int expectedHP = initialDefenderHP - warrior1.Damage;

            arena.Fight("Thor", "Loki");

            Assert.AreEqual(expectedHP, warrior2.HP);
        }

        [Test]
        public void Warriors_ShouldReturnReadOnlyCollection()
        {
            arena.Enroll(warrior1);
            Assert.IsInstanceOf<IReadOnlyCollection<Warrior>>(arena.Warriors);
        }

        [Test]
        public void Count_ShouldReturnCorrectNumber()
        {
            Assert.AreEqual(0, arena.Count);
            arena.Enroll(warrior1);
            Assert.AreEqual(1, arena.Count);
        }
    }
}
