namespace ReleaseLib.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var release = ReleaseLib.MusicBrainz.Release.Load("c0b0105b-a942-43c4-a2a8-a54f847a200e", true);
        }
    }
}
