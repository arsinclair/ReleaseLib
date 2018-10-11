using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ReleaseLib.APIHelpers;
using System;
using System.Collections.Generic;

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
        public DateTime? FirstReleaseDate { get; set; }

        [JsonProperty(PropertyName = "artist-credit")]
        public List<ArtistCredit> ArtistCredit { get; set; }

        [JsonProperty(PropertyName = "secondary-types")]
        public List<string> SecondaryTypes { get; set; }

        [JsonProperty(PropertyName = "secondary-type-ids")]
        public List<string> SecondaryTypeIds { get; set; }

        #region Methods
        public ReleaseGroup()
        {
        }

        public static ReleaseGroup Load(string Id)
        {
            return _Load(Id, false);
        }
        public static ReleaseGroup Load(string Id, params string[] AdditionalFields)
        {
            return _Load(Id, false, AdditionalFields);
        }
        public static ReleaseGroup Load(string Id, bool IncludeAllAdditionalFields)
        {
            return _Load(Id, true);
        }
        private static ReleaseGroup _Load(string Id, bool IncludeAllAdditionalFields, params string[] AdditionalFields)
        {
            string json = string.Empty;
            if (IncludeAllAdditionalFields == true)
            {
                json = MBAPIHelper.GetReleaseGroupById(Id, IncludeAllAdditionalFields).Result;
            }
            else
            {
                json = MBAPIHelper.GetReleaseGroupById(Id, AdditionalFields).Result;
            }
            var release = JObject.Parse(json).ToObject<ReleaseGroup>();
            return release;
        }
        #endregion
    }
}
