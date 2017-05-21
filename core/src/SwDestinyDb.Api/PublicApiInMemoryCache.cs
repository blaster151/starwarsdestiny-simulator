using System.Collections.Generic;
using SwDestinyDb.Api.Dtos;

namespace SwDestinyDb.Api
{
    public class PublicApiInMemoryCache : IPublicApi
    {
        private readonly IPublicApi _api;

        public PublicApiInMemoryCache(IPublicApi api)
        {
            _api = api;
            _cardBySetCache = new Dictionary<string, List<Card>>();
            _deckListCache = new Dictionary<string, DeckList>();
        }

        private List<Card> _cardCache = null;
        public List<Card> GetCards()
        {
            if (_cardCache == null)
                _cardCache = _api.GetCards();            
            return _cardCache;
        }

        private Dictionary<string, List<Card>> _cardBySetCache = null;
        public List<Card> GetCards(string setCode)
        {
            if (!_cardBySetCache.ContainsKey(setCode))
            {
                _cardBySetCache[setCode] = _api.GetCards(setCode);
            }
            return _cardBySetCache[setCode];
        }

        public List<Card> GetCards(Set set)
        {
            return GetCards(set.code);
        }

        private Dictionary<string, DeckList> _deckListCache = null;
        public DeckList GetDeckList(string id)
        {
            if (!_deckListCache.ContainsKey(id))
            {
                _deckListCache[id] = _api.GetDeckList(id);
            }
            return _deckListCache[id];
        }
     
        private List<Set> _setsCache = null;
        public List<Set> GetSets()
        {
            if (_setsCache == null)
                _setsCache = _api.GetSets();
            return _setsCache;
        }

      
    }
}
