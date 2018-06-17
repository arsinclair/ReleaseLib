using Newtonsoft.Json;

namespace ReleaseLib.MusicBrainz
{
    public class LabelInfo
    {
        [JsonProperty(PropertyName = "catalog-number")]
        public string CatalogNumber { get; set; }

        public Label Label { get; set; }
    }
}