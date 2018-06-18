using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Globalization;

namespace ReleaseLib.MusicBrainz
{
    public class MusicBrainzDateTimeConverter : JsonConverter
    {
        public static readonly string[] validFormats = new[] { "yyyy", "yyyy-MM", "yyyy-MM-dd" };
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(DateTime));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            DateTime result;
            string dateString = JToken.Load(reader).ToObject<string>();
            var success = DateTime.TryParseExact(dateString, validFormats, CultureInfo.InvariantCulture, DateTimeStyles.None, out result);
            if (success != true)
            {
                return null;
            }
            return result;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
