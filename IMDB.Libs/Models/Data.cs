using System.Runtime.Serialization;

namespace IMDB.Libs.Models
{
    [DataContract]
    public class Data
    {
        /*fixdis*/
        [DataMember(Name = "id")]
        public string id { get; set; }

        [DataMember(Name = "chartRating")]
        public string chartRating { get; set; }
    }
}
