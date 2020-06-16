using System.Runtime.Serialization;

namespace IMDB.Libs.Models
{
    /// <summary>
    /// Defines data for external API results
    /// </summary>
    /// <param name="id"> id of movie </param>>
    /// <param name="chartRating"> Rating of movie </param>>
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
