using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dndSim.Models.Spells.ClassSpells
{
    public class BarbarianSpells : Spells
    {
        List<String> availableSpells;
        public BarbarianSpells()
        {
            availableSpells = new List<String>() { "Commune With Nature", "Beast Sense", "Speak with Animals" };         
            getSpells();
        }

        public void getSpells()
        {
            List<Spell> freshSpells = SpellFactory.getSpells();
            foreach(Spell s in freshSpells)//inefficient, tree, dicitonary, integers for spell number and organization?
            {
                foreach(String spell in availableSpells )
                {
                    if (s.name == spell)
                    {
                        allSpells.Add(s);
                        break;
                    }
                }
                
            }
        }
    }
}