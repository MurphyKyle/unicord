using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace CommunityBot.Features.DnDHelper
{
    public static class RandomEncounter
    {
        public static Monster m = new Monster();
        public static List<Monster> monsters = new List<Monster>();

        public static void ParseMonsters(string jsonMonsters)
        {
            Console.WriteLine(Newtonsoft.Json.JsonConvert.DeserializeObject(System.IO.File.ReadAllText(@"C:\Users\Kent Stringer\Desktop\Gray Render.txt")));
        }

    }
}
