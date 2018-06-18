using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReleaseLib.MusicBrainz
{
    public class ReleaseGroup
    {
        public string Id { get; set; }

        public string Title { get; set; }

        [JsonProperty(PropertyName = "primary-type")]
        public string PrimaryType { get; set; }

        [JsonProperty(PropertyName = "primary-type-id")]
        public string PrimaryTypeId { get; set; }

        public string Disambiguation { get; set; }

        [JsonProperty(PropertyName = "first-release-date")]
        [JsonConverter(typeof(MusicBrainzDateTimeConverter))]
        public DateTime FirstReleaseDate { get; set; }

        [JsonProperty(PropertyName = "artist-credit")]
        public ArtistCredit ArtistCredit { get; set; }

        [JsonProperty(PropertyName = "secondary-types")]
        public List<string> SecondaryTypes { get; set; }

        [JsonProperty(PropertyName = "secondary-type-ids")]
        public List<string> SecondaryTypeIds { get; set; }
    }
}
