using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SwDestinyDb.Api.Dtos
{
    [DataContract]
    public class Set
    {
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public string code { get; set; }
        [DataMember]
        public int position { get; set; }
        [DataMember]
        public string available { get; set; }
        [DataMember]
        public int known { get; set; }
        [DataMember]
        public int total { get; set; }
        [DataMember]
        public string url { get; set; }
    }
}
