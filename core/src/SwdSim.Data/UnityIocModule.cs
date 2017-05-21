using Microsoft.Practices.Unity;
using SwdSim.Data.SwDestinyDb;
using SwdSim.Data.SwDestinyDb.Builders;
using SwdSim.Data.SwDestinyDb.Converters;
using SwdSim.Domain.Repositories;
using System;

namespace SwdSim.Data
{
    public class UnityIocModule : UnityContainerExtension
    {

        protected override void Initialize()
        {
            Container.RegisterType<IDeckRepository, DeckRepository>();

            Container.RegisterType<IDestinyDeckBuilder, DestinyDeckBuilder>();
            Container.RegisterType<ICardDefinitionConverter, CardDefinitionConverter>();
            Container.RegisterType<IBattlefieldBuilder, BattlefieldBuilder>();
            Container.RegisterType<IPlayableCardBuilder, PlayableCardBuilder>();
            Container.RegisterType<ICharacterBuilder, CharacterBuilder>();

        }
    }
}
