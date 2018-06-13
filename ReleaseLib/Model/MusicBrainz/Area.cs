using Newtonsoft.Json;

namespace ReleaseLib.MusicBrainz
{
    public class Area
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Disambiguation { get; set; }

        [JsonProperty(PropertyName = "sort-name")]
        public string SortName { get; set; }
    }
}
