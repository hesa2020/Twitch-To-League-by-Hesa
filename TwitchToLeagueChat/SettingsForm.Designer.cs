namespace TwitchToLeagueChat
{
    partial class SettingsForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonGrabKey = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TwitchBotKey = new System.Windows.Forms.TextBox();
            this.TwitchBotUsername = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.GameDirectory = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SummonerName = new System.Windows.Forms.TextBox();
            this.TwitchMinimumLevel = new System.Windows.Forms.ComboBox();
            this.LeagueServer = new System.Windows.Forms.ComboBox();
            this.LeaguePassword = new System.Windows.Forms.TextBox();
            this.LeagueUsername = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.buttonGrabKey);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.TwitchBotKey);
            this.groupBox1.Controls.Add(this.TwitchBotUsername);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(389, 107);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Twitch Account Settings";
            // 
            // buttonGrabKey
            // 
            this.buttonGrabKey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonGrabKey.Location = new System.Drawing.Point(9, 74);
            this.buttonGrabKey.Name = "buttonGrabKey";
            this.buttonGrabKey.Size = new System.Drawing.Size(374, 23);
            this.buttonGrabKey.TabIndex = 5;
            this.buttonGrabKey.Text = "Grab Access Key";
            this.buttonGrabKey.UseVisualStyleBackColor = true;
            this.buttonGrabKey.Click += new System.EventHandler(this.ButtonGrabKey_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Access Key:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Account Name:";
            // 
            // TwitchBotKey
            // 
            this.TwitchBotKey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TwitchBotKey.Location = new System.Drawing.Point(118, 45);
            this.TwitchBotKey.Name = "TwitchBotKey";
            this.TwitchBotKey.PasswordChar = '•';
            this.TwitchBotKey.Size = new System.Drawing.Size(265, 20);
            this.TwitchBotKey.TabIndex = 1;
            // 
            // TwitchBotUsername
            // 
            this.TwitchBotUsername.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TwitchBotUsername.Location = new System.Drawing.Point(118, 19);
            this.TwitchBotUsername.Name = "TwitchBotUsername";
            this.TwitchBotUsername.Size = new System.Drawing.Size(265, 20);
            this.TwitchBotUsername.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.GameDirectory);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.SummonerName);
            this.groupBox2.Controls.Add(this.TwitchMinimumLevel);
            this.groupBox2.Controls.Add(this.LeagueServer);
            this.groupBox2.Controls.Add(this.LeaguePassword);
            this.groupBox2.Controls.Add(this.LeagueUsername);
            this.groupBox2.Location = new System.Drawing.Point(12, 125);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(389, 183);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "League Account Settings";
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button2.Location = new System.Drawing.Point(347, 150);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(36, 23);
            this.button2.TabIndex = 10;
            this.button2.Text = "...";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // GameDirectory
            // 
            this.GameDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GameDirectory.Location = new System.Drawing.Point(118, 151);
            this.GameDirectory.Name = "GameDirectory";
            this.GameDirectory.Size = new System.Drawing.Size(223, 20);
            this.GameDirectory.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 154);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(83, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "Game Directory:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 128);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Summoner name:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 101);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Minimum Level:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Server:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Bot Password:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Bot Username:";
            // 
            // SummonerName
            // 
            this.SummonerName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SummonerName.Location = new System.Drawing.Point(118, 125);
            this.SummonerName.Name = "SummonerName";
            this.SummonerName.Size = new System.Drawing.Size(265, 20);
            this.SummonerName.TabIndex = 6;
            // 
            // TwitchMinimumLevel
            // 
            this.TwitchMinimumLevel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TwitchMinimumLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TwitchMinimumLevel.FormattingEnabled = true;
            this.TwitchMinimumLevel.Items.AddRange(new object[] {
            "Moderators",
            "Subscribers",
            "Viewers"});
            this.TwitchMinimumLevel.Location = new System.Drawing.Point(118, 98);
            this.TwitchMinimumLevel.Name = "TwitchMinimumLevel";
            this.TwitchMinimumLevel.Size = new System.Drawing.Size(265, 21);
            this.TwitchMinimumLevel.Sorted = true;
            this.TwitchMinimumLevel.TabIndex = 5;
            // 
            // LeagueServer
            // 
            this.LeagueServer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LeagueServer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.LeagueServer.FormattingEnabled = true;
            this.LeagueServer.Items.AddRange(new object[] {
            "BR",
            "EUNE",
            "EUW",
            "JP",
            "LA1",
            "LA2",
            "NA",
            "OC1",
            "RU",
            "TEST",
            "TR"});
            this.LeagueServer.Location = new System.Drawing.Point(118, 71);
            this.LeagueServer.Name = "LeagueServer";
            this.LeagueServer.Size = new System.Drawing.Size(265, 21);
            this.LeagueServer.Sorted = true;
            this.LeagueServer.TabIndex = 4;
            // 
            // LeaguePassword
            // 
            this.LeaguePassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LeaguePassword.Location = new System.Drawing.Point(118, 45);
            this.LeaguePassword.Name = "LeaguePassword";
            this.LeaguePassword.PasswordChar = '•';
            this.LeaguePassword.Size = new System.Drawing.Size(265, 20);
            this.LeaguePassword.TabIndex = 3;
            // 
            // LeagueUsername
            // 
            this.LeagueUsername.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LeagueUsername.Location = new System.Drawing.Point(118, 19);
            this.LeagueUsername.Name = "LeagueUsername";
            this.LeagueUsername.Size = new System.Drawing.Size(265, 20);
            this.LeagueUsername.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(326, 317);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 350);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonGrabKey;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox TwitchBotKey;
        public System.Windows.Forms.TextBox TwitchBotUsername;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox SummonerName;
        public System.Windows.Forms.ComboBox TwitchMinimumLevel;
        public System.Windows.Forms.ComboBox LeagueServer;
        public System.Windows.Forms.TextBox LeaguePassword;
        public System.Windows.Forms.TextBox LeagueUsername;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.TextBox GameDirectory;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}