using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ReleaseLib.Tests
{
    public class ReleaseGroupTests
    {
        [Fact]
        public void LoadExistingRGAllFields()
        {
            var releaseGroup = MusicBrainz.ReleaseGroup.Load("1801e6a4-31ad-49df-805f-a1e8bc3934e9", true);
            Assert.Equal("Pixel Dragon", releaseGroup.Title);
            Assert.Equal("d6038452-8ee0-3f68-affc-2de9a1ede0b9", releaseGroup.PrimaryTypeId);
            Assert.Equal("Single", releaseGroup.PrimaryType);
        }

        [Fact]
        public void LoadNotExistingRG()
        {
            Action action = () => MusicBrainz.ReleaseGroup.Load("unknown", true);
            AggregateException exception = Assert.Throws<AggregateException>(action);
            Assert.Equal(typeof(HttpRequestException), exception.InnerException.GetType());
            Assert.Contains("400 (Bad Request)", exception.InnerException.Message);
        }
    }
}
