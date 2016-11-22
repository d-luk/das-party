using System.Linq;
using SpotifyAPI.Web.Models;

namespace DasPartyHost.Models
{
    public class TrackResult
    {
        public string ID { get; }
        public string Name { get; }
        public string[] Artists { get; }
        public int Votes { get; }

        public bool HideArtist { private get; set; }

        public TrackResult(string id, string name, string[] artists, int votes = 1)
        {
            ID = id;
            Name = name;
            Artists = artists;
            Votes = votes;
        }

        public TrackResult(FullTrack track) : this(track.Id, track.Name, track.Artists.Select(artist => artist.Name).ToArray())
        {
        }

        public override string ToString() => (HideArtist ? "" : Artists[0] + " - ") + Name;
    }
}