using Newtonsoft.Json;

namespace ReleaseLib.MusicBrainz
{
    /// <summary>
    /// Трек.
    /// </summary>
    public class Track
    {
        /// <summary>
        /// GUID трека в базе данных MusicBrainz.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Порядковый номер трека в треклисте.
        /// </summary>
        public int Position { get; set; }

        public string Number { get; set; }

        /// <summary>
        /// Название трека.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Продолжительность звучания трека.
        /// </summary>
        [JsonConverter(typeof(MusicBrainzDurationConverter))]
        public int? Length { get; set; }

        public Recording Recording { get; set; }
    }
}
