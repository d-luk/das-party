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
            this.panel1 = new System.Windows.Forms.Panel();
            this.playBtn = new System.Windows.Forms.Button();
            this.skipBtn = new System.Windows.Forms.Button();
            this.nowPlaying = new System.Windows.Forms.Label();
            this.searchListBox = new System.Windows.Forms.ListBox();
            this.searchInput = new System.Windows.Forms.TextBox();
            this.searchGroupBox = new System.Windows.Forms.GroupBox();
            this.addTrackBtn = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.nowPlayingBox = new System.Windows.Forms.GroupBox();
            this.nowPlayingImage = new System.Windows.Forms.PictureBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.refreshBtn = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.searchGroupBox.SuspendLayout();
            this.panel2.SuspendLayout();
            this.nowPlayingBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nowPlayingImage)).BeginInit();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.playBtn);
            this.panel1.Controls.Add(this.skipBtn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(418, 16);
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
            this.nowPlaying.Size = new System.Drawing.Size(342, 73);
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
            this.panel2.Controls.Add(this.nowPlayingBox);
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(514, 458);
            this.panel2.TabIndex = 4;
            // 
            // nowPlayingBox
            // 
            this.nowPlayingBox.Controls.Add(this.nowPlaying);
            this.nowPlayingBox.Controls.Add(this.nowPlayingImage);
            this.nowPlayingBox.Controls.Add(this.panel1);
            this.nowPlayingBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.nowPlayingBox.Location = new System.Drawing.Point(0, 366);
            this.nowPlayingBox.Name = "nowPlayingBox";
            this.nowPlayingBox.Size = new System.Drawing.Size(514, 92);
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
            // panel5
            // 
            this.panel5.Controls.Add(this.button2);
            this.panel5.Controls.Add(this.button1);
            this.panel5.Controls.Add(this.refreshBtn);
            this.panel5.Controls.Add(this.dataGridView1);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(514, 458);
            this.panel5.TabIndex = 2;
            // 
            // refreshBtn
            // 
            this.refreshBtn.Location = new System.Drawing.Point(13, 337);
            this.refreshBtn.Name = "refreshBtn";
            this.refreshBtn.Size = new System.Drawing.Size(75, 23);
            this.refreshBtn.TabIndex = 1;
            this.refreshBtn.Text = "Refresh";
            this.refreshBtn.UseVisualStyleBackColor = true;
            this.refreshBtn.Click += new System.EventHandler(this.refreshBtn_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView1.Size = new System.Drawing.Size(514, 458);
            this.dataGridView1.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.searchGroupBox);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(514, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(200, 458);
            this.panel4.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(342, 337);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Upvote";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(423, 337);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Downvote";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 458);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel4);
            this.MaximumSize = new System.Drawing.Size(1024, 768);
            this.MinimumSize = new System.Drawing.Size(16, 310);
            this.Name = "View";
            this.Text = "Party Macher 2000";
            this.panel1.ResumeLayout(false);
            this.searchGroupBox.ResumeLayout(false);
            this.searchGroupBox.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.nowPlayingBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nowPlayingImage)).EndInit();
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}

