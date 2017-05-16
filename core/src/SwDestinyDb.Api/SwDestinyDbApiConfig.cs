using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwDestinyDb.Api
{
    public class SwDestinyDbApiConfig
    {
        public SwDestinyDbApiConfig()
        {
            BaseUrl = "https://swdestinydb.com/api";
        }
        public string BaseUrl { get; set; }
    }
}
