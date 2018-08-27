using CommunityBot.Features.DnDHelper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityBot
{
    public static class Constants
    {
        internal static readonly string ResourceFolder = "resources";
        internal static readonly string UserAccountsFolder = "users";
        internal static readonly string ServerAccountsFolder = "servers";
        internal static readonly string LogFolder = "logs";
        internal static readonly string InvisibleString = "\u200b";

        public const ulong DailyMuiniesGain = 250;
        public const int MessageRewardCooldown = 30;
        public const int MessageRewardMinLenght = 20;
        public const int MaxMessageLength = 2000;
        public static readonly Tuple<int, int> MessagRewardMinMax = Tuple.Create(1, 5);
        public static readonly int MinTimerIntervall = 3000;

        public static readonly string[] DidYouKnows = {
            "You can fork me on GitHub ;) xoxo <3",
            "If you don't know what to add, you can add some of my messages. :P",
            "Wanna see someone's Miunies? Add a mention to your cash command.",
            "I just love when a programmer PULL requests their code into me.",
            "Protection? I don't accept code just from anybody, alright?",
            "You get a couple Miunies for sending messages (with a short cooldown).",
            "A lot of commands have shorter and easier to use aliases!"
        };

        public static Dictionary<string, Dictionary<NumberRange, string[]>> TreasureCatalog = new Dictionary<string, Dictionary<NumberRange, string[]>>()
        {
            {"1-c",new Dictionary<NumberRange, string[]>()
                {
                    {new NumberRange(1,14), null},
                    {new NumberRange(15,29), new string[]{ "1","6","1000", "cp" } },
                    {new NumberRange(30,52), new string[]{ "1","8","100", "sp" }},
                    {new NumberRange(53,95), new string[]{ "2","8","10", "gp" }},
                    {new NumberRange(96,100), new string[]{ "1","4","10", "pp" }}
                }
            },
            {"1-g",new Dictionary<NumberRange, string[]>()
                {
                    {new NumberRange(1,90), null},
                    {new NumberRange(91,95), new string[]{ "1","1","gems"} },
                    {new NumberRange(96,100), new string[]{ "1","1","art"}}
                }
            },
            {"1-i",new Dictionary<NumberRange, string[]>()
                {
                    {new NumberRange(1,71), null},
                    {new NumberRange(72,95), new string[]{ "1","1", "1","mundane"} },
                    {new NumberRange(96,100), new string[]{ "1","1", "1", "minor" }}
                }
            },
            {"2-c",new Dictionary<NumberRange, string[]>()
                {
                    {new NumberRange(1,13), null},
                    {new NumberRange(14,23), new string[]{ "1","10","1000", "cp" } },
                    {new NumberRange(24,43), new string[]{ "2","10","100", "sp" }},
                    {new NumberRange(44,95), new string[]{ "4","10","10", "gp" }},
                    {new NumberRange(96,100), new string[]{ "2","8","10", "pp" }}
                }
            },
            {"2-g",new Dictionary<NumberRange, string[]>()
                {
                    {new NumberRange(1,81), null},
                    {new NumberRange(82,95), new string[]{ "1","3","gems"} },
                    {new NumberRange(96,100), new string[]{ "1","3","art"}}
                }
            },
            {"2-i",new Dictionary<NumberRange, string[]>()
                {
                    {new NumberRange(1,49), null},
                    {new NumberRange(50,85), new string[]{ "1","3", "2", "mundane"} },
                    {new NumberRange(86,100), new string[]{ "1","1", "2", "minor" }}
                }
            },
            {"3-c",new Dictionary<NumberRange, string[]>()
                {
                    {new NumberRange(1,11), null},
                    {new NumberRange(12,21), new string[]{ "2","10","1000", "cp" } },
                    {new NumberRange(22,41), new string[]{ "4","8","100", "sp" }},
                    {new NumberRange(42,95), new string[]{ "1","4","10", "gp" }},
                    {new NumberRange(96,100), new string[]{ "1","10","10", "pp" }}
                }
            },
            {"3-g",new Dictionary<NumberRange, string[]>()
                {
                    {new NumberRange(1,77), null},
                    {new NumberRange(78,95), new string[]{ "1","3","gems"} },
                    {new NumberRange(96,100), new string[]{ "1","3","art"}}
                }
            },
            {"3-i",new Dictionary<NumberRange, string[]>()
                {
                    {new NumberRange(1,49), null},
                    {new NumberRange(50,79), new string[]{ "1","3", "3", "mundane"} },
                    {new NumberRange(80,100), new string[]{ "1","1", "3","minor" }}
                }
            },
            {"4-c",new Dictionary<NumberRange, string[]>()
                {
                    {new NumberRange(1,11), null},
                    {new NumberRange(12,21), new string[]{ "3","10","1000", "cp" } },
                    {new NumberRange(22,41), new string[]{ "4","12","100", "sp" }},
                    {new NumberRange(42,95), new string[]{ "1","6","10", "gp" }},
                    {new NumberRange(96,100), new string[]{ "1","8","10", "pp" }}
                }
            },
            {"4-g",new Dictionary<NumberRange, string[]>()
                {
                    {new NumberRange(1,70), null},
                    {new NumberRange(71,95), new string[]{ "1","4","gems"} },
                    {new NumberRange(96,100), new string[]{ "1","3","art"}}
                }
            },
            {"4-i",new Dictionary<NumberRange, string[]>()
                {
                    {new NumberRange(1,42), null},
                    {new NumberRange(43,62), new string[]{ "1","4","4", "mundane"} },
                    {new NumberRange(63,100), new string[]{ "1","3","4","minor" }}
                }
            },
            {"5-c",new Dictionary<NumberRange, string[]>()
                {
                    {new NumberRange(1,10), null},
                    {new NumberRange(11,19), new string[]{ "1","4","10000", "cp" } },
                    {new NumberRange(20,38), new string[]{ "1","6","1000", "sp" }},
                    {new NumberRange(39,95), new string[]{ "1","8","100", "gp" }},
                    {new NumberRange(96,100), new string[]{ "1","10","10", "pp" }}
                }
            },
            {"5-g",new Dictionary<NumberRange, string[]>()
                {
                    {new NumberRange(1,60), null},
                    {new NumberRange(61,95), new string[]{ "1","4","gems"} },
                    {new NumberRange(96,100), new string[]{ "1","4","art"}}
                }
            },
            {"5-i",new Dictionary<NumberRange, string[]>()
                {
                    {new NumberRange(1,57), null},
                    {new NumberRange(58,67), new string[]{ "1","4", "5", "mundane"} },
                    {new NumberRange(68,100), new string[]{ "1","3", "5", "minor" }}
                }
            },
            {"6-c",new Dictionary<NumberRange, string[]>()
                {
                    {new NumberRange(1,10), null},
                    {new NumberRange(11,18), new string[]{ "1","6","10000", "cp" } },
                    {new NumberRange(19,37), new string[]{ "1","8","1000", "sp" }},
                    {new NumberRange(38,95), new string[]{ "1","10","100", "gp" }},
                    {new NumberRange(96,100), new string[]{ "1","12","10", "pp" }}
                }
            },
            {"6-g",new Dictionary<NumberRange, string[]>()
                {
                    {new NumberRange(1,56), null},
                    {new NumberRange(57,92), new string[]{ "1","4","gems"} },
                    {new NumberRange(93,100), new string[]{ "1","4","art"}}
                }
            },
            {"6-i",new Dictionary<NumberRange, string[]>()
                {
                    {new NumberRange(1,51), null},
                    {new NumberRange(55,59), new string[]{ "1","4","6","mundane"} },
                    {new NumberRange(60,99), new string[]{ "1","3", "6", "minor" }},
                    {new NumberRange(100,100), new string[]{ "1","1","6", "medium" }}

                }
            },
            { "7-c", new Dictionary<NumberRange, string[]>()
                {
                    { new NumberRange(1, 11), null},
                    { new NumberRange(12, 18), new string[]{ "1","10","10000", "cp" } },
                    { new NumberRange(19, 35), new string[]{ "1","12","1000", "sp" } },
                    { new NumberRange(36, 93), new string[]{ "2","6","100", "gp" } },
                    { new NumberRange(94, 100), new string[]{ "3","4","10", "pp" } }
                }
            },
            { "7-g", new Dictionary<NumberRange, string[]>()
                {
                    { new NumberRange(1, 60), null},
                    { new NumberRange(61, 95), new string[]{ "1", "4"," gems" } },
                    { new NumberRange(96, 100), new string[]{ "1", "4", "art" } }
                }
            },
            { "7-i", new Dictionary<NumberRange, string[]>()
                {
                    { new NumberRange(1, 51), null},
                    { new NumberRange(52, 97), new string[] { "1", "3", "7", "minor" } },
                    { new NumberRange(98, 100), new string[] { "1", "1", "7", "medium" } }

                }
            },
            { "8-c", new Dictionary<NumberRange, string[]>()
                {
                    { new NumberRange(1, 10), null },
                    { new NumberRange(11, 15), new string[] { "1", "12", "10000", "cp" } },
                    { new NumberRange(16, 29), new string[] { "2", "6", "1000", "sp" } },
                    { new NumberRange(30, 87), new string[] { "2", "8", "100", "gp" } },
                    { new NumberRange(88, 100), new string[] { "3", "6", "10", "pp" } }
                }
            },
            { "8-g", new Dictionary<NumberRange, string[]>()
                {
                    { new NumberRange(1, 45), null },
                    { new NumberRange(46, 85), new string[] { "1", "6", "gems" } },
                    { new NumberRange(86, 100), new string[] { "1", "4", "art" } }
                }
            },
            { "8-i", new Dictionary<NumberRange, string[]>()
                {
                    { new NumberRange(1, 48), null },
                    { new NumberRange(49, 96), new string[] { "1", "4", "8", "minor" } },
                    { new NumberRange(97, 100), new string[] { "1", "1", "8", "medium" } }
                }
            },
            { "9-c", new Dictionary<NumberRange, string[]>()
                {
                    { new NumberRange(1, 10), null },
                    { new NumberRange(11, 15), new string[] { "2", "6", "10000", "cp" } },
                    { new NumberRange(16, 29), new string[] { "2", "8", "1000", "sp" } },
                    { new NumberRange(30, 85), new string[] { "5", "4", "100", "gp" } },
                    { new NumberRange(86, 100), new string[] { "2", "12", "10", "pp" } }
                }
            },
            { "9-g", new Dictionary<NumberRange, string[]>()
                {
                    { new NumberRange(1, 40), null },
                    { new NumberRange(41, 80), new string[] { "1", "8", "gems" } },
                    { new NumberRange(81, 100), new string[] { "1", "4", "art" } }
                }
            },
            { "9-i", new Dictionary<NumberRange, string[]>()
                {
                    { new NumberRange(1, 43), null },
                    { new NumberRange(44, 91), new string[] { "1", "4", "9", "minor" } },
                    { new NumberRange(92, 100), new string[] { "1", "1", "9", "medium" } }
                }
            },
            { "10-c", new Dictionary<NumberRange, string[]>()
                {
                    { new NumberRange(1, 10), null },
                    { new NumberRange(11, 24), new string[] { "2", "10", "1000", "sp" } },
                    { new NumberRange(25, 79), new string[] { "6", "4", "100", "gp" } },
                    { new NumberRange(80, 100), new string[] { "5", "6", "10", "pp" } }
                }
            },
            { "10-g", new Dictionary<NumberRange, string[]>()
                {
                    { new NumberRange(1, 35), null },
                    { new NumberRange(36, 79), new string[] { "1", "8", "gems" } },
                    { new NumberRange(80, 100), new string[] { "1", "6", "art" } }
                }
            },
            { "10-i", new Dictionary<NumberRange, string[]>()
                {
                    { new NumberRange(1, 40), null },
                    { new NumberRange(41, 88), new string[] { "1", "4", "10", "minor" } },
                    { new NumberRange(89, 99), new string[] { "1", "1", "10", "medium" } },
                    { new NumberRange(100, 100), new string[] { "1", "1", "10", "major" } }
                }
            },
            { "11-c", new Dictionary<NumberRange, string[]>()
                {
                    { new NumberRange(1, 8), null },
                    { new NumberRange(9, 14), new string[] { "3", "10", "1000", "sp" } },
                    { new NumberRange(15, 75), new string[] { "4", "8", "100", "gp" } },
                    { new NumberRange(76, 100), new string[] { "4", "10", "10", "pp" } }
                }
            },
            { "11-g", new Dictionary<NumberRange, string[]>()
                {
                    { new NumberRange(1, 24), null },
                    { new NumberRange(25, 74), new string[] { "1", "10", "gems" } },
                    { new NumberRange(75, 100), new string[] { "1", "6", "art" } }
                }
            },
            { "11-i", new Dictionary<NumberRange, string[]>()
                {
                    { new NumberRange(1, 31), null },
                    { new NumberRange(32, 84), new string[] { "1", "4", "11", "minor" } },
                    { new NumberRange(15, 75), new string[] { "1", "1", "11", "medium" } },
                    { new NumberRange(76, 100), new string[] { "1", "1", "11", "major" } }
                }
            },
            { "12-c", new Dictionary<NumberRange, string[]>()
                {
                    { new NumberRange(1, 8), null },
                    { new NumberRange(9, 14), new string[] { "3", "12", "1000", "sp" } },
                    { new NumberRange(15, 75), new string[] { "1", "4", "1000", "gp" } },
                    { new NumberRange(76, 100), new string[] { "1", "4", "100", "pp" } }
                }
            },
            { "12-g", new Dictionary<NumberRange, string[]>()
                {
                    { new NumberRange(1, 17), null },
                    { new NumberRange(18, 70), new string[] { "1", "10", "gems" } },
                    { new NumberRange(71, 100), new string[] { "1", "8", "art" } }
                }
            },
            { "12-i", new Dictionary<NumberRange, string[]>()
                {
                    { new NumberRange(1, 27), null },
                    { new NumberRange(28, 82), new string[] { "1", "6", "12", "minor" } },
                    { new NumberRange(83, 97), new string[] { "1", "1", "12", "medium" } },
                    { new NumberRange(98, 100), new string[] { "1", "1", "12", "major" } }
                }
            },
            { "13-c", new Dictionary<NumberRange, string[]>()
                {
                    { new NumberRange(1, 8), null },
                    { new NumberRange(9, 75), new string[] { "1", "4", "1000", "gp" } },
                    { new NumberRange(76, 100), new string[] { "1", "10", "100", "pp" } }
                }
            },
            { "13-g", new Dictionary<NumberRange, string[]>()
                {
                    { new NumberRange(1, 11), null },
                    { new NumberRange(12, 66), new string[] { "1", "12", "gems" } },
                    { new NumberRange(67, 100), new string[] { "1", "10", "art" } }
                }
            },
            { "13-i", new Dictionary<NumberRange, string[]>()
                {
                    { new NumberRange(1, 19), null },
                    { new NumberRange(20, 73), new string[] { "1", "6", "13", "minor" } },
                    { new NumberRange(74, 95), new string[] { "1", "1", "13", "medium" } },
                    { new NumberRange(96, 100), new string[] { "1", "1", "13", "major" } }
                }
            },
            { "14-c", new Dictionary<NumberRange, string[]>()
                {
                    { new NumberRange(1, 8), null },
                    { new NumberRange(9, 75), new string[] { "1", "6", "1000", "gp" } },
                    { new NumberRange(76, 100), new string[] { "1", "12", "100", "pp" } }
                }
            },
            { "14-g", new Dictionary<NumberRange, string[]>()
                {
                    { new NumberRange(1, 11), null },
                    { new NumberRange(12, 66), new string[] { "2", "8", "gems" } },
                    { new NumberRange(67, 100), new string[] { "2", "6", "art" } }
                }
            },
            { "14-i", new Dictionary<NumberRange, string[]>()
                {
                    { new NumberRange(1, 19), null },
                    { new NumberRange(20, 58), new string[] { "1", "6", "14", "minor" } },
                    { new NumberRange(59, 92), new string[] { "1", "1", "14", "medium" } },
                    { new NumberRange(93, 100), new string[] { "1", "1", "14", "major" } }
                }
            },
            { "15-c", new Dictionary<NumberRange, string[]>()
                {
                    { new NumberRange(1, 3), null },
                    { new NumberRange(4, 74), new string[] { "1", "8", "1000", "gp" } },
                    { new NumberRange(75, 100), new string[] { "3", "4", "100", "pp" } }
                }
            },
            { "15-g", new Dictionary<NumberRange, string[]>()
                {
                    { new NumberRange(1, 9), null },
                    { new NumberRange(10, 65), new string[] { "2", "10", "gems" } },
                    { new NumberRange(66, 100), new string[] { "2", "8", "art" } }
                }
            },
            { "15-i", new Dictionary<NumberRange, string[]>()
                {
                    { new NumberRange(1, 11), null },
                    { new NumberRange(12, 46), new string[] { "1", "10", "15", "minor" } },
                    { new NumberRange(47, 90), new string[] { "1", "1", "15", "medium" } },
                    { new NumberRange(91, 100), new string[] { "1", "1", "15", "major" } }
                }
            },
            { "16-c", new Dictionary<NumberRange, string[]>()
                {
                    { new NumberRange(1, 3), null },
                    { new NumberRange(4, 74), new string[] { "1", "12", "1000", "gp" } },
                    { new NumberRange(75, 100), new string[] { "3", "4", "100", "pp" } }
                }
            },
            { "16-g", new Dictionary<NumberRange, string[]>()
                {
                    { new NumberRange(1, 7), null },
                    { new NumberRange(8, 64), new string[] { "4", "6", "gems" } },
                    { new NumberRange(65, 100), new string[] { "2", "10", "art" } }
                }
            },
            { "16-i", new Dictionary<NumberRange, string[]>()
                {
                    { new NumberRange(1, 40), null },
                    { new NumberRange(41, 46), new string[] { "1", "10", "16", "minor" } },
                    { new NumberRange(47, 90), new string[] { "1", "3", "16", "medium" } },
                    { new NumberRange(91, 100), new string[] { "1", "1", "16", "major" } }
                }
            },
            { "17-c", new Dictionary<NumberRange, string[]>()
                {
                    { new NumberRange(1, 3), null },
                    { new NumberRange(4, 68), new string[] { "3", "4", "1000", "gp" } },
                    { new NumberRange(69, 100), new string[] { "2", "10", "100", "pp" } }
                }
            },
            { "17-g", new Dictionary<NumberRange, string[]>()
                {
                    { new NumberRange(1, 4), null },
                    { new NumberRange(5, 63), new string[] { "4", "8", "gems" } },
                    { new NumberRange(64, 100), new string[] { "3", "8", "art" } }
                }
            },
            { "17-i", new Dictionary<NumberRange, string[]>()
                {
                    { new NumberRange(1, 33), null },
                    { new NumberRange(34, 83), new string[] { "1", "3", "17", "medium" } },
                    { new NumberRange(84, 100), new string[] { "1", "1", "17", "major" } }
                }
            },
            { "18-c", new Dictionary<NumberRange, string[]>()
                {
                    { new NumberRange(1, 2), null },
                    { new NumberRange(3, 65), new string[] { "3", "4", "1000", "gp" } },
                    { new NumberRange(66, 100), new string[] { "5", "4", "100", "pp" } }
                }
            },
            { "18-g", new Dictionary<NumberRange, string[]>()
                {
                    { new NumberRange(1, 4), null },
                    { new NumberRange(5, 54), new string[] { "3", "12", "gems" } },
                    { new NumberRange(55, 100), new string[] { "3", "10", "art" } }
                }
            },
            { "18-i", new Dictionary<NumberRange, string[]>()
                {
                    { new NumberRange(1, 24), null },
                    { new NumberRange(25, 80), new string[] { "1", "4", "18", "medium" } },
                    { new NumberRange(81, 100), new string[] { "1", "1", "18", "major" } }
                }
            },
            { "19-c", new Dictionary<NumberRange, string[]>()
                {
                    { new NumberRange(1, 2), null },
                    { new NumberRange(3, 65), new string[] { "3", "8", "1000", "gp" } },
                    { new NumberRange(66, 100), new string[] { "3", "10", "100", "pp" } }
                }
            },
            { "19-g", new Dictionary<NumberRange, string[]>()
                {
                    { new NumberRange(1, 3), null },
                    { new NumberRange(4, 50), new string[] { "6", "6", "gems" } },
                    { new NumberRange(51, 100), new string[] { "6", "6", "art" } }
                }
            },
            { "19-i", new Dictionary<NumberRange, string[]>()
                {
                    { new NumberRange(1, 4), null },
                    { new NumberRange(5, 70), new string[] { "1", "4", "19", "medium" } },
                    { new NumberRange(71, 100), new string[] { "1", "1", "19", "major" } }
                }
            },
            { "20-c", new Dictionary<NumberRange, string[]>()
                {
                    { new NumberRange(1, 2), null },
                    { new NumberRange(3, 65), new string[] { "4", "8", "1000", "gp" } },
                    { new NumberRange(66, 100), new string[] { "4", "10", "100", "pp" } }
                }
            },
            { "20-g", new Dictionary<NumberRange, string[]>()
                {
                    { new NumberRange(1, 2), null },
                    { new NumberRange(3, 38), new string[] { "3", "10", "gems" } },
                    { new NumberRange(39, 100), new string[] { "7", "6", "art" } }
                }
            },
            { "20-i", new Dictionary<NumberRange, string[]>()
                {
                    { new NumberRange(1, 25), null },
                    { new NumberRange(26, 65), new string[] { "1", "4", "20", "medium" } },
                    { new NumberRange(66, 100), new string[] { "1", "3", "20", "major" } }
                }
            }
        };

        public static Dictionary<NumberRange, string[][]> GemCatalog = new Dictionary<NumberRange, string[][]>() {
            
                {new NumberRange(1,25), new string[][]{ new string[]{ "4", "4", "1", "gp" },new string[]{
                    "Agate", "Azurite", "Blue Quartz", "Hematite", "Lapis Lazuli", "Malachite", "Obsidian", "Rhodochrosite",
                    "Tiger Eye Turquoise", "Freshwater (irregular) pearl" } }},
                {new NumberRange(26,50), new string[][]{ new string[]{ "2", "4", "10", "gp" },new string[]{
                    "Bloodstone", "carnelian", "chalcedony", "chrysoprase", "citrine", "jasper moonstone", "onyx", "periot",
                    "rock crystal (clear quartz)", "sard", "sardonyx", "rose quartz", "zircon"} }},
                {new NumberRange(51,70), new string[][]{ new string[]{ "4", "10", "10", "gp" },new string[]{
                    "Amber", "Amethyst", "Chrysoberyl", "Coral", "Garnet", "Jade", "Jet", "(white, golden, pink, or silver) pearl", "Tourmaline",
                "(red spinel, red-brown or deep green) Spinel"} }},
                {new NumberRange(71,90), new string[][]{ new string[]{ "2", "4", "100", "gp" },new string[]{
                    "Alexandrite", "Aquamarine", "Violet Garnet", "Black Pearl", "Deep Blue Spinel", "Golden Yellow Topaz"} }},
                {new NumberRange(91,99), new string[][]{ new string[]{ "4", "4", "100", "gp" },new string[] {
                "Emerald", "(white, black, or fire) Opal", "Blue Sapphire", "(fiery yellow or rich purple) Corundum", "(blue or black) Star Sapphire", "Star Ruby"} }},
                {new NumberRange(100,100), new string[][]{ new string[]{ "2", "4", "1000", "gp" },new string[]{
                    "Clearest bright green emerald", "(blue-white, canary, pink, brown, or blue) Diamond", "Jacinth"} }}
        };

        public static Dictionary<NumberRange, string[][]> ArtCatalog = new Dictionary<NumberRange, string[][]>() {

                {new NumberRange(1,10), new string[][]{ new string[]{ "1", "10", "10", "gp" },new string[]{"Silver ewer", "carved bone or ivory statuette;", "finely wrought small gold bracelet" } }},
                {new NumberRange(11,25), new string[][]{ new string[]{ "3", "6", "10", "gp" },new string[]{"Cloth of gold vestments", "black velvet mask with numerous citrines", "silver chalice with lapis lazuli gems"} }},
                {new NumberRange(26,40), new string[][]{ new string[]{ "1", "6", "100", "gp" },new string[]{"Large well-done wool tapestry", "brass mug with jade inlays"} }},
                {new NumberRange(41,50), new string[][]{ new string[]{ "1", "10", "100", "gp" },new string[]{"Silver comb with moonstones", "silver-plated steel longsword with jet jewel in hilt"} }},
                {new NumberRange(51,60), new string[][]{ new string[]{ "2", "6", "100", "gp" },new string[] {"Carved harp of exotic wood with ivory inlay and zircon gems", "solid gold idol (10 lb.)"} }},
                {new NumberRange(61, 70), new string[][]{ new string[]{ "3", "6", "100", "gp" },new string[]{"Gold dragon comb with red garnet eye", "gold and topaz bottle stopper cork", "ceremonial electrum dagger with a star ruby in the pommel"} }},
                {new NumberRange(71,80), new string[][]{ new string[]{ "4", "6", "100", "gp" },new string[]{"Eyepatch with mock eye of sapphire and moonstone", "fire opal pendant on a fine gold chain", "old masterpiece painting"} }},
                {new NumberRange(81,85), new string[][]{ new string[]{ "5", "6", "100", "gp" },new string[] {"Embroidered silk and velvet mantle with numerous moonstones", "sapphire pendant on gold chain"} }},
                {new NumberRange(86, 90), new string[][]{ new string[]{ "1", "4", "1000", "gp" },new string[]{"Embroidered and bejeweled glove", "jeweled anklet", "gold music box"} }},
                {new NumberRange(91,95), new string[][]{ new string[]{ "1", "6", "1000", "gp" },new string[]{"Golden circlet with four aquamarines", "a string of small pink pearls (necklace)"} }},
                {new NumberRange(96,99), new string[][]{ new string[]{ "2", "4", "1000", "gp" },new string[] {"Jeweled gold crown", "jeweled electrum ring"} }},
                {new NumberRange(100, 100), new string[][]{ new string[]{ "2", "6", "1000", "gp" },new string[]{"Gold Ruby Ring", "gold cup set with emeralds"} }}
        };

        public static Dictionary<NumberRange, string[]> AlchemyCatalog = new Dictionary<NumberRange, string[]>() {
                {new NumberRange(1,12), new string[]{ "1", "4", "1", " Alchemist’s fire (20 gp each)" } },
                {new NumberRange(13,24), new string[]{ "2", "4", "1", " Acid (10 gp each)" } },
                {new NumberRange(25,36), new string[]{ "1", "4", "1", " Smokesticks (20 gp each)" } },
                {new NumberRange(37,48), new string[]{ "1", "4", "1", " Holy water (25 gp each)" } },
                {new NumberRange(49,62), new string[]{ "1", "4", "1", " AntiToxin (50 gp each)" } },
                {new NumberRange(63,74), new string[]{ "1", "1", "1", " Everburning torch" } },
                {new NumberRange(75,88), new string[]{ "1", "4", "1", " Tanglefoot bags (50 gp each)" } },
                {new NumberRange(89,100), new string[]{ "1", "4", "1", " Thunderstones (30 gp each)" } },
        };

        public static Dictionary<NumberRange, string> ArmorCatalog = new Dictionary<NumberRange, string>() {
                {new NumberRange(1,12), "Chain shirt (100 gp)" }, 
                {new NumberRange(13,18), "Masterwork studded leather (175 gp)" }, 
                {new NumberRange(19,26), "Breastplate (200 gp)" }, 
                {new NumberRange(271,34), "Banded mail (250 gp)" }, 
                {new NumberRange(35,54), "Half-plate (600 gp)" }, 
                {new NumberRange(56,80), "Full plate (1,500 gp)" }, 
                {new NumberRange(81,90), "Darkwood Shield (257 gp)" }, 
                {new NumberRange(91,100), "Masterwork heavy steel shield (170 gp)" }
        };

        public static Dictionary<NumberRange, string> WeaponCatalog = new Dictionary<NumberRange, string>() {
                {new NumberRange(1,50), "Chain shirt (100 gp)" },
                {new NumberRange(51,70), "Masterwork studded leather (175 gp)" },
                {new NumberRange(71,100), "Breastplate (200 gp)" }
        };

        public static Dictionary<NumberRange, string> ToolsAndGearCatalog = new Dictionary<NumberRange, string>() {
                {new NumberRange(1,3), "Backpack, empty (2 gp)" },
                {new NumberRange(4,6), "Crowbar (2 gp)" },
                {new NumberRange(7,11), "Lantern, bullseye (12 gp)" },
                {new NumberRange(12,16), "Lock, simple (20 gp)" },
                {new NumberRange(17,21), "Lock, average (40 gp)" },
                {new NumberRange(22,28), "Lock, good (80 gp)" },
                {new NumberRange(29,35), "Lock, superior (150 gp)" },
                {new NumberRange(36,40), "Manacles, masterwork (50 gp)" },
                {new NumberRange(41,43), "Mirror, small steel (10 gp)" },
                {new NumberRange(44,46), "Rope, silk (50 ft.) (10 gp)" },
                {new NumberRange(47,53), "Spyglass (1,000 gp)" },
                {new NumberRange(54,58), "Artisan’s tools, masterwork (55 gp)" },
                {new NumberRange(59,63), "Climber’s kit (80 gp)" },
                {new NumberRange(64,68), "Disguise kit (50 gp)" },
                {new NumberRange(69,73), "Healer’s kit (50 gp)" },
                {new NumberRange(74,77), "Holy symbol, silver (25 gp)" },
                {new NumberRange(78,81), "Hourglass (25 gp)" },
                {new NumberRange(82,88), "Magnifying glass (100 gp)" },
                {new NumberRange(89,95), "Musical instrument, masterwork (100 gp)" },
                {new NumberRange(96,100), "Thieves’ tools, masterwork (50 gp)" },
        };
    }
}
