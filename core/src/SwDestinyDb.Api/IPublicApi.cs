using SwDestinyDb.Api.Dtos;
using System.Collections.Generic;

namespace SwDestinyDb.Api
{
    public interface IPublicApi
    {
        List<Set> GetSets();
        List<Card> GetCards();
        List<Card> GetCards(Set set);
        List<Card> GetCards(string setCode);

    } 
}
