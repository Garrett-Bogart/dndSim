using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dndSim.Models.Spells
{
    public class Spell
    {

        public String Name { get; set; }
        public int Range { get; set; }
        public int Level { get; set; }
        public String LongDesc { get; set; }
        public String CastTime { get; set; }
        public String Concentration { get; set; }

        public Spell(String name, int level, int range,String castTime, String concentration, String desc )
        {
            if(!Validate.SpellValidator.validateSpell(name, level, range, castTime, concentration))
            {
                throw new ArgumentException("Spell: had an invalid argument: " + name);
            }
            this.Name = name;
            this.Level = level;
            this.Range = range;
            this.CastTime = castTime;
            this.Concentration = concentration;
            LongDesc = desc;
        }

        public String getShortDesc()
        {
            return Name + " Range: "+ Range + " Level: " + Level + " castTime: "+ CastTime+ " concentration: "+ Concentration +"\n";
        }
    }
}