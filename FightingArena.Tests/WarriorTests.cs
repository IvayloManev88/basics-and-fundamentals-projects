namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class WarriorTests
    {
        private Warrior attacker;
        private Warrior defender;

        [SetUp]
        public void SetUp()
        {
            attacker = new Warrior("Thor", 40, 100);
            defender = new Warrior("Loki", 30, 100);
        }

        // Constructor and property validation

        [TestCase("", 40, 100)]
        [TestCase(" ", 40, 100)]
        [TestCase(null, 40, 100)]
        public void Constructor_InvalidName_ShouldThrow(string name, int dmg, int hp)
        {
            var ex = Assert.Throws<ArgumentException>(() => new Warrior(name, dmg, hp));
            Assert.AreEqual("Name should not be empty or whitespace!", ex.Message);
        }

        [TestCase(0)]
        [TestCase(-5)]
        public void Constructor_NonPositiveDamage_ShouldThrow(int invalidDamage)
        {
            var ex = Assert.Throws<ArgumentException>(() => new Warrior("Ares", invalidDamage, 100));
            Assert.AreEqual("Damage value should be positive!", ex.Message);
        }

        [TestCase(-1)]
        [TestCase(-50)]
        public void Constructor_NegativeHP_ShouldThrow(int invalidHP)
        {
            var ex = Assert.Throws<ArgumentException>(() => new Warrior("Ares", 30, invalidHP));
            Assert.AreEqual("HP should not be negative!", ex.Message);
        }

        [Test]
        public void Constructor_ValidData_ShouldSetProperties()
        {
            var warrior = new Warrior("Ares", 50, 120);
            Assert.AreEqual("Ares", warrior.Name);
            Assert.AreEqual(50, warrior.Damage);
            Assert.AreEqual(120, warrior.HP);
        }

        // Attack method validation

        [Test]
        public void Attack_WithLowHP_ShouldThrow()
        {
            attacker = new Warrior("Weakling", 40, 30); // equal to MIN_ATTACK_HP

            var ex = Assert.Throws<InvalidOperationException>(() => attacker.Attack(defender));
            Assert.AreEqual("Your HP is too low in order to attack other warriors!", ex.Message);
        }

        [Test]
        public void Attack_EnemyWithLowHP_ShouldThrow()
        {
            defender = new Warrior("AlmostDead", 20, 30);

            var ex = Assert.Throws<InvalidOperationException>(() => attacker.Attack(defender));
            Assert.AreEqual("Enemy HP must be greater than 30 in order to attack him!", ex.Message);
        }

        [Test]
        public void Attack_EnemyTooStrong_ShouldThrow()
        {
            defender = new Warrior("StrongGuy", 120, 100); // damage > attacker's HP

            var ex = Assert.Throws<InvalidOperationException>(() => attacker.Attack(defender));
            Assert.AreEqual("You are trying to attack too strong enemy", ex.Message);
        }

        [Test]
        public void Attack_EnemyHPGreaterThan30_AndDamageExceedsEnemyHP_ShouldSetEnemyHPToZero()
        {
            defender = new Warrior("WeakGuy", 10, 35); // HP > 30
            attacker = new Warrior("StrongGuy", 40, 100); // Damage > defender.HP

            attacker.Attack(defender);

            Assert.AreEqual(0, defender.HP);
        }

        [Test]
        public void Attack_ShouldDecreaseAttackerHP_ByEnemyDamage()
        {
            int expectedHP = attacker.HP - defender.Damage;

            attacker.Attack(defender);

            Assert.AreEqual(expectedHP, attacker.HP);
        }

        [Test]
        public void Attack_ShouldReduceDefenderHP_ByAttackerDamage()
        {
            int expectedHP = defender.HP - attacker.Damage;

            attacker.Attack(defender);

            Assert.AreEqual(expectedHP, defender.HP);
        }
    }
}