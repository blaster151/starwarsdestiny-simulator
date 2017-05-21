using Microsoft.Practices.Unity;


namespace SwDestinyDb.Api
{
    public class UnityIocModule : UnityContainerExtension
    {

        protected override void Initialize()
        {
            Container.RegisterType<IPublicApi, PublicApi>("Http", new InjectionConstructor());
            Container.RegisterType<IPublicApi, PublicApiInMemoryCache>(new InjectionConstructor(new ResolvedParameter<IPublicApi>("Http")));
        }
    }
}
