using CommunityBot.Entities;
using CommunityBot.Features.GlobalAccounts;
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
	/// <summary>
	/// All inventory commands go here
	/// </summary>
	public class InventoryCommands : ModuleBase<SocketCommandContext>
	{
		[Command("inventory"), Alias("inv")]
		[Summary("DMs your inventory items to you <(inv)entory>")]
		[Cooldown(10)]
		public async Task GetInventory()
		{
			// catches and keeps msg from posting to discord channel publicly
			await ( Context.Message.Channel as SocketTextChannel ).DeleteMessagesAsync(await Context.Message.Channel.GetMessagesAsync(1).FlattenAsync());

			// get the calling user
			IGuildUser user = Context.Message.Author as IGuildUser;

			// create dm tube
			var dmChannel = await user.GetOrCreateDMChannelAsync();

			// 
			//var contextString = Context.Guild?.Name ?? "DMs with me";

			await dmChannel.SendMessageAsync("You inventory contents: \n" + GetAllInvItems(), false);
			//await ( Context.Message.Author as SocketUser ).SendMessageAsync(GetAllInvItems());
		}

		private string GetAllInvItems()
		{
			var account = GlobalUserAccounts.GetUserAccount(Context.User.Id);
			return account.Inv.ToString();
		}
	}
}
