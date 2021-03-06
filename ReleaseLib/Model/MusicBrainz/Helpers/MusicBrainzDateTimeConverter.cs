﻿using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Globalization;

namespace ReleaseLib.MusicBrainz
{
    /// <summary>
    /// Custom converter for Json.Net to handle multiple datetime string format.
    /// </summary>
    public class MusicBrainzDateTimeConverter : DateTimeConverterBase
    {
        public static readonly string[] DefaultInputFormats = new[] { "yyyy", "yyyy-MM", "yyyy-MM-dd" };
        public static readonly string DefaultOutputFormat = "yyyyMMdd";
        public static bool DefaultEvaluateEmptyStringAsNull = true;

        private string[] InputFormats = DefaultInputFormats;
        private string OutputFormat = DefaultOutputFormat;
        private bool EvaluateEmptyStringAsNull = DefaultEvaluateEmptyStringAsNull;

        public MusicBrainzDateTimeConverter()
        {
        }

        public MusicBrainzDateTimeConverter(string[] inputFormats, string outputFormat, bool evaluateEmptyStringAsNull = true)
        {
            if (inputFormats != null) InputFormats = inputFormats;
            if (outputFormat != null) OutputFormat = outputFormat;
            EvaluateEmptyStringAsNull = evaluateEmptyStringAsNull;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            DateTime result;
            string dateString = JToken.Load(reader).ToObject<string>();

            var success = DateTime.TryParseExact(dateString, InputFormats, CultureInfo.InvariantCulture, DateTimeStyles.None, out result);
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
