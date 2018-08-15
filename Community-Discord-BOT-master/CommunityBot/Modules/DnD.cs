using CommunityBot.Features.DnDHelper;
using CommunityBot.Features.GlobalAccounts;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CommunityBot.Modules
{
    public class DnD : ModuleBase<SocketCommandContext>
    {
        [Command("Encounter"), Remarks("Shows how many Miunies you have")]
        [Alias("Fight", "fight")]
        public async Task GenerateFight(string cr)
        {
            await Context.Channel.SendMessageAsync(RandomEncounter.GetEncounter(cr));
        }
    }
}
