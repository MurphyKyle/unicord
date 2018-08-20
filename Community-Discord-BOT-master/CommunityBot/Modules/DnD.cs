using CommunityBot.Features.DnDHelper;
using CommunityBot.Features.GlobalAccounts;
using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CommunityBot.Modules
{
    //embed.WithColor(70, 5, 120); -- boss color
    public class DnD : ModuleBase<SocketCommandContext>
    {
        private Random randy = new Random();
        [Command("Encounter"), Remarks("Generates a random ancounter given the parameters")]
        [Alias("Fight", "fight")]
        public async Task GenerateFight(string cr, string amount = "1")
        {
            int j = 0;
            Int32.TryParse(amount, out j);
            var embed = new EmbedBuilder();
            float challengeRating = 0;
            float.TryParse(cr, out challengeRating);
            if (challengeRating <= 0 || challengeRating > 25)
            {
                embed.WithDescription("You are either way too nice or far too evil. Choose a CR between 1 and 25\n");
                embed.WithTitle("Um........no");
                embed.WithColor(255, 0, 0);
            }
            else
            {
                if (j > 20)
                {
                    embed.WithDescription("While i respect your zeal that is just too many monsters \n");
                    embed.WithTitle("Too many monsters!");
                    embed.WithColor(255, 0, 0);
                }
                else
                {
                    embed.WithDescription("The monsters: \n");
                    for (int i = j; i > 0; i--)
                    {
                        embed.Description += (DnDHelperClass.ParseMonsters(cr) + "\n\n");
                    }
                    embed.WithTitle("Your party is attacked!");
                    embed.WithColor(255, 0, 0);
                }
            }
            await Context.Channel.SendMessageAsync("", embed: embed.Build());
        }
        [Command("Encounter"), Remarks("Generates a truly random encounter")]
        [Alias("Fight", "fight")]
        public async Task GenerateFight()
        {
            var embed = new EmbedBuilder();
            embed.WithDescription("The monsters: \n");
            for (int i = randy.Next(1,10); i > 0; i--)
            {
                embed.Description += (DnDHelperClass.ParseMonsters((randy.Next(1,25)).ToString()) + "\n\n");
            }
            embed.WithTitle("Your party is attacked!");
            embed.WithColor(255, 0, 0);

            await Context.Channel.SendMessageAsync("", embed: embed.Build());
        }

        [Command("Treasure"), Remarks("Generates a truly random encounter")]
        [Alias("Loot", "loot")]
        public async Task GenerateLoot(int partyLevel, int partySize = 1)
        {
            var embed = new EmbedBuilder();
            embed.WithDescription("The Loot! \n");
            for (int i = randy.Next(1,partySize); i > 0; i--)
            {
                embed.Description += (DnDHelperClass.ParseMagicItems(partyLevel) + "\n\n");
            }
            embed.WithTitle("Your party found:");
            embed.WithColor(0, 255, 0);

            await Context.Channel.SendMessageAsync("", embed: embed.Build());
        }
        [Command("RollStats"), Remarks("Generates Random stats")]
        [Alias("Stats", "stats")]
        public async Task RollStats()
        {
            var embed = new EmbedBuilder();
            embed.Description += "**4d6(dropping lowest die) stats**\n";
            Dictionary<string, int> stats3d6 = new Dictionary<string, int> {
                { "Strength", RollSingleStat() },
                { "Dexterity", RollSingleStat() },
                { "Constitution", RollSingleStat() },
                { "Intelligence", RollSingleStat() },
                { "Wisdom", RollSingleStat() },
                { "Charisma", RollSingleStat() }
            };
            foreach (KeyValuePair<string,int> item in stats3d6)
            {
                embed.Description += $"{item.Key}:{item.Value}\n";
            }
            embed.Description += "\n**1d20 stats**\n";
            Dictionary<string, int> stats1d20 = new Dictionary<string, int> {
                { "Strength", randy.Next(1,20) },
                { "Dexterity", randy.Next(1,20) },
                { "Constitution", randy.Next(1,20) },
                { "Intelligence", randy.Next(1,20) },
                { "Wisdom", randy.Next(1,20) },
                { "Charisma", randy.Next(1,20) }
            };
            foreach (KeyValuePair<string, int> item in stats1d20)
            {
                embed.Description += $"{item.Key}:{item.Value}\n";
            }
            embed.WithTitle("Da Stats:");
            embed.WithColor(170, 5, 120);

            await Context.Channel.SendMessageAsync("", embed: embed.Build());
        }

        public int RollSingleStat()
        {
            int lowestNum = 6;
            int index = 0;
            int[] rolls = { randy.Next(1, 6), randy.Next(1, 6), randy.Next(1, 6), randy.Next(1, 6) };
            for (int i = 0; i < rolls.Length; i++)
            {
                if (rolls[i] < lowestNum)
                {
                    lowestNum = rolls[i];
                    index = i;
                }
            }
            rolls[index] = 0;
            int total = 0;
            foreach (int item in rolls)
            {
                total += item;
            }
            if (lowestNum == 6)
            {
                return 24;
            }
            return total;
        }
    }
}
