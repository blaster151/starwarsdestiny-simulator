using SwDestinyDb.Api.Dtos;

namespace SwdSim.Data.SwDestinyDb
{
    public interface ICardDefinitionConverter
    {
        CardDefinition Convert(Card card);
    }
}
