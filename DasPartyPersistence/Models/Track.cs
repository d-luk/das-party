namespace DasPartyPersistence.Models
{
    public class Track
    {
        public string ID { get; }
        public string Name { get; }
        public string Artist { get; }
        public string ImageURL { get; }
        public int Votes { get; }

        public Track(string id, string artist, string name, string imageUrl, int votes)
        {
            ID = id;
            Artist = artist;
            Name = name;
            ImageURL = imageUrl;
            Votes = votes;
        }

        public string GetPlaylistTrackID(string playlistID) 
            => DB.R.Table("playlistTrack").Filter(DB.R.HashMap("playlistID", playlistID)
                .With("trackID", ID))[0].G("id").RunResult<string>(DB.Connection);
        
        public void Delete(string playlistID)
        {
            DB.R.Table("vote").Filter(DB.R.HashMap("playlistTrackID", GetPlaylistTrackID(playlistID))).Run(DB.Connection);
            DB.R.Table("playlistTrack").Filter(DB.R.HashMap("trackID", ID)).Delete().Run(DB.Connection);
        }

        public void Vote(string userID, string playlistID, bool isDownvote = false)
        {
            var playlistTrackID = GetPlaylistTrackID(playlistID);

            // Remove previous vote if exists
            DB.R.Table("vote")
                .Filter(DB.R.HashMap("userID", userID).With("playlistTrackID", playlistTrackID))
                .Delete().Run(DB.Connection);

            // Add vote
            DB.R.Table("vote")
                .Insert(DB.R.HashMap("userID", userID)
                    .With("playlistTrackID", playlistTrackID)
                    .With("isDownvote", isDownvote)).Run(DB.Connection);
        }
    }
}