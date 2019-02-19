using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dndSim.Models.Spells
{
    public abstract class Spells
    {
        public List<Spell> allSpells { get; set; }
        public List<Spell> memorized { get; set; }
        public List<Spell> rituals { get; set; }

        public Spells()
        {
            allSpells = new List<Spell>();
            memorized = new List<Spell>();
            rituals = new List<Spell>();
        }

    }
}