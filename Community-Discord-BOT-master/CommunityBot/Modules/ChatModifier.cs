using CommunityBot.Preconditions;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityBot.Handlers;
using Discord;
using Discord.WebSocket;
using System.Net;
using System.Net.Http;
using System.Xml;
using HtmlAgilityPack;
using CommunityBot.Features.GlobalAccounts;

namespace CommunityBot.Modules
{
    public class ChatModifier : ModuleBase<SocketCommandContext>
    {
        [Command("anon"), Alias("a")]
        [Summary("Sends an anonymous message to the channel <(a)non (message)>")]
        [Cooldown(5)]
        public async Task AnonMessage([Remainder] string message)
        {
            await (Context.Message.Channel as SocketTextChannel).DeleteMessagesAsync(await Context.Message.Channel.GetMessagesAsync(1).FlattenAsync());
            await Context.Channel.SendMessageAsync("Someone says:\n" + message);
        }

        [Command("dm"), Alias("d")]
        [Summary("Sends an anonymous message to the the user specified <(d)m (@user) (message)>")]
        [Cooldown(5)]
        public async Task AnonMessageToUser(IGuildUser target, [Remainder] string message)
        {
            await (Context.Message.Channel as SocketTextChannel).DeleteMessagesAsync(await Context.Message.Channel.GetMessagesAsync(1).FlattenAsync());

            var dmChannel = await target.GetOrCreateDMChannelAsync();
            var contextString = Context.Guild?.Name ?? "DMs with me";

            await Context.Channel.SendMessageAsync("Sent to " + target.Mention);
            await dmChannel.SendMessageAsync("Someone sends thier regards: " + message, false);
        }

        [Command("color"), Alias("c")]
        [Cooldown(5)]
        [Summary("Change the color for the message sent <(c)olor (red, green, orange) (message)>")]
        public async Task ColorMessage(string color, [Remainder] string message)
        {
            await (Context.Message.Channel as SocketTextChannel).DeleteMessagesAsync(await Context.Message.Channel.GetMessagesAsync(1).FlattenAsync());
            string messageToPrint = "```";
            switch (color.ToLower())
            {
                case "red":
                    messageToPrint += @"diff
- " + message + "```";
                    break;
                case "green":
                    messageToPrint += @"diff
+ " + message + "```";
                    break;
                case "orange":
                    messageToPrint += @"fix
" + message + "```";
                    break;
                default:
                    messageToPrint = Context.User.Mention + ", cannot find the color specified! Available colors: (Red, Orange, Green)";
                    break;
            }
            await Context.Channel.SendMessageAsync(Context.User.Username + " says: " + messageToPrint);
        }

        [Command("acolor"), Alias("ac")]
        [Cooldown(5)]
        [Summary("Change the color for the anonymous message sent <(c)olor (red, green, orange) (message)>")]
        public async Task AnonymousColorMessage(string color, [Remainder] string message)
        {
            await (Context.Message.Channel as SocketTextChannel).DeleteMessagesAsync(await Context.Message.Channel.GetMessagesAsync(1).FlattenAsync());
            string messageToPrint = "```";
            switch (color.ToLower())
            {
                case "red":
                    messageToPrint += @"diff
- " + message + "```";
                    break;
                case "green":
                    messageToPrint += @"diff
+ " + message + "```";
                    break;
                case "orange":
                    messageToPrint += @"fix
" + message + "```";
                    break;
                default:
                    messageToPrint = "Cannot find the color specified! Available colors: (Red, Orange, Green)";
                    break;
            }
            await Context.Channel.SendMessageAsync("Someone says: " + messageToPrint);
        }

        [Command("font"), Alias("f")]
        [Cooldown(5)]
        [Summary("Change the font for the message sent <(f)ont (font type) (message)>")]
        public async Task FontMessage(string font, [Remainder] string message)
        {
            await (Context.Message.Channel as SocketTextChannel).DeleteMessagesAsync(await Context.Message.Channel.GetMessagesAsync(1).FlattenAsync());
            //http://qaz.wtf/u/convert.cgi?text=Message+here

            List<HtmlNode> list = new List<HtmlNode>();

            var html = new HtmlDocument();
            html.LoadHtml(new WebClient().DownloadString("http://qaz.wtf/u/convert.cgi?text=" + message));
            var root = html.DocumentNode;
            var anchors = root.Descendants("tr");
            anchors.ToList().ForEach(x => list.Add(x));

            bool found = false;
            string unicodeMessage = "";
            foreach (HtmlNode node in list)
            {
                if (node.FirstChild.FirstChild.InnerHtml.ToLower() == font.ToLower())
                {
                    unicodeMessage = WebUtility.HtmlDecode(node.LastChild.InnerHtml);
                    found = true;
                    continue;
                }
            }

            if (found)
            {
                await Context.Channel.SendMessageAsync(Context.User.Username + " says: " + unicodeMessage);
            }
            else
            {
                await Context.Channel.SendMessageAsync(Context.User.Mention + ", something went wrong, go here to find available fonts: http://qaz.wtf/u/convert.cgi?text=" + message);
            }
        }

        [Command("afont"), Alias("af")]
        [Cooldown(5)]
        [Summary("Change the font for the anonymous message sent <(af)ont (font type) (message)>")]
        public async Task AnonymousFontMessage(string font, [Remainder] string message)
        {
            await (Context.Message.Channel as SocketTextChannel).DeleteMessagesAsync(await Context.Message.Channel.GetMessagesAsync(1).FlattenAsync());
            //http://qaz.wtf/u/convert.cgi?text=Message+here

            List<HtmlNode> list = new List<HtmlNode>();

            var html = new HtmlDocument();
            html.LoadHtml(new WebClient().DownloadString("http://qaz.wtf/u/convert.cgi?text=" + message));
            var root = html.DocumentNode;
            var anchors = root.Descendants("tr");
            anchors.ToList().ForEach(x => list.Add(x));

            bool found = false;
            string unicodeMessage = "";
            foreach (HtmlNode node in list)
            {
                if (node.FirstChild.FirstChild.InnerHtml.ToLower() == font.ToLower())
                {
                    unicodeMessage = WebUtility.HtmlDecode(node.LastChild.InnerHtml);
                    found = true;
                    continue;
                }
            }

            if (found)
            {
                await Context.Channel.SendMessageAsync("Someone says: " + unicodeMessage);
            }
            else
            {
                await Context.Channel.SendMessageAsync("Something went wrong, go here to find available fonts: http://qaz.wtf/u/convert.cgi?text=" + message);
            }
        }
    }
}