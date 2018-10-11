using Newtonsoft.Json;
using System.Collections.Generic;

namespace ReleaseLib.MusicBrainz
{
    /// <summary>
    /// Музыкальный лейбл.
    /// </summary>
    public class Label
    {
        /// <summary>
        /// GUID лейбла в базе данных MusicBrainz.
        /// </summary>
        public string Id { get; set; }

        public string Name { get; set; }

        [JsonProperty(PropertyName = "sort-name")]
        public string SortName { get; set; }

        [JsonProperty(PropertyName = "label-code")]
        public int? LabelCode { get; set; }

        public string Disambiguation { get; set; }

        public List<Tag> Tags { get; set; }
    }
}