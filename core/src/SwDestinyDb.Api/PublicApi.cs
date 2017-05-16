using RestSharp;
using SwDestinyDb.Api.Dtos;
using System.Collections.Generic;
using System;

namespace SwDestinyDb.Api
{
    public class PublicApi : IPublicApi
    {
        private readonly SwDestinyDbApiConfig _config;

        public PublicApi() : this(new SwDestinyDbApiConfig())
        {

        }
        public PublicApi(SwDestinyDbApiConfig config)
        {
            _config = config;
        }

        private RestClient BuildClient()
        {
            var baseUrl = string.Format($"{_config.BaseUrl}/public");
            return new RestClient(baseUrl);
        }
       
        public List<Set> GetSets()
        {
            var client = BuildClient();
            var request = new RestRequest("sets");
            return client.Execute<List<Set>>(request).Data;
        }
       
        public List<Card> GetCards()
        {
            var client = BuildClient();
            var request = new RestRequest("cards");
            return client.Execute<List<Card>>(request).Data;
        }

        public List<Card> GetCards(Set set)
        {
            return GetCards(set.code);
        }

        public List<Card> GetCards(string setCode)
        {
            var client = BuildClient();
            var request = new RestRequest("cards/{setCode}.json");
            request.AddParameter("setCode", setCode, ParameterType.UrlSegment);
            return client.Execute<List<Card>>(request).Data;
        }
    }
}
