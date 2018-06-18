using Newtonsoft.Json;
using ReleaseLib.MusicBrainz;
using System;

namespace ReleaseLib.MusicBrainz
{
    public class ReleaseEvent
    {
        [JsonConverter(typeof(MusicBrainzDateTimeConverter))]
        public DateTime Date { get; set; }

        public Area Area { get; set; }
    }
}