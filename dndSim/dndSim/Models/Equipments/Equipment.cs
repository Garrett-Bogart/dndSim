using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dndSim.Models.Equipments
{
    public class Equipment
    {
        
        public String Name { get; set; }
        public String Description { get; set; }
        public int Type { get; set; }//0: simple melee, 1: simple range, 2: martial melee, 3: martial range, 4: magical melee, 5: magical range, 6: magical armour

        public Equipment(String Name, int Type, String Description)
        {
            this.Name = Name;
            this.Description = Description;
            this.Type = Type;
        }
        public Equipment(String Name, int Type): this(Name, Type, "") { }
        public Equipment(String Name) : this(Name, 0) { }

    }
}