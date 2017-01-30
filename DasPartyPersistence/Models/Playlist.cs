using System.Linq;

namespace DasPartyPersistence.Models
{
    public class Playlist
    {
        public string ID { get; }
        public string Name { get; }
        public User Host { get; }

        public Playlist(string id, string name, User host)
        {
            ID = id;
            Name = name;
            Host = host;
        }

        public static Playlist Get(string id)
        {
            return DB.R.Table("playlist").Filter(DB.R.HashMap("id", id)).Merge(playlist
                    => DB.R.HashMap("host", DB.R.Table("user").Get(playlist.G("hostID"))))[0].Without("hostID")
                .RunResult<Playlist>(DB.Connection);
        }

        public static Playlist GetByHost(string hostID)
        {
            return DB.R.Table("playlist").Filter(DB.R.HashMap("hostID", hostID)).Merge(playlist
                    => DB.R.HashMap("host", DB.R.Table("user").Get(playlist.G("hostID"))))[0]
                .RunResult<Playlist>(DB.Connection);
        }

        public Track[] GetTracks() => GetTracks(ID);

        public static Track[] GetTracks(string playlistID)
        {
            return DB.R.Table("playlistTrack").Filter(DB.R.HashMap("playlistID", playlistID))

                // PlaylistTrack to Track with left join
                .InnerJoin(DB.R.Table("track"), (plTrack, track) => plTrack.G("trackID").Eq(track.G("id")))
                .G("right")

                // Temporarily add playlistTrackID
                .Merge(
                    track =>
                        DB.R.HashMap("playlistTrackID",
                            DB.R.Table("playlistTrack").Filter(DB.R.HashMap("playlistID", playlistID)
                                .With("trackID", track.G("id"))).Nth(0)["id"]))

                // Calculate votes
                .Merge(track => DB.R.HashMap("votes",
                    // Count all upvotes of this track
                    DB.R.Table("vote")
                        .Filter(DB.R.HashMap("playlistTrackID", track.G("playlistTrackID"))
                            .With("isDownvote", false)).Count()

                        // Subtract all downvotes
                        .Sub(DB.R.Table("vote")
                            .Filter(DB.R.HashMap("playlistTrackID", track.G("playlistTrackID"))
                                .With("isDownvote", true)).Count())))
                .Without("playlistTrackID")
                .OrderBy(DB.R.Desc("votes"))
                .RunResult<Track[]>(DB.Connection);
        }

        public Track GetTrack(string trackID)
        {
            // TODO: Optimize with custom query
            return GetTracks().First(t => t.ID == trackID);
        }

        public void AddTrack(Track track, string userID)
        {
            // Add track to database if not exists
            var trackExists =
                DB.R.Table("track").Filter(DB.R.HashMap("id", track.ID)).Count().Gt(0).Run<bool>(DB.Connection);
            if (!trackExists)
            {
                DB.R.Table("track")
                    .Insert(
                        DB.R.HashMap("id", track.ID)
                            .With("name", track.Name)
                            .With("artist", track.Artist)
                            .With("imageURL", track.ImageURL))
                    .Run(DB.Connection);
            }

            // Add track to playlist if not exists
            var trackInPlaylist = trackExists && DB.R.Table("playlistTrack")
                                      .Filter(DB.R.HashMap("trackID", track.ID))
                                      .Count().Gt(0)
                                      .Run<bool>(DB.Connection);
            if (!trackInPlaylist)
            {
                DB.R.Table("playlistTrack")
                    .Insert(DB.R.HashMap("playlistID", ID).With("trackID", track.ID))
                    .Run(DB.Connection);
            }

            // Add upvote by host if not exists
            track.Vote(userID, ID);
        }
    }
}