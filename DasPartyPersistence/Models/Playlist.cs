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

        public static Playlist Get(string hostID)
        {
            // TODO: Filter on hostID
            return DB.R.Table("playlist").Merge(playlist
                    => DB.R.HashMap("host", DB.R.Table("user").Get(playlist.G("hostID"))))[0].Without("hostID")
                .RunResult<Playlist>(DB.Connection);
        }

        public Track[] GetTracks()
        {
            return DB.R.Table("playlistTrack").Filter(DB.R.HashMap("playlistID", ID))

                // PlaylistTrack to Track with left join
                .InnerJoin(DB.R.Table("track"), (plTrack, track) => plTrack.G("trackID").Eq(track.G("id")))
                .G("right")

                // Temporarily add playlistTrackID
//                .Merge(track => DB.R.HashMap("playlistTrackID",
//                    DB.R.Table("playlistTrack").Filter(DB.R.HashMap("playlistID", ID)
//                        .With("trackID", track.G("id"))).G("id")))
                .Merge(track => DB.R.HashMap("playlistTrackID", "x"))

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

                // Remove playlistTrackID and execute
                .Without("playlistTrackID")
                .RunResult<Track[]>(DB.Connection);
        }

        public void AddTrack(Track track)
        {
            // Add track to database if not exists
            var trackExists =
                DB.R.Table("track").Filter(DB.R.HashMap("id", track.ID)).Count().Gt(0).Run<bool>(DB.Connection);
            if (!trackExists)
            {
                DB.R.Table("track")
                    .Insert(DB.R.HashMap("id", track.ID).With("name", track.Name).With("artist", track.Artist))
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
            track.Vote(Host.ID, ID);
        }
    }
}