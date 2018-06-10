using System;
using System.Collections.Generic;

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
        public string MusicBrainz_ID { get; set; }

        /// <summary>
        /// Порядковый номер трека в треклисте.
        /// </summary>
        public int Position { get; set; }

        /// <summary>
        /// Список исполнителей, ассоциированный с треком.
        /// </summary>
        public List<Artist> Artists { get; set; }

        /// <summary>
        /// Название трека.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Продолжительность звучания трека.
        /// </summary>
        public TimeSpan Duration { get; set; }
    }
}
