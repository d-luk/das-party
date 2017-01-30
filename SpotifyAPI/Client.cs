using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net.Mime;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace DasPartyHost.Spotify
{
    public class Client
    {
        private readonly SpotifyLocalAPI _spotify;
        private readonly View _view;

        private bool _switching;

        public Client(View view)
        {
            _view = view;

            _spotify = new SpotifyLocalAPI {ListenForEvents = true};
            _spotify.OnPlayStateChange += (s, e) => Playing = Status.Playing;
            _spotify.OnTrackChange += (s, e) =>
            {
                if (_switching) _switching = false;
                else view.PlayNextTrack();
            };
            TryConnect();

            _isPlaying = Status.Playing;
        }

        public StatusResponse Status
        {
            get
            {
                TryConnect();
                return _spotify.GetStatus();
            }
        }

        private bool _processStarted;

        private void TryConnect()
        {
            while (true)
            {
                if (!SpotifyLocalAPI.IsSpotifyRunning())
                {
                    if (!_processStarted)
                    {
                        // Try to start the Spotify client and try to connect again
                        try
                        {
                            Process.Start(Path.Combine(
                                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Spotify",
                                "Spotify.exe"));
                            _processStarted = true;
                            continue;
                        }
                        catch (Win32Exception)
                        {
                        }
                    }

                    var result = MessageBox.Show(_view, "Spotify is not running", "Cannot start party!",
                        MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);

                    if (result == DialogResult.Retry) continue;
                    else MediaTypeNames.Application.Exit();
                }
                if (!SpotifyLocalAPI.IsSpotifyWebHelperRunning())
                {
                    var result = MessageBox.Show(_view, "Spotify Web Helper is not running. Try restarting Spotify.",
                        "Cannot start party!", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);

                    if (result == DialogResult.Retry) continue;
                    else MediaTypeNames.Application.Exit();
                }
                if (!_spotify.Connect())
                {
                    var result = MessageBox.Show(_view, "Could not connect to Spotify. Try restarting Spotify.",
                        "Cannot start party!", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);

                    if (result == DialogResult.Retry) continue;
                    else MediaTypeNames.Application.Exit();
                }
                break;
            }
        }

        private bool _isPlaying;

        public bool Playing
        {
            get { return _isPlaying; }
            set
            {
                if (!_isPlaying && value) Play();
                else if (_isPlaying && !value) Pause();
            }
        }

        private async void Play()
        {
            await _spotify.Play();
            _isPlaying = true;
            _view.InvokeIfRequired(() => _view.UpdatePlayButton());
        }

        private async void Pause()
        {
            await _spotify.Pause();
            _isPlaying = false;
            _view.InvokeIfRequired(() => _view.UpdatePlayButton());
        }

        public async void Play(string trackID)
        {
            _switching = true;
            await _spotify.PlayURL("spotify:track:" + trackID);
        }

        public void Skip() => _spotify.Skip();
    }
}