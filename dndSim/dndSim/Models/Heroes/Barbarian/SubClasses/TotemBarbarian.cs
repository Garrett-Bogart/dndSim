using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dndSim.Models.Heroes.Barbarians.SubClasses
{
    public class TotemBarbarian : PrimalPath
    {
        //need something for ritual casting 
        public int FirstTotem { get; set; }
        public int SecondTotem { get; set; }
        public bool RitualCasting { get; set; }
        public int ThirdTotem { get; set; }

        public TotemBarbarian(int level)
        {
            FirstTotem = level>= 3 ? Dice.customeDie(3, 1) : -1;
            SecondTotem = level >= 6 ? Dice.customeDie(3, 1) : -1;
            RitualCasting = level >= 10 ? true : false;
            ThirdTotem = level >= 14 ? Dice.customeDie(3, 1) : -1;
        }

        private String getFirstTotem()
        {
            String totem = "";
            if(FirstTotem == 1)
            {
                totem = "Bear Totem 1: ";
            }
            else if (FirstTotem == 2)
            {
                totem = "Eagle Totem 1: ";
            }
            else if (FirstTotem == 3)
            {
                totem = "Wolf Totem 1: ";
            }
            return totem;
        }

        private String getSecondTotem()
        {
            String totem = "";
            if (SecondTotem == 1)
            {
                totem = "Bear Totem 2: ";
            }
            else if (SecondTotem == 2)
            {
                totem = "Eagle Totem 2: ";
            }
            else if (SecondTotem == 3)
            {
                totem = "Wolf Totem 2: ";
            }
            return totem;
        }

        private String getThirdTotem()
        {
            String totem = "";
            if (ThirdTotem == 1)
            {
                totem = "Bear Totem 3: ";
            }
            else if (ThirdTotem == 2)
            {
                totem = "Eagle Totem 3: ";
            }
            else if (ThirdTotem == 3)
            {
                totem = "Wolf Totem 3: ";
            }
            return totem;
        }



        public override List<String> toString()
        {
            List<String> skills = new List<string>();
            skills.Add("-------- Totem Path --------");
            skills.Add(getFirstTotem());
            skills.Add(getSecondTotem());
            //ritual casting and spells
            skills.Add(getThirdTotem());
            return skills;
        }

    }
}