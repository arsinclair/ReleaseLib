using System.Collections;
using System.Collections.Generic;

namespace ReleaseLib.MusicBrainz
{
    public class ArtistCredit
    {
        public string JoinPhrase { get; set; }
        public Artist Artist { get; set; }
        public string Name { get; set; }

        public static string GetAsString(IEnumerable<ArtistCredit> artistCredit)
        {
            string result = string.Empty;
            foreach (var item in artistCredit)
            {
                result += item.Name + item.JoinPhrase;
            }
            return result;
        }
    }
}
