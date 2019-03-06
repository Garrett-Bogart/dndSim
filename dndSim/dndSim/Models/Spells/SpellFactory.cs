using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dndSim.Models.Spells
{
    //make into a singleton eventually
    public static class SpellFactory
    {
        static readonly List<Spell> Spells = makeSpells();
        static bool done = false;

        private static List<Spell> makeSpells()
        {
            List<Spell> spells = new List<Spell>();
            //Spells.Add(new Spell("Speak with Animals", 1, 0, "Action", "10 minutes", "")); if the spells are alphabetized then characters can get spells in linear time
            spells.Add(new Spell("Beast Sense", 2, 5, "Action", "Conc. Up to 1 hour", "A willing beast becomes your eyes and ears while the spell lasts. You can no longer perceive your own senses, becoming blind and deaf, but your perception through the beast includes any special senses the beast may have. You may end the spell early using your action to regain your own senses."));
            spells.Add(new Spell("Commune With Nature", 1, 0, "Action", "Instantaneous", "You briefly become one with nature and gain knowledge of the surrounding territory. In the outdoors, the spell gives you knowledge of the land within 3 miles of you. In caves and other natural underground settings, the radius is limited to 300 feet. The spell doesn’t function where nature has been replaced by construction, such as in dungeons and towns.You instantly gain knowledge of up to three facts of your choice about any of the following subjects as they relate to the area:\nterrain and bodies of water\nprevalent plants, minerals, animals, or peoples\npowerful celestials, fey, fiends, elementals, or undead\ninfluence from other planes of existence\nbuildings\nFor example, you could determine the location of powerful undead in the area, the location of major sources of safe drinking water, and the location of any nearby towns."));
            spells.Add(new Spell("Speak with Animals", 1, 0, "Action", "10 minutes", "Although limited by the intelligence of the beast, you can understand and speak with beasts. You learn about the beast's experiences over the last day, as well as local places and creatures. If your DM allows, the beast may also complete a small task for you, if you can successfully convince it to do so."));

            return spells;
        }
        public static List<Spell> getSpells()
        {
            return Spells;
        }

        public static void addSpell(String name, int level, int range, String castTime, String concentration, String desc)
        {
            Spells.Add(new Spell(name, level, range, castTime, concentration, desc));
        }
    }
}