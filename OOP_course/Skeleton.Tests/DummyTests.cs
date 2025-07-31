using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
   
    public class DummyTests
    {
        private const int health = 100;
        private const int exprerience = 100;
        private Dummy dummy;
        private Axe axe;
        [SetUp]
        public void Setup()
        {
            axe = new Axe(100, 100);
            dummy = new Dummy(health, exprerience);

        }



        [Test]
        public void Test_DummyLoosesHealthIfAttacked()
        {
            axe.Attack(dummy);
            Assert.AreNotEqual(health, dummy.Health,"Health is not decreased after an attack");
        }

        [Test]
        public void Test_DeadDummyThrowsExceptionUponAttack()
        {
            axe.Attack(dummy);

            Assert.Throws<InvalidOperationException>(() =>  axe.Attack(dummy), "Dummy is dead.");
        }

        [Test]
        public void Test_DeadDummyCanGiveXP()
        {
            axe.Attack(dummy);
            int givenExperience = dummy.GiveExperience();

            Assert.AreEqual(exprerience, givenExperience, "Dummy does not give XP if dead");
        }

        [Test]
        public void Test_AliveDummyCannotGiveXP()
        {



            Assert.Throws<InvalidOperationException>(() => dummy.GiveExperience(), "Target is not dead.");
        }
    }
}