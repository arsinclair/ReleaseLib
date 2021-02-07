using System;
using System.Net.Http;
using Xunit;

namespace ReleaseLib.Tests
{
    public class ReleaseTests
    {
        [Fact]
        public void LoadExistingReleaseAllFields()
        {
            var release = MusicBrainz.Release.Load("af8adf29-c5bf-4212-a85c-d84a6a7462cf", true);
            Assert.Equal("af8adf29-c5bf-4212-a85c-d84a6a7462cf", release.Id);
            Assert.Equal("Libre", release.Title);
            Assert.NotEmpty(release.Media);
            Assert.NotEmpty(release.Media[0].Tracks);
        }

        [Fact]
        public void LoadNotExistingRG()
        {
            Action action = () => MusicBrainz.Release.Load("unknown", true);
            AggregateException exception = Assert.Throws<AggregateException>(action);
            Assert.Equal(typeof(HttpRequestException), exception.InnerException.GetType());
            Assert.Contains("400 (Bad Request)", exception.InnerException.Message);
        }
    }
}
