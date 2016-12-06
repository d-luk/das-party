using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using SpotifyAPI.Local;
using SpotifyAPI.Local.Models;

namespace DasPartyHost.Spotify
{
    /// <summary>
    /// Remote for controlling the Spotify client
    /// </summary>
    public class SpotifyRemote
    {
        private readonly SpotifyLocalAPI _spotify;
        private bool _switching;

        public SpotifyRemote()
        {
            _spotify = new SpotifyLocalAPI {ListenForEvents = true};
            _spotify.OnPlayStateChange += (s, e) =>
            {
                // Match Remote.IsPlaying with client
                if (Status.Playing != IsPlaying) IsPlaying = Status.Playing;
            };
            _spotify.OnTrackChange += async (s, e) =>
            {
                // Pause and trigger OnTrackDone if track was not changed by Remote
                if (_switching) _switching = false;
                else
                {
                    await Pause();
                    OnTrackDone?.Invoke(this, EventArgs.Empty);
                }
            };
            TryConnect();

            IsPlaying = Status.Playing;
        }

        #region Events

        public EventHandler OnPlayStateChange;
        public EventHandler OnTrackDone;
        public EventHandler<ConnectionErrorEventArgs> OnConnectionError;

        public class ConnectionErrorEventArgs : EventArgs
        {
            public Type ErrorType { get; }

            public ConnectionErrorEventArgs(Type errorType)
            {
                ErrorType = errorType;
            }

            public enum Type
            {
                SpotifyNotRunning,
                SpotifyWebHelperConnection,
                SpotifyConnection
            }
        }
        
        #endregion

        public StatusResponse Status
        {
            get
            {
                TryConnect();
                return _spotify.GetStatus();
            }
        }

        private bool _isPlaying;
        public bool IsPlaying
        {
            get { return _isPlaying; }
            private set
            {
                _isPlaying = value;
                OnPlayStateChange?.Invoke(this, EventArgs.Empty);
            }
        }

        public async Task Play()
        {
            await _spotify.Play();
            IsPlaying = true;
        }

        public async Task Pause()
        {
            await _spotify.Pause();
            IsPlaying = false;
        }

        public async void Play(string trackID)
        {
            _switching = true;
            await _spotify.PlayURL("spotify:track:" + trackID);
            IsPlaying = true;
        }

        public void Skip() => _spotify.Skip();

        #region Connect to Spotify client

        private bool _processStarted;

        private void TryConnect()
        {
            var connected = false;
            while (!connected)
            {
                if (!SpotifyLocalAPI.IsSpotifyRunning())
                {
                    if (!_processStarted)
                    {
                        // Try to start the Spotify client and try to connect again
                        _processStarted = true;
                        try
                        {
                            Process.Start(Path.Combine(
                                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Spotify",
                                "Spotify.exe"));
                            continue;
                        }
                        catch (Win32Exception)
                        {
                            // Could not find or start Spotify client
                        }
                    }

                    OnConnectionError?.Invoke(this,
                        new ConnectionErrorEventArgs(ConnectionErrorEventArgs.Type.SpotifyNotRunning));
                }
                if (!SpotifyLocalAPI.IsSpotifyWebHelperRunning())
                {
                    OnConnectionError?.Invoke(this,
                        new ConnectionErrorEventArgs(ConnectionErrorEventArgs.Type.SpotifyWebHelperConnection));
                }
                if (!_spotify.Connect())
                {
                    OnConnectionError?.Invoke(this,
                        new ConnectionErrorEventArgs(ConnectionErrorEventArgs.Type.SpotifyConnection));
                }

                connected = true;
            }
        }

        #endregion
    }
}