# ReleaseLib
A library designed for collecting and organising information about any musical release available in open databases like MusicBrainz and Discogs.

Usage Example 1 (to get release from MusicBrainz):
```C#
namespace ReleaseLib.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var release = ReleaseLib.MusicBrainz.Release.Load("7714a4c9-0870-426a-b503-9ea0787e3eb9");
        }
    }
}
```

Usage Example 2 (to get **raw json** from MusicBrainz web service):
```C#
namespace ReleaseLib.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var json = APIHelpers.MBAPIHelper.GetById(
                "release", 
                "7714a4c9-0870-426a-b503-9ea0787e3eb9", 
                new[] { "recordings", "label-rels" }
            ).Result;
        }
    }
}
```