using System;
using System.Collections.Generic;
using SwDestinyDb.Api.Dtos;
using SwdSim.Domain;
using SwdSim.Domain.Constructs;
using SwdSim.Data.SwDestinyDb.Converters;

namespace SwdSim.Data.SwDestinyDb
{
    public class CardDefinitionService : ICardDefinitionService
    {
        private readonly DieConverter _dieConverter = new DieConverter();
        private readonly AffiliationConverter _affiliationConverter = new AffiliationConverter();
        private readonly CardTypeConverter _cardTypeConverter = new CardTypeConverter();
        private readonly FactionConverter _factionConverter = new FactionConverter();
        private readonly SubTypeConverter _subTypeConverter = new SubTypeConverter();
        private readonly PointsConverter _pointsConverter = new PointsConverter();
        private readonly ElitePointsConverter _elitePointsConverter = new ElitePointsConverter();

        public CardDefinition GetDefinition(Card card)
        {
            return new CardDefinition()
            {
                Name = card.name,
                Affiliation = _affiliationConverter.Convert(card),
                CardType = _cardTypeConverter.Convert(card),
                Cost = card.cost,
                Health = card.health,
                HasDie = card.has_die,
                Faction = _factionConverter.Convert(card),
                SubTitle = card.subtitle,
                SubType = _subTypeConverter.Convert(card),
                IsUnique = card.is_unique,
                Points = _pointsConverter.Convert(card),
                ElitePoints = _elitePointsConverter.Convert(card),
                DieDefinition = _dieConverter.ConvertSidesToDieDefinition(card)
            };
        }
              
    }
}
