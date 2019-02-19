using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NUnit.Framework;
using dndSim.Models.Heroes.Barbarians;
namespace dndSim.Test.Heroes
{
    [TestFixture]
    public class HeroTest
    {
        [Test]
        public void AttributeBonusTest()
        {
            Barbarian b = new Barbarian();
            int ExpectedAttributeBonus = -6;
            for(int i = 0; i < 31; i++)
            {
                if (i % 2 == 0)
                {
                    ExpectedAttributeBonus++;
                }
                int bonus = b.calculateAttributeBonus(i);
                Assert.AreEqual(ExpectedAttributeBonus, bonus);

            }

        }
    }
}