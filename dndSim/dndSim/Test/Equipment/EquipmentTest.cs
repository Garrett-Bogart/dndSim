using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NUnit.Framework;

namespace dndSim.Test.Equipment
{
    [TestFixture]
    public class EquipmentTest
    {
        public void validateEquipment(String name, String desc, int type, Models.Equipments.Equipment e)
        {
            Assert.AreEqual(name, e.Name);
            Assert.AreEqual(desc, e.Description);
            Assert.AreEqual(type, e.Type);
        }
        [Test]
        public void EquipmentConstructor()
        {
            Models.Equipments.Equipment e = new Models.Equipments.Equipment("ax");
            validateEquipment("ax", "", 0, e);
            e = new Models.Equipments.Equipment("ax", 1);
            validateEquipment("ax", "", 1, e);
            e = new Models.Equipments.Equipment("ax", 1, "asdf");
            validateEquipment("ax", "asdf", 1, e);
            e.Description = "aaaaa";
            e.Name = "bbbb";
            e.Type = 4;
            validateEquipment("bbbb", "aaaaa", 4, e);
        }
    }
}