using Newtonsoft.Json;
using System.Collections.Generic;

namespace ReleaseLib.MusicBrainz
{
    public class Recording
    {
        public string Id { get; set; }

        public string Title { get; set; }

        [JsonConverter(typeof(MusicBrainzDurationConverter))]
        public int? Length { get; set; }

        public string Disambiguation { get; set; }

        public bool Video { get; set; }

        public List<Release> Releases { get; set; }

        [JsonProperty(PropertyName = "artist-credit")]
        public List<ArtistCredit> ArtistCredit { get; set; }

        public Recording()
        {

        }
    }
}
