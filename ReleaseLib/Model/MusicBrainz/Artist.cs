namespace ReleaseLib.MusicBrainz
{
    /// <summary>
    /// Исполнитель. Может быть человеком, группой, оркестром, и т.п.
    /// </summary>
    public class Artist
    {
        /// <summary>
        /// GUID исполнителя в базе данных MusicBrainz.
        /// </summary>
        public string MusicBrainz_ID { get; set; }
    }
}