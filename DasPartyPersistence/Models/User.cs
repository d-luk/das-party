using RethinkDb.Driver.Ast;

namespace DasPartyPersistence.Models
{
    public class User
    {
        public string ID { get; }
        public string Name { get; }

        public User(string id, string name)
        {
            ID = id;
            Name = name;
        }

        public static User Get(string id)
        {
            return DB.R.Table("user").Filter(DB.R.HashMap("id", id)).Nth(0).RunResult<User>(DB.Connection);
        }

        /// <summary>
        /// Retrieves all votes casted by the provided <paramref name="userID"/>. 
        /// The results will be filtered by the <paramref name="playlistID"/> if provided.
        /// If no <paramref name="playlistID"/> is present, <see cref="Vote.TrackID"/> will be <c>null</c> for each result.
        /// </summary>
        public static Vote[] GetVotes(string userID, string playlistID = null)
        {
            ReqlExpr query = DB.R.Table("vote").Filter(DB.R.HashMap("userID", userID));

            if (!string.IsNullOrEmpty(playlistID))
            {
                // Filter by playlistID
                query = query.InnerJoin(DB.R.Table("playlistTrack"),
                        (vote, playlistTrack) => vote.G("playlistTrackID").Eq(playlistTrack.G("id")))
                    .Without(DB.R.HashMap("right", "id"))
                    .Zip().Filter(DB.R.HashMap("playlistID", playlistID))
                    .Without("playlistID"); 
            }

            return query.RunResult<Vote[]>(DB.Connection);
        }
    }
}