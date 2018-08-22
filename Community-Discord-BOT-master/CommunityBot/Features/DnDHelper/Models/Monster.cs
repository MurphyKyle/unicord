using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommunityBot.Features.DnDHelper
{
    public class Monster
    {
        public string alignment { get; set; }
        public string challenge { get; set; }
        public string size { get; set; }
        public string name { get; set; }
        public string xp { get; set; }
        public string type { get; set; }
        public string page { get; set; }
        public Dictionary<string, string> environment { get; set; }

        public Monster()
        {

        }

        public override string ToString()
        {
            return $"{name}\n CR: {challenge}\n Alignment: {alignment}\n XP: {xp}\n Type: {type}\n Size: {size}\n Page Found: {page}\n";
        }
    }
}
