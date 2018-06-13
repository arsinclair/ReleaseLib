using Newtonsoft.Json;
using ReleaseLib.MusicBrainz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReleaseLib.MusicBrainz
{
    public class ArtistCredit
    {
        public string JoinPhrase { get; set; }
        public Artist Artist { get; set; }
        public string Name { get; set; }
    }
}
