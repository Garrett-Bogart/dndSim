using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dndSim.Models.Equipments
{
    public class Armour : Equipment
    {
        public int AC { get; set; }
        public int DexLimit { get; set; }

        public Armour(String Name, int Type, int AC, int DexLimit, String Description) : base(Name, Type, Description)
        {
            this.AC = AC;
            this.DexLimit = DexLimit;
        }

        public Armour(String Name, int Type, int AC, int DexLimit) : this(Name, Type, AC, DexLimit, "") { }
        public Armour(String Name, int Type, int AC) : this(Name, Type, AC, 0) { }
    }
}