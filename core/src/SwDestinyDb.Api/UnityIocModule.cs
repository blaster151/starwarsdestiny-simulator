using Microsoft.Practices.Unity;


namespace SwDestinyDb.Api
{
    public class UnityIocModule : UnityContainerExtension
    {

        protected override void Initialize()
        {
            Container.RegisterType<IPublicApi, PublicApi>(new InjectionConstructor());           
        }
    }
}
