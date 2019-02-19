using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dndSim.Models
{
   static public class Dice
    {

        private static Random rand = new Random();
        public const int d2 = 2;
        public const int d4 = 4;
        public const int d6 = 6;
        public const int d8 = 8;
        public const int d10 = 10;
        public const int d12 = 12;
        public const int d20 = 20;
        public const int d100 = 100;

        public static int roll(int size,  int amount)
        {
            int total = 0;
            for(int i = 0; i < amount; i++)
            {
                total += rand.Next(size) + 1;
            }
            return total;
        }

        public static int rollD2(int amount)
        {
            return roll(d2, amount);
        }

        public static int rollD4(int amount)
        {
            return roll(d4, amount);
        }

        public static int rollD6(int amount)
        {
            return roll(d6, amount);
        }

        public static int rollD8(int amount)
        {
            return roll(d8, amount);
        }

        public static int rollD10(int amount)
        {
            return roll(d10, amount);
        }

        public static int rollD12(int amount)
        {
            return roll(d12, amount);
        }

        public static int rollD20(int amount)
        {
            return roll(d20, amount);
        }

        public static int rollD100(int amount)
        {
            return roll(d100, amount);
        }

        public static int rollD2()
        {
            return roll(d2, 1);
        }

        public static int rollD4()
        {
            return roll(d4, 1);
        }

        public static int rollD6()
        {
            return roll(d6, 1);
        }

        public static int rollD8()
        {
            return roll(d8, 1);
        }

        public static int rollD10()
        {
            return roll(d10, 1);
        }

        public static int rollD12()
        {
            return roll(d12, 1);
        }

        public static int rollD20()
        {
            return roll(d20, 1);
        }

        public static int rollD100()
        {
            return roll(d100, 1);
        }

        public static int customeDie(int size, int amount)
        {
            return roll(size, amount);
        }
    }
}