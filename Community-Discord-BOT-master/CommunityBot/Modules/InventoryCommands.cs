using CommunityBot.Entities;
using CommunityBot.Featires.Inventory;
using CommunityBot.Features.GlobalAccounts;
using CommunityBot.Preconditions;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityBot.Features.Inventory;
using Newtonsoft.Json;
using System.Xml;

namespace CommunityBot.Modules
{
	/// <summary>
	/// 1D	Take in a command adding an item
	/// 2D	Take in a command looking for an item
	/// 3D	Take in a command deleting an item
	/// 4D	Take in a command to look at their inventory
	/// 5D	Take in a command for editing an item
	/// 6D	Parse JSON Objects
	/// </summary>
	public class InventoryCommands : ModuleBase<SocketCommandContext>
	{
		private GlobalUserAccount userAccount;

		/// <summary>
		/// The bot will take in a command like “~inventory” and print all their items to the user.
		/// </summary>
		[Command("inventory"), Alias("inv")]
		[Summary("DMs your inventory items to you <(inv)entory>")]
		[Cooldown(10)]
		public async Task GetInventory()
		{
			// catches and keeps msg from posting to discord channel publicly
			//await ( Context.Message.Channel as SocketTextChannel ).DeleteMessagesAsync(await Context.Message.Channel.GetMessagesAsync(1).FlattenAsync());

			// get the calling user
			userAccount = GlobalUserAccounts.GetUserAccount(Context.User.Id);
			//IGuildUser userComms = Context.Message.Author as IGuildUser;

			// create dm tube
			//var dmChannel = await userComms.GetOrCreateDMChannelAsync();

			string response = GetAllInvItems();

			if (response == null)
			{
				response = "Y U N0 HAVE STUFF?";
				//await dmChannel.SendMessageAsync("Y U N0 HAVE STUFF?", false);
			}
			else
			{
				response = "Your inventory itams... \n" + response;
			}

			await Context.Channel.SendMessageAsync(response);
			//await dmChannel.SendMessageAsync(response, false);
		}

		/// <summary>
		/// The bot will take in a command like “~addItem (name) (description) (att1:val1)...” to their own database that can persist that item.The key will be what the user has to search by to get their item.
		/// </summary>
		[Command("invadditem"), Alias("additem")]
		[Summary("Adds an item to your inventory (name~ description~ attName1:attValue1~ attName2:attValue2~ ...)")]
		[Cooldown(5)]
		public async Task AddItem([Remainder] string data)
		{//params string[] attributes
		 // get the calling user
			userAccount = GlobalUserAccounts.GetUserAccount(Context.User.Id);
			string msg = "";

			try
			{
				List<string> atts = data.Split('~').ToList();
				string name = atts[0].Trim();
				string description = atts[1].Trim();
				atts.RemoveRange(0, 2);

				if (!userAccount.Inv.AddToInv(name, description, atts))
				{
					throw new Exception();
				}

				msg = $"YAS! Added \"{name}\" to your inventory";
			}
			catch (Exception ex)
			{
				msg = "OH NOES! Your itam is broken, can't go into inventory.";
				//msg += "Make sure your format is right: \"name, description, att1:val1, att2:val2, etc..\"";
			}

			await Context.Channel.SendMessageAsync(msg, false);
		}

		/// <summary>
		/// The bot will take in a command like “~findItem(name)” and find that item from their database and return it to them by printing it.	
		/// </summary>
		[Command("invfinditem"), Alias("finditem")]
		[Summary("Finds an item in the inventory by its name")]
		[Cooldown(5)]
		public async Task FindItem(string name)
		{
			// get the calling user
			userAccount = GlobalUserAccounts.GetUserAccount(Context.User.Id);
			IGuildUser userComms = Context.Message.Author as IGuildUser;

			// create dm tube
			//var dmChannel = await userComms.GetOrCreateDMChannelAsync();

			string msg = "";

			try
			{
				Item[] itams = userAccount.Inv.GetItemByName(name);

				switch (itams.Length)
				{
					case 0:
						msg += "NO ITAMS by that name";
						break;
					case 1:
						msg += $"Found it! {GetItamStrings(itams)}";
						break;
					default:
						msg += $"DEEZ?\n {GetItamStrings(itams)}";
						break;
				}

				await Context.Channel.SendMessageAsync(msg);
				//dmChannel.SendMessageAsync(msg);
			}
			catch (Exception e)
			{
				throw e;
			}

		}

		/// <summary>
		/// The bot will take in a command like “~delItem (name)” and find that item from their inventory and delete it.
		/// </summary>
		[Command("invdelitem"), Alias("delitem")]
		[Summary("Deletes an item in the inventory by its name")]
		[Cooldown(5)]
		public async Task DeleteItem(string name)
		{
			// get the calling user
			userAccount = GlobalUserAccounts.GetUserAccount(Context.User.Id);
			//IGuildUser userComms = Context.Message.Author as IGuildUser;

			// create dm tube
			//var dmChannel = await userComms.GetOrCreateDMChannelAsync();

			string msg = "";

			try
			{
				if (userAccount.Inv.DeleteItemByName(name))
				{
					msg += "Kewl, deleted some stuffs..";
				}
			}
			catch (Exception e)
			{
				msg += $"Uh oh! - {e.Message}";
			}

			await Context.Channel.SendMessageAsync(msg);
			//dmChannel.SendMessageAsync(msg);
		}

		/// <summary>
		/// The bot will take in a command like “~edititem (name) (propertyName:newValue) and will update the key’s data to the newly passed data.
		/// </summary>
		[Command("invedititem"), Alias("edititem")]
		[Summary("Edits an item in the inventory by its name, using a key:value pair to update information")]
		[Cooldown(5)]
		public async Task EditItem([Remainder] string data)
		{
			// get the calling user
			userAccount = GlobalUserAccounts.GetUserAccount(Context.User.Id);
			string msg = "";

			try
			{
				List<string> fields = data.Trim().Split('~').ToList();
				string name = fields[0];
				fields.RemoveAt(0);

				if (userAccount.Inv.UpdateItem(name, fields))
				{
					msg += "Oh yeah, Got them updates!";
				}
				else
				{
					msg += "No such itam!";
				}
			}
			catch (Exception)
			{
				throw;
			}

			await Context.Channel.SendMessageAsync(msg);
		}

		/// <summary>
		/// The bot has to be able to parse from JSON formatted text and display JSON objects in an easier to read way.
		/// </summary>
		[Command("invaddjson"), Alias("addjson")]
		[Summary("Edits an item in the inventory by its name, using a key:value pair to update information")]
		[Cooldown(5)]
		public async Task AddJson([Remainder] string jsonText)
		{
			// get the calling user
			userAccount = GlobalUserAccounts.GetUserAccount(Context.User.Id);
			userAccount.Inv = JsonConvert.DeserializeObject<Inventory>(jsonText);

			await Context.Channel.SendMessageAsync("RIGHTEOUS, we got itams!");
		}

		/// <summary>
		/// The bot will take in a command like “~inventory” and print all their items to the user.
		/// </summary>
		[Command("invgetjson"), Alias("getjson")]
		[Summary("Gets the entire inventory in JSON or just the item with the given name")]
		[Cooldown(10)]
		public async Task GetJson([Remainder] string name = null)
		{
			// get the calling user
			userAccount = GlobalUserAccounts.GetUserAccount(Context.User.Id);
			// get json response
			string msg = "Your inventory itams... \n" + userAccount.Inv.ToJson(name);
			// send json response
			await Context.Channel.SendMessageAsync(msg);
		}

		/// <summary>
		/// The bot will take in a command like “~inventory” and print all their items to the user.
		/// </summary>
		[Command("clearmyinventory")]
		[Summary("DELETES ALL ITEMS from the inventory")]
		[Cooldown(10)]
		public async Task ClearInventory([Remainder] string confirmer = "nope")
		{
			// get the calling user
			userAccount = GlobalUserAccounts.GetUserAccount(Context.User.Id);
			string msg = "";

			if (confirmer.Equals("LEEROY JENKINS"))
			{
				userAccount.Inv.Clear();
				msg += "WAT DID YOO DO!? ITAMS ARE ALL DED!";
			}
			else
			{
				msg += "\t\t If you REALLY want to delete your inventory, send \"clearmyinventory LEEROY JENKINS\"";
			}

			await Context.Channel.SendMessageAsync(msg);
		}

		private string GetAllInvItems()
		{
			string res = null;

			if (userAccount.Inv.Size > 0)
			{
				res = userAccount.Inv.ToString();
			}

			return res;
		}

		private string GetItamStrings(params Item[] itams)
		{
			StringBuilder sb = new StringBuilder();

			foreach (Item itm in itams)
			{
				sb.Append($"{itm.ToString()}\n");

			}
			return sb.ToString();
		}


	} // end class
}
