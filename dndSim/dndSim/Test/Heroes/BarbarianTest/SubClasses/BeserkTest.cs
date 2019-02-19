using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using dndSim.Models.Heroes.Barbarians.SubClasses;
using NUnit.Framework;
namespace dndSim.Test.Heroes.BarbarianTest.SubClasses
{
    [TestFixture]
    public class BeserkTest
    {
        public String makeBarb(int level)
        {
            String test = "";
            BeserkBarbarian b = new BeserkBarbarian(level);
            if(b.Frenzy)
            {
                test += "frenzy\n";
            }
            if(b.MindlessRage)
            {
                test += "mindless\n";
            }
            if(b.IntimidatingPresence)
            {
                test += "intimidating\n";
            }
            if(b.Retaliation)
            {
                test += "retaliation\n";
            }
            return test;
        }

        [Test]
        public void ConstructorTest()
        {
            Assert.AreEqual("", makeBarb(1));
            Assert.AreEqual("", makeBarb(2));
            Assert.AreEqual("frenzy\n", makeBarb(3));
            Assert.AreEqual("frenzy\n", makeBarb(5));
            Assert.AreEqual("frenzy\nmindless\n", makeBarb(6));
            Assert.AreEqual("frenzy\nmindless\n", makeBarb(9));
            Assert.AreEqual("frenzy\nmindless\nintimidating\n", makeBarb(10));
            Assert.AreEqual("frenzy\nmindless\nintimidating\n", makeBarb(12));
            Assert.AreEqual("frenzy\nmindless\nintimidating\nretaliation\n", makeBarb(14));

        }
        [Test]
        public void toStringTest()
        {
            for(int i = 1; i < 21; i++)
            {
                BeserkBarbarian b = new BeserkBarbarian(i);
                List<String> skills = b.toString();
                foreach (String s in skills)
                {
                    if(i < 3)
                    {
                        Assert.AreEqual("-------- Beserk Path --------", skills[0]);
                        Assert.AreEqual("", skills[1]);
                        Assert.AreEqual("", skills[2]);
                        Assert.AreEqual("", skills[3]);
                        Assert.AreEqual("", skills[4]);
                    }

                    if (i >= 3 && i < 6)
                    {
                        Assert.AreEqual("-------- Beserk Path --------", skills[0]);
                        Assert.AreEqual("Frenzy: \n", skills[1]);
                        Assert.AreEqual("", skills[2]);
                        Assert.AreEqual("", skills[3]);
                        Assert.AreEqual("", skills[4]);
                    }

                    if (i >= 6 && i < 10)
                    {
                        Assert.AreEqual("-------- Beserk Path --------", skills[0]);
                        Assert.AreEqual("Frenzy: \n", skills[1]);
                        Assert.AreEqual("Mindless Rage: \n", skills[2]);
                        Assert.AreEqual("", skills[3]);
                        Assert.AreEqual("", skills[4]);
                    }

                    if (i >= 10 && i <14)
                    {
                        Assert.AreEqual("-------- Beserk Path --------", skills[0]);
                        Assert.AreEqual("Frenzy: \n", skills[1]);
                        Assert.AreEqual("Mindless Rage: \n", skills[2]);
                        Assert.AreEqual("Intimidating Presence: \n", skills[3]);
                        Assert.AreEqual("", skills[4]);
                    }

                    if (i >= 14)
                    {
                        Assert.AreEqual("-------- Beserk Path --------", skills[0]);
                        Assert.AreEqual("Frenzy: \n", skills[1]);
                        Assert.AreEqual("Mindless Rage: \n", skills[2]);
                        Assert.AreEqual("Intimidating Presence: \n", skills[3]);
                        Assert.AreEqual("Retaliation: \n", skills[4]);
                    }
                }
            }
        }
    }
}