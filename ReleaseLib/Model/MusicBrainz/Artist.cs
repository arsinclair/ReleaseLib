using Newtonsoft.Json;

namespace ReleaseLib.MusicBrainz
{
    /// <summary>
    /// Исполнитель. Может быть человеком, группой, оркестром, и т.п.
    /// </summary>
    public class Artist
    {
        /// <summary>
        /// GUID исполнителя в базе данных MusicBrainz.
        /// </summary>
        public string Id { get; set; }
        public string Name { get; set; }

        [JsonProperty(PropertyName = "sort-name")]
        public string SortName { get; set; }

        public string Disambiguation { get; set; }
    }
}