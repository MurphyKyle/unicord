using CommunityBot.Preconditions;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CommunityBot.Modules
{
	public class Inventory : ModuleBase<SocketCommandContext>
	{

		[Command("anon"), Alias("a")]
		[Summary("Sends an anonymous message to the channel <(a)non (message)>")]
		[Cooldown(5)]
		public async Task AnonMessage([Remainder] string message)
		{
			await ( Context.Message.Channel as SocketTextChannel ).DeleteMessagesAsync(await Context.Message.Channel.GetMessagesAsync(1).FlattenAsync());
			await Context.Channel.SendMessageAsync("Someone says:\n" + message);
		}
	}
}
