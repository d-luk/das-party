using System.Linq;
using SpotifyAPI.Web.Enums;

namespace SpotifyWebAPI
{
    public class WebAPI
    {
        private readonly SpotifyAPI.Web.SpotifyWebAPI _spotify;

        public WebAPI()
        {
            _spotify = new SpotifyAPI.Web.SpotifyWebAPI
            {
                UseAuth = false
            };
        }

        public TrackResult[] SearchTracks(string input, int limit = 20)
        {
            return _spotify.SearchItems(input, SearchType.Track, limit).Tracks.Items
                .Select(fullTrack => new TrackResult(fullTrack)).ToArray();
        }

        public TrackResult GetTrackByID(string trackID)
        {
            var track = _spotify.GetTrack(trackID);
            return track != null ? new TrackResult(track) : null;
        }
    }
} 