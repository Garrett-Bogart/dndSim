using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dndSim.Models.Equipments
{
    public class Weapon : Equipment
    {
        public int HitDie { get; set; }
        public List<String> Traits { get; set; }//weapons are varied so eventually ill need a way to determine what traits are available 
        public int MinRange { get; set; }
        public int MaxRange { get; set; }


        public Weapon(String Name, int Type, int HitDie, int MinRange, int MaxRange, String Description, List<String> Traits) : base(Name, Type, Description)
        {
            if (MinRange > MaxRange)
                throw new ArgumentException("Weapon: MinRange has to be less than MaxRange");
            this.Traits = new List<string>();
            this.HitDie = HitDie;
            this.MinRange = MinRange;
            this.MaxRange = MaxRange;
            this.Traits = Traits;
        }

        public Weapon(String Name, int Type, int HitDie, int MinRange, int MaxRange, String Description, String Traits) :base(Name, Type, Description)
        {
            if (MinRange > MaxRange)
                throw new ArgumentException("Weapon: MinRange has to be less than MaxRange");
            this.Traits = new List<string>();
            this.HitDie = HitDie;
            this.MinRange = MinRange;
            this.MaxRange = MaxRange;
            String[] words = Traits.Split(',');
            foreach(String s in words)
            {
                this.Traits.Add(s);
            }
        }

        public Weapon(String Name, int Type, int HitDie, int MinRange, int MaxRange, String Description) : this(Name, Type, HitDie, MinRange, MaxRange, Description, "") { }

        public Weapon(String Name, int Type, int HitDie, int MinRange, int MaxRange) : this(Name, Type, HitDie, MinRange, MaxRange,"") { }

        public Weapon(String Name, int Type, int HitDie, int MinRange) : this(Name, Type, HitDie, MinRange, MinRange) { }
    
    }
}