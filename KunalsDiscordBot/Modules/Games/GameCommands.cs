﻿//System name spaces
using System.Threading.Tasks;

//D# name spaces
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using DSharpPlus.Interactivity.Extensions;

using KunalsDiscordBot.Attributes;

namespace KunalsDiscordBot.Modules.Games
{
    [Group("Games")]
    [Decor("IndianRed", ":video_game:")]
    [Description("A set of commands to play popular games with other server members")]
    [ModuleLifespan(ModuleLifespan.Transient)]
    public class GameCommands : BaseCommandModule
    {
        [Command("Connect4")]
        [Description("The Connect 4 game, play with a friend")]
        public async Task Connect(CommandContext ctx, DiscordMember other, int numberOfCells = 5)
        {
            if (ctx.User.Equals(other))
            {
                await ctx.Channel.SendMessageAsync("You can't play against yourself genius").ConfigureAwait(false);
                return;
            }
            else if (other.IsBot)
            {
                await ctx.Channel.SendMessageAsync("You can't play against a bot dum dum").ConfigureAwait(false);
                return;
            }

            ConnectFour connect = new ConnectFour(ctx, ctx.User, other, numberOfCells);

            await ctx.Channel.SendMessageAsync("").ConfigureAwait(false);
        }

        [Command("TicTacToe")]
        [Description("The TicTacToe game, play with a friend")]
        public async Task TicTacToe(CommandContext ctx, DiscordMember other, int numberOfCells = 3)
        {
            if (ctx.User.Equals(other))
            {
                await ctx.Channel.SendMessageAsync("You can't play against yourself genius").ConfigureAwait(false);
                return;
            }
            else if (other.IsBot)
            {
                await ctx.Channel.SendMessageAsync("You can't play against a bot dum dum").ConfigureAwait(false);
                return;
            }

            TicTacToe tictactoe = new TicTacToe(ctx, ctx.User, other, numberOfCells);

            await ctx.Channel.SendMessageAsync("").ConfigureAwait(false);
        }

        [Command("BattleShip")]
        [Description("The BattleShip game, play with a friend. Make sure you allow DM's from server members")]
        public async Task PlayBattleShip(CommandContext ctx, DiscordMember other)
        {
            if (ctx.User.Equals(other))
            {
                await ctx.Channel.SendMessageAsync("You can't play against yourself genius").ConfigureAwait(false);
                return;
            }
            else if (other.IsBot)
            {
                await ctx.Channel.SendMessageAsync("You can't play against a bot dum dum").ConfigureAwait(false);
                return;
            }
            else if(BattleShip.currentPlayers.Find(x => x.member == ctx.Member) != null || BattleShip.currentPlayers.Find(x => x.member == other) != null)
            {
                await ctx.Channel.SendMessageAsync("One of the players is already in a match").ConfigureAwait(false);
                return;
            }

            BattleShip battleShip = new BattleShip(ctx.Member, other, ctx.Client);

            var message = await ctx.Channel.SendMessageAsync("Started").ConfigureAwait(false);
        }

        //AI
        [Command("RPS")]
        [Description("Rock Paper Scissors")]
        public async Task RockPaperScissors(CommandContext ctx, string option)
        {
            int optionToInt = 0;
            switch (option.ToLower())
            {
                case var val when val == "paper" || val == "p":
                    optionToInt = 1;
                    break;
                case var val when val == "scissors" || val == "s":
                    optionToInt = 2;
                    break;
            }

            RockPaperScissor rockPaperScissor = new RockPaperScissor(optionToInt, ctx);

            await ctx.Channel.SendMessageAsync("").ConfigureAwait(false);
        }

        //1v1 Multiplayer
        [Command("RPS")]
        [Description("Rock Paper Scissors")]
        public async Task RockPaperScissors(CommandContext ctx, DiscordMember member, string option)
        {
            if (ctx.Member.Equals(member))
            {
                await ctx.Channel.SendMessageAsync("Can't play with yourself genius");
                return;
            }
            else if (member.IsBot)
            {
                await ctx.Channel.SendMessageAsync("You can't play against a bot dum dum");
                return;
            }

            await ctx.Channel.SendMessageAsync($"{member.Mention}, its your turn. Rock, Paper or Scissors?");

            var interactivity = ctx.Client.GetInteractivity();
            var messsage = await interactivity.WaitForMessageAsync(x => x.Channel == ctx.Channel && x.Author == member).ConfigureAwait(false);

            int optionToInt1 = Evaluate(option), optionToInt2 = Evaluate(messsage.Result.Content);

            RockPaperScissor rockPaperScissor = new RockPaperScissor(ctx, optionToInt1, optionToInt2, ctx.Member, member);

            await ctx.Channel.SendMessageAsync("").ConfigureAwait(false);

            int Evaluate(string optionChosen)
            {
                switch (optionChosen.ToLower())
                {
                    case var val when val == "paper" || val == "p":
                        return 1;
                    case var val when val == "scissors" || val == "s":
                        return 2;
                }

                return 0;
            }
        }

    }
}