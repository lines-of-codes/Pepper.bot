﻿using System;
namespace KunalsDiscordBot.Modules.Games.Complex.UNO.Cards
{
    public class SkipCard : PowerCard
    {
        public SkipCard(CardColor color, CardType type = CardType.Skip) : base(color, type)
        {

        }

        public override CardType stackables => CardType.Skip;
    }
}