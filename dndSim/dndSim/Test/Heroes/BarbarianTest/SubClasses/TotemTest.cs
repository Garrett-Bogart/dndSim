using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NUnit.Framework;
using dndSim.Models.Heroes.Barbarians.SubClasses;

namespace dndSim.Test.Heroes.BarbarianTest.SubClasses
{
    public class TotemTest
    {
        public void makeBarb(int level)
        {
            
            TotemBarbarian b = new TotemBarbarian(level);
            Assert.AreEqual("-------- Totem Path --------", b.toString()[0]);
            if(level < 3)
            {
                Assert.AreEqual("", b.toString()[1]);
            }
            else if (b.FirstTotem == 1)
            {
                Assert.AreEqual("Bear Totem 1: ", b.toString()[1]);
            }
            else if(b.FirstTotem == 2)
            {
                Assert.AreEqual("Eagle Totem 1: ", b.toString()[1]);
            }
            else if (b.FirstTotem == 3)
            {
                Assert.AreEqual("Wolf Totem 1: ", b.toString()[1]);
            }
            else if (b.ThirdTotem != -1)
            {
                Assert.Fail();
            }

            if(level < 6)
            {
                Assert.AreEqual("", b.toString()[2]);
            }
            else if (b.SecondTotem == 1)
            {
                Assert.AreEqual("Bear Totem 2: ", b.toString()[2]);
            }
            else if (b.SecondTotem == 2)
            {
                Assert.AreEqual("Eagle Totem 2: ", b.toString()[2]);
            }
            else if (b.SecondTotem == 3)
            {
                Assert.AreEqual("Wolf Totem 2: ", b.toString()[2]);
            }
            else if (b.ThirdTotem != -1)
            {
                Assert.Fail();
            }

            if(level < 14)
            {
                Assert.AreEqual("", b.toString()[3]);
            }
            else if (b.ThirdTotem == 1)
            {
                Assert.AreEqual("Bear Totem 3: ", b.toString()[3]);
            }
            else if (b.ThirdTotem == 2)
            {
                Assert.AreEqual("Eagle Totem 3: ", b.toString()[3]);
            }
            else if (b.ThirdTotem == 3)
            {
                Assert.AreEqual("Wolf Totem 3: ", b.toString()[3]);
            }
            else if(b.ThirdTotem != -1)
            {
                Assert.Fail();
            }
        }

        [Test]
        public void ConstructorTest()
        {
            for(int i = 1; i < 21; i++)
            {
                makeBarb(i);
            }

        }
        
    }
}