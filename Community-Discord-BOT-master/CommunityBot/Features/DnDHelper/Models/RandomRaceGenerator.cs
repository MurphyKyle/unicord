using System;
using System.Collections.Generic;
using System.Text;

namespace CommunityBot.Features.DnDHelper.Models
{
    public class RandomRaceGenerator
    {
        private Random randy = new Random();
        public string Race { get; set; }

        public RandomRaceGenerator()
        {
            GetRace();
        }
        private void GetRace()
        {
            int selection = randy.Next(1, 100);
            if (selection <= 45)
            {
                Race = "Human";
            }
            else if (selection <= 52)
            {
                Race = "Elf";
            }
            else if (selection <= 59)
            {
                Race = "Dwarf";
            }
            else if (selection <= 65)
            {
                Race = "Halfling";
            }
            else if (selection <= 72)
            {
                Race = "Gnome";
            }
            else if (selection <= 80)
            {
                Race = "Half-Elf";
            }
            else if (selection <= 89)
            {
                Race = "Half-Orc";
            }
            else 
            {
                GetSpecialRace();
            }
        }

        private void GetSpecialRace()
        {
            int selection = randy.Next(1, 99);
            if (selection <= 4)
            {
                Race = "Aasimar";
            }
            else if (selection <= 8)
            {
                Race = "Catfolk";
            }
            else if (selection <= 13)
            {
                Race = "Dhampir";
            }
            else if (selection <= 17)
            {
                Race = "Drow";
            }
            else if (selection <= 22)
            {
                Race = "Fetchling";
            }
            else if (selection <= 27)
            {
                Race = "Goblin";
            }
            else if (selection <= 31)
            {
                Race = "Hobgoblin";
            }
            else if (selection <= 35)
            {
                Race = "Ifrit";
            }
            else if (selection <= 39)
            {
                Race = "Kobold";
            }
            else if (selection <= 43)
            {
                Race = "Orc";
            }
            else if (selection <= 47)
            {
                Race = "Oread";
            }
            else if (selection <= 51)
            {
                Race = "Ratfolk";
            }
            else if (selection <= 55)
            {
                Race = "Sylph";
            }
            else if (selection <= 59)
            {
                Race = "Tengu";
            }
            else if (selection <= 63)
            {
                Race = "Tiefling";
            }
            else if (selection <= 65)
            {
                Race = "Changeling";
            }
            else if (selection <= 67)
            {
                Race = "Duergar";
            }
            else if (selection <= 69)
            {
                Race = "Gillmen";
            }
            else if (selection <= 71)
            {
                Race = "Grippli";
            }
            else if (selection <= 73)
            {
                Race = "Kitsune";
            }
            else if (selection <= 75)
            {
                Race = "Merfolk";
            }
            else if (selection <= 77)
            {
                Race = "Nagaji";
            }
            else if (selection <= 79)
            {
                Race = "Samsaran";
            }
            else if (selection <= 81)
            {
                Race = "Strix";
            }
            else if (selection <= 83)
            {
                Race = "Suli";
            }
            else if (selection <= 85)
            {
                Race = "Svirfneblin";
            }
            else if (selection <= 87)
            {
                Race = "Vanara";
            }
            else if (selection <= 88)
            {
                Race = "Vishkanya";
            }
            else if (selection <= 89)
            {
                Race = "Wayang";
            }
            else if (selection <= 90)
            {
                Race = "Android";
            }
            else if (selection <= 91)
            {
                Race = "Ghoran";
            }
            else if (selection <= 92)
            {
                Race = "Lashunta";
            }
            else if (selection <= 93)
            {
                Race = "Monkey Goblin";
            }
            else if (selection <= 94)
            {
                Race = "Gathlain";
            }
            else if (selection <= 95)
            {
                Race = "Kasatha";
            }
            else if (selection <= 96)
            {
                Race = "Syrinx";
            }
            else if (selection <= 97)
            {
                Race = "Trox";
            }
            else if (selection <= 98)
            {
                Race = "Wyrwood";
            }
            else 
            {
                Race = "Wyvaran";
            }
        }
    }
}
