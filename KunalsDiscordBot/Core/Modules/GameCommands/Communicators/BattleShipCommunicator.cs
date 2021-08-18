﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DSharpPlus.Entities;
using DSharpPlus.Interactivity;
using DSharpPlus.Interactivity.Enums;

namespace KunalsDiscordBot.Modules.Games.Communicators
{
    public class BattleShipCommunicator : DiscordCommunicator
    {
        public DiscordChannel dmChannel { get; private set; }
        public Regex battleShipInputExpression { get; private set; }

        public BattleShipCommunicator(Regex expression, TimeSpan span, DiscordChannel channel, Regex shipExpression) : base(expression, span) 
        {
            dmChannel = channel;
            battleShipInputExpression = shipExpression;
        }

        public async override Task<string> Input(InteractivityExtension interactivity, string inputMessage, InputData data)
        {
            await SendMessage(inputMessage);

            var message = await WaitForMessage(interactivity, data.conditions, data.span);

            if (message.TimedOut)
                return afkInputvalue;
            else if (message.Result.Content.ToLower().Equals(data.leaveMessage))
                return quitInputvalue;
            else if (!inputExpression.IsMatch(message.Result.Content))
            {
                await SendMessage(data.regexMatchFailExpression);

                return inputFormatNotFollow;
            }

            return message.Result.Content;
        }

        public async Task<string> ShipInput(InteractivityExtension interactivity, string inputMessage, InputData data)
        {
            await SendMessage(inputMessage);

            var message = await WaitForMessage(interactivity, data.conditions, data.span);

            if (message.TimedOut)
                return afkInputvalue;
            else if (message.Result.Content.ToLower().Equals(data.leaveMessage))
                return quitInputvalue;
            else if (!battleShipInputExpression.IsMatch(message.Result.Content))
            {
                await SendMessage(data.regexMatchFailExpression);

                return inputFormatNotFollow;
            }

            return message.Result.Content;
        }

        public async Task EditMessage(DiscordMessage message, string newMessage) => await message.ModifyAsync(newMessage);
        public async Task EditMessage(DiscordMessage message, DiscordEmbed embed) => await message.ModifyAsync(embed);
        public async Task EditMessage(DiscordMessage message, string newMessage, DiscordEmbed embed) => await message.ModifyAsync(newMessage, embed);

        public async Task<DiscordMessage> SendEmbedToPlayer(DiscordEmbed embed) => await SendEmbedToPlayer(dmChannel, embed);
        public async Task<DiscordMessage> SendMessage(string message) => await SendMessageToPlayer(dmChannel, message);
        public async Task<DiscordMessage> SendMessage(string message, DiscordEmbed embed) => await SendMessageToPlayer(dmChannel, message, embed);
        public async Task SendPageinatedMessage(DiscordUser user, List<Page> pages, PaginationEmojis emojis, PaginationBehaviour pagination, PaginationDeletion deletion)
            => await SendPageinatedMessage(dmChannel, user, pages, emojis, pagination, deletion, timeSpan);
    }
}
