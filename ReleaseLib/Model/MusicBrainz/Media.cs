using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ReleaseLib.MusicBrainz
{
    /// <summary>
    /// Носитель.
    /// </summary>
    public class Media
    {
        /// <summary>
        /// Название носителя.
        /// </summary>
        public string Title { get; set; }

        [JsonProperty(PropertyName = "track-count")]
        public int TrackCount { get; set; }

        /// <summary>
        /// Набор треков, ассоциированный с носителем.
        /// </summary>
        public List<Track> Tracks { get; set; }

        [JsonProperty(PropertyName = "format-id")]
        public string FormatId { get; set; }

        [JsonProperty(PropertyName = "track-offset")]
        public int TrackOffset { get; set; }

        public int Position { get; set; }

        public string Format { get; set; }

        /// <summary>
        /// Продолжительность звучания всех треков на носителе.
        /// </summary>
        public TimeSpan Duration { get; set; }
    }
}