using System.Collections.Generic;
using System.Linq;
using DasPartyPersistence.Models;
using Microsoft.AspNet.SignalR;

namespace DasPartyWeb
{
    public class PlaylistHub : Hub
    {
        private readonly List<Playlist> _playlists = new List<Playlist>();

        public bool Join(string playlistID)
        {
            Groups.Add(Context.ConnectionId, playlistID);

            var playlistFound = _playlists.Any(playlist => playlist.ID == playlistID);

            var success = playlistFound;
            if (!playlistFound)
            {
                var newPlaylist = InitPlaylist(playlistID);
                if (newPlaylist != null)
                {
                    _playlists.Add(InitPlaylist(playlistID));
                    success = true;
                }
            }

            return success;
        }

        private Playlist InitPlaylist(string playlistID)
        {
            var playlist = Playlist.Get(playlistID);

            playlist.OnPlaylistChange += (s, a) =>
            {
                Clients.Group(playlistID).applyChanges(a.Tracks);
            };

            return playlist;
        }
        
    }
}