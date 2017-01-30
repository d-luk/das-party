using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using DasPartyPersistence;
using DasPartyPersistence.Models;
using SpotifyAPI.Local.Enums;
using SpotifyWebAPI;
using Timer = System.Timers.Timer;

namespace DasPartyHost
{
    public partial class View : Form
    {
        private readonly SpotifyRemote _remote;
        private readonly WebAPI _web;

        private readonly Playlist _playlist;

        private const string UserID = "9b9e4883-3d06-462f-ae16-324968aab4f6";

        public View()
        {
            InitializeComponent();
            
            // Connect to the Spotify client:
            _remote = new SpotifyRemote();
            UpdateTrackView();
            UpdatePlayButton();
            _remote.OnTrackDone += (s, a) => this.InvokeIfRequired(() => PlayNextTrack());
            _remote.OnConnectionError += OnRemoteConnectionError;
            _remote.OnPlayStateChange += (s, a) => this.InvokeIfRequired(UpdatePlayButton);

            // Connect to the Spotify web API:
            _web = new WebAPI();

            // Retrieve playlist from database
            _playlist = Playlist.GetByHost(UserID);
            UpdatePlaylistView();

            // Listen to playlist changes
            var listener = PlaylistListener.Instance;
            listener.Timeout = 100; 
            listener.AddHandler(_playlist.ID, (sender, args) => UpdatePlaylistView());
        }

        #region Update view

        private void UpdateTrackView()
        {
            var track = _remote.Status.Track;
            this.InvokeIfRequired(() =>
            {
                if (track != null)
                {
                    nowPlaying.Text = track.ArtistResource.Name + " - " + track.TrackResource.Name;
                    nowPlayingImage.Image = track.GetAlbumArt(AlbumArtSize.Size160);
                }
                else
                {
                    nowPlaying.Text = "Nothing";
                    nowPlayingImage.Image = null;
                }
            });
        }

        private void UpdatePlayButton() => playBtn.Text = _remote.IsPlaying ? "Pause" : "Play";

        private void UpdatePlaylistView()
        {
            this.InvokeIfRequired(() =>
            {
                var selectedRowIndex = dataGridView1.CurrentCell?.RowIndex;
                dataGridView1.DataSource = _playlist.GetTracks();

                // Select the previously selected row again
                if (selectedRowIndex != null && dataGridView1.Rows.Count > selectedRowIndex)
                {
                    // Select the first *visible* column (1)
                    dataGridView1.CurrentCell = dataGridView1.Rows[(int) selectedRowIndex].Cells[1];
                }
            });
        }

        #endregion

        #region Spotify control

        private void playBtn_Click(object sender, EventArgs e)
        {
            Task.Run(async () =>
            {
                if (_remote.IsPlaying) await _remote.Pause();
                else await _remote.Play();
            });

            this.InvokeIfRequired(UpdatePlayButton);
        }

        private void skipBtn_Click(object sender, EventArgs e)
        {
            _remote.Skip();
            playBtn.Focus();
        }

        public bool PlayNextTrack()
        {
            var tracks = _playlist.GetTracks();

            var success = true;
            if (tracks.Length > 0)
            {
                // Find track with most votes
                var track = tracks.MaxBy(t => t.Votes);

                // Remove track from playlist
                track.Delete(_playlist.ID);
                _remote.Play(track.ID);
                UpdatePlaylistView();
            }
            else success = false;
            UpdateTrackView();

            return success;
        }

        #endregion

        #region Track search

        private Timer _searchTimer;

        /// <summary>
        /// Retrieve search results based on input
        /// and put them in a listBox
        /// </summary>
        private void searchInput_TextChanged(object sender, EventArgs e)
        {
            // Executes after 500ms of not typing
            _searchTimer?.Close();
            _searchTimer = new Timer(500) {AutoReset = false};
            _searchTimer.Elapsed += (s, ex) =>
            {
                this.InvokeIfRequired(() =>
                {
                    addTrackBtn.Enabled = false;
                    searchListBox.ClearSelected();
                });
                var results = _web.SearchTracks(searchInput.Text);
                if (results.Length == 0) return;

                // Check if artist names can be hidden in results (if all are the same)
                var hideArtists = true;
                var tmpName = "";
                foreach (var track in results)
                {
                    var name = track.Artist;
                    if (tmpName == "") tmpName = name;
                    else if (name != tmpName)
                    {
                        hideArtists = false;
                        break;
                    }
                }

                // Add tracks to the result list
                Invoke(new MethodInvoker(delegate
                {
                    searchListBox.Items.Clear();

                    foreach (var track in results)
                    {
                        track.HideArtist = hideArtists;
                        searchListBox.Items.Add(track);
                    }
                }));
            };
            _searchTimer.Start();
        }

        /// <summary>
        /// Enables add-button when a track result is selected
        /// </summary>
        private void searchListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            addTrackBtn.Enabled = searchListBox.SelectedIndex >= 0;
        }

        private void addTrackBtn_Click(object sender, EventArgs e)
        {
            // Add track to the database
            var result = (TrackResult) searchListBox.SelectedItem;
            _playlist.AddTrack(new Track(result.ID, result.Artist, result.Name, result.ImageURL, result.Votes), UserID);

            // Remove result from the list
            searchListBox.Items.RemoveAt(searchListBox.SelectedIndex);
        }

        #endregion

        #region Managing playlist

        private void refreshBtn_Click(object sender, EventArgs e) => UpdatePlaylistView();

        private Track SelectedTrack => (Track) dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].DataBoundItem;

        /// <summary>
        /// Delete a track from the playlist
        /// </summary>
        private void View_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                SelectedTrack.Delete(_playlist.ID);
            }
        }

        #region Voting on a track

        private void upvoteBtn_Click(object sender, EventArgs e) => SelectedTrack.Vote(UserID, _playlist.ID);
        private void downvoteBtn_Click(object sender, EventArgs e) => SelectedTrack.Vote(UserID, _playlist.ID, true);

        #endregion

        #endregion

        #region Connection handling

        /// <summary>
        /// Tells the user that the Spotify client connection failed
        /// </summary>
        private void OnRemoteConnectionError(object s, SpotifyRemote.ConnectionErrorEventArgs a)
        {
            DialogResult result;
            switch (a.ErrorType)
            {
                case SpotifyRemote.ConnectionErrorEventArgs.Type.SpotifyNotRunning:
                    result = MessageBox.Show(this, "Spotify is not running", "Cannot start party!",
                        MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);

                    if (result == DialogResult.Retry) a.Retry = true;
                    else Application.Exit();
                    break;
                case SpotifyRemote.ConnectionErrorEventArgs.Type.SpotifyWebHelperConnection:
                    result = MessageBox.Show(this, "Spotify Web Helper is not running. Try restarting Spotify.",
                        "Cannot start party!", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);

                    if (result == DialogResult.Retry) a.Retry = true;
                    else Application.Exit();
                    break;
                case SpotifyRemote.ConnectionErrorEventArgs.Type.SpotifyConnection:
                    result = MessageBox.Show(this, "Could not connect to Spotify. Try restarting Spotify.",
                        "Cannot start party!", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);

                    if (result == DialogResult.Retry) a.Retry = true;
                    else Application.Exit();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        #endregion
    }
}