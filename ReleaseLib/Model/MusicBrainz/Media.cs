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
        /// Набор треков, ассоциированный с носителем.
        /// </summary>
        public List<Track> Tracks { get; set; }

        /// <summary>
        /// Продолжительность звучания всех треков на носителе.
        /// </summary>
        public TimeSpan Duration { get; set; }

        /// <summary>
        /// Формат носителя. Например, аудиокассета, CD-диск, цифровой носитель.
        /// </summary>
        public MediumFormat Format { get; set; }
    }
}