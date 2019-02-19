using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NUnit.Framework;
namespace dndSim.Test.Equipment
{
    [TestFixture]
    public class Armour
    {
        public void validateArmour(String name, int Type, String desc, int AC, int DexLimit, Models.Equipments.Armour a)
        {
            Assert.AreEqual(name, a.Name);
            Assert.AreEqual(Type, a.Type);
            Assert.AreEqual(desc, a.Description);
            Assert.AreEqual(AC, a.AC);
            Assert.AreEqual(DexLimit, a.DexLimit);
        }
        [Test]
        public void ArmourConstructor()
        {
            Models.Equipments.Armour a = new Models.Equipments.Armour("Leather", 2, 12);
            validateArmour("Leather", 2, "", 12, 0, a);
            a = new Models.Equipments.Armour("Leather", 2, 12,2);
            validateArmour("Leather", 2, "", 12, 2, a);
            a = new Models.Equipments.Armour("Leather", 2, 12, 2, "aaaa");
            validateArmour("Leather", 2, "aaaa", 12, 2, a);
            a.AC = 20;
            a.DexLimit = 20;
            validateArmour("Leather", 2, "aaaa", 20, 20, a);
        }
    }
}