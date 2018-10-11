namespace ReleaseLib.MusicBrainz
{
    /// <summary>
    /// Tag
    /// </summary>
    public class Tag
    {
        public string Name { get; set; }
        public int Count { get; set; }

        public override string ToString()
        {
            return Name; 
        }
    }
}
