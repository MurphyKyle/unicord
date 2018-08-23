using CommunityBot.Features.DnDHelper.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommunityBot.Features.DnDHelper
{
    public static class TreasureGenerator
    {
        private static Random randy = new Random();

        public static string GetLoot(int partyLevel)
        {
            int selection = randy.Next(1,100);
            string retVal = "";
            foreach (KeyValuePair<NumberRange, string[]> item in Constants.TreasureCatalog[partyLevel.ToString() + "-c"])
            {
                if (item.Key==selection)
                {
                    retVal += GetCoin(item.Value);
                }
            }
            selection = randy.Next(1, 100);
            foreach (KeyValuePair<NumberRange, string[]> item in Constants.TreasureCatalog[partyLevel.ToString() + "-g"])
            {
                if (item.Key == selection)
                {
                    retVal += GetGoods(item.Value);
                }
            }
            selection = randy.Next(1, 100);
            foreach (KeyValuePair<NumberRange, string[]> item in Constants.TreasureCatalog[partyLevel.ToString() + "-i"])
            {
                if (item.Key == selection)
                {
                    retVal += GetItems(item.Value);
                }
            }
            return retVal;
        }

        public static string GetCoin(string[] parms)
        {
            if(parms != null)
            {
                int total = 0;
                for (int i = 0; i < Int32.Parse(parms[0]); i++)
                {
                    total += randy.Next(1, Int32.Parse(parms[1]));
                }
                total *= Int32.Parse(parms[2]);
                return $"{total}{parms[3]}\n";
            }
            else
            {
                return "";
            }
            
        }

        public static string GetGoods(string[] parms)
        {
            string retVal = "";
            if(parms != null)
            {
                for (int i = 0; i < Int32.Parse(parms[0]); i++)
                {
                    if (parms[2] == "gems")
                    {
                        retVal += GetGem();
                    }
                    else
                    {
                        retVal += GetArt();
                    }
                }
            }
            return retVal;
        }

        public static string GetItems(string[] parms)
        {
            string retVal = "";
            if(parms != null)
            {
                for (int i = 0; i < Int32.Parse(parms[0]); i++)
            {
                switch (parms[2])
                {
                    case "mundane":
                        retVal += GetMundaneItem();
                        break;
                    case "minor":
                        retVal += DnDHelper.DnDHelperClass.ParseMagicItems(1);
                        break;
                    case "medium":
                        retVal += DnDHelper.DnDHelperClass.ParseMagicItems(2);
                        break;
                    case "major":
                        retVal += DnDHelper.DnDHelperClass.ParseMagicItems(3);
                        break;
                }
            }
            }
            return retVal + "\n";
        }

        private static string GetMundaneItem()
        {
            int selection = randy.Next(1, 100);
            string retVal = "";
            if (new NumberRange(1,17) == selection)
            {
                selection = randy.Next(1, 100);
                foreach (KeyValuePair<NumberRange, string[]> item in Constants.AlchemyCatalog)
                {
                    if (item.Key == selection)
                    {
                        retVal = $"{GetCoin(item.Value)}\n";
                    }
                }
            }
            else if (new NumberRange(18, 50) == selection)
            {
                selection = randy.Next(1, 100);
                foreach (KeyValuePair<NumberRange, string> item in Constants.ArmorCatalog)
                {
                    if (item.Key == selection)
                    {
                        retVal = $"{item.Value}\n";
                    }
                }

            }
            else if (new NumberRange(51, 83) == selection)
            {
                selection = randy.Next(1, 100);
                foreach (KeyValuePair<NumberRange, string> item in Constants.WeaponCatalog)
                {
                    if (item.Key == selection)
                    {
                        retVal = $"{item.Value}\n";
                    }
                }
            }
            else
            {
                selection = randy.Next(1, 100);
                foreach (KeyValuePair<NumberRange, string> item in Constants.ToolsAndGearCatalog)
                {
                    if (item.Key == selection)
                    {
                        retVal = $"{item.Value}\n";
                    }
                }
            }
            
            return retVal;
        }

        private static string GetArt()
        {
            int selection = randy.Next(1, 100);
            string retVal = "";
            foreach (KeyValuePair<NumberRange, string[][]> item in Constants.ArtCatalog)
            {
                if (item.Key == selection)
                {
                    retVal = $"{item.Value[1][randy.Next(item.Value[1].Length)]} - {GetCoin(item.Value[0])}\n";
                }
            }
            return retVal;
        }

        private static string GetGem()
        {
            int selection = randy.Next(1, 100);
            string retVal = "";
            foreach (KeyValuePair<NumberRange,string[][]> item in Constants.GemCatalog)
            {
                if (item.Key == selection)
                {
                    retVal = $"{item.Value[1][randy.Next(item.Value[1].Length)]} - {GetCoin(item.Value[0])}\n";
                }
            }
            return retVal;
        }
    }
}
