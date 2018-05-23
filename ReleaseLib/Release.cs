using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReleaseLib
{
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
        public string MusicBrainz_ID { get; set; }

        /// <summary>
        /// ID релиза в базе данных Discogs.
        /// </summary>
        public string Discogs_ID { get; set; }

        /// <summary>
        /// Год выпуска текущего релиза.
        /// </summary>
        public DateTime Year { get; set; }

        /// <summary>
        /// Год выпуска оригинального релиза. Актуален в релизах типа Reissue.
        /// </summary>
        public DateTime YearOriginated { get; set; }

        /// <summary>
        /// Страна выпуска релиза. Для цифровых релизов - Worldwide.
        /// </summary>
        public Country Country { get; set; }

        /// <summary>
        /// Исполнители, с которыми ассоциирован данный релиз.
        /// </summary>
        public List<Artist> Artists { get; set; }

        /// <summary>
        /// Лейблы, на которых данный релиз был выпущен.
        /// </summary>
        public List<Label> Labels { get; set; }

        #region Methods
        public Release()
        {
            var _settings = new Settings();
        }
        #endregion
    }
}
