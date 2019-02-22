using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using dndSim.Models.Heroes;
namespace dndSim.Validate
{
    public static class ValidateHero
    {
        public static String validateHero(Hero hero, String validSave1, String validSave2)
        {
            String correct = "";
            correct += validateSavingThrows(hero, validSave1, validSave2);
            correct += validateNonproficientSavingThrows(hero, validSave1, validSave2);
            correct += validateProficiency(hero.Level, hero.Proficiency);
            correct += hero.TempHp == 0 ? "" : "Temp Hp is greater than 0";
            correct += hero.Level > 0 && hero.Level < 21 ? "" : "Level is " + hero.Level;
            return correct;
        }

        public static String validateProficienctSavingThrows(Hero hero, String s1, String s2)
        {
            String correct = "";
            if (s1 == "StrSave" || s2 == "StrSave")
            {
                correct = hero.StrSave ? "" : "StrSave was should be proficient";
            }
            if (s1 == "DexSave" || s2 == "DexSave")
            {
                correct = hero.DexSave ? "" : "DexSave was should be proficient";
            }
            if (s1 == "ConSave" || s2 == "ConSave")
            {
                correct = hero.ConSave ? "" : "ConSave was should be proficient";
            }
            if (s1 == "WisSave" || s2 == "WisSave")
            {
                correct = hero.WisSave ? "" : "WisSave was should be proficient";
            }
            if (s1 == "IntSave" || s2 == "IntSave")
            {
                correct = hero.IntSave ? "" : "IntSave was should be proficient";
            }
            if (s1 == "CharSave" || s2 == "CharSave")
            {
                correct = hero.CharSave ? "" : "CharSave was should be proficient";
            }

            return correct;
        }

        public static String validateNonproficientSavingThrows(Hero hero, String s1, String s2)
        {
            String correct = "";
            if (s1 != "StrSave" && s2 != "StrSave")
            {
                correct = !hero.StrSave ? "" : "StrSave was should not be proficient";
            }
            if (s1 != "DexSave" && s2 != "DexSave")
            {
                correct = !hero.DexSave ? "" : "DexSave was should not be proficient";
            }
            if (s1 != "ConSave" && s2 != "ConSave")
            {
                correct = !hero.ConSave ? "" : "ConSave was should not be proficient";
            }
            if (s1 != "WisSave" && s2 != "WisSave")
            {
                correct = !hero.WisSave ? "" : "WisSave was should not be proficient";
            }
            if (s1 != "IntSave" && s2 != "IntSave")
            {
                correct = !hero.IntSave ? "" : "IntSave was should not be proficient";
            }
            if (s1 != "CharSave" && s2 != "CharSave")
            {
                correct = !hero.CharSave ? "" : "CharSave was should not be proficient";
            }

            return correct;

        }

        public static String validateSavingThrows(Hero hero, String s1, String s2)
        {
            String correct = validateProficienctSavingThrows(hero, s1, s2);

            return correct;
        }

        public static String validateProficiency(int level, int proficiency)
        {
            String valid = "";
            if (level <= 4 && proficiency != 2)
            {
                valid = "2: level: " + level + "proficiency: " + proficiency;
            }

            if (level > 4 && level <= 8 && proficiency != 3)
            {
                valid = "3: level: " + level + "proficiency: " + proficiency;
            }

            if (level > 8 && level <= 12 && proficiency != 4)
            {
                valid = "4: level: " + level + "proficiency: " + proficiency;
            }

            if (level > 12 && level <= 16 && proficiency != 5)
            {
                valid = "5: level: " + level + "proficiency: " + proficiency;
            }

            if (level > 16 && level <= 20 && proficiency != 6)
            {
                valid = "6: level: " + level + "  proficiency: " + proficiency;
            }
            return valid;
        }
    }
}