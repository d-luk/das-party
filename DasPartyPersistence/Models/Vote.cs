namespace DasPartyPersistence.Models
{
    public class Vote
    {
        public int ID { get; }
        public string User { get; } // TODO
        public string Track { get; } // TODO
        public bool IsDownvote { get; }

        public Vote(int id, string user, string track, bool isDownvote)
        {
            ID = id;
            User = user;
            Track = track;
            IsDownvote = isDownvote;
        }
    }
}