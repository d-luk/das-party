using RethinkDb.Driver;
using RethinkDb.Driver.Net;

namespace DasPartyPersistence
{
    public static class DB
    {
        public static RethinkDB R => RethinkDB.R;

        private static Connection _conn;

        public static Connection Connection
            => _conn ?? (_conn = R.Connection()
                   .Hostname("westre.net")
                   .Port(119)
                   .Db("party")
                   .Timeout(60)
                   .Connect());

        public static void Close() => _conn.Close();
        public static void Reconnect() => _conn.Reconnect();

        // TODO: Database limits/timeouts
    }
}