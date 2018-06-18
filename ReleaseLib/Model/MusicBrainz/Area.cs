using Newtonsoft.Json;
using System.Collections.Generic;

namespace ReleaseLib.MusicBrainz
{
    public class Area
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Disambiguation { get; set; }

        [JsonProperty(PropertyName = "sort-name")]
        public string SortName { get; set; }

        [JsonProperty(PropertyName = "iso-3166-1-codes")]
        public List<string> ISOCodes_XX { get; set; }
    }
}
