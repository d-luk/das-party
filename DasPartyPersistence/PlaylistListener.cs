using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Timers;
using DasPartyPersistence.Models;
using Timer = System.Timers.Timer;

namespace DasPartyPersistence
{
    public class PlaylistListener
    {
        /// <summary>
        /// Milliseconds to wait until the change event is invoked (default is 1000ms)
        /// </summary>
        public int Timeout { private get; set; } = 1000;

        private readonly Dictionary<string, EventHandler<PlaylistChangeEventArgs>> _eventsDict
            = new Dictionary<string, EventHandler<PlaylistChangeEventArgs>>();

        public void AddHandler(string playlistID, EventHandler<PlaylistChangeEventArgs> handler)
        {
            lock (_eventsDict)
            {
                var containsKey = _eventsDict.ContainsKey(playlistID);

                // Add event handler to dictionary
                if (!containsKey) _eventsDict[playlistID] = null;
                _eventsDict[playlistID] += handler;

                // Start listening
                if (!containsKey) StartListening(playlistID);
            }
        }

        private void StartListening(string playlistID)
        {
            // Listen for vote changes
            new Thread(() =>
            {
                var voteChanges = DB.R.Table("vote").Changes().RunCursor<Vote>(DB.Connection);
                // TODO: Only changes on current playlist

                foreach (var voteChange in voteChanges)
                {
                    Debug.WriteLine("Votes changed");
                    FireEvent(playlistID);
                }
            }) {IsBackground = true}.Start();

            // Listen for playlistTrack changes
            new Thread(() =>
            {
                var playlistChanges = DB.R.Table("playlistTrack").Filter(DB.R.HashMap("playlistID", playlistID))
                    .Changes().RunCursor<Playlist>(DB.Connection);

                foreach (var playlistChange in playlistChanges)
                {
                    Debug.WriteLine("Playlist tracks changed");
                    FireEvent(playlistID);
                }
            }) {IsBackground = true}.Start();
        }

        private readonly Dictionary<string, Timer> _timers = new Dictionary<string, Timer>();

        private void FireEvent(string playlistID)
        {
            var fireEvent = new Action(() => _eventsDict[playlistID]
                .Invoke(this, new PlaylistChangeEventArgs(playlistID)));

            if (Timeout == 0)
            {
                fireEvent();
                return;
            }

            Timer timer;
            if (!_timers.ContainsKey(playlistID))
            {
                // Create timer for playlist
                timer = new Timer(Timeout) {AutoReset = false};
                _timers[playlistID] = timer;
            }
            else timer = _timers[playlistID];

            if (!timer.Enabled)
            {
                // Reset timer
                timer.Interval = Timeout;
                ElapsedEventHandler[] h = {null};
                timer.Elapsed += h[0] = (s, a) =>
                {
                    fireEvent();
                    timer.Elapsed -= h[0];
                };
                timer.Start();
            }
        }

        public class PlaylistChangeEventArgs : EventArgs
        {
            // TODO: Only store changes

            private readonly string _playlistID;

            private Track[] _tracks;
            public Track[] Tracks => _tracks ?? (_tracks = Playlist.GetTracks(_playlistID));

            public PlaylistChangeEventArgs(string playlistID)
            {
                _playlistID = playlistID;
            }
        }

        #region Singleton

        private static volatile PlaylistListener _instance;
        private static readonly object SyncRoot = new object();

        public static PlaylistListener Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (SyncRoot)
                    {
                        if (_instance == null)
                            _instance = new PlaylistListener();
                    }
                }

                return _instance;
            }
        }

        #endregion
    }
}