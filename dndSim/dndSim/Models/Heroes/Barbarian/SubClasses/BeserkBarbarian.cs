using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dndSim.Models.Heroes.Barbarians.SubClasses
{
    public class BeserkBarbarian : PrimalPath 
    {
        public bool Frenzy { get; set; } = false;
        public bool MindlessRage { get; set; } = false;
        public bool IntimidatingPresence { get; set; } = false;
        public bool Retaliation { get; set; } = false;

        public BeserkBarbarian(int level)
        {
            Frenzy = level >= 3 ? true : false;
            MindlessRage = level >= 6 ? true : false;
            IntimidatingPresence = level >= 10 ? true : false;
            Retaliation = level >= 14 ? true : false;
        }

        public override List<String> toString()
        {
            List<String> skills = new List<string>();
            skills.Add("-------- Beserk Path --------");
            skills.Add(Frenzy ? "Frenzy: \n": "");
            skills.Add(MindlessRage ? "Mindless Rage: \n" : "");
            skills.Add(IntimidatingPresence ? "Intimidating Presence: \n" : "");
            skills.Add(Retaliation ? "Retaliation: \n" : "");

            return skills;
        }

    }
}