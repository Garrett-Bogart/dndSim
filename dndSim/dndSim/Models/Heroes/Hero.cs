using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using dndSim.Models.Equipments;
namespace dndSim.Models.Heroes
{
    public abstract class Hero : Characters
    {
        
        protected int level;
        protected int tempHp;
        public int Proficiency { get; set; } = 2;
        public bool StrSave { get; set; }
        public bool DexSave { get; set; } = false;
        public bool ConSave { get; set; } = false;
        public bool WisSave { get; set; } = false;
        public bool IntSave { get; set; } = false;
        public bool CharSave { get; set; } = false;
        public Spells.Spells spells {get;set;}
        public List<int> ItemProficiencies { get; set; }
        public List<Equipment> inventory;
        public List<Equipment> equipedItems;

        public Hero() : base()
        {
            Random rand = new Random();
            level = rand.Next() % 20 + 1;
            tempHp = 0;
            Proficiency = ((level - 1) / 4) + 2;
            spells = new Spells.ClassSpells.NoSpells();
            ItemProficiencies = new List<int>();
            inventory = new List<Equipment>();
            inventory = new List<Equipment>();
        }

        public int Level
        {
            get { return level; }
            set
            {
                if (value < 1 || value > 20)
                    throw new ArgumentException("Heroes: level must be between 1-20");
                level = value;
                Proficiency = 0;
            }
        }

        public int TempHp
        {
            get { return tempHp; }
            set
            {
                if (value < 1)
                    value = 0;
                if (value > tempHp)
                    tempHp = value;
            }
        }

        public bool equipItem(String name)
        {
            bool equiped = false;

            foreach(Equipment e in inventory)
            {
                if(e.Name == name)
                {
                    equipedItems.Add(e);
                    equiped = true;
                }
            }

            return equiped;
        }

        public bool dequipItem(String name)
        {
            bool dequip = false;

            foreach(Equipment e in equipedItems)
            {
                if(e.Name == name)
                {
                    equipedItems.Remove(e);
                    dequip = true;
                }
            }
            return dequip;
        }

        public bool removeItemFromInventory(String name)
        {
            bool dequip = false;

            foreach (Equipment e in inventory)
            {
                if (e.Name == name)
                {
                    inventory.Remove(e);
                    dequipItem(name);
                    dequip = true;
                }
            }
            return dequip;
        }
        public abstract String getSkills();
  
    }
}