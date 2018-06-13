using System;
using System.Collections.Generic;

namespace ReleaseLib.MusicBrainz
{
    /// <summary>
    /// Релиз. Может представлять любую выпущенную музыкальную единицу (например, альбом, сингл, микстейп, и т.п.).
    /// </summary>
    public class Release
    {
        /// <summary>
        /// Название релиза
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Штрихкод релиза. Актуален для физических копий.
        /// </summary>
        public string Barcode { get; set; }

        /// <summary>
        /// GUID релиза в базе данных MusicBrainz.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Год выпуска текущего релиза.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Год выпуска оригинального релиза. Актуален в релизах типа Reissue.
        /// </summary>
        public DateTime YearOriginated { get; set; }

        /// <summary>
        /// Страна выпуска релиза. Для цифровых релизов - Worldwide.
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Исполнители, с которыми ассоциирован данный релиз.
        /// </summary>
        public List<Artist> Artists { get; set; }

        /// <summary>
        /// Лейблы, на которых данный релиз был выпущен.
        /// </summary>
        public List<Label> Labels { get; set; }

        /// <summary>
        /// Список музыкальных стилей, к которым можно отнести данный релиз.
        /// </summary>
        public List<string> Styles { get; set; }

        /// <summary>
        /// Список музыкальных жанров, к которым можно отнести данный релиз.
        /// </summary>
        public List<string> Genres { get; set; }

        /// <summary>
        /// Список носителей, на которых был выпущен данный релиз (например, 2xCD, 1xLP, и т.п.).
        /// </summary>
        public List<Media> Media { get; set; }

        /// <summary>
        /// Длительность звучания всех треков на всех носителях данного релиза.
        /// </summary>
        public TimeSpan Duration { get; set; }

        private Settings _settings;
        #region Methods
        public Release()
        {
        }
        #endregion
    }
}
