using System.Collections.Generic;
using System.Linq;
using DasPartyPersistence;
using DasPartyPersistence.Models;
using Microsoft.AspNet.SignalR;
using SpotifyWebAPI;

namespace DasPartyWeb
{
    public class PlaylistHub : Hub
    {
        private static readonly List<Playlist> Playlists = new List<Playlist>();
        private static readonly WebAPI WebAPI = new WebAPI();

        public bool Join(string playlistID)
        {
            Groups.Add(Context.ConnectionId, playlistID);

            var playlistFound = Playlists.Any(playlist => playlist.ID == playlistID);

            var success = playlistFound;
            if (!playlistFound)
            {
                var newPlaylist = InitPlaylist(playlistID);
                if (newPlaylist != null)
                {
                    Playlists.Add(InitPlaylist(playlistID));
                    success = true;
                }
            }

            return success;
        }

        private Playlist InitPlaylist(string playlistID)
        {
            var playlist = Playlist.Get(playlistID); 
            PlaylistListener.Instance.AddHandler(playlist.ID, (s, a) => Clients.Group(playlistID).applyChanges(a.Tracks));
            return playlist;
        }

        public bool Vote(string userID, string playlistID, string trackID, bool isDownvote)
        {
            // TODO: Authentication
            var playlist = Playlists.FirstOrDefault(p => p.ID == playlistID);

            var success = playlist != null;
            if (success)
            {
                var track = playlist.GetTrack(trackID);
                success = track != null;
                if (success)
                {
                    track.Vote(userID, playlistID, isDownvote);
                }
            }

            return success;
        }

        public TrackResult[] Search(string input)
            => WebAPI.SearchTracks(input, 10);

        public bool AddTrack(string userID, string playlistID, string trackID)
        {
            // TODO: Authentication
            var playlist = Playlists.FirstOrDefault(p => p.ID == playlistID);

            var success = playlist != null;
            if (success)
            {
                var track = WebAPI.GetTrackByID(trackID);
                success = track != null;
                if (success)
                {
                    playlist.AddTrack(new Track(track.ID, track.Artist, track.Name, track.ImageURL, track.Votes), userID);
                }
            }

            return success;
        }
    }
}