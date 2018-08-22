using System;
using System.Collections.Generic;
using System.Text;

namespace CommunityBot.Features.DnDHelper.Models
{
    public class RandomClassGenerator
    {
        //http://triangularroom.com/2015/10/02/pathfinder-random-class-table/

        private Random rand = new Random();
        public string Class { get; set; }
        public RandomClassGenerator()
        {
            GenerateRandomClass();
        }

        public void GenerateRandomClass()
        {
            int num = rand.Next(1, 99);
            if (num <= 3)
            {
                Class = "Alchemist";
            }
            else if (num <= 4)
            {
                Class = "Anti-Paladin";
            }
            else if (num <= 7)
            {
                Class = "Arcanist";
            }
            else if (num <= 10)
            {
                Class = "Barbarian";
            }
            else if (num <= 13)
            {
                Class = "Bard";
            }
            else if (num <= 16)
            {
                Class = "Bloodrager";
            }
            else if (num <= 19)
            {
                Class = "Brawler";
            }
            else if (num <= 22)
            {
                Class = "Cavalier";
            }
            else if (num <= 25)
            {
                Class = "Cleric";
            }
            else if (num <= 28)
            {
                Class = "Druid";
            }
            else if (num <= 31)
            {
                Class = "Fighter";
            }
            else if (num <= 34)
            {
                Class = "Gunslinger";
            }
            else if (num <= 37)
            {
                Class = "Hunter";
            }
            else if (num <= 40)
            {
                Class = "Investigator";
            }
            else if (num <= 42)
            {
                Class = "Kineticist";
            }
            else if (num <= 45)
            {
                Class = "Magus";
            }
            else if (num <= 47)
            {
                Class = "Medium";
            }
            else if (num <= 50)
            {
                Class = "Monk";
            }
            else if (num <= 51)
            {
                Class = "Ninja";
            }
            else if (num <= 53)
            {
                Class = "Occultist";
            }
            else if (num <= 56)
            {
                Class = "Oracle";
            }
            else if (num <= 59)
            {
                Class = "Paladin";
            }
            else if (num <= 61)
            {
                Class = "Psychic";
            }
            else if (num <= 64)
            {
                Class = "Ranger";
            }
            else if (num <= 67)
            {
                Class = "Rogue";
            }
            else if (num <= 68)
            {
                Class = "Samurai";
            }
            else if (num <= 71)
            {
                Class = "Shaman";
            }
            else if (num <= 74)
            {
                Class = "Skald";
            }
            else if (num <= 77)
            {
                Class = "Slayer";
            }
            else if (num <= 81)
            {
                Class = "Sorcerer";
            }
            else if (num <= 82)
            {
                Class = "Spiritualist";
            }
            else if (num <= 85)
            {
                Class = "Summoner";
            }
            else if (num <= 88)
            {
                Class = "Swashbuckler";
            }
            else if (num <= 91)
            {
                Class = "Warpriest";
            }
            else if (num <= 94)
            {
                Class = "Witch";
            }
            else if (num <= 97)
            {
                Class = "Wizard";
            }
            else if (num <= 99)
            {
                Class = "Vigilante";
            }
        }
    }
}