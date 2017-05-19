﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwdSim.Domain.Constructs.Cards;
using Card = SwDestinyDb.Api.Dtos.Card;

namespace SwdSim.Data.SwDestinyDb.Builders
{
    public class BattlefieldBuilder
    {
        public Battlefield Build(CardDefinition card)
        {
            if (card.CardType != Domain.CardType.Battlefield) throw new Exception("Card is not a Battlefield.");
            var battlefield = new Battlefield(); //todo - name, text etc.
            //TODO - add behaviors
            return battlefield;
        }
    }
}
