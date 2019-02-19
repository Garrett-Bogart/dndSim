using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dndSim.Models
{
    public abstract class Characters
    {
        public enum ItemTypes { Simple_Melee, Simple_Range, Martial_Melee, Martial_Range, Magical_Melee, Magical_Range, Magical_Armour, Light_Armour, Medium_Armour, Heavy_Armour, Other };
        public virtual int Hp { get; set; }
        public virtual int Speed { get; set; }
        public virtual int Strength { get; set; }
        public virtual int Dexterity { get; set; }
        public virtual int Constitution { get; set; }
        public virtual int Wisdom { get; set; }
        public virtual int Intelligence { get; set; }
        public virtual int Charisma { get; set; }
        public virtual int AC { get; set; }

        public Characters()
        {
            Random rand = new Random();
            Hp = Dice.rollD100();
            Speed = Dice.rollD6() * 5;
            Strength = Dice.rollD6(3);
            Dexterity = Dice.rollD6(3);
            Constitution = Dice.rollD6(3);
            Wisdom = Dice.rollD6(3);
            Intelligence = Dice.rollD6(3);
            Charisma = Dice.rollD6(3);
            AC = Dice.rollD6(3);
        }

        public int calculateAttributeBonus(int att)
        {
            return att%2 == 0 ? (att-10)/2 : (att-11)/2;
        }
    }
}