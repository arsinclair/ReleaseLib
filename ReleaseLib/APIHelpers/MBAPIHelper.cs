using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ReleaseLib.APIHelpers
{
    public static class MBAPIHelper
    {
        public static string ServiceUrl = "https://musicbrainz.org";

        public static Task<string> GetAreaById(string AreaId)
        {
            return GetById("area", AreaId, new string[] { });
        }

        public static Task<string> GetArtistById(string ArtistId)
        {
            return GetById("artist", ArtistId, new string[] { });
        }

        public static Task<string> GetArtistById(string ArtistId, params string[] AdditionalFields)
        {
            return GetById("artist", ArtistId, AdditionalFields);
        }

        public static Task<string> GetArtistById(string ArtistId, bool IncludeAllAdditionalFields)
        {
            string[] fieldSet = new string[] { };
            if (IncludeAllAdditionalFields == true)
            {
                fieldSet = new List<string> { "recordings", "releases", "release-groups", "works" }.ToArray();
            }
            return GetById("artist", ArtistId, fieldSet);
        }

        public static Task<string> GetCollectionById(string CollectionId)
        {
            return GetById("collection", CollectionId, new string[] { });
        }

        public static Task<string> GetCollectionById(string CollectionId, params string[] AdditionalFields)
        {
            return GetById("collection", CollectionId, AdditionalFields);
        }

        public static Task<string> GetCollectionById(string CollectionId, bool IncludeAllAdditionalFields)
        {
            string[] fieldSet = new string[] { };
            if (IncludeAllAdditionalFields == true)
            {
                fieldSet = new List<string> { "user-collections" }.ToArray();
            }
            throw new NotImplementedException(); // "user-collections" require authentication : Not Implemented Yet
            return GetById("collection", CollectionId, fieldSet);
        }

        public static Task<string> GetEventById(string EventId)
        {
            return GetById("event", EventId, new string[] { });
        }

        public static Task<string> GetInstrumentById(string InstrumentId)
        {
            return GetById("instrument", InstrumentId, new string[] { });
        }

        public static Task<string> GetLabelById(string LabelId)
        {
            return GetById("label", LabelId, new string[] { });
        }

        public static Task<string> GetLabelById(string LabelId, params string[] AdditionalFields)
        {
            return GetById("label", LabelId, AdditionalFields);
        }

        public static Task<string> GetLabelById(string LabelId, bool IncludeAllAdditionalFields)
        {
            string[] fieldSet = new string[] { };
            if (IncludeAllAdditionalFields == true)
            {
                fieldSet = new List<string> { "releases" }.ToArray();
            }
            return GetById("label", LabelId, fieldSet);
        }

        public static Task<string> GetReleaseById(string ReleaseId)
        {
            return GetById("release", ReleaseId, new string[] { });
        }

        public static Task<string> GetPlaceById(string PlaceId)
        {
            return GetById("place", PlaceId, new string[] { });
        }

        public static Task<string> GetRecordingById(string RecordingId)
        {
            return GetById("recording", RecordingId, new string[] { });
        }

        public static Task<string> GetRecordingById(string RecordingId, params string[] AdditionalFields)
        {
            return GetById("recording", RecordingId, AdditionalFields);
        }

        public static Task<string> GetRecordingById(string RecordingId, bool IncludeAllAdditionalFields)
        {
            string[] fieldSet = new string[] { };
            if (IncludeAllAdditionalFields == true)
            {
                fieldSet = new List<string> { "artists", "releases" }.ToArray();
            }
            return GetById("recording", RecordingId, fieldSet);
        }

        public static Task<string> GetReleaseById(string ReleaseId, params string[] AdditionalFields)
        {
            return GetById("release", ReleaseId, AdditionalFields);
        }

        public static Task<string> GetReleaseById(string ReleaseId, bool IncludeAllAdditionalFields)
        {
            string[] fieldSet = new string[] { };
            if (IncludeAllAdditionalFields == true)
            {
                var fields = new List<string> { "artists", "collections", "labels", "recordings", "release-groups" };
                var relationshipsFields = new List<string> { "area-rels", "artist-rels", "event-rels", "instrument-rels", "label-rels", "place-rels", "recording-rels", "release-rels", "release-group-rels", "series-rels", "url-rels", "work-rels" };
                fields.AddRange(relationshipsFields);
                fieldSet = fields.ToArray();
            }
            return GetById("release", ReleaseId, fieldSet);
        }

        public static Task<string> GetReleaseGroupById(string ReleaseGroupId)
        {
            return GetById("release-group", ReleaseGroupId, new string[] { });
        }

        public static Task<string> GetReleaseGroupById(string ReleaseGroupId, params string[] AdditionalFields)
        {
            return GetById("release-group", ReleaseGroupId, AdditionalFields);
        }

        public static Task<string> GetReleaseGroupById(string ReleaseGroupId, bool IncludeAllAdditionalFields)
        {
            string[] fieldSet = new string[] { };
            if (IncludeAllAdditionalFields == true)
            {
                fieldSet = new List<string> { "artists", "releases" }.ToArray();
            }
            return GetById("release-group", ReleaseGroupId, fieldSet);
        }

        public static Task<string> GetSeriesById(string SeriesId)
        {
            return GetById("series", SeriesId, new string[] { });
        }

        public static Task<string> GetWorkById(string WorkId)
        {
            return GetById("work", WorkId, new string[] { });
        }

        public static Task<string> GetUrlById(string UrlId)
        {
            return GetById("url", UrlId, new string[] { });
        }

        public static Task<string> GetById(string EntityType, string EntityId, string[] AdditionalFields)
        {
            var url = EntityType + "/" + EntityId + "?fmt=json";
            if (AdditionalFields.Length > 0)
            {
                url += "&inc=";
                for (int i = 0; i < AdditionalFields.Length; i++)
                {
                    url += AdditionalFields[i] + " ";
                }
                url = url.Trim();
            }
            return Get(url);
        }

        /// <summary>
        /// Асинхронно запрашивает данные из базы MusicBrainz через веб-сервис JSON по указанному URL.
        /// </summary>
        /// <param name="Url">Относительный URL ресурса в базе данных. Пример, release/c0b0105b-a942-43c4-a2a8-a54f847a200e?fmt=json.</param>
        /// <returns></returns>
        public static Task<string> Get(string Url)
        {
            HttpClient JSONClient = new HttpClient();
            JSONClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            JSONClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/63.0.3239.132 Safari/537.36");
            return JSONClient.GetStringAsync($"{ServiceUrl}/ws/2/{Url}");
        }
    }
}
