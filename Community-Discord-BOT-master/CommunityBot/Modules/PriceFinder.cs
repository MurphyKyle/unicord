using Discord;
using Discord.Commands;
using HtmlAgilityPack;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CommunityBot.Modules
{
    public class PriceFinder : ModuleBase<SocketCommandContext>
    {
        private Dictionary<string, List<Tuple<string, string>>> FoodItemsAndPrices = new Dictionary<string, List<Tuple<string, string>>>();

        [Command("priceFor")]
        [Summary("You can check the price of the top 5 products from stores like Walmart, Harmons, Sam's: ex. priceFor \"name of item\"")]
        public async Task FindPriceForFood([Remainder]string food)
        {
            var walmartHtml = GetRoot($"https://www.walmart.com/search/?query={food}&cat_id=0");
            var targetJson = GetJSONRoot($"https://redsky.target.com/v1/plp/search/?count=24&offset=0&keyword={food}&default_purchasability_filter=true&store_ids=2641%2C2609%2C768%2C1751%2C1750%2C2150%2C1752%2C2123%2C1755%2C1814%2C1753%2C1754&visitorId=016563622E180201AB289F871F207095&pageId=%2Fs%2Fcheese&channel=web");
            GetWalmartTop5Products(walmartHtml);
            GetTop5TargetProducts(targetJson);

            var embed = new EmbedBuilder();
            embed.WithTitle($"Top 5 products for {food}");
            embed.WithColor(240, 98, 16);

            await Context.Channel.SendMessageAsync("", embed: embed.Build());
        }

        private void GetWalmartTop5Products(HtmlDocument html)
        {
            var firstItem = html.DocumentNode.SelectSingleNode("//*[@class=\"Grid-col u-size-6-12 u-size-1-4-m u-size-1-5-xl search-gridview-first-col-item\"]");
            var middleItems = html.DocumentNode.SelectNodes("//*[@class=\"Grid-col u-size-6-12 u-size-1-4-m u-size-1-5-xl\"]");
            var lastItem = html.DocumentNode.SelectSingleNode("//*[@class=\"Grid-col u-size-6-12 u-size-1-4-m u-size-1-5-xl search-gridview-last-col-item\"]");
            while (middleItems.Count > 3)
            {
                middleItems.RemoveAt(middleItems.Count - 1);
            }
            middleItems.Insert(0, firstItem);
            middleItems.Add(lastItem);
            foreach(var foodNode in middleItems)
            {
                var productName = foodNode.SelectSingleNode(".//*[@class=\"product-title-link line-clamp line-clamp-2\"]").InnerText;
                var productPrice = foodNode.SelectSingleNode(".//*[@class=\"price display-inline-block arrange-fit price price-main\"]").InnerText;      
                if(!FoodItemsAndPrices.ContainsKey("Walmart"))
                {
                    FoodItemsAndPrices.Add("Walmart", new List<Tuple<string, string>>() { new Tuple<string, string>(productName, productPrice) });
                }
                else
                {
                    FoodItemsAndPrices["Walmart"].Add(new Tuple<string, string>(productName, productPrice));
                }
            }
        }

        private void GetTop5TargetProducts(JObject json)
        {
            //This weird line allows us to get all the way to the Item list
            IList<JToken> items = (IList<JToken>)json.Last.First.First.First.First.First;
            int index = 0;
            int count = 0;
            while (count < 5)
            {
                JToken token = items[index];
                index++;
                var itemAttributes = token.Children();
                var offerPriceChidren = itemAttributes.ElementAt(27).First;
                if (offerPriceChidren.ToString().Equals("Only At Target"))
                {
                    continue;
                }
                //priceKeyValue is the string representation of "price": ($0.00).
                string priceKeyValue = offerPriceChidren.ElementAt(0).ToString();
                /*
                 *  We take priceKeyValue and split it on the ':' which makes it an array. 
                 *  Then we get the price string from index 1, and trim the whitespace.
                 */
                string productPrice = priceKeyValue.Split(':')[1].Trim();
                // We split the itemAttributes so we can separate the titel from the unwanted data.
                string[] splitItemArray = itemAttributes.ElementAt(3).ToString().Split('"');
                // The product name is always on index 3 with the way target's JSON file is formatted.
                string productName = splitItemArray[3];

                if (!FoodItemsAndPrices.ContainsKey("Target"))
                {
                    FoodItemsAndPrices.Add("Target", new List<Tuple<string, string>>() { new Tuple<string, string>(productName, productPrice) });
                }
                else
                {
                    FoodItemsAndPrices["Target"].Add(new Tuple<string, string>(productName, productPrice));
                }
                count++;
            }
        }

        private void GetHarmonsTop5Products(JObject json)
        {
            string harmonsJSONString = json.ToString();
        }

        private HtmlDocument GetRoot(string website)
        {
            var html = new HtmlDocument();
            html.LoadHtml(new WebClient().DownloadString(website));
            return html;
        }

        private JObject GetJSONRoot(string website)
        {
            string jsonString = new WebClient().DownloadString(website);
            JObject jsonObject = (JObject)Newtonsoft.Json.JsonConvert.DeserializeObject(jsonString);
            return jsonObject;
        }

       

    }
}
