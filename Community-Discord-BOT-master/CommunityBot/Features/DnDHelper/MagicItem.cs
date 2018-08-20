using System;
using System.Collections.Generic;
using System.Text;

namespace CommunityBot.Features.DnDHelper
{
    public class MagicItem
    {
        public string Name { get; set; }
        public string Rarity { get; set; }
        public string Type { get; set; }
        public string Page { get; set; }

        public override string ToString()
        {
            return $"{Name}\n Rarity: {Rarity}\n Type: {Type}\n Page Found: {Page}\n";
        }

    }
}
