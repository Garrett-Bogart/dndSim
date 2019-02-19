using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace dndSim.Models.Heroes.Barbarians
{
    public class Barbarian : Hero
    {
        private int strength;
        public int Rages { get; set; }
        public bool UnarmoredDefense { get; set; }
        public bool RecklessAttack { get; set; }
        public bool DangerSense { get; set; }
        public SubClasses.PrimalPath primalPath { get; }
        public bool PrimalPath{ get; set; }
        public bool ExtraAttack { get; set; }
        public bool FastMovement { get; set; }
        public bool FeralInstinct { get; set; }
        public bool BrutalCritical { get; set; }
        public bool RelentlessRage { get; set; }
        public bool ImprovedBrutalCritcal { get; set; }
        public bool PersistantRage { get; set; }
        public bool MasterBrutalCritcal { get; set; }
        public bool IndomitableMight { get; set; }
        public bool PrimalChampion { get; set; }
        //Belongs to all classess so should be moved up to hero class
        public List<String> Skills { get; set; }

        public Barbarian() : base()
        {
            Skills = new List<string>();
            Rages = calculateRages();
            UnarmoredDefense = true;
            RecklessAttack = Level >= 2 ? true : false;
            DangerSense = Level >= 2 ? true : false;
            PrimalPath = Level >= 3 ? true : false;
            primalPath = Level >=3 ? getPrimalPath(Dice.rollD2()) : new SubClasses.EmptyBarbarian();
            ExtraAttack = Level >= 5 ? true : false;
            FastMovement = Level >= 5 ? true : false;
            FeralInstinct = Level >= 7 ? true : false;
            BrutalCritical = Level >= 9 ? true : false;
            RelentlessRage = Level >= 11 ? true : false;
            ImprovedBrutalCritcal = Level >= 13 ? true : false;
            PersistantRage = Level >= 15 ? true : false;
            MasterBrutalCritcal = Level >= 17 ? true : false;
            IndomitableMight = Level >= 18 ? true : false;
            PrimalChampion = Level == 20 ? true : false;

            getSkills();
            if(primalPath.GetType() == typeof(SubClasses.PrimalPath))
            {
                spells = new Spells.ClassSpells.BarbarianSpells();
            }
            else
            {
                spells = new Spells.ClassSpells.NoSpells();
            }
            Hp = calculateHealth();
            inventory.Add(new Equipments.Weapon("Handaxe", (int)ItemTypes.Simple_Melee, 6, 5));
            inventory.Add(new Equipments.Armour("Chain Mail", (int)ItemTypes.Medium_Armour, 13,2));
            StrSave = true;
            ConSave = true;
        }

        public SubClasses.PrimalPath getPrimalPath(int path)
        {
            SubClasses.PrimalPath newPath = new SubClasses.EmptyBarbarian();
            if(path == 1)
            {
                newPath = new SubClasses.BeserkBarbarian(this.Level);
            }
            else if(path == 2)
            {
                newPath = new SubClasses.TotemBarbarian(this.Level);
            }
            return newPath;
        }

        public int calculateRages()
        {
            int rages = 2;
            if (level <= 2)
                rages = 2;
            else if (Level >= 3 && Level < 6)
                rages = 3;
            else if (Level >= 6 && Level < 12)
                rages = 4;
            else if (Level >= 12 && Level < 16)
                rages = 5;
            else if (Level >= 16 && Level < 20)
                rages = 6;
            else if (Level >= 20)
                rages = 1000;
            return rages;
        }

        public int getRageDamage()
        {
            int damage = 2;
            if (Level >= 1 && Level < 8)
                damage = 2;
            else if (Level >= 9 && Level < 16)
                damage = 3;
            else if (Level >= 16 && Level < 21)
                damage = 4;
            return damage;
        }

        public int calculateHealth()
        {
            int total = 0;
            total += 12 + calculateAttributeBonus(Constitution);
            for(int i = 1; i < level; i++)
            {
                total+= Dice.rollD12() + calculateAttributeBonus(Constitution);
            }
            return total;
        }

        public override String getSkills()
        {
            String skills = "";
            Skills.Add(UnarmoredDefense ? "Unarmoured Defense: \n" : "");
            Skills.Add(RecklessAttack ? "Reckless Attack: \n" : "");
            Skills.Add(DangerSense ? "Danger Sense: \n" : "");
            //for every path feature have it start with primal path modifier.
            Skills.Add(ExtraAttack ? "Extra Attack: \n" : "");
            Skills.Add(FastMovement ? "Fast Movement: \n" : "");
            Skills.Add(FeralInstinct ? "Feral Instinct: \n" : "");
            Skills.Add(BrutalCritical ? "Brutal Critical: \n" : "");
            Skills.Add(RelentlessRage ? "Relentless Rage: \n" : "");
            Skills.Add(ImprovedBrutalCritcal ? "Improved Brutal Critcal: \n" : "");
            Skills.Add(PersistantRage ? "Persistant Rage: \n" : "");
            Skills.Add(MasterBrutalCritcal ? "Master Brutal Critcal: \n" : "");
            Skills.Add(IndomitableMight ? "Indomitable Might: \n" : "");
            Skills.Add(PrimalChampion ? "Primal Champion: \n" : "");
            Skills.AddRange(primalPath.toString());

            return skills;
        }

        public override int Strength
        {
            get
            {
                if (PrimalChampion)
                    return strength + 4;
                return strength;
            }
            set { strength = value; }
        }
    }
}