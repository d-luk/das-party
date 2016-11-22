using SpotifyAPI.Web;
using SpotifyAPI.Web.Enums;
using SpotifyAPI.Web.Models;

namespace DasPartyHost.Spotify
{
    public class WebAPI
    {
        private readonly SpotifyWebAPI _spotify;

        public WebAPI()
        {
            _spotify = new SpotifyWebAPI
            {
                UseAuth = false // Disables Auth
            };
        }

        public SearchItem Search(string input) => _spotify.SearchItems(input, SearchType.Track);
    }
}