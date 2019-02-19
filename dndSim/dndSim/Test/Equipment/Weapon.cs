using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NUnit.Framework;
namespace dndSim.Test.Equipment
{
    [TestFixture]
    public class Weapon
    {
        public void validateWeapon(String name, int Type,int HitDie, int MinRange, int MaxRange, String desc, List<String> Traits, Models.Equipments.Weapon a)
        {
            Assert.AreEqual(name, a.Name);
            Assert.AreEqual(Type, a.Type);
            Assert.AreEqual(desc, a.Description);
            Assert.AreEqual(MinRange, a.MinRange);
            Assert.AreEqual(MaxRange, a.MaxRange);
            Assert.AreEqual(HitDie, a.HitDie);
            Assert.AreEqual(Traits.Count, a.Traits.Count);
            for(int i = 0; i < a.Traits.Count; i++)
            {
                Assert.AreEqual(Traits[i], a.Traits[i]);
            }
        }
        [Test]
        public void WeaponConstructor()
        {
            Models.Equipments.Weapon a = new Models.Equipments.Weapon("HandAx", 2, 6,5);
            validateWeapon("HandAx",2, 6, 5, 5, "",new List<string>() {"" }, a);

            a = new Models.Equipments.Weapon("HandAx", 2, 6, 5,10);
            validateWeapon("HandAx", 2, 6, 5, 10, "", new List<string>() { "" }, a);

            a = new Models.Equipments.Weapon("HandAx", 2, 6, 5, 10,"aaaa");
            validateWeapon("HandAx", 2, 6, 5, 10, "aaaa", new List<string>() { "" }, a);

            a = new Models.Equipments.Weapon("HandAx", 2, 6, 5, 10, "aaaa","Light, Versitle");
            validateWeapon("HandAx", 2, 6, 5, 10, "aaaa", new List<string>() { "Light"," Versitle" }, a);

            a = new Models.Equipments.Weapon("HandAx", 2, 6, 5, 10, "aaaa", new List<string>() { "Light", " Versitle" });
            validateWeapon("HandAx", 2, 6, 5, 10, "aaaa", new List<string>() { "Light", " Versitle" }, a);

            a.HitDie = 7;
            a.MinRange = 8;
            a.MaxRange = 100;
            a.Traits = new List<string>() { "Light", " Versitle", "Heavy" };
            validateWeapon("HandAx", 2, 7, 8, 100, "aaaa", new List<string>() { "Light", " Versitle", "Heavy" }, a);
        }

        [Test]
        public void InvalidWeaponConstructor()
        {
            var ex = Assert.Throws<ArgumentException>(() => new Models.Equipments.Weapon("HandAx", 2, 6, 5, 4));
            Assert.AreEqual("Weapon: MinRange has to be less than MaxRange", ex.Message);

            ex = Assert.Throws<ArgumentException>(() => new Models.Equipments.Weapon("HandAx", 2, 6, 5, 4, "aaaa", new List<string>() { "Light", " Versitle" }));
            Assert.AreEqual("Weapon: MinRange has to be less than MaxRange", ex.Message);
        }
    }
}