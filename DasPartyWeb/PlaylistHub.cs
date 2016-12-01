using System.Collections.Generic;
using System.Linq;
using DasPartyPersistence.Models;
using Microsoft.AspNet.SignalR;
using SpotifyAPI.Web;

namespace DasPartyWeb
{
    public class PlaylistHub : Hub
    {
        private static readonly List<Playlist> Playlists = new List<Playlist>();
        private readonly SpotifyWebAPI _api = new SpotifyWebAPI();

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
            playlist.OnPlaylistChange += (s, a) => Clients.Group(playlistID).applyChanges(a.Tracks);
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

//        public Track[] Search(string input)
//        {
//            new SpotifyWebAPI();
//        }
    }
}