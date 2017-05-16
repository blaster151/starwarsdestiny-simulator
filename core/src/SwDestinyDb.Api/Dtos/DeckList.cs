using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SwDestinyDb.Api.Dtos
{
    [DataContract]
    public class DeckList
    {
        [DataMember]
        public int id { get; set; }
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public string date_creation { get; set; }
        [DataMember]
        public string date_update { get; set; }
        [DataMember]
        public string description_md { get; set; }
        [DataMember]
        public int user_id { get; set; }
        [DataMember]
        public string affiliation_code { get; set; }
        [DataMember]
        public string affiliation_name { get; set; }
        [DataMember]
        public Dictionary<string,DeckListCard> slots { get; set; }
        [DataMember]
        public Dictionary<string, DeckListCard> characters { get; set; }
    }

    [DataContract]
    public class DeckListCard
    {
        public int quantity { get; set; }
        public int dice { get; set; }
    }
}
