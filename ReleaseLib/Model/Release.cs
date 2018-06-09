using Newtonsoft.Json.Linq;
using ReleaseLib.APIHelpers;
using System;
using System.Collections.Generic;
using System.Threading;

namespace ReleaseLib
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

        private string _musicBrainz_ID;
        /// <summary>
        /// GUID релиза в базе данных MusicBrainz.
        /// </summary>
        public string MusicBrainz_ID
        {
            get
            {
                return _musicBrainz_ID;
            }
            set
            {
                _musicBrainz_ID = value;
                OnMusicbrainzIDSubmitted(_musicBrainz_ID, ParseRelease);
                resetEvent.WaitOne();
            }
        }

        private string _discogs_ID;
        /// <summary>
        /// ID релиза в базе данных Discogs.
        /// </summary>
        public string Discogs_ID
        {
            get
            {
                return _discogs_ID;
            }
            set
            {
                _discogs_ID = value;
                OnDiscogsIDSubmitted(_discogs_ID);
                resetEvent.WaitOne();
            }
        }

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
        public List<Medium> Mediums { get; set; }

        /// <summary>
        /// Длительность звучания всех треков на всех носителях данного релиза.
        /// </summary>
        public TimeSpan Duration { get; set; }

        private Settings _settings;
        #region Methods
        public Release()
        {
            _settings = new Settings();
        }
        #endregion

        ManualResetEvent resetEvent = new ManualResetEvent(false);

        #region Events
        private async void OnMusicbrainzIDSubmitted(string value, Action<string> parseReleaseCallback)
        {
            var data = await MBAPIHelper.GetReleaseById(value, true);
            parseReleaseCallback(data);
        }

        private void ParseRelease(string JSON)
        {
            dynamic data = JObject.Parse(JSON);
            this.Title = data.title;
            if (data.country)
            {
                this.Country = _settings.Countries.Find(c => data.country == c.Title || data.country == c.XXCode);
            }


            var _x = data.title as string;
            var Title = _x;
            resetEvent.Set();
        }

        private void OnDiscogsIDSubmitted(string value)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
