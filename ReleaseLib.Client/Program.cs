namespace ReleaseLib.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var releaseGroup = ReleaseLib.MusicBrainz.ReleaseGroup.Load("1801e6a4-31ad-49df-805f-a1e8bc3934e9", true);
            var release = ReleaseLib.MusicBrainz.Release.Load("fb703252-61b4-44a8-aeb8-4b9d0eaff040", true);
            var artist = ReleaseLib.MusicBrainz.Artist.Load("24f1766e-9635-4d58-a4d4-9413f9f98a4c", true);
        }
    }
}
