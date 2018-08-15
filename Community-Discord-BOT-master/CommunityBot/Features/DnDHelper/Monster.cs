using System;
using System.Collections.Generic;
using System.Text;

namespace CommunityBot.Features.DnDHelper
{
    public class Monster
    {
        public string name { get; set; }
        public string alignment { get; set; }
        public string challenge { get; set; }
        public string size { get; set; }
        public string xp { get; set; }
        public string type { get; set; }
        public string page { get; set; }
        public Dictionary<string,string> environment { get; set; }
    }
}
