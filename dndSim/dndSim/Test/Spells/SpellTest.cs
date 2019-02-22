using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NUnit.Framework;
using dndSim.Validate;

namespace dndSim.Test.Spells
{
    [TestFixture]
    public class SpellTest
    {
        public void validateSpell(String name, int level, int range, String castTime, String concentration, String desc, Models.Spells.Spell s )
        {
            Assert.IsTrue(SpellValidator.validateSpell(s));
            Assert.AreEqual(name, s.Name);
            Assert.AreEqual(level, s.Level);
            Assert.AreEqual(range, s.Range);
            Assert.AreEqual(castTime, s.CastTime);
            Assert.AreEqual(desc, s.LongDesc);
            Assert.AreEqual(concentration, s.Concentration);
        }

        [Test]
        public void SpellConstructorTest()
        {
            Models.Spells.Spell s = new Models.Spells.Spell("aaa", 4, 50, "action", "1 hour", "all the death");
            validateSpell("aaa", 4, 50, "action", "1 hour", "all the death", s);
        }

        [Test]
        public void SpellSetterTest()
        {
            Models.Spells.Spell s = new Models.Spells.Spell("aaa", 4, 50, "action", "1 hour", "all the death");
            validateSpell("aaa", 4, 50, "action", "1 hour", "all the death", s);
            s.Name = "bbb";
            s.Level = 8;
            s.Range = 5;
            s.CastTime = "bonus action";
            s.Concentration = "none";
            s.LongDesc = "dsadasd";
            validateSpell("bbb", 8, 5, "bonus action", "none", "dsadasd", s);
        }
        [Test]
        public void InvalidSpellTest()
        {
            var ex = Assert.Throws<ArgumentException>(() => new Models.Spells.Spell("", 4, 50, "action", "1 hour", "all the death"));
            ex = Assert.Throws<ArgumentException>(() => new Models.Spells.Spell("aaa", 90, 50, "action", "1 hour", "all the death"));
            ex = Assert.Throws<ArgumentException>(() => new Models.Spells.Spell("aaa", -1, 50, "action", "1 hour", "all the death"));
            ex = Assert.Throws<ArgumentException>(() => new Models.Spells.Spell("aaa", 4, -1, "action", "1 hour", "all the death"));
            ex = Assert.Throws<ArgumentException>(() => new Models.Spells.Spell("aaa", 4, 50, "", "1 hour", "all the death"));
            ex = Assert.Throws<ArgumentException>(() => new Models.Spells.Spell("aaa", 4, 50, "action", "", "all the death"));

        }

        [Test]
        public void SpellDescriptionTest()
        {
            Models.Spells.Spell s = new Models.Spells.Spell("aaa", 4, 50, "action", "1 hour", "all the death");
            Assert.AreEqual("aaa Range: 50 Level: 4 castTime: action concentration: 1 hour\n", s.getShortDesc());
        }
    }
}