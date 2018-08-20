using CommunityBot.Features.DnDHelper;
using CommunityBot.Features.GlobalAccounts;
using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CommunityBot.Modules
{
    public class DnD : ModuleBase<SocketCommandContext>
    {
        [Command("Encounter"), Remarks("Shows how many Miunies you have")]
        [Alias("Fight", "fight")]
        public async Task GenerateFight(string cr)
        {
            //await Context.Channel.SendMessageAsync(RandomEncounter.GetEncounter(cr));
        }

        [Command("sheet")]
        public async Task CharacterSheetSave(string stat, [Remainder]string value)
        {
            bool valid = true;
            string retVal = $"Successfully added ";
            var account = GlobalUserAccounts.GetUserAccount(Context.User.Id);
            int test = 0;
            switch (stat.ToLower())
            {
                case "str":
                case "s":
                case "strength":
                    if (int.TryParse(value, out test))
                    {
                        account.CharacterSheet.Add("str", value);
                        retVal += $"{value} strength!";
                    }
                    else
                    {
                        await Context.Channel.SendMessageAsync("Please enter a valid integer");
                        valid = false;
                    }
                    break;
                case "dex":
                case "d":
                case "dexterity":
                    if (int.TryParse(value, out test))
                    {
                        account.CharacterSheet.Add("dex", value);
                        retVal += $"{value} dexterity!";
                    }
                    else
                    {
                        await Context.Channel.SendMessageAsync("Please enter a valid integer");
                        valid = false;
                    }
                    break;
                case "con":
                case "c":
                case "constitution":
                    if (int.TryParse(value, out test))
                    {
                        account.CharacterSheet.Add("con", value);
                        retVal += $"{value} constitution!";
                    }
                    else
                    {
                        await Context.Channel.SendMessageAsync("Please enter a valid integer");
                        valid = false;
                    }
                    break;
                case "int":
                case "i":
                case "intelligence":
                    if (int.TryParse(value, out test))
                    {
                        account.CharacterSheet.Add("int", value);
                        retVal += $"{value} intelligence!";
                    }
                    else
                    {
                        await Context.Channel.SendMessageAsync("Please enter a valid integer");
                        valid = false;
                    }
                    break;
                case "wis":
                case "w":
                case "wisdom":
                    if (int.TryParse(value, out test))
                    {
                        account.CharacterSheet.Add("wis", value);
                        retVal += $"{value} wisdom!";
                    }
                    else
                    {
                        await Context.Channel.SendMessageAsync("Please enter a valid integer");
                        valid = false;
                    }
                    break;
                case "cha":
                case "ch":
                case "charisma":
                    if (int.TryParse(value, out test))
                    {
                        account.CharacterSheet.Add("cha", value);
                        retVal += $"{value} charisma!";
                    }
                    else
                    {
                        await Context.Channel.SendMessageAsync("Please enter a valid integer");
                        valid = false;
                    }
                    break;
                case "armor":
                case "a":
                    if (int.TryParse(value, out test))
                    {
                        account.CharacterSheet.Add("armor", value);
                        retVal += $"{value} as an armor!";
                    }
                    else
                    {
                        await Context.Channel.SendMessageAsync("Please enter a valid integer");
                        valid = false;
                    }
                    break;
                case "weapon":
                case "we":
                    Regex regex = new Regex("[1-9]*d[1-9]*");
                    if (regex.IsMatch(value))
                    {
                        account.CharacterSheet.Add("weapon", value);
                        retVal += $"{value} as a weapon!";
                    }
                    else
                    {
                        await Context.Channel.SendMessageAsync("Please enter a valid damage format (XdY)");
                        valid = false;
                    }
                    break;
                case "name":
                case "n":
                    account.CharacterSheet.Add("name", value);
                    retVal += $"{value} as your character's name!";
                    break;
                case "hp":
                case "h":
                    if (int.TryParse(value, out test))
                    {
                        account.CharacterSheet.Add("hp", value);
                        retVal += $"{value} as your character's hp!";
                    }
                    else
                    {
                        await Context.Channel.SendMessageAsync("Please enter a valid integer");
                        valid = false;
                    }
                    break;
                default:
                    retVal = $"Couldn't add {stat} - {value}. Try adding (s)trength, (d)exterity, (c)onstitution, (i)ntelligence, (w)isdom, (ch)arisma, (n)ame, (we)apon, or (a)rmor.";
                    break;
            }
            if (valid)
            {
                GlobalGuildAccounts.SaveAccounts(Context.User.Id);
                await Context.Channel.SendMessageAsync(retVal);
            }
        }

        private static bool EarlyStop { get; set; } = false;

        [Command("duel")]
        public async Task CharacterSheetDuel(IGuildUser playerToFight)
        {
            Random rand = new Random();
            var player1 = GlobalUserAccounts.GetUserAccount(Context.User.Id);
            var player2 = GlobalUserAccounts.GetUserAccount(playerToFight.Id);

            int player1Hp = int.Parse(player1.CharacterSheet["hp"]);
            int player2Hp = int.Parse(player2.CharacterSheet["hp"]);
            int player1DexMod = (int.Parse(player1.CharacterSheet["dex"]) - 10) / 2;
            int player2DexMod = (int.Parse(player2.CharacterSheet["dex"]) - 10) / 2;
            int player1StrMod = (int.Parse(player1.CharacterSheet["str"]) - 10) / 2;
            int player2StrMod = (int.Parse(player2.CharacterSheet["str"]) - 10) / 2;
            int initiativePlayer1 = rand.Next(1, 21) + player1DexMod;
            int initiativePlayer2 = rand.Next(1, 21) + player2DexMod;

            string[] player1Weapon = player1.CharacterSheet["weapon"].Split('d');
            int player1WeaponNumber = int.Parse(player1Weapon[0]);
            int player1WeaponSide = int.Parse(player1Weapon[1]);

            string[] player2Weapon = player2.CharacterSheet["weapon"].Split('d');
            int player2WeaponNumber = int.Parse(player2Weapon[0]);
            int player2WeaponSide = int.Parse(player2Weapon[1]);

            bool player1First = true;
            if (initiativePlayer1 == initiativePlayer2)
            {
                if (player2DexMod > player1DexMod)
                {
                    player1First = false;
                }
                else if (player1DexMod == player2DexMod)
                {
                    int finalizer = rand.Next(1, 21);
                    if (finalizer > 10)
                    {
                        player1First = false;
                    }
                }
            }
            else if (initiativePlayer2 > initiativePlayer1)
            {
                player1First = false;
            }

            int player1AC = 10 + player1DexMod + (int.Parse(player1.CharacterSheet["armor"]));
            int player2AC = 10 + player2DexMod + (int.Parse(player2.CharacterSheet["armor"]));

            int round = 1;
            do
            {
                await Context.Channel.SendMessageAsync($"Round {round}! Fight...");
                if (player1First)
                {
                    int attackRoll = rand.Next(0, 21) + player1StrMod;
                    int damage = 0;
                    for (int i = 0; i < player1WeaponNumber; i++)
                    {
                        damage += rand.Next(1, player1WeaponSide);
                    }
                    if (attackRoll > player2AC)
                    {
                        player2Hp -= damage;
                        await Context.Channel.SendMessageAsync($"{player1.CharacterSheet["name"]} hit {player2.CharacterSheet["name"]} for {damage} damage! {player2.CharacterSheet["name"]}: {player2Hp}/{int.Parse(player2.CharacterSheet["hp"])}");
                        if (player2Hp < 0)
                        {
                            break;
                        }
                    }
                    else if (attackRoll == player2AC)
                    {
                        player2Hp -= (damage / 2);
                        await Context.Channel.SendMessageAsync($"{player1.CharacterSheet["name"]} hit {player2.CharacterSheet["name"]} with a glancing blow of {damage / 2} damage! {player2.CharacterSheet["name"]}: {player2Hp}/{int.Parse(player2.CharacterSheet["hp"])}");
                        if (player2Hp < 0)
                        {
                            break;
                        }
                    }
                    else
                    {
                        await Context.Channel.SendMessageAsync($"{player1.CharacterSheet["name"]} missed {player2.CharacterSheet["name"]}! {player2.CharacterSheet["name"]}: {player2Hp}/{int.Parse(player2.CharacterSheet["hp"])}");
                    }
                }
                else
                {
                    int attackRoll = rand.Next(0, 21) + player2StrMod;
                    int damage = 0;
                    for (int i = 0; i < player2WeaponNumber; i++)
                    {
                        damage += rand.Next(1, player2WeaponSide);
                    }
                    if (attackRoll > player1AC)
                    {
                        player1Hp -= damage;
                        await Context.Channel.SendMessageAsync($"{player2.CharacterSheet["name"]} hit {player1.CharacterSheet["name"]} for {damage} damage! {player1.CharacterSheet["name"]}: {player1Hp}/{int.Parse(player1.CharacterSheet["hp"])}");
                        if (player1Hp < 0)
                        {
                            break;
                        }
                    }
                    else if (attackRoll == player1AC)
                    {
                        player1Hp -= (damage / 2);
                        await Context.Channel.SendMessageAsync($"{player2.CharacterSheet["name"]} hit {player1.CharacterSheet["name"]} with a glancing blow of {damage / 2} damage! {player1.CharacterSheet["name"]}: {player1Hp}/{int.Parse(player1.CharacterSheet["hp"])}");
                        if (player1Hp < 0)
                        {
                            break;
                        }
                    }
                    else
                    {
                        await Context.Channel.SendMessageAsync($"{player2.CharacterSheet["name"]} missed {player1.CharacterSheet["name"]}! {player1.CharacterSheet["name"]}: {player1Hp}/{int.Parse(player1.CharacterSheet["hp"])}");
                    }
                }
                await Context.Channel.SendMessageAsync("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                player1First = !player1First;
                round++;
            } while ((player1Hp >= 0 || player2Hp >= 0) && !EarlyStop);

            if (!EarlyStop)
            {
                if (player1Hp >= 0)
                {
                    await Context.Channel.SendMessageAsync($"{player1.CharacterSheet["name"]} wins!");
                }
                else
                {
                    await Context.Channel.SendMessageAsync($"{player2.CharacterSheet["name"]} wins!");
                }
            }
            EarlyStop = false;
        }

        [Command("duel")]
        public async Task CharacterSheetDuel(IGuildUser playerToFight1, IGuildUser playerToFight2)
        {
            Random rand = new Random();
            var player1 = GlobalUserAccounts.GetUserAccount(playerToFight1.Id);
            var player2 = GlobalUserAccounts.GetUserAccount(playerToFight2.Id);

            int player1Hp = int.Parse(player1.CharacterSheet["hp"]);
            int player2Hp = int.Parse(player2.CharacterSheet["hp"]);
            int player1DexMod = (int.Parse(player1.CharacterSheet["dex"]) - 10) / 2;
            int player2DexMod = (int.Parse(player2.CharacterSheet["dex"]) - 10) / 2;
            int player1StrMod = (int.Parse(player1.CharacterSheet["str"]) - 10) / 2;
            int player2StrMod = (int.Parse(player2.CharacterSheet["str"]) - 10) / 2;
            int initiativePlayer1 = rand.Next(1, 21) + player1DexMod;
            int initiativePlayer2 = rand.Next(1, 21) + player2DexMod;

            string[] player1Weapon = player1.CharacterSheet["weapon"].Split('d');
            int player1WeaponNumber = int.Parse(player1Weapon[0]);
            int player1WeaponSide = int.Parse(player1Weapon[1]);

            string[] player2Weapon = player2.CharacterSheet["weapon"].Split('d');
            int player2WeaponNumber = int.Parse(player2Weapon[0]);
            int player2WeaponSide = int.Parse(player2Weapon[1]);

            bool player1First = true;
            if (initiativePlayer1 == initiativePlayer2)
            {
                if (player2DexMod > player1DexMod)
                {
                    player1First = false;
                }
                else if (player1DexMod == player2DexMod)
                {
                    int finalizer = rand.Next(1, 21);
                    if (finalizer > 10)
                    {
                        player1First = false;
                    }
                }
            }
            else if (initiativePlayer2 > initiativePlayer1)
            {
                player1First = false;
            }

            int player1AC = 10 + player1DexMod + (int.Parse(player1.CharacterSheet["armor"]));
            int player2AC = 10 + player2DexMod + (int.Parse(player2.CharacterSheet["armor"]));

            int round = 1;
            do
            {
                await Context.Channel.SendMessageAsync($"Round {round}! Fight...");
                if (player1First)
                {
                    int attackRoll = rand.Next(0, 21) + player1StrMod;
                    int damage = 0;
                    for (int i = 0; i < player1WeaponNumber; i++)
                    {
                        damage += rand.Next(1, player1WeaponSide);
                    }
                    if (attackRoll > player2AC)
                    {
                        player2Hp -= damage;
                        await Context.Channel.SendMessageAsync($"{player1.CharacterSheet["name"]} hit {player2.CharacterSheet["name"]} for {damage} damage! {player2.CharacterSheet["name"]}: {player2Hp}/{int.Parse(player2.CharacterSheet["hp"])}");
                        if (player2Hp < 0)
                        {
                            break;
                        }
                    }
                    else if (attackRoll == player2AC)
                    {
                        player2Hp -= (damage / 2);
                        await Context.Channel.SendMessageAsync($"{player1.CharacterSheet["name"]} hit {player2.CharacterSheet["name"]} with a glancing blow of {damage / 2} damage! {player2.CharacterSheet["name"]}: {player2Hp}/{int.Parse(player2.CharacterSheet["hp"])}");
                        if (player2Hp < 0)
                        {
                            break;
                        }
                    }
                    else
                    {
                        await Context.Channel.SendMessageAsync($"{player1.CharacterSheet["name"]} missed {player2.CharacterSheet["name"]}! {player2.CharacterSheet["name"]}: {player2Hp}/{int.Parse(player2.CharacterSheet["hp"])}");
                    }
                }
                else
                {
                    int attackRoll = rand.Next(0, 21) + player2StrMod;
                    int damage = 0;
                    for (int i = 0; i < player2WeaponNumber; i++)
                    {
                        damage += rand.Next(1, player2WeaponSide);
                    }
                    if (attackRoll > player1AC)
                    {
                        player1Hp -= damage;
                        await Context.Channel.SendMessageAsync($"{player2.CharacterSheet["name"]} hit {player1.CharacterSheet["name"]} for {damage} damage! {player1.CharacterSheet["name"]}: {player1Hp}/{int.Parse(player1.CharacterSheet["hp"])}");
                        if (player1Hp < 0)
                        {
                            break;
                        }
                    }
                    else if (attackRoll == player1AC)
                    {
                        player1Hp -= (damage / 2);
                        await Context.Channel.SendMessageAsync($"{player2.CharacterSheet["name"]} hit {player1.CharacterSheet["name"]} with a glancing blow of {damage / 2} damage! {player1.CharacterSheet["name"]}: {player1Hp}/{int.Parse(player1.CharacterSheet["hp"])}");
                        if (player1Hp < 0)
                        {
                            break;
                        }
                    }
                    else
                    {
                        await Context.Channel.SendMessageAsync($"{player2.CharacterSheet["name"]} missed {player1.CharacterSheet["name"]}! {player1.CharacterSheet["name"]}: {player1Hp}/{int.Parse(player1.CharacterSheet["hp"])}");
                    }
                }
                await Context.Channel.SendMessageAsync("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                player1First = !player1First;
                round++;
            } while ((player1Hp >= 0 || player2Hp >= 0) && !EarlyStop);

            if (!EarlyStop)
            {
                if (player1Hp >= 0)
                {
                    await Context.Channel.SendMessageAsync($"{player1.CharacterSheet["name"]} wins!");
                }
                else
                {
                    await Context.Channel.SendMessageAsync($"{player2.CharacterSheet["name"]} wins!");
                }
            }
            EarlyStop = false;
        }

        [Command("stopfight"), Alias("stop")]
        public async Task StopFight()
        {
            EarlyStop = true;
            await Context.Channel.SendMessageAsync("The fight has been cancelled");
        }
    }
}