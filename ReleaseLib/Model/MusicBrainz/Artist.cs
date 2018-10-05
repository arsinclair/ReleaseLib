using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ReleaseLib.APIHelpers;

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
        public Area Area { get; set; }

        public string Type { get; set; }

        [JsonProperty(PropertyName = "type-id")]
        public string TypeId { get; set; }

        [JsonProperty(PropertyName = "sort-name")]
        public string SortName { get; set; }

        public string Disambiguation { get; set; }

        #region Methods
        public Artist()
        {
        }

        public static Artist Load(string Id)
        {
            return _Load(Id, false);
        }
        public static Artist Load(string Id, params string[] AdditionalFields)
        {
            return _Load(Id, false, AdditionalFields);
        }
        public static Artist Load(string Id, bool IncludeAllAdditionalFields)
        {
            return _Load(Id, true);
        }
        private static Artist _Load(string Id, bool IncludeAllAdditionalFields, params string[] AdditionalFields)
        {
            string json = string.Empty;
            if (IncludeAllAdditionalFields == true)
            {
                json = MBAPIHelper.GetArtistById(Id, IncludeAllAdditionalFields).Result;
            }
            else
            {
                json = MBAPIHelper.GetArtistById(Id, AdditionalFields).Result;
            }
            var release = JObject.Parse(json).ToObject<Artist>();
            return release;
        }
        #endregion
    }
}