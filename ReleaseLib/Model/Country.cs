namespace ReleaseLib
{
    public class Country
    {
        #region Fields
        /// <summary>
        /// Название страны.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Двухсимвольный код страны по системе ISO 3166-1 alpha-2
        /// </summary>
        public string XXCode { get; set; }

        /// <summary>
        /// Трёхсимвольный код страны по системе ISO 3166-1 alpha-3
        /// </summary>
        public string XXXCode { get; set; }
        #endregion
    }
}
