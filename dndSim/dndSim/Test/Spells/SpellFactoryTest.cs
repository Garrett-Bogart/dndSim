using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NUnit.Framework;
namespace dndSim.Test.Spells
{
    [TestFixture]
    public class SpellFactoryTest
    {

        [Test]
        public void SpellFactoryInitialTest()
        {
            Assert.AreEqual(3, Models.Spells.SpellFactory.getSpells().Count);
            Models.Spells.SpellFactory.addSpell("aaa", 4, 5, "action", "1 hour", "all the death");
            Assert.AreEqual(4, Models.Spells.SpellFactory.getSpells().Count);
        }
    }
}