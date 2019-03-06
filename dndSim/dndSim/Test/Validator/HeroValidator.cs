using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NUnit.Framework;
using dndSim.Validate;
namespace dndSim.Test.Validator
{
    [TestFixture]
    public class HeroValidator
    {
        private ValidateCharacter vc = new ValidateCharacter();
        private ValidateHero vh = new ValidateHero();

        [Test]
        public void validateProficiencyEquation()
        {
            int level = 1;
            int proficiency = ((level - 1) / 4) + 2;
            Assert.AreEqual(2, proficiency);
            level=2;
            proficiency = ((level - 1) / 4) + 2;
            Assert.AreEqual(2, proficiency);
            level=3;
            proficiency = ((level - 1) / 4) + 2;
            Assert.AreEqual(2, proficiency);
            level=4;
            proficiency = ((level - 1) / 4) + 2;
            Assert.AreEqual(2, proficiency);


            level=5;
            proficiency = ((level - 1) / 4) + 2;
            Assert.AreEqual(3, proficiency);
            level=6;
            proficiency = ((level - 1) / 4) + 2;
            Assert.AreEqual(3, proficiency);
            level=7;
            proficiency = ((level - 1) / 4) + 2;
            Assert.AreEqual(3, proficiency);
            level=8;
            proficiency = ((level - 1) / 4) + 2;
            Assert.AreEqual(3, proficiency);

            level = 9;
            proficiency = ((level - 1) / 4) + 2;
            Assert.AreEqual(4, proficiency);
            level = 10;
            proficiency = ((level - 1) / 4) + 2;
            Assert.AreEqual(4, proficiency);
            level = 11;
            proficiency = ((level - 1) / 4) + 2;
            Assert.AreEqual(4, proficiency);
            level = 12;
            proficiency = ((level - 1) / 4) + 2;
            Assert.AreEqual(4, proficiency);

            level = 13;
            proficiency = ((level - 1) / 4) + 2;
            Assert.AreEqual(5, proficiency);
            level = 14;
            proficiency = ((level - 1) / 4) + 2;
            Assert.AreEqual(5, proficiency);
            level = 15;
            proficiency = ((level - 1) / 4) + 2;
            Assert.AreEqual(5, proficiency);
            level = 16;
            proficiency = ((level - 1) / 4) + 2;
            Assert.AreEqual(5, proficiency);

            level = 17;
            proficiency = ((level - 1) / 4) + 2;
            Assert.AreEqual(6, proficiency);
            level = 18;
            proficiency = ((level - 1) / 4) + 2;
            Assert.AreEqual(6, proficiency);
            level = 19;
            proficiency = ((level - 1) / 4) + 2;
            Assert.AreEqual(6, proficiency);
            level = 20;
            proficiency = ((level - 1) / 4) + 2;
            Assert.AreEqual(6, proficiency);

        }

        [Test]
        public void validateProficiencyTest()
        {
            /*levels: 1-4 proficiency should be 2*/
            Assert.AreEqual("", vh.validateProficiency(1, 2));
            Assert.AreEqual("", vh.validateProficiency(4, 2));
            Assert.AreNotEqual("", vh.validateProficiency(1, 1));
            Assert.AreNotEqual("", vh.validateProficiency(1, 3));
            Assert.AreNotEqual("", vh.validateProficiency(4, 1));
            Assert.AreNotEqual("", vh.validateProficiency(4, 3));

            /*levels: 5-8 proficiency should be 3*/
            Assert.AreEqual("", vh.validateProficiency(5, 3));
            Assert.AreEqual("", vh.validateProficiency(8, 3));
            Assert.AreNotEqual("", vh.validateProficiency(5, 2));
            Assert.AreNotEqual("", vh.validateProficiency(5, 5));
            Assert.AreNotEqual("", vh.validateProficiency(8, 2));
            Assert.AreNotEqual("", vh.validateProficiency(8, 5));

            /*levels: 9-12 proficiency should be 4*/
            Assert.AreEqual("", vh.validateProficiency(9, 4));
            Assert.AreEqual("", vh.validateProficiency(12, 4));
            Assert.AreNotEqual("", vh.validateProficiency(9, 3));
            Assert.AreNotEqual("", vh.validateProficiency(9, 5));
            Assert.AreNotEqual("", vh.validateProficiency(12, 3));
            Assert.AreNotEqual("", vh.validateProficiency(12, 5));

            /*levels: 13-16 proficiency should be 5*/
            Assert.AreEqual("", vh.validateProficiency(13, 5));
            Assert.AreEqual("", vh.validateProficiency(16, 5));
            Assert.AreNotEqual("", vh.validateProficiency(13, 4));
            Assert.AreNotEqual("", vh.validateProficiency(13, 6));
            Assert.AreNotEqual("", vh.validateProficiency(16, 4));
            Assert.AreNotEqual("", vh.validateProficiency(16, 6));

            /*levels: 17-20 proficiency should be 6*/
            Assert.AreEqual("", vh.validateProficiency(17, 6));
            Assert.AreEqual("", vh.validateProficiency(20, 6));
            Assert.AreNotEqual("", vh.validateProficiency(17, 5));
            Assert.AreNotEqual("", vh.validateProficiency(17, 7));
            Assert.AreNotEqual("", vh.validateProficiency(20, 5));
            Assert.AreNotEqual("", vh.validateProficiency(20, 7));
        }
    }
}