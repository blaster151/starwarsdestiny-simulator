using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SwDestinyDb.Api.Dtos
{
    [DataContract]
    public class Card
    {
        [DataMember]
        public List<string> sides { get; set; }
        //public string set_code { get; set; }
        // public string set_name { get; set; }
        [DataMember]
        public string type_code { get; set; }
        [DataMember]
        public string type_name { get; set; }
        [DataMember]
        public string faction_code { get; set; }
        [DataMember]
        public string faction_name { get; set; }
        [DataMember]
        public string affiliation_code { get; set; }
        [DataMember]
        public string affiliation_name { get; set; }
        [DataMember]
        public string rarity_code { get; set; }
        [DataMember]
        public string rarity_name { get; set; }
        [DataMember]
        public int position { get; set; }
        [DataMember]
        public string code { get; set; }
        [DataMember]
        public string ttscardid { get; set; }
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public string subtitle { get; set; }
        [DataMember]
        public int? cost { get; set; }
        [DataMember]
        public int? health { get; set; }
        [DataMember]
        public string points { get; set; }
        [DataMember]
        public string text { get; set; }
        [DataMember]
        public int deck_limit { get; set; }
        [DataMember]
        public string flavor { get; set; }
        [DataMember]
        public string illustrator { get; set; }
        [DataMember]
        public bool is_unique { get; set; }
        [DataMember]
        public bool has_die { get; set; }
        [DataMember]
        public bool has_errata { get; set; }
        [DataMember]
        public string url { get; set; }
        [DataMember]
        public string imagesrc { get; set; }
        [DataMember]
        public string label { get; set; }
        [DataMember]
        public int cp { get; set; }
        [DataMember]
        public string subtype_code { get; set; }
        [DataMember]
        public string subtype_name { get; set; }
    }
    
}
