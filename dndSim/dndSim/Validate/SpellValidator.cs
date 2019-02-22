using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using dndSim.Models.Spells;
namespace dndSim.Validate
{
    static public class SpellValidator
    {
        private const int MAXLEVEL = 9;
        private const int LOWESTLEVEL = 0;

        public static bool validateSpell(Spell spell)
        {
            bool valid = true;
            if (spell.Level < LOWESTLEVEL || spell.Level > MAXLEVEL)
                valid = false;
            if (spell.Name.Length == 0)
                valid = false;
            if (spell.Range < 0)
                valid = false;
            if (spell.CastTime.Length == 0)
                valid = false;
            if (spell.Concentration.Length == 0)
                valid = false;

            return valid;
        }

        public static bool validateSpell(String name, int level, int range, String action, String concentration)
        {
            bool valid = true;
            if (level < LOWESTLEVEL || level > MAXLEVEL)
                valid = false;
            if (name.Length == 0)
                valid = false;
            if (range < 0)
                valid = false;
            if (action.Length == 0)
                valid = false;
            if (concentration.Length == 0)
                valid = false;

            return valid;
        }
    }


}