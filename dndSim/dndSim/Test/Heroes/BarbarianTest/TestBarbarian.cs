using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NUnit.Framework;
using dndSim.Validate;
using dndSim.Models.Heroes;
using dndSim.Models.Heroes.Barbarians;
using dndSim.Models.Heroes.Barbarians.SubClasses;

namespace dndSim.Test.Heroes
{
    [TestFixture]
    public class TestBarbarian
    {
        private ValidateCharacter validate = new ValidateCharacter();
        private ValidateHero vh = new ValidateHero();

        public String validateCharacter(Hero hero)
        {
            String correct = "";
            correct += validate.validateAttributesBarabarian("Strength", hero.Strength);
            correct += validate.validateAttributes("Dexterity", hero.Dexterity);
            correct += validate.validateAttributes("Wisdom", hero.Wisdom);
            correct += validate.validateAttributesBarabarian("Constitution", hero.Constitution);
            correct += validate.validateAttributes("Intelligence", hero.Intelligence);
            correct += validate.validateAttributes("Charisma", hero.Charisma);
            return correct;
        }

        /*Should also be in its own validation class*/
        public String validateHero(Hero hero, String validSave1, String validSave2)
        {
            String correct = "";
            correct += vh.validateSavingThrows(hero, validSave1, validSave2);
            correct += vh.validateNonproficientSavingThrows(hero, validSave1, validSave2);
            correct += vh.validateProficiency(hero.Level, hero.Proficiency);
            correct += hero.TempHp == 0 ? "" : "Temp Hp is greater than 0";
            correct += hero.Level > 0 && hero.Level < 21 ? "" : "Level is " + hero.Level;
            return correct;
        }

        public void validateLevel1(Barbarian barb)
        {
            Assert.IsTrue(barb.UnarmoredDefense);
        }

        public void validateLevel2(Barbarian barb)
        {
            if (barb.Level < 2)
            {
                Assert.IsFalse(barb.DangerSense);
                validateLevel1(barb);
                return;
            }
            Assert.IsTrue(barb.UnarmoredDefense);
            Assert.IsTrue(barb.RecklessAttack);
        }

        public void validateLevel3(Barbarian barb)
        {
            if (barb.Level < 3)
            {
                Assert.IsFalse(barb.PrimalPath);
                validateLevel2(barb);
                return;
            }
            Assert.IsTrue(barb.UnarmoredDefense);
            Assert.IsTrue(barb.RecklessAttack);
            Assert.IsTrue(barb.DangerSense);
            Assert.IsTrue(barb.PrimalPath);
        }

        public void validateLevel5(Barbarian barb)
        {
            if (barb.Level < 5)
            {
                Assert.IsFalse(barb.FastMovement);
                Assert.IsFalse(barb.ExtraAttack);
                validateLevel3(barb);
                return;
            }
            Assert.IsTrue(barb.UnarmoredDefense);
            Assert.IsTrue(barb.RecklessAttack);
            Assert.IsTrue(barb.DangerSense);
            Assert.IsTrue(barb.PrimalPath);
            Assert.IsTrue(barb.ExtraAttack);
            Assert.IsTrue(barb.FastMovement);
        }

        public void validateLevel7(Barbarian barb)
        {
            if (barb.Level < 7)
            {
                Assert.IsFalse(barb.FeralInstinct);
                validateLevel5(barb);
                return;
            }
            Assert.IsTrue(barb.UnarmoredDefense);
            Assert.IsTrue(barb.RecklessAttack);
            Assert.IsTrue(barb.DangerSense);
            Assert.IsTrue(barb.PrimalPath);
            Assert.IsTrue(barb.ExtraAttack);
            Assert.IsTrue(barb.FastMovement);
            Assert.IsTrue(barb.FeralInstinct);
        }

        public void validateLevel9(Barbarian barb)
        {
            if (barb.Level < 9)
            {
                Assert.IsFalse(barb.BrutalCritical);
                validateLevel7(barb);
                return;
            }
            Assert.IsTrue(barb.UnarmoredDefense);
            Assert.IsTrue(barb.RecklessAttack);
            Assert.IsTrue(barb.DangerSense);
            Assert.IsTrue(barb.PrimalPath);
            Assert.IsTrue(barb.ExtraAttack);
            Assert.IsTrue(barb.FastMovement);
            Assert.IsTrue(barb.FeralInstinct);
            Assert.IsTrue(barb.BrutalCritical);
        }

        public void validateLevel11(Barbarian barb)
        {
            if (barb.Level < 11)
            {
                Assert.IsFalse(barb.RelentlessRage);
                validateLevel9(barb);
                return;
            }
            Assert.IsTrue(barb.UnarmoredDefense);
            Assert.IsTrue(barb.RecklessAttack);
            Assert.IsTrue(barb.DangerSense);
            Assert.IsTrue(barb.PrimalPath);
            Assert.IsTrue(barb.ExtraAttack);
            Assert.IsTrue(barb.FastMovement);
            Assert.IsTrue(barb.FeralInstinct);
            Assert.IsTrue(barb.BrutalCritical);
            Assert.IsTrue(barb.RelentlessRage);
        }

        public void validateLevel13(Barbarian barb)
        {
            if (barb.Level < 13)
            {
                Assert.IsFalse(barb.ImprovedBrutalCritcal);
                validateLevel11(barb);
                return;
            }
            Assert.IsTrue(barb.UnarmoredDefense);
            Assert.IsTrue(barb.RecklessAttack);
            Assert.IsTrue(barb.DangerSense);
            Assert.IsTrue(barb.PrimalPath);
            Assert.IsTrue(barb.ExtraAttack);
            Assert.IsTrue(barb.FastMovement);
            Assert.IsTrue(barb.FeralInstinct);
            Assert.IsTrue(barb.BrutalCritical);
            Assert.IsTrue(barb.RelentlessRage);
            Assert.IsTrue(barb.ImprovedBrutalCritcal);
        }

        public void validateLevel15(Barbarian barb)
        {
            if (barb.Level < 15)
            {
                Assert.IsFalse(barb.PersistantRage);
                validateLevel13(barb);
                return;
            }
            Assert.IsTrue(barb.UnarmoredDefense);
            Assert.IsTrue(barb.RecklessAttack);
            Assert.IsTrue(barb.DangerSense);
            Assert.IsTrue(barb.PrimalPath);
            Assert.IsTrue(barb.ExtraAttack);
            Assert.IsTrue(barb.FastMovement);
            Assert.IsTrue(barb.FeralInstinct);
            Assert.IsTrue(barb.BrutalCritical);
            Assert.IsTrue(barb.RelentlessRage);
            Assert.IsTrue(barb.ImprovedBrutalCritcal);
            Assert.IsTrue(barb.PersistantRage);
        }

        public void validateLevel17(Barbarian barb)
        {
            if(barb.Level < 17)
            {
                Assert.IsFalse(barb.MasterBrutalCritcal);
                validateLevel15(barb);
                return;
            }
            Assert.IsTrue(barb.UnarmoredDefense);
            Assert.IsTrue(barb.RecklessAttack);
            Assert.IsTrue(barb.DangerSense);
            Assert.IsTrue(barb.PrimalPath);
            Assert.IsTrue(barb.ExtraAttack);
            Assert.IsTrue(barb.FastMovement);
            Assert.IsTrue(barb.FeralInstinct);
            Assert.IsTrue(barb.BrutalCritical);
            Assert.IsTrue(barb.RelentlessRage);
            Assert.IsTrue(barb.ImprovedBrutalCritcal);
            Assert.IsTrue(barb.PersistantRage);
            Assert.IsTrue(barb.MasterBrutalCritcal);
        }

        public void validateLevel18(Barbarian barb)
        {
            if(barb.Level < 18)
            {
                Assert.IsFalse(barb.IndomitableMight);
                validateLevel17(barb);
                return;
            }
            Assert.IsTrue(barb.UnarmoredDefense);
            Assert.IsTrue(barb.RecklessAttack);
            Assert.IsTrue(barb.DangerSense);
            Assert.IsTrue(barb.PrimalPath);
            Assert.IsTrue(barb.ExtraAttack);
            Assert.IsTrue(barb.FastMovement);
            Assert.IsTrue(barb.FeralInstinct);
            Assert.IsTrue(barb.BrutalCritical);
            Assert.IsTrue(barb.RelentlessRage);
            Assert.IsTrue(barb.ImprovedBrutalCritcal);
            Assert.IsTrue(barb.PersistantRage);
            Assert.IsTrue(barb.MasterBrutalCritcal);
            Assert.IsTrue(barb.IndomitableMight);
        }
 
        public void validateLevel20(Barbarian barb)
        {
            if(barb.Level < 20)
            {
                Assert.IsFalse(barb.PrimalChampion);
                validateLevel18(barb);
                return;
            }
            Assert.IsTrue(barb.UnarmoredDefense);
            Assert.IsTrue(barb.RecklessAttack);
            Assert.IsTrue(barb.DangerSense);
            Assert.IsTrue(barb.PrimalPath);
            Assert.IsTrue(barb.ExtraAttack);
            Assert.IsTrue(barb.FastMovement);
            Assert.IsTrue(barb.FeralInstinct);
            Assert.IsTrue(barb.BrutalCritical);
            Assert.IsTrue(barb.RelentlessRage);
            Assert.IsTrue(barb.ImprovedBrutalCritcal);
            Assert.IsTrue(barb.PersistantRage);
            Assert.IsTrue(barb.MasterBrutalCritcal);
            Assert.IsTrue(barb.IndomitableMight);
            Assert.IsTrue(barb.PrimalChampion);
        }


        /*Should be in its own test file*/
        [Test]
        public void validateValidateAttributes()
        {
            Assert.AreNotEqual("", validate.validateAttributes("test", 21));
            Assert.AreNotEqual("", validate.validateAttributes("test", -1));

            Assert.AreEqual("", validate.validateAttributes("test", 20));
            Assert.AreEqual("", validate.validateAttributes("test", 3));
        }

        [Test]
        public void BarbarianConstructorTest()
        {
            var barb = new Barbarian();
            for(int i = 0; i < 100000; i++)
            {
                barb = new Barbarian();
                Assert.AreEqual("", validateCharacter(barb));
                Assert.AreEqual("", validateHero(barb,"StrSave", "ConSave"));
                validateLevel20(barb);
            }
        }

        [Test]
        public void BarbarianSubclassTest()
        {
            List<PrimalPath> paths = new List<PrimalPath>() {new BeserkBarbarian(1), new TotemBarbarian(1) };
            for(int i = 1; i < 1000; i++)
            {
                Barbarian b = new Barbarian();
                if(b.Level < 3)
                {
                    Assert.IsInstanceOf<EmptyBarbarian>(b.primalPath);
                }
                else if(b.Level >= 3)
                {
                    bool isType = false;
                    foreach(PrimalPath p in paths)
                    {
                        if(b.primalPath.GetType() == p.GetType() )
                        {
                            isType = true;
                        }
                    }
                    Assert.IsTrue(isType);
                }
            }
        }

        [Test]
        public void calculateHealthTest()
        {
            Barbarian b = new Barbarian();
            int conBonus = b.calculateAttributeBonus(b.Constitution);
            int[] range= {12+conBonus,22 };
            bool inRange = false;
            for(int i = 1; i < 21; i ++)
            {           
                inRange = false;
                b.Level = i;
                int currentHealth = b.calculateHealth();
                Assert.AreEqual(i, b.Level);
                if(currentHealth >= range[0] && currentHealth <= range[1])
                {
                    inRange = true;
                    range[0] = range[0]+1+conBonus;
                    range[1] = range[1] + 12+conBonus;
                }
                Assert.IsTrue(inRange);
            }
        }

        [Test]
        public void calculateRagesTest()
        {
            Barbarian b = new Barbarian();
            int rages = 2;
            for(int i = 1; i < 21; i++)
            {
                b.Level = i;
                int expected = b.calculateRages();
                if (i == 3 || i == 6 || i == 12 || i == 16 || i == 20)
                {
                    rages++;
                }
                if (b.Level == 20)
                    rages = 1000;
                Assert.AreEqual(rages, b.calculateRages());

            }
        }

        [Test]
        public void getRageDamageTest()
        {
            Barbarian b = new Barbarian();
            int Expected = 2;
            for(int i = 1; i < 21; i++)
            {
                b.Level = i;
                if (b.Level == 9 || b.Level == 16)
                    Expected++;
                Assert.AreEqual(Expected, b.getRageDamage());
            }
        }
    }
}