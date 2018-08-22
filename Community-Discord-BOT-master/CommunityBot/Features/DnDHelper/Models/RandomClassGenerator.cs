using System;
using System.Collections.Generic;
using System.Text;

namespace CommunityBot.Features.DnDHelper.Models
{
    public class RandomClassGenerator
    {
        private Random randy = new Random();
        public string Class { get; set; }
    }
}
