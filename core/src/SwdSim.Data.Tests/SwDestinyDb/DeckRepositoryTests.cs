using NUnit.Framework;
using SwdSim.Data.SwDestinyDb.Builders;
using SwDestinyDb.Api;
using Moq;
using SwDestinyDb.Api.Dtos;
using SwdSim.Data.SwDestinyDb;
using SwdSim.Data.SwDestinyDb.Exceptions;
using System.Collections.Generic;
using SwdSim.Domain.Constructs;
using SwdSim.Domain.Tests;

namespace SwdSim.Data.Tests.SwDestinyDb
{
    [TestFixture]
    public class DeckRepositoryTests
    {
        private Mock<IPublicApi> _publicApi;
        private Mock<IDestinyDeckBuilder> _deckBuilder;
        private DeckRepository _deckRepository;

        private string _deckListId;
        private DeckList _deckList;
        private DestinyDeck _deck;

        [SetUp]
        public void Setup()
        {
            _publicApi = new Mock<IPublicApi>(MockBehavior.Strict);
            _deckBuilder = new Mock<IDestinyDeckBuilder>(MockBehavior.Strict);
            _deckListId = "1";
            _deck = TestUtils.GetValidDestinyDeck();
            _deckList = new DeckList();
            _deckRepository = new DeckRepository(_publicApi.Object, _deckBuilder.Object);
        }

        [TearDown]
        public void TearDown()
        {
            _publicApi.VerifyAll();
            _deckBuilder.VerifyAll();
        }
        
        [Test]
        public void BuildDeck_DeckListNotFound_ThrowsDeckListNotFoundExceptionn()
        {
            _deckList = null;
            _publicApi.Setup(api => api.GetDeckList(_deckListId)).Returns(_deckList);
            Assert.Throws<DeckListNotFoundException>(() =>
            {
                _deckRepository.GetDestinyDeck(_deckListId);
            });
        }

        [Test]
        public void BuildDeck_CallsDeckBuilder_ReturnsDeck()
        {
            var cards = new List<Card>();            
            _publicApi.Setup(api => api.GetDeckList(_deckListId)).Returns(_deckList);
            _publicApi.Setup(api => api.GetCards()).Returns(cards);
            _deckBuilder.Setup(b => b.Build(_deckList, cards)).Returns(_deck);
            
            var deck =_deckRepository.GetDestinyDeck(_deckListId);

            Assert.AreSame(_deck, deck);
        }
    }
}