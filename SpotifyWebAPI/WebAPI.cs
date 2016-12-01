using SpotifyAPI.Web.Enums;
using SpotifyAPI.Web.Models;

namespace SpotifyWebAPI
{
    public class WebAPI
    {
        private readonly SpotifyAPI.Web.SpotifyWebAPI _spotify;

        public WebAPI()
        {
            _spotify = new SpotifyAPI.Web.SpotifyWebAPI
            {
                UseAuth = false // Disables Auth
            };
        }

        public SearchItem Search(string input) => _spotify.SearchItems(input, SearchType.Track);
    }
}