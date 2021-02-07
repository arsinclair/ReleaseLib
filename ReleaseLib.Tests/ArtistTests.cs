using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ReleaseLib.Tests
{
    public class ArtistTests
    {
        

        [Fact]
        public void LoadExistingArtistAllFields()
        {
            var artist = ReleaseLib.MusicBrainz.Artist.Load("24f1766e-9635-4d58-a4d4-9413f9f98a4c", true);
            Assert.Equal("Johann Sebastian Bach", artist.Name);
            Assert.Equal("24f1766e-9635-4d58-a4d4-9413f9f98a4c", artist.Id);
            Assert.NotEmpty(artist.Tags);
        }

        [Fact]
        public void LoadNotExistingArtist()
        {
            Action action = () => MusicBrainz.Artist.Load("unknown", true);
            AggregateException exception = Assert.Throws<AggregateException>(action);
            Assert.Equal(typeof(HttpRequestException), exception.InnerException.GetType());
            Assert.Contains("400 (Bad Request)", exception.InnerException.Message);
        }
    }
}
