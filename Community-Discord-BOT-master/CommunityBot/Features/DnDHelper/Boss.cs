using System;
using System.Collections.Generic;
using System.Text;

namespace CommunityBot.Features.DnDHelper
{
    public class Boss
    {
        public string[] Race { get; set; } = {"Human","Elf","Orc","Gnome","Halfling","Half-Orc","Half-Elf" };
        public string[] Class { get; set; } = {"Fighter", "Rouge", "Ranger", "Wizard", "Sorceror", "Barbarian", "Bard" };

        private Dictionary<string, int> Stats;
        public string[] WeaponType { get; set; } = { "Dagger", "Short Sword", "Long Sword", "Staff", "Short Bow", "Long Bow", "Spear", "Crossbow"};
        public string[] ArmorType { get; set; } = {"Leather", "Studded Leather", "Chain Mail", "Half Plate", "Full Plate", "Mithril Plate" };
        public int WeaponBonus { get; set; }
        public int ArmorBonus { get; set; }

        private Random randy = new Random();

        public Boss(int difficulty)
        {
            RollBoss(difficulty);
        }

        private void RollBoss(int difficulty)
        {
            RollStat(difficulty);
            Stats = new Dictionary<string, int>{
                { "Strength", RollStat(difficulty) },
                { "Dexterity", RollStat(difficulty) },
                { "Constitution", RollStat(difficulty) },
                { "Intelligence", RollStat(difficulty) },
                { "Wisdom", RollStat(difficulty) },
                { "Charisma", RollStat(difficulty) },};
            WeaponBonus = RollBonus(difficulty);
            ArmorBonus = RollBonus(difficulty);
        }

        private int RollStat(int difficulty)
        {
            int total = 0;
            for (int i = 0; i < 2 ; i++)
            {
                total += randy.Next(1, 6);
            }
            return total + randy.Next(difficulty/2,difficulty);
        }

        private int RollBonus(int difficulty)
        {
            int total = 0;
            for (int i = 0; i < 1 + difficulty; i++)
            {
                total += randy.Next(0,2);
            }
            return total;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{Race[randy.Next(Race.Length)]} {Class[randy.Next(Class.Length)]}\n" );
            foreach (KeyValuePair<string,int> item in Stats)
            {
                sb.Append($"{item.Key}: {item.Value}\n");
            }
            sb.Append($"Weilding a {WeaponType[randy.Next(WeaponType.Length)]} + {WeaponBonus}\n");
            sb.Append($"Wearing {ArmorType[randy.Next(ArmorType.Length)]} + {ArmorBonus}");
            return sb.ToString();
        }
    }
}
