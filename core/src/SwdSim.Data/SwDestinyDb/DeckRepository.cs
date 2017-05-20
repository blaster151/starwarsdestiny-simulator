using SwdSim.Domain.Repositories;
using SwdSim.Domain.Constructs;
using SwDestinyDb.Api;
using SwdSim.Data.SwDestinyDb.Exceptions;

namespace SwdSim.Data.SwDestinyDb
{
    public class DeckRepository : IDeckRepository
    {
        private readonly IPublicApi _api;
        private readonly IDestinyDeckBuilder _deckBuilder;

        public DeckRepository(IPublicApi swDestinyDbApi, IDestinyDeckBuilder deckBuilder)
        {
            _api = swDestinyDbApi;
            _deckBuilder = deckBuilder;
        }
        
        public DestinyDeck GetDestinyDeck(string deckId)
        {
            var deckList = _api.GetDeckList(deckId);
            if (deckList == null) throw new DeckListNotFoundException();
            var cards = _api.GetCards();
            return _deckBuilder.Build(deckList, cards);
             
        }
    }
}
