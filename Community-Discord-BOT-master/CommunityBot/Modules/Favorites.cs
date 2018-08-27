using CommunityBot.Features.GlobalAccounts;
using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace CommunityBot.Modules
{
    public class Favorites : ModuleBase<SocketCommandContext>
    {

        /// <summary>
        /// this method adds both the site and input the user has specified to the user's Favorites 
        /// </summary>
        /// <param name="site">the website the user wants to add</param>
        /// <param name="input">the phrase the user enters to access it</param>
        /// <returns></returns>
        [Command("addFav"), Alias("addf", "addfav", "add fav"), Summary("Adds a favorite link to the user's favorites list using a phrase and a link. For example addFav \"website\" \"phrase\"")]
        public async Task AddFavorite(string site, [Remainder]string input)
        {
            string responce = "";
            string link = !site.Contains("http://") && !site.Contains("http://") ? $"http://{site}" : site;
            if (IsUrlValid(site))
            {
                var account = GlobalUserAccounts.GetUserAccount(Context.User.Id);
                account.Favorites.Add(input, link);
                GlobalUserAccounts.SaveAccounts(Context.User.Id);
                responce = $"{link} successfully saved to the phrase {input}";
            }
            else
            {
                responce = $"{link} is an invalid link";
            }

            await Context.Channel.SendMessageAsync(responce);

        }
        /// <summary>
        /// this method gets the link that user wants to open in their browser
        /// </summary>
        /// <param name="phrase"></param>
        /// <returns></returns>
        [Command("fetchFav"), Alias("ff", "fetch fav", "fetchfav", "fetch"), Summary("Gets a user's favorite at the specified phrase location. For example fetchFav \"phrase\"")]
        public async Task FetchLink([Remainder]string phrase)
        {
            string responce = "";
            var account = GlobalUserAccounts.GetUserAccount(Context.User.Id);

            if (account.Favorites.ContainsKey(phrase))
            {
                responce = $"Successfully fetched {account.Favorites[phrase]}";
            }

            await Context.Channel.SendMessageAsync(responce);

        }

        [Command("rmFav"), Alias("rmfav", "rm fav", "rmf"), Summary("Removes a favorite link from the user's favorites list using a phrase. For example rmFav \"phrase\"")]
        public async Task RemoveFav([Remainder]string phrase)
        {
            var account = GlobalUserAccounts.GetUserAccount(Context.User.Id);

            if (account.Favorites.ContainsKey(phrase))
            {
                account.Favorites.Remove(phrase);
                GlobalUserAccounts.SaveAccounts(Context.User.Id);
            }

            await Context.Channel.SendMessageAsync($"Removed: {phrase}");

        }

        [Command("showFavs"), Alias("show fav", "showfav", "showFav", "showfavs", "showf"), Summary("Show the user's favorites saved")]
        public async Task ShowFavs()
        {
            StringBuilder stringBuilder = new StringBuilder();
            var account = GlobalUserAccounts.GetUserAccount(Context.User.Id);
            
            foreach(var keyValue in account.Favorites)
            {
                stringBuilder.Append($" {keyValue.Key}: {keyValue.Value}\n");
            }
            
            await Context.Channel.SendMessageAsync(stringBuilder.ToString());
        }

        [Command("clearFavs"), Alias("clearfavs", "clearfav", "clearFav", "clearF"), Summary("Removes all of the user's favorites they saved")]
        public async Task ClearFavs()
        {
            var account = GlobalUserAccounts.GetUserAccount(Context.User.Id);
            account.Favorites.Clear();
            GlobalUserAccounts.SaveAccounts(account.Id);
            await Context.Channel.SendMessageAsync("Favorites Cleared");

        }

        /// <summary>
        /// This method checks if the url is formated correctly.
        /// </summary>
        /// <param name="uriName">the name of the link</param>
        /// <returns></returns>
        private bool IsUrlValid(string uriName)
        {
            return Uri.IsWellFormedUriString(uriName, UriKind.RelativeOrAbsolute);
        }

    }
}
