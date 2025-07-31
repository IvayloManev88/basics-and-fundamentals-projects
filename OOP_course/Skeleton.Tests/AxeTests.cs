using NUnit.Framework;
using System;
using System.Runtime.CompilerServices;

namespace Skeleton.Tests
{
   
    public class AxeTests
    {
        private int attack = 10;
        private int durability = 10;
        private  Axe axe;
        private Dummy dummy;
        [SetUp]
        public void Setup()
        {
            axe = new Axe(attack, durability);
            dummy = new Dummy(100, 100);
           
        }


        [Test]
        public void Test_WeaponUsesDurabilityAfterAttack()
        {
            axe.Attack(dummy);
            Assert.AreEqual(9,axe.DurabilityPoints);
            
        }
        [Test]
        public void Test_AttackingWithBrokenWeapon()
        { 
            for (int i = 0; i < durability; i++)
            {
                axe.Attack(dummy);
            }
            
            Assert.Throws<InvalidOperationException>(() => axe.Attack(dummy), "Axe is broken.");
        }


        [Test]
        public void Test_WeaponUsesDurabilityAfterMultipleAttack()
        {
            for (int i = 0; i < 5; i++)
            {
                axe.Attack(dummy);
            }

            Assert.AreEqual(5, axe.DurabilityPoints);
        }

        [Test]
        public void Test_AttackIsSet()
        {
            Assert.AreEqual(attack, axe.AttackPoints, "Attack is not set");
        }
        [Test]
        public void Test_DurabilityIsSet()
        {
            Assert.AreEqual(durability, axe.DurabilityPoints, "Durability is not set");
        }

    }
}