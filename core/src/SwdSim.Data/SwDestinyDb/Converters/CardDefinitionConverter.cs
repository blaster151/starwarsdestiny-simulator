using System;
using System.Collections.Generic;
using SwDestinyDb.Api.Dtos;
using SwdSim.Domain;
using SwdSim.Domain.Constructs;
using SwdSim.Data.SwDestinyDb.Converters;

namespace SwdSim.Data.SwDestinyDb.Converters
{
    public class CardDefinitionConverter : ICardDefinitionConverter
    {
        private readonly DieConverter _dieConverter = new DieConverter();
        private readonly AffiliationConverter _affiliationConverter = new AffiliationConverter();
        private readonly CardTypeConverter _cardTypeConverter = new CardTypeConverter();
        private readonly FactionConverter _factionConverter = new FactionConverter();
        private readonly SubTypeConverter _subTypeConverter = new SubTypeConverter();
        private readonly PointsConverter _pointsConverter = new PointsConverter();
        private readonly ElitePointsConverter _elitePointsConverter = new ElitePointsConverter();

        public CardDefinition Convert(Card card)
        {
            return new CardDefinition()
            {
                Name = card.name,
                Affiliation = _affiliationConverter.Convert(card.affiliation_code),
                CardType = _cardTypeConverter.Convert(card.type_code),
                Cost = card.cost,
                Health = card.health,
                HasDie = card.has_die,
                Faction = _factionConverter.Convert(card.faction_code),
                SubTitle = card.subtitle,
                SubType = _subTypeConverter.Convert(card.subtype_code),
                IsUnique = card.is_unique,
                Points = _pointsConverter.Convert(card.points),
                ElitePoints = _elitePointsConverter.Convert(card.points),
                DieDefinition = _dieConverter.Convert(card.sides)
            };
        }
              
    }
}
