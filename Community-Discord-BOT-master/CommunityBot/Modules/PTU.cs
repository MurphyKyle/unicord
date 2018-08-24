using CommunityBot.Features.Economy;
using CommunityBot.Features.GlobalAccounts;
using Discord;
using Discord.Commands;
using System.Linq;
using System.Threading.Tasks;
using static CommunityBot.Features.Economy.Daily;
using static CommunityBot.Global;
using static CommunityBot.Features.Economy.Transfer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using System.Net;
using System.Xml;

namespace CommunityBot.Modules
{
    public class PTU : ModuleBase<SocketCommandContext>
	{
		[Command("spawn" ), Remarks("says hi back")]
		public async Task SpawnThemAll(int qty, string pkmon = "pokemon", int min_lvl = 0, int max_lvl = 100)
		{

			pkmon.ToLower();

			var html = new HtmlDocument();
			html.LoadHtml(new WebClient().DownloadString($"http://www.ptu.panda-games.net/scripts/generate_pokemon.php?" +
				$"generation_type={(!pkmon.Equals("pokemon") ? "specific" : "all")}&" +
				$"generation_choice={(!pkmon.Equals("pokemon") ? pkmon.First().ToString().ToUpper() + pkmon.Substring(1) : "Any%20Pokemon")}" +
				$"&min_level={(min_lvl <= max_lvl ? min_lvl : 0)}" +
				$"&max_level={(min_lvl <= max_lvl ? max_lvl : 100)}" +
				$"&inc_legend=false" +
				$"&inc_shiny=true" +
				$"&limit_evo=false" +
				$"&evo_limit=Zero&amount={qty}" +
				$"&spec_nature=false" +
				$"&selected_nature=1" +
				$"&inc_start=true" +
				$"&two_step=false" +
				$"&generation_type2=gen" +
				$"&generation_choice2=Generation%20One%20Pokemon" +
				$"&inc_tms=true" +
				$"&tm_amount=random"));
			var root = html.DocumentNode;
			var descendants = root.Descendants("div");



			foreach (var node in descendants)
			{
				var embed = new EmbedBuilder();
				var infoTable = node.Descendants("table").ElementAt(0).Descendants("tr");
				var statTable = node.Descendants("table").ElementAt(1).Descendants("tr");
				var AbilityTable = node.Descendants("table").ElementAt(5).Descendants("tr");
				var MoveTable = node.Descendants("table").ElementAt(6).Descendants("tr");

				string species = infoTable.ElementAt(0).Descendants("th").ElementAt(0).InnerText;
				string pkmonImg = ImgUrl(infoTable.ElementAt(1).Descendants("td").ElementAt(0).InnerHtml);
				string lvl = infoTable.ElementAt(2).Descendants("td").ElementAt(0).InnerText;
				string gender = infoTable.ElementAt(3).Descendants("td").ElementAt(0).InnerText;
				string nature = infoTable.ElementAt(6).Descendants("td").ElementAt(0).InnerText.Substring(8);
				string[] type = new string[2];
				string[] types = { findType(infoTable.ElementAt(7).Descendants("td").ElementAt(0).Descendants().ElementAt(3).OuterHtml),
				(infoTable.ElementAt(7).Descendants("td").ElementAt(0).Descendants().Count() == 5 ? findType(infoTable.ElementAt(7).Descendants("td").ElementAt(0).Descendants().ElementAt(4).OuterHtml) : "")};
				//not using yet
				string capabilities = infoTable.ElementAt(9).Descendants("td").ElementAt(0).InnerText;
				string skills = infoTable.ElementAt(10).Descendants("td").ElementAt(0).InnerText;
				//
				string[] topRow = { "Stats", "Base", "Total" };
				string[] HPStat = { "HP", statTable.ElementAt(1).Descendants("td").ElementAt(0).InnerText, statTable.ElementAt(1).Descendants("td").ElementAt(1).InnerText};
				string[] AtkStat = { "Atk", statTable.ElementAt(2).Descendants("td").ElementAt(0).InnerText, statTable.ElementAt(2).Descendants("td").ElementAt(1).InnerText };
				string[] DefStat = { "Def", statTable.ElementAt(3).Descendants("td").ElementAt(0).InnerText, statTable.ElementAt(3).Descendants("td").ElementAt(1).InnerText };
				string[] SpAtkStat = { "SpAtk", statTable.ElementAt(4).Descendants("td").ElementAt(0).InnerText, statTable.ElementAt(4).Descendants("td").ElementAt(1).InnerText };
				string[] SpDefStat = { "SpDef", statTable.ElementAt(5).Descendants("td").ElementAt(0).InnerText, statTable.ElementAt(5).Descendants("td").ElementAt(1).InnerText };
				string[] SpeedStat = { "Speed", statTable.ElementAt(6).Descendants("td").ElementAt(0).InnerText, statTable.ElementAt(6).Descendants("td").ElementAt(1).InnerText };
				List<string> abilities = new List<string>();
				List<string> moves = new List<string>();

				for(int i = 1; i < AbilityTable.Count(); i += 8)
				{
					string name = "**" + AbilityTable.ElementAt(i).InnerText + "** - ";
					string freq = AbilityTable.ElementAt(i + 2).Descendants("td").ElementAt(1).InnerText.Trim() == "-" ? "" : AbilityTable.ElementAt(i + 2).Descendants("td").ElementAt(1).InnerText + " - ";
					string trigger = AbilityTable.ElementAt(i + 3).Descendants("td").ElementAt(1).InnerText.Trim() == "-" ? "" : AbilityTable.ElementAt(i + 3).Descendants("td").ElementAt(1).InnerText + " - ";
					string target = AbilityTable.ElementAt(i + 4).Descendants("td").ElementAt(1).InnerText.Trim() == "-" ? "" : AbilityTable.ElementAt(i + 4).Descendants("td").ElementAt(1).InnerText + " - ";
					string range = AbilityTable.ElementAt(i + 5).Descendants("td").ElementAt(1).InnerText.Trim() == "-" ? "" : AbilityTable.ElementAt(i + 5).Descendants("td").ElementAt(1).InnerText + " - ";
					string pg = AbilityTable.ElementAt(i + 6).InnerText;

					abilities.Add($"{name + freq + trigger + target + range}\n{pg}");
				}

				for(int i = 1; i < MoveTable.Count(); i += 11)
				{
					string name = "**" + MoveTable.ElementAt(i).InnerText + "** - ";
					string freq = MoveTable.ElementAt(i + 2).Descendants("td").ElementAt(1).InnerText.Trim() == "-" ? "" : MoveTable.ElementAt(i + 2).Descendants("td").ElementAt(1).InnerText + " - ";
					var moveType = findType(MoveTable.ElementAt(i + 3).Descendants("td").ElementAt(1).InnerHtml) + " - ";
					string AC = MoveTable.ElementAt(i + 5).Descendants("td").ElementAt(1).InnerText.Trim() == "-" ? "" : "AC: " + MoveTable.ElementAt(i + 5).Descendants("td").ElementAt(1).InnerText + " - ";
					string thatsAlotOfDamage = MoveTable.ElementAt(i + 6).Descendants("td").ElementAt(1).InnerText.Trim() == "-" ? "" : formatDamage(MoveTable.ElementAt(i + 6).Descendants("td").ElementAt(1).InnerText) + " - ";
					string range = MoveTable.ElementAt(i + 7).Descendants("td").ElementAt(1).InnerText.Trim() == "-" ? "" : MoveTable.ElementAt(i + 7).Descendants("td").ElementAt(1).InnerText + " - ";
					string pg = MoveTable.ElementAt(i + 9).InnerText;

					moves.Add(name + freq + moveType + AC + thatsAlotOfDamage + range + "\n" + pg);
				}
				


				switch (gender) {
					case "Gender: Male":
						gender = "♂";
						embed.WithColor(137, 207, 240);
						break;
					case "Gender: Female":
						gender = "♀";
						embed.WithColor(240, 98, 146);
						break;
					default:
						gender = "⚲";
						embed.WithColor(128, 128, 218);
						break;
				}

				string l1 = species + " " + gender;
				string l3 = lvl + " " + nature;
				string l4 = types[0] + "/" + types[1];
				string l5 = HPStat[1] + "\t" + HPStat[0] + "\t" + HPStat[2] + "\n"
					+ AtkStat[1] + "\t" + AtkStat[0] + "\t" + AtkStat[2] + "\n"
					+ DefStat[1] + "\t" + DefStat[0] + "\t" + DefStat[2] + "\n"
					+ SpAtkStat[1] + "\t" + SpAtkStat[0] + "\t" + SpAtkStat[2] + "\n"
					+ SpDefStat[1] + "\t" + SpDefStat[0] + "\t" + SpDefStat[2] + "\n"
					+ SpeedStat[1] + "\t" + SpeedStat[0] + "\t" + SpeedStat[2];
				string l6 = String.Join("\n", abilities);
				string l7 = String.Join("\n", moves);
				string l8 = capabilities;
				string l9 = skills;

				embed.WithTitle(l1);
				embed.WithThumbnailUrl(pkmonImg);
				embed.WithDescription($"{l3}\n{l4}\n{l5}\n\n{l6}\n\n{l7}\n\n{l8}\n{l9}");

				await Context.Channel.SendMessageAsync("", embed: embed.Build());
			}


		}
		//<img src="images/types/14.png" alt="14">
		private string findType(string tag)
		{
			tag = tag.Substring(tag.IndexOf('\'')+1);
			tag = tag.Substring(tag.IndexOf('\'')+1);
			tag = tag.Substring(tag.IndexOf('\'') + 1);
			string elementNum = tag.Substring(0, tag.Length-2);

			switch (elementNum)
			{
				case "1":
					tag = "Bug";
					break;
				case "2":
					tag = "Dark";
					break;
				case "3":
					tag = "Dragon";
					break;
				case "4":
					tag = "Electric";
					break;
				case "5":
					tag = "Fairy";
					break;
				case "6":
					tag = "Fighting";
					break;
				case "7":
					tag = "Fire";
					break;
				case "8":
					tag = "Flying";
					break;
				case "9":
					tag = "Ghost";
					break;
				case "10":
					tag = "Grass";
					break;
				case "11":
					tag = "Ground";
					break;
				case "12":
					tag = "Ice";
					break;
				case "13":
					tag = "Normal";
					break;
				case "14":
					tag = "Poison";
					break;
				case "15":
					tag = "Psychic";
					break;
				case "16":
					tag = "Rock";
					break;
				case "17":
					tag = "Steel";
					break;
				case "18":
					tag = "Water";
					break;
				default:
					break;
			}

			return tag;

		}

		private string formatDamage(string allDamage)
		{
			string i1 = allDamage.Substring(allDamage.IndexOf(':') + 2);
			string i2 = i1.Substring(0, i1.IndexOf(':') - 10);
			return i2;
		}

		private string ImgUrl(string tag)
		{
			int firstIndex = tag.IndexOf('\'');
			int secondIndex = tag.IndexOf('\'', firstIndex + 1);
			int range = secondIndex - firstIndex;

			return $"http://www.ptu.panda-games.net/{tag.Substring(firstIndex + 1, range - 1)}";
		}
    }
}
