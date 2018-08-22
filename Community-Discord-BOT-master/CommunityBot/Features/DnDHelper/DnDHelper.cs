using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Linq;

namespace CommunityBot.Features.DnDHelper
{
    public static class DnDHelperClass
    {
        public static Monster m = new Monster();
        public static List<Monster> monsters = new List<Monster>();

        public static string ParseMonsters(string cr)
        {
            string s = System.IO.File.ReadAllText(@"..\..\..\JSONFiles\MonsterList.txt");
            JObject m = (JObject)Newtonsoft.Json.JsonConvert.DeserializeObject(s);
            List<Monster> monsters = new List<Monster>();
            IList<JToken> list = m;
            for (int i = 0; i < list.Count; i++)
            {
                JToken monsterToken = list[i];
                var attributes = monsterToken.Children();

                Dictionary<string, string> at = new Dictionary<string, string>();
                for (int j = 0; j < attributes.ElementAt(0).Count(); j++)
                {
                    var test = attributes.ElementAt(0).ElementAt(j).ToString();
                    string[] testing = test.Split('"');
                    at.Add(testing[1], testing[testing.Count()-2]);
                }
                Monster mon = new Monster();
                mon.alignment = at["alignment"];
                mon.challenge = at["challenge"];
                mon.size = at["size"];
                mon.name = at["name"];
                mon.xp = at["xp"];
                mon.type = at["type"];
                mon.page = at["page"];
                if (at["challenge"] == cr)
                {
                    monsters.Add(mon);
                }
            }
            Random randy = new Random();

            return monsters[randy.Next(monsters.Count())].ToString();
        }

        public static string ParseMagicItems(int cl)
        {
            string s = System.IO.File.ReadAllText(@"..\\..\\..\JSONFiles\MagicItems.txt");
            JObject m = (JObject)Newtonsoft.Json.JsonConvert.DeserializeObject(s);
            List<MagicItem> items = new List<MagicItem>();
            IList<JToken> list = m;
            for (int i = 0; i < list.Count; i++)
            {
                JToken itemToken = list[i];
                var attributes = itemToken.Children();

                Dictionary<string, string> at = new Dictionary<string, string>();
                for (int j = 0; j < attributes.ElementAt(0).Count(); j++)
                {
                    var test = attributes.ElementAt(0).ElementAt(j).ToString();
                    string[] testing = test.Split('"');
                    at.Add(testing[1], testing[testing.Count() - 2]);
                }
                MagicItem item = new MagicItem();
                item.Name = at["name"];
                item.Rarity = at["rarity"];
                item.Type = at["type"];
                item.Page = at["page"];
                if (cl < 5)
                {
                    if (at["rarity"] == "Uncommon" || at["rarity"] == "Common")
                    {
                        items.Add(item);
                    }
                }
                else if (cl < 11)
                {
                    if (at["rarity"] == "Uncommon" || at["rarity"] == "Common" || at["rarity"] == "Rare")
                    {
                        items.Add(item);
                    }
                }
                else if (cl < 17)
                {
                    if (at["rarity"] == "Uncommon" || at["rarity"] == "Common" || at["rarity"] == "Rare" || at["rarity"] == "Very Rare")
                    {
                        items.Add(item);
                    }
                }
                else
                {
                    items.Add(item);
                }
            }
            Random randy = new Random();

            return items[randy.Next(items.Count())].ToString();
        }

    }
}
