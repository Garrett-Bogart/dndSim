using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dndSim.Models.Spells
{
    public class Spell
    {
        public String name { get; set; }
        public int range { get; set; }
        public int level { get; set; }
        public String longDesc { get; set; }
        public String castTime { get; set; }
        public String concentration { get; set; }

        public Spell(String name, int level, int range,String castTime, String concentration, String desc )
        {
            this.name = name;
            this.level = level;
            this.range = range;
            this.castTime = castTime;
            this.concentration = concentration;
            longDesc = desc;
        }

        public String getShortDesc()
        {
            return name + " Range: "+ range + " Level: " + level + " castTime"+ castTime+ " concentration: "+ concentration +"\n";
        }
    }
}