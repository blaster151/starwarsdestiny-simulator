using SwdSim.Domain.Constructs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeckList = SwDestinyDb.Api.Dtos.DeckList;
using Card = SwDestinyDb.Api.Dtos.Card;
using SwdSim.Domain.Constructs.Cards;
using SwDestinyDbTypeCode = SwDestinyDb.Api.TypeCode;
using SwdSim.Data.SwDestinyDb.Builders;
using SwdSim.Domain;

namespace SwdSim.Data.SwDestinyDb
{
    public class DestinyDeckBuilder : IDestinyDeckBuilder
    {
        private ICardDefinitionConverter _cardDefinitionService;
        public DestinyDeckBuilder(ICardDefinitionConverter cardDefinitionService)
        {
            _cardDefinitionService = cardDefinitionService;
        }
        private readonly CharacterBuilder _characterBuilder = new CharacterBuilder();
        private readonly BattlefieldBuilder _battleFieldBuilder = new BattlefieldBuilder();
        private readonly PlayableCardBuilder _playableCardBuilder = new PlayableCardBuilder();
      
        public DestinyDeck Build(DeckList deckList, List<Card> destinyCards)
        {
            var cards = destinyCards.ToDictionary(m => m.code, m => _cardDefinitionService.Convert(m));
            Func<string, CardDefinition> cardLookup = code => cards[code];

            var characters = BuildCharacters(deckList, cardLookup);
            var drawDeck = BuildDrawDeck(deckList, cardLookup);
            var battleField = BuildBattlefield(deckList, cardLookup);
            return new DestinyDeck(characters, drawDeck, battleField);
        }

        private List<Character> BuildCharacters(DeckList deckList, Func<string, CardDefinition> fnFindCard)
        {
            var characters = new List<Character>();
            foreach (var character in deckList.characters)
            {
                var characterCard = fnFindCard(character.Key);
                for (int i = 1; i <= character.Value.quantity; i++)
                {                   
                    characters.Add(_characterBuilder.Build(characterCard, character.Value.dice));
                }
            }
            return characters;
        }

        
        private List<PlayableCard> BuildDrawDeck(DeckList deckList, Func<string, CardDefinition> fnFindCard)
        {
            var drawDeck = new List<PlayableCard>();
            foreach (var slot in deckList.slots)
            {
                var card = fnFindCard(slot.Key);
                if (!_playableCardBuilder.CanBuildCard(card)) continue;
                for (int i = 1; i <= slot.Value.quantity; i++)
                {
                    drawDeck.Add(_playableCardBuilder.Build(card));
                }
            }
            return drawDeck;
        }

        private Battlefield BuildBattlefield(DeckList deckList, Func<string, CardDefinition> fnFindCard)
        {
            var battleFields = new List<Battlefield>();
            foreach (var slot in deckList.slots)
            {
                var card = fnFindCard(slot.Key);
                if (card.CardType != CardType.Battlefield) continue;
                battleFields.Add(_battleFieldBuilder.Build(card));
            }
            if (battleFields.Count == 0) throw new Exception("No battlefields found.");
            if (battleFields.Count > 1) throw new Exception("More than one battlefield found.");
            return battleFields.First();
        }


    }
}
