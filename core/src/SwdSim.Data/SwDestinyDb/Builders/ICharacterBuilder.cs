using SwdSim.Domain.Constructs.Cards;

namespace SwdSim.Data.SwDestinyDb.Builders
{
    public interface ICharacterBuilder
    {
        Character Build(CardDefinition card, int numberOfDice);
    }
}
