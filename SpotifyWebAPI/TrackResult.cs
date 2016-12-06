using System.Linq;
using SpotifyAPI.Web.Models;

namespace SpotifyWebAPI
{
    public class TrackResult
    {
        public string ID { get; }
        public string Name { get; }
        public string Artist { get; }
        public string ImageURL { get; }
        public int Votes { get; }

        public bool HideArtist { private get; set; }

        public TrackResult(string id, string name, string artist, string imageUrl, int votes = 0)
        {
            ID = id;
            Name = name;
            Artist = artist;
            ImageURL = imageUrl;
            Votes = votes;
        }

        public TrackResult(FullTrack track) : this(track.Id, track.Name, track.Artists.Select(artist => artist.Name).FirstOrDefault(), (track.Album.Images[1] ?? track.Album.Images[0])?.Url)
        {
        }

        public override string ToString() => (HideArtist ? "" : Artist + " - ") + Name;
    }
}