using Newtonsoft.Json;
using System;

namespace ReleaseLib.MusicBrainz
{
    public class Relation
    {
        public string Type { get; set; }

        [JsonProperty(PropertyName = "type-id")]
        public string TypeId { get; set; }

        public string Direction { get; set; }

        [JsonConverter(typeof(MusicBrainzDateTimeConverter))]
        public DateTime? Begin { get; set; }

        [JsonConverter(typeof(MusicBrainzDateTimeConverter))]
        public DateTime? End { get; set; }

        [JsonProperty(PropertyName = "target-type")]
        public string TargetType { get; set; }

        [JsonProperty(PropertyName = "target-credit")]
        public string TargetCredit { get; set; }

        [JsonProperty(PropertyName = "source-credit")]
        public string SourceCredit { get; set; }

        public bool Ended { get; set; }

        public Artist Artist { get; set; }

        public Label Label { get; set; }

        public Url Url { get; set; }

        public override string ToString()
        {
            return $"{this.TargetType} - {this.Type}";
        }
    }
}
