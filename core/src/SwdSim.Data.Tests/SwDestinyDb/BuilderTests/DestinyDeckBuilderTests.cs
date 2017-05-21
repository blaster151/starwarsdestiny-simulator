using Moq;
using NUnit.Framework;
using SwDestinyDb.Api.Dtos;
using SwdSim.Data.SwDestinyDb;
using SwdSim.Data.SwDestinyDb.Builders;
using SwdSim.Data.SwDestinyDb.Converters;
using System.Collections.Generic;
using System.Linq;
using DeckList = SwDestinyDb.Api.Dtos.DeckList;

namespace SwdSim.Data.Tests.SwDestinyDb.BuilderTests
{
    [TestFixture]
    public class DestinyDeckBuilderTests
    {

        private Mock<IBattlefieldBuilder> _battleFieldBuilder;
        private Mock<IPlayableCardBuilder> _playableCardBuilder;
        private Mock<ICharacterBuilder> _characterBuilder;
        private Mock<ICardDefinitionConverter> _cardDefinitionConverter;
        private DestinyDeckBuilder _destinyDeckBuilder;
       
        [SetUp]
        public void SetUp()
        {
            _battleFieldBuilder = new Mock<IBattlefieldBuilder>();
            _playableCardBuilder = new Mock<IPlayableCardBuilder>();
            _characterBuilder = new Mock<ICharacterBuilder>();
            _cardDefinitionConverter = new Mock<ICardDefinitionConverter>();
            _destinyDeckBuilder = new DestinyDeckBuilder(_cardDefinitionConverter.Object, _battleFieldBuilder.Object, _playableCardBuilder.Object, _characterBuilder.Object);
        }

        [Test]
        public void DestinyDeckBuilder_Build_Expected()
        {
            //build a deck consisting of
            //  1 Elite Character
            //  2 Non-Elite Copies of the Same Character
            //  10 Events
            //  10 Upgrades
            //  10 Supports
            //  1 Battlefield
            //Arrange
            var deckList = new DeckList()
            {
                slots = new System.Collections.Generic.Dictionary<string, DeckListCard>(),
                characters = new System.Collections.Generic.Dictionary<string, DeckListCard>()
            };

            var cards = new List<Card>()
            {
                new Card() { code = "uniqueCharacter", type_code = "character" },
                new Card() { code = "nonUniqueCharacter", type_code = "character" },
                new Card() { code = "battlefield", type_code = "battlefield" },
            };
            cards.AddRange(Enumerable.Range(1, 10).Select((m, i) => new Card() { code = $"upgrade_{i+1}", type_code = "upgrade" }));
            cards.AddRange(Enumerable.Range(1, 10).Select((m, i) => new Card() { code = $"support_{i+1}", type_code = "support" }));
            cards.AddRange(Enumerable.Range(1, 10).Select((m, i) => new Card() { code = $"event_{i+1}", type_code = "event" }));

            deckList.characters.Add("uniqueCharacter", new DeckListCard() { dice = 2, quantity = 1 });
            deckList.characters.Add("nonUniqueCharacter", new DeckListCard() { dice = 1, quantity = 2 });
            deckList.slots.Add("battlefield", new DeckListCard() { quantity = 1 });
            Enumerable.Range(1, 10).ToList().ForEach(i =>
            {
                deckList.slots.Add($"upgrade_{i}", new DeckListCard() { dice = 1, quantity = 1 });
                deckList.slots.Add($"support_{i}", new DeckListCard() { dice = 1, quantity = 1 });
                deckList.slots.Add($"event_{i}", new DeckListCard() { dice = 0, quantity = 1 });
            });
            _cardDefinitionConverter.Setup(c => c.Convert(It.IsAny<Card>())).Returns((Card c) => new CardDefinition() { CardType = new CardTypeConverter().Convert(c.type_code) });
            _playableCardBuilder.Setup(p => p.CanBuildCard(It.IsAny<CardDefinition>())).Returns(true);

            //Act
            var deck = _destinyDeckBuilder.Build(deckList, cards);

            //Assert
            _battleFieldBuilder.Verify(b => b.Build(It.Is<CardDefinition>(d => d.CardType == Domain.CardType.Battlefield)), Times.Exactly(1));
            _characterBuilder.Verify(b => b.Build(It.Is<CardDefinition>(d => d.CardType == Domain.CardType.Character), 2), Times.Exactly(1));
            _characterBuilder.Verify(b => b.Build(It.Is<CardDefinition>(d => d.CardType == Domain.CardType.Character), 1), Times.Exactly(2));
            _playableCardBuilder.Verify(b => b.Build(It.Is<CardDefinition>(d => d.CardType == Domain.CardType.Upgrade)), Times.Exactly(10));
            _playableCardBuilder.Verify(b => b.Build(It.Is<CardDefinition>(d => d.CardType == Domain.CardType.Support)), Times.Exactly(10));
            _playableCardBuilder.Verify(b => b.Build(It.Is<CardDefinition>(d => d.CardType == Domain.CardType.Event)), Times.Exactly(10));
        }
    }
}
