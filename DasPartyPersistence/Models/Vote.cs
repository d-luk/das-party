namespace DasPartyPersistence.Models
{
    public class Vote
    {
        public string ID { get; }
        public string UserID { get; }
        public string PlaylistTrackID { get; }
        public string TrackID { get; }
        public bool IsDownvote { get; }

        public Vote(string id, string userID, string playlistTrackID, bool isDownvote, string trackID = null)
        {
            ID = id;
            UserID = userID;
            PlaylistTrackID = playlistTrackID;
            IsDownvote = isDownvote;
            TrackID = trackID;
        }
    }
}