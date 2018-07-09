using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Globalization;

namespace ReleaseLib.MusicBrainz
{
    /// <summary>
    /// Custom converter for Json.Net to handle multiple datetime string format.
    /// </summary>
    public class MusicBrainzDurationConverter : JsonConverter
    {
        public static readonly string[] DefaultInputFormats = new[] { "yyyy", "yyyy-MM", "yyyy-MM-dd" };
        public static readonly string DefaultOutputFormat = "yyyyMMdd";
        public static bool DefaultEvaluateEmptyStringAsNull = true;

        private string[] InputFormats = DefaultInputFormats;
        private string OutputFormat = DefaultOutputFormat;
        private bool EvaluateEmptyStringAsNull = DefaultEvaluateEmptyStringAsNull;

        public MusicBrainzDurationConverter()
        {
        }

        public MusicBrainzDurationConverter(string[] inputFormats, string outputFormat, bool evaluateEmptyStringAsNull = true)
        {
            if (inputFormats != null) InputFormats = inputFormats;
            if (outputFormat != null) OutputFormat = outputFormat;
            EvaluateEmptyStringAsNull = evaluateEmptyStringAsNull;
        }

        public override bool CanConvert(Type objectType)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            int result;
            string input = JToken.Load(reader).ToObject<string>();

            var success = int.TryParse(input, out result);
            if (success != true)
                return null;

            return result;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue(((DateTime)value).ToString(OutputFormat));
        }
    }
}
