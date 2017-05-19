using SwDestinyDb.Api.Dtos;

namespace SwdSim.Data.SwDestinyDb
{
    public interface ICardDefinitionService
    {
        CardDefinition GetDefinition(Card card);
    }
}
