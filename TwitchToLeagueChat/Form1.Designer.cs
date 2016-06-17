namespace TwitchToLeagueChat
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonRun = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.ButtonWhitelistAdd = new System.Windows.Forms.Button();
            this.ButtonWhitelistRemove = new System.Windows.Forms.Button();
            this.Whitelist_username = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.Whitelist = new System.Windows.Forms.DataGridView();
            this.Username = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label10 = new System.Windows.Forms.Label();
            this.ButtonBlacklistAdd = new System.Windows.Forms.Button();
            this.ButtonBlacklistRemove = new System.Windows.Forms.Button();
            this.Blacklist_username = new System.Windows.Forms.TextBox();
            this.Blacklist = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FilterSetting = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonGrabKey = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TwitchBotKey = new System.Windows.Forms.TextBox();
            this.TwitchBotUsername = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
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
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.Bannedwords_textbox = new System.Windows.Forms.TextBox();
            this.Bannedwords_pattern = new System.Windows.Forms.ComboBox();
            this.ButtonBannedwordsAdd = new System.Windows.Forms.Button();
            this.ButtonBannedwordsRemove = new System.Windows.Forms.Button();
            this.Bannedwords = new System.Windows.Forms.DataGridView();
            this.BannedText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BannedPattern = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Whitelist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Blacklist)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Bannedwords)).BeginInit();
            this.SuspendLayout();
            // 
            // linkLabel1
            // 
            this.linkLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(12, 439);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(93, 13);
            this.linkLabel1.TabIndex = 0;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "twitch.tv/HesaHD";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(610, 429);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonRun
            // 
            this.buttonRun.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRun.Location = new System.Drawing.Point(691, 429);
            this.buttonRun.Name = "buttonRun";
            this.buttonRun.Size = new System.Drawing.Size(75, 23);
            this.buttonRun.TabIndex = 4;
            this.buttonRun.Text = "Run";
            this.buttonRun.UseVisualStyleBackColor = true;
            this.buttonRun.Click += new System.EventHandler(this.buttonRun_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.splitContainer1);
            this.groupBox3.Controls.Add(this.FilterSetting);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Location = new System.Drawing.Point(384, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(388, 411);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Blacklist / Whitelist Settings";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Location = new System.Drawing.Point(9, 46);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.ButtonWhitelistAdd);
            this.splitContainer1.Panel1.Controls.Add(this.ButtonWhitelistRemove);
            this.splitContainer1.Panel1.Controls.Add(this.Whitelist_username);
            this.splitContainer1.Panel1.Controls.Add(this.label9);
            this.splitContainer1.Panel1.Controls.Add(this.Whitelist);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.label10);
            this.splitContainer1.Panel2.Controls.Add(this.ButtonBlacklistAdd);
            this.splitContainer1.Panel2.Controls.Add(this.ButtonBlacklistRemove);
            this.splitContainer1.Panel2.Controls.Add(this.Blacklist_username);
            this.splitContainer1.Panel2.Controls.Add(this.Blacklist);
            this.splitContainer1.Size = new System.Drawing.Size(373, 359);
            this.splitContainer1.SplitterDistance = 184;
            this.splitContainer1.TabIndex = 12;
            // 
            // ButtonWhitelistAdd
            // 
            this.ButtonWhitelistAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonWhitelistAdd.Location = new System.Drawing.Point(215, 157);
            this.ButtonWhitelistAdd.Name = "ButtonWhitelistAdd";
            this.ButtonWhitelistAdd.Size = new System.Drawing.Size(75, 23);
            this.ButtonWhitelistAdd.TabIndex = 19;
            this.ButtonWhitelistAdd.Text = "Add";
            this.ButtonWhitelistAdd.UseVisualStyleBackColor = true;
            this.ButtonWhitelistAdd.Click += new System.EventHandler(this.ButtonWhitelistAdd_Click);
            // 
            // ButtonWhitelistRemove
            // 
            this.ButtonWhitelistRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonWhitelistRemove.Location = new System.Drawing.Point(296, 157);
            this.ButtonWhitelistRemove.Name = "ButtonWhitelistRemove";
            this.ButtonWhitelistRemove.Size = new System.Drawing.Size(75, 23);
            this.ButtonWhitelistRemove.TabIndex = 18;
            this.ButtonWhitelistRemove.Text = "Remove";
            this.ButtonWhitelistRemove.UseVisualStyleBackColor = true;
            this.ButtonWhitelistRemove.Click += new System.EventHandler(this.ButtonWhitelistRemove_Click);
            // 
            // Whitelist_username
            // 
            this.Whitelist_username.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Whitelist_username.Location = new System.Drawing.Point(3, 159);
            this.Whitelist_username.Name = "Whitelist_username";
            this.Whitelist_username.Size = new System.Drawing.Size(206, 20);
            this.Whitelist_username.TabIndex = 17;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 6);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(50, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "Whitelist:";
            // 
            // Whitelist
            // 
            this.Whitelist.AllowUserToAddRows = false;
            this.Whitelist.AllowUserToDeleteRows = false;
            this.Whitelist.AllowUserToResizeColumns = false;
            this.Whitelist.AllowUserToResizeRows = false;
            this.Whitelist.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Whitelist.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.Whitelist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Whitelist.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Username});
            this.Whitelist.Location = new System.Drawing.Point(3, 22);
            this.Whitelist.Name = "Whitelist";
            this.Whitelist.RowHeadersVisible = false;
            this.Whitelist.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.Whitelist.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Whitelist.ShowCellErrors = false;
            this.Whitelist.ShowCellToolTips = false;
            this.Whitelist.ShowEditingIcon = false;
            this.Whitelist.ShowRowErrors = false;
            this.Whitelist.Size = new System.Drawing.Size(365, 129);
            this.Whitelist.TabIndex = 15;
            // 
            // Username
            // 
            this.Username.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Username.HeaderText = "Username";
            this.Username.Name = "Username";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 5);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 13);
            this.label10.TabIndex = 24;
            this.label10.Text = "Blacklist:";
            // 
            // ButtonBlacklistAdd
            // 
            this.ButtonBlacklistAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonBlacklistAdd.Location = new System.Drawing.Point(215, 143);
            this.ButtonBlacklistAdd.Name = "ButtonBlacklistAdd";
            this.ButtonBlacklistAdd.Size = new System.Drawing.Size(75, 23);
            this.ButtonBlacklistAdd.TabIndex = 23;
            this.ButtonBlacklistAdd.Text = "Add";
            this.ButtonBlacklistAdd.UseVisualStyleBackColor = true;
            this.ButtonBlacklistAdd.Click += new System.EventHandler(this.ButtonBlacklistAdd_Click);
            // 
            // ButtonBlacklistRemove
            // 
            this.ButtonBlacklistRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonBlacklistRemove.Location = new System.Drawing.Point(293, 143);
            this.ButtonBlacklistRemove.Name = "ButtonBlacklistRemove";
            this.ButtonBlacklistRemove.Size = new System.Drawing.Size(75, 23);
            this.ButtonBlacklistRemove.TabIndex = 22;
            this.ButtonBlacklistRemove.Text = "Remove";
            this.ButtonBlacklistRemove.UseVisualStyleBackColor = true;
            this.ButtonBlacklistRemove.Click += new System.EventHandler(this.ButtonBlacklistRemove_Click);
            // 
            // Blacklist_username
            // 
            this.Blacklist_username.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Blacklist_username.Location = new System.Drawing.Point(3, 145);
            this.Blacklist_username.Name = "Blacklist_username";
            this.Blacklist_username.Size = new System.Drawing.Size(206, 20);
            this.Blacklist_username.TabIndex = 21;
            // 
            // Blacklist
            // 
            this.Blacklist.AllowUserToAddRows = false;
            this.Blacklist.AllowUserToDeleteRows = false;
            this.Blacklist.AllowUserToResizeColumns = false;
            this.Blacklist.AllowUserToResizeRows = false;
            this.Blacklist.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Blacklist.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.Blacklist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Blacklist.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1});
            this.Blacklist.Location = new System.Drawing.Point(3, 21);
            this.Blacklist.Name = "Blacklist";
            this.Blacklist.RowHeadersVisible = false;
            this.Blacklist.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Blacklist.Size = new System.Drawing.Size(362, 116);
            this.Blacklist.TabIndex = 20;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn1.HeaderText = "Username";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // FilterSetting
            // 
            this.FilterSetting.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FilterSetting.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FilterSetting.FormattingEnabled = true;
            this.FilterSetting.Items.AddRange(new object[] {
            "Blacklist Only",
            "None",
            "Whitelist Only"});
            this.FilterSetting.Location = new System.Drawing.Point(145, 19);
            this.FilterSetting.Name = "FilterSetting";
            this.FilterSetting.Size = new System.Drawing.Size(237, 21);
            this.FilterSetting.Sorted = true;
            this.FilterSetting.TabIndex = 9;
            this.FilterSetting.SelectedValueChanged += new System.EventHandler(this.FilterSetting_SelectedValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(32, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "Filter:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonGrabKey);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.TwitchBotKey);
            this.groupBox1.Controls.Add(this.TwitchBotUsername);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(366, 107);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Twitch Account Settings";
            // 
            // buttonGrabKey
            // 
            this.buttonGrabKey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonGrabKey.Location = new System.Drawing.Point(9, 74);
            this.buttonGrabKey.Name = "buttonGrabKey";
            this.buttonGrabKey.Size = new System.Drawing.Size(351, 23);
            this.buttonGrabKey.TabIndex = 5;
            this.buttonGrabKey.Text = "Grab Access Key";
            this.buttonGrabKey.UseVisualStyleBackColor = true;
            this.buttonGrabKey.Click += new System.EventHandler(this.buttonGrabKey_Click);
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
            this.TwitchBotKey.Size = new System.Drawing.Size(242, 20);
            this.TwitchBotKey.TabIndex = 1;
            // 
            // TwitchBotUsername
            // 
            this.TwitchBotUsername.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TwitchBotUsername.Location = new System.Drawing.Point(118, 19);
            this.TwitchBotUsername.Name = "TwitchBotUsername";
            this.TwitchBotUsername.Size = new System.Drawing.Size(242, 20);
            this.TwitchBotUsername.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
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
            this.groupBox2.Size = new System.Drawing.Size(366, 155);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "League Account Settings";
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
            this.SummonerName.Size = new System.Drawing.Size(242, 20);
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
            this.TwitchMinimumLevel.Size = new System.Drawing.Size(242, 21);
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
            "Brazil",
            "EU Nordic",
            "EU West",
            "Latin America North",
            "Latin America South",
            "NA",
            "Oceania",
            "Phillipines",
            "Public Beta Environment",
            "Russia",
            "Taiwan",
            "Thailand",
            "Turkey",
            "Vietnamn"});
            this.LeagueServer.Location = new System.Drawing.Point(118, 71);
            this.LeagueServer.Name = "LeagueServer";
            this.LeagueServer.Size = new System.Drawing.Size(242, 21);
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
            this.LeaguePassword.Size = new System.Drawing.Size(242, 20);
            this.LeaguePassword.TabIndex = 3;
            // 
            // LeagueUsername
            // 
            this.LeagueUsername.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LeagueUsername.Location = new System.Drawing.Point(118, 19);
            this.LeagueUsername.Name = "LeagueUsername";
            this.LeagueUsername.Size = new System.Drawing.Size(242, 20);
            this.LeagueUsername.TabIndex = 2;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox4.Controls.Add(this.Bannedwords_textbox);
            this.groupBox4.Controls.Add(this.Bannedwords_pattern);
            this.groupBox4.Controls.Add(this.ButtonBannedwordsAdd);
            this.groupBox4.Controls.Add(this.ButtonBannedwordsRemove);
            this.groupBox4.Controls.Add(this.Bannedwords);
            this.groupBox4.Location = new System.Drawing.Point(12, 285);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(366, 138);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Banned Words";
            // 
            // Bannedwords_textbox
            // 
            this.Bannedwords_textbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Bannedwords_textbox.Location = new System.Drawing.Point(6, 111);
            this.Bannedwords_textbox.Name = "Bannedwords_textbox";
            this.Bannedwords_textbox.Size = new System.Drawing.Size(122, 20);
            this.Bannedwords_textbox.TabIndex = 27;
            // 
            // Bannedwords_pattern
            // 
            this.Bannedwords_pattern.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Bannedwords_pattern.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Bannedwords_pattern.FormattingEnabled = true;
            this.Bannedwords_pattern.Items.AddRange(new object[] {
            "Contains",
            "End With",
            "Equals",
            "Start With"});
            this.Bannedwords_pattern.Location = new System.Drawing.Point(134, 110);
            this.Bannedwords_pattern.Name = "Bannedwords_pattern";
            this.Bannedwords_pattern.Size = new System.Drawing.Size(67, 21);
            this.Bannedwords_pattern.Sorted = true;
            this.Bannedwords_pattern.TabIndex = 26;
            // 
            // ButtonBannedwordsAdd
            // 
            this.ButtonBannedwordsAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonBannedwordsAdd.Location = new System.Drawing.Point(207, 109);
            this.ButtonBannedwordsAdd.Name = "ButtonBannedwordsAdd";
            this.ButtonBannedwordsAdd.Size = new System.Drawing.Size(75, 23);
            this.ButtonBannedwordsAdd.TabIndex = 25;
            this.ButtonBannedwordsAdd.Text = "Add";
            this.ButtonBannedwordsAdd.UseVisualStyleBackColor = true;
            this.ButtonBannedwordsAdd.Click += new System.EventHandler(this.ButtonBannedwordsAdd_Click);
            // 
            // ButtonBannedwordsRemove
            // 
            this.ButtonBannedwordsRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonBannedwordsRemove.Location = new System.Drawing.Point(285, 109);
            this.ButtonBannedwordsRemove.Name = "ButtonBannedwordsRemove";
            this.ButtonBannedwordsRemove.Size = new System.Drawing.Size(75, 23);
            this.ButtonBannedwordsRemove.TabIndex = 24;
            this.ButtonBannedwordsRemove.Text = "Remove";
            this.ButtonBannedwordsRemove.UseVisualStyleBackColor = true;
            this.ButtonBannedwordsRemove.Click += new System.EventHandler(this.ButtonBannedwordsRemove_Click);
            // 
            // Bannedwords
            // 
            this.Bannedwords.AllowUserToAddRows = false;
            this.Bannedwords.AllowUserToDeleteRows = false;
            this.Bannedwords.AllowUserToResizeColumns = false;
            this.Bannedwords.AllowUserToResizeRows = false;
            this.Bannedwords.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Bannedwords.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.Bannedwords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Bannedwords.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BannedText,
            this.BannedPattern});
            this.Bannedwords.Location = new System.Drawing.Point(6, 19);
            this.Bannedwords.Name = "Bannedwords";
            this.Bannedwords.RowHeadersVisible = false;
            this.Bannedwords.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.Bannedwords.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Bannedwords.ShowCellErrors = false;
            this.Bannedwords.ShowCellToolTips = false;
            this.Bannedwords.ShowEditingIcon = false;
            this.Bannedwords.ShowRowErrors = false;
            this.Bannedwords.Size = new System.Drawing.Size(354, 84);
            this.Bannedwords.TabIndex = 16;
            // 
            // BannedText
            // 
            this.BannedText.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.BannedText.HeaderText = "Text";
            this.BannedText.Name = "BannedText";
            // 
            // BannedPattern
            // 
            this.BannedPattern.HeaderText = "Pattern";
            this.BannedPattern.Name = "BannedPattern";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.buttonRun);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.linkLabel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Twitch To League Chat by Hesa";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Whitelist)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Blacklist)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Bannedwords)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buttonRun;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox FilterSetting;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonGrabKey;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TwitchBotKey;
        private System.Windows.Forms.TextBox TwitchBotUsername;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox SummonerName;
        private System.Windows.Forms.ComboBox TwitchMinimumLevel;
        private System.Windows.Forms.ComboBox LeagueServer;
        private System.Windows.Forms.TextBox LeaguePassword;
        private System.Windows.Forms.TextBox LeagueUsername;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button ButtonWhitelistAdd;
        private System.Windows.Forms.Button ButtonWhitelistRemove;
        private System.Windows.Forms.TextBox Whitelist_username;
        private System.Windows.Forms.Label label9;
        public System.Windows.Forms.DataGridView Whitelist;
        private System.Windows.Forms.DataGridViewTextBoxColumn Username;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button ButtonBlacklistAdd;
        private System.Windows.Forms.Button ButtonBlacklistRemove;
        private System.Windows.Forms.TextBox Blacklist_username;
        public System.Windows.Forms.DataGridView Blacklist;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button ButtonBannedwordsAdd;
        private System.Windows.Forms.Button ButtonBannedwordsRemove;
        public System.Windows.Forms.DataGridView Bannedwords;
        private System.Windows.Forms.DataGridViewTextBoxColumn BannedText;
        private System.Windows.Forms.DataGridViewTextBoxColumn BannedPattern;
        private System.Windows.Forms.ComboBox Bannedwords_pattern;
        private System.Windows.Forms.TextBox Bannedwords_textbox;
    }
}

