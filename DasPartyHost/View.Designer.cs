namespace DasPartyHost
{
    partial class View
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(View));
            this.panel1 = new System.Windows.Forms.Panel();
            this.playBtn = new System.Windows.Forms.Button();
            this.skipBtn = new System.Windows.Forms.Button();
            this.nowPlaying = new System.Windows.Forms.Label();
            this.searchListBox = new System.Windows.Forms.ListBox();
            this.searchInput = new System.Windows.Forms.TextBox();
            this.searchGroupBox = new System.Windows.Forms.GroupBox();
            this.addTrackBtn = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.artistDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.imageURLDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.votesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.trackBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel3 = new System.Windows.Forms.Panel();
            this.refreshBtn = new System.Windows.Forms.Button();
            this.upvoteBtn = new System.Windows.Forms.Button();
            this.downvoteBtn = new System.Windows.Forms.Button();
            this.nowPlayingBox = new System.Windows.Forms.GroupBox();
            this.nowPlayingImage = new System.Windows.Forms.PictureBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.searchGroupBox.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBindingSource)).BeginInit();
            this.panel3.SuspendLayout();
            this.nowPlayingBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nowPlayingImage)).BeginInit();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.playBtn);
            this.panel1.Controls.Add(this.skipBtn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(391, 16);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(5);
            this.panel1.Size = new System.Drawing.Size(93, 73);
            this.panel1.TabIndex = 0;
            // 
            // playBtn
            // 
            this.playBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.playBtn.Location = new System.Drawing.Point(5, 5);
            this.playBtn.Name = "playBtn";
            this.playBtn.Size = new System.Drawing.Size(83, 41);
            this.playBtn.TabIndex = 0;
            this.playBtn.Text = "Play";
            this.playBtn.UseVisualStyleBackColor = true;
            this.playBtn.Click += new System.EventHandler(this.playBtn_Click);
            // 
            // skipBtn
            // 
            this.skipBtn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.skipBtn.Location = new System.Drawing.Point(5, 46);
            this.skipBtn.Name = "skipBtn";
            this.skipBtn.Size = new System.Drawing.Size(83, 22);
            this.skipBtn.TabIndex = 2;
            this.skipBtn.Text = "Skip";
            this.skipBtn.UseVisualStyleBackColor = true;
            this.skipBtn.Click += new System.EventHandler(this.skipBtn_Click);
            // 
            // nowPlaying
            // 
            this.nowPlaying.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nowPlaying.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nowPlaying.Location = new System.Drawing.Point(76, 16);
            this.nowPlaying.Name = "nowPlaying";
            this.nowPlaying.Padding = new System.Windows.Forms.Padding(10);
            this.nowPlaying.Size = new System.Drawing.Size(315, 73);
            this.nowPlaying.TabIndex = 0;
            this.nowPlaying.Text = "Nothing";
            this.nowPlaying.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // searchListBox
            // 
            this.searchListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.searchListBox.FormattingEnabled = true;
            this.searchListBox.Location = new System.Drawing.Point(5, 38);
            this.searchListBox.Name = "searchListBox";
            this.searchListBox.Size = new System.Drawing.Size(190, 392);
            this.searchListBox.TabIndex = 1;
            this.searchListBox.SelectedIndexChanged += new System.EventHandler(this.searchListBox_SelectedIndexChanged);
            // 
            // searchInput
            // 
            this.searchInput.Dock = System.Windows.Forms.DockStyle.Top;
            this.searchInput.Location = new System.Drawing.Point(5, 18);
            this.searchInput.Name = "searchInput";
            this.searchInput.Size = new System.Drawing.Size(190, 20);
            this.searchInput.TabIndex = 2;
            this.searchInput.TextChanged += new System.EventHandler(this.searchInput_TextChanged);
            // 
            // searchGroupBox
            // 
            this.searchGroupBox.Controls.Add(this.searchListBox);
            this.searchGroupBox.Controls.Add(this.searchInput);
            this.searchGroupBox.Controls.Add(this.addTrackBtn);
            this.searchGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.searchGroupBox.Location = new System.Drawing.Point(0, 0);
            this.searchGroupBox.Name = "searchGroupBox";
            this.searchGroupBox.Padding = new System.Windows.Forms.Padding(5);
            this.searchGroupBox.Size = new System.Drawing.Size(200, 458);
            this.searchGroupBox.TabIndex = 3;
            this.searchGroupBox.TabStop = false;
            this.searchGroupBox.Text = "Search track";
            // 
            // addTrackBtn
            // 
            this.addTrackBtn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.addTrackBtn.Enabled = false;
            this.addTrackBtn.Location = new System.Drawing.Point(5, 430);
            this.addTrackBtn.Name = "addTrackBtn";
            this.addTrackBtn.Size = new System.Drawing.Size(190, 23);
            this.addTrackBtn.TabIndex = 3;
            this.addTrackBtn.Text = "Add track";
            this.addTrackBtn.UseVisualStyleBackColor = true;
            this.addTrackBtn.Click += new System.EventHandler(this.addTrackBtn_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.nowPlayingBox);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(487, 458);
            this.panel2.TabIndex = 4;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.dataGridView1);
            this.panel5.Controls.Add(this.panel3);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(487, 366);
            this.panel5.TabIndex = 2;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.artistDataGridViewTextBoxColumn,
            this.imageURLDataGridViewTextBoxColumn,
            this.votesDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.trackBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(487, 341);
            this.dataGridView1.TabIndex = 0;
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.ReadOnly = true;
            this.iDDataGridViewTextBoxColumn.Visible = false;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // artistDataGridViewTextBoxColumn
            // 
            this.artistDataGridViewTextBoxColumn.DataPropertyName = "Artist";
            this.artistDataGridViewTextBoxColumn.HeaderText = "Artist";
            this.artistDataGridViewTextBoxColumn.Name = "artistDataGridViewTextBoxColumn";
            this.artistDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // imageURLDataGridViewTextBoxColumn
            // 
            this.imageURLDataGridViewTextBoxColumn.DataPropertyName = "ImageURL";
            this.imageURLDataGridViewTextBoxColumn.HeaderText = "ImageURL";
            this.imageURLDataGridViewTextBoxColumn.Name = "imageURLDataGridViewTextBoxColumn";
            this.imageURLDataGridViewTextBoxColumn.ReadOnly = true;
            this.imageURLDataGridViewTextBoxColumn.Visible = false;
            // 
            // votesDataGridViewTextBoxColumn
            // 
            this.votesDataGridViewTextBoxColumn.DataPropertyName = "Votes";
            this.votesDataGridViewTextBoxColumn.HeaderText = "Votes";
            this.votesDataGridViewTextBoxColumn.Name = "votesDataGridViewTextBoxColumn";
            this.votesDataGridViewTextBoxColumn.ReadOnly = true;
            this.votesDataGridViewTextBoxColumn.Width = 50;
            // 
            // trackBindingSource
            // 
            this.trackBindingSource.DataSource = typeof(DasPartyPersistence.Models.Track);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.refreshBtn);
            this.panel3.Controls.Add(this.upvoteBtn);
            this.panel3.Controls.Add(this.downvoteBtn);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 341);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(487, 25);
            this.panel3.TabIndex = 4;
            // 
            // refreshBtn
            // 
            this.refreshBtn.Dock = System.Windows.Forms.DockStyle.Left;
            this.refreshBtn.Location = new System.Drawing.Point(0, 0);
            this.refreshBtn.Name = "refreshBtn";
            this.refreshBtn.Size = new System.Drawing.Size(75, 25);
            this.refreshBtn.TabIndex = 1;
            this.refreshBtn.Text = "Refresh";
            this.refreshBtn.UseVisualStyleBackColor = true;
            this.refreshBtn.Click += new System.EventHandler(this.refreshBtn_Click);
            // 
            // upvoteBtn
            // 
            this.upvoteBtn.Dock = System.Windows.Forms.DockStyle.Right;
            this.upvoteBtn.Location = new System.Drawing.Point(337, 0);
            this.upvoteBtn.Name = "upvoteBtn";
            this.upvoteBtn.Size = new System.Drawing.Size(75, 25);
            this.upvoteBtn.TabIndex = 2;
            this.upvoteBtn.Text = "Upvote";
            this.upvoteBtn.UseVisualStyleBackColor = true;
            this.upvoteBtn.Click += new System.EventHandler(this.upvoteBtn_Click);
            // 
            // downvoteBtn
            // 
            this.downvoteBtn.Dock = System.Windows.Forms.DockStyle.Right;
            this.downvoteBtn.Location = new System.Drawing.Point(412, 0);
            this.downvoteBtn.Name = "downvoteBtn";
            this.downvoteBtn.Size = new System.Drawing.Size(75, 25);
            this.downvoteBtn.TabIndex = 3;
            this.downvoteBtn.Text = "Downvote";
            this.downvoteBtn.UseVisualStyleBackColor = true;
            this.downvoteBtn.Click += new System.EventHandler(this.downvoteBtn_Click);
            // 
            // nowPlayingBox
            // 
            this.nowPlayingBox.Controls.Add(this.nowPlaying);
            this.nowPlayingBox.Controls.Add(this.nowPlayingImage);
            this.nowPlayingBox.Controls.Add(this.panel1);
            this.nowPlayingBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.nowPlayingBox.Location = new System.Drawing.Point(0, 366);
            this.nowPlayingBox.Name = "nowPlayingBox";
            this.nowPlayingBox.Size = new System.Drawing.Size(487, 92);
            this.nowPlayingBox.TabIndex = 4;
            this.nowPlayingBox.TabStop = false;
            this.nowPlayingBox.Text = "Now playing";
            // 
            // nowPlayingImage
            // 
            this.nowPlayingImage.Dock = System.Windows.Forms.DockStyle.Left;
            this.nowPlayingImage.Location = new System.Drawing.Point(3, 16);
            this.nowPlayingImage.Name = "nowPlayingImage";
            this.nowPlayingImage.Size = new System.Drawing.Size(73, 73);
            this.nowPlayingImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.nowPlayingImage.TabIndex = 1;
            this.nowPlayingImage.TabStop = false;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.searchGroupBox);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(487, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(200, 458);
            this.panel4.TabIndex = 2;
            // 
            // View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(687, 458);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel4);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(0, 310);
            this.Name = "View";
            this.Text = "Das.Party";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.View_KeyDown);
            this.panel1.ResumeLayout(false);
            this.searchGroupBox.ResumeLayout(false);
            this.searchGroupBox.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBindingSource)).EndInit();
            this.panel3.ResumeLayout(false);
            this.nowPlayingBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nowPlayingImage)).EndInit();
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button playBtn;
        private System.Windows.Forms.ListBox searchListBox;
        private System.Windows.Forms.TextBox searchInput;
        private System.Windows.Forms.GroupBox searchGroupBox;
        private System.Windows.Forms.Button skipBtn;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label nowPlaying;
        private System.Windows.Forms.GroupBox nowPlayingBox;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.PictureBox nowPlayingImage;
        private System.Windows.Forms.Button addTrackBtn;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button refreshBtn;
        private System.Windows.Forms.Button upvoteBtn;
        private System.Windows.Forms.Button downvoteBtn;
        private System.Windows.Forms.BindingSource trackBindingSource;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn artistDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn imageURLDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn votesDataGridViewTextBoxColumn;
    }
}

