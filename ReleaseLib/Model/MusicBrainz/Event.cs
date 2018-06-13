using Newtonsoft.Json;

namespace ReleaseLib.MusicBrainz
{
    public class Event
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }

        [JsonProperty(PropertyName = "type-id")]
        public string TypeId { get; set; }

        public bool Cancelled { get; set; }
        public string Disambiguation { get; set; }
        public string Setlist { get; set; }

        [JsonProperty(PropertyName = "life-span")]
        public LifeSpan LifeSpan { get; set; }
    }
}
