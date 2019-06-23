using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using TwitchToLeagueChat.Managers;
using TwitchToLeagueChat.Objects;

namespace TwitchToLeagueChat
{
    public partial class Form1 : Form
    {
        private bool _isRunning;
        public IRC ChatEngine = new IRC();
        public LolChatManager LoLChat;
        private SettingsForm settingsForm = new SettingsForm();
        private string previousSong = "";

        public Form1()
        {
            InitializeComponent();
            FilterSetting.Text = Properties.Settings.Default["Filter"].ToString();
            var whitelist = Properties.Settings.Default["Whitelist"].ToString().Split(',');
            foreach (var username in whitelist)
            {
                if (string.IsNullOrEmpty(username)) continue;
                Whitelist.Rows.Add(username);
                Whitelist.Rows[Whitelist.Rows.Count - 1].ReadOnly = true;
            }
            var blacklist = Properties.Settings.Default["Blacklist"].ToString().Split(',');
            foreach (var username in blacklist)
            {
                if (string.IsNullOrEmpty(username)) continue;
                Blacklist.Rows.Add(username);
                Blacklist.Rows[Blacklist.Rows.Count - 1].ReadOnly = true;
            }
            var bannedwords = Properties.Settings.Default["Bannedwords"].ToString().Split(',');
            foreach (var bannedword in bannedwords)
            {
                var datas = bannedword.Split(':');
                if (string.IsNullOrEmpty(datas[0])) continue;

                Bannedwords.Rows.Add(datas[0], datas[1]);
                Bannedwords.Rows[Bannedwords.Rows.Count - 1].ReadOnly = true;
            }
            TwitchChatManager.Bannedwords = Bannedwords;
            TwitchChatManager.Blacklist = Blacklist;
            TwitchChatManager.Whitelist = Whitelist;
            TwitchChatManager.FilterMode = FilterSetting.Text;
            SpotifyTimer.Tick += SpotifyTimer_Tick;
            SpotifyTimer.Start();
        }

        private void SpotifyTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                var proc = Process.GetProcessesByName("Spotify").FirstOrDefault(p => !string.IsNullOrWhiteSpace(p.MainWindowTitle));
                if (proc == null)
                {
                    CurrentSongLabel.Text = "Current Song: Spotify is not running!";
                    if (CurrentSongLabel.Text != previousSong)
                    {
                        previousSong = CurrentSongLabel.Text;
                        File.WriteAllText(Path.Combine(Environment.CurrentDirectory, "current_song.txt"), "");
                    }
                }
                else
                {
                    if
                        (
                            string.Equals(proc.MainWindowTitle.Trim(), "Spotify", StringComparison.InvariantCultureIgnoreCase) ||
                            string.Equals(proc.MainWindowTitle.Trim(), "Spotify Premium", StringComparison.InvariantCultureIgnoreCase)
                        )
                    {
                        CurrentSongLabel.Text = "Current Song: Spotify Paused";
                        if (CurrentSongLabel.Text != previousSong)
                        {
                            previousSong = CurrentSongLabel.Text;
                            File.WriteAllText(Path.Combine(Environment.CurrentDirectory, "current_song.txt"), "");
                        }
                    }
                    else
                    {
                        CurrentSongLabel.Text = proc.MainWindowTitle;
                        if(CurrentSongLabel.Text != previousSong)
                        {
                            previousSong = CurrentSongLabel.Text;
                            File.WriteAllText(Path.Combine(Environment.CurrentDirectory, "current_song.txt"), proc.MainWindowTitle);
                        }
                    }
                }
            }
            catch (Exception)
            {
                CurrentSongLabel.Text = "Current Song: Spotify is not running!";
                if (CurrentSongLabel.Text != previousSong)
                {
                    previousSong = CurrentSongLabel.Text;
                    File.WriteAllText(Path.Combine(Environment.CurrentDirectory, "current_song.txt"), "");
                }
            }
        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://twitch.tv/TheHesa");
        }

        private void Button1_Click(object sender, System.EventArgs e)
        {
            Properties.Settings.Default["Filter"] = FilterSetting.Text;
            var whitelist = "";
            foreach (DataGridViewRow row in Whitelist.Rows)
            {
                //DataRow row = rowView.Row;
                if(Whitelist.Rows.IndexOf(row) == Whitelist.Rows.Count-1)
                    whitelist += row.Cells[0].Value;
                else
                    whitelist += row.Cells[0].Value + ",";
            }
            Properties.Settings.Default["Whitelist"] = whitelist;
            var blacklist = "";
            foreach (DataGridViewRow row in Blacklist.Rows)
            {
                //DataRow row = rowView.Row;
                if (Blacklist.Rows.IndexOf(row) == Blacklist.Rows.Count - 1)
                    blacklist += row.Cells[0].Value;
                else
                    blacklist += row.Cells[0].Value + ",";
            }
            Properties.Settings.Default["Blacklist"] = blacklist;
            var bannedwords = "";
            foreach (DataGridViewRow row in Bannedwords.Rows)
            {
                //DataRow row = rowView.Row;
                if (Bannedwords.Rows.IndexOf(row) == Bannedwords.Rows.Count - 1)
                    bannedwords += row.Cells[0].Value + ":"+ row.Cells[1].Value;
                else
                    bannedwords += row.Cells[0].Value + ":" + row.Cells[1].Value + ",";
            }
            Properties.Settings.Default["Bannedwords"] = bannedwords;

            Properties.Settings.Default.Save(); // Saves settings in application configuration file
            if(sender != null) MessageBox.Show(@"Settings have been saved successfully.");
        }

        private void ButtonRun_Click(object sender, System.EventArgs e)
        {
            if (settingsForm == null || settingsForm.Disposing) settingsForm = new SettingsForm();
            if (string.IsNullOrEmpty(settingsForm.TwitchBotUsername.Text)
                || string.IsNullOrEmpty(settingsForm.TwitchBotKey.Text)
                || string.IsNullOrEmpty(settingsForm.LeagueUsername.Text)
                || string.IsNullOrEmpty(settingsForm.LeaguePassword.Text)
                || string.IsNullOrEmpty(settingsForm.LeagueServer.Text)
                || string.IsNullOrEmpty(settingsForm.TwitchMinimumLevel.Text)
                || string.IsNullOrEmpty(settingsForm.SummonerName.Text)
            )
            {
                MessageBox.Show(@"Please fill all settings correctly.");
                return;
            }
            Button1_Click(null, e);
            _isRunning = !_isRunning;
            buttonRun.Text = _isRunning ? "Stop" : "Run";
            if (_isRunning)
            {
                LoLChat = new LolChatManager();
                LoLChat.Initialize(Properties.Settings.Default["LeagueUsername"].ToString(),
                    Properties.Settings.Default["LeaguePassword"].ToString(),
                    Properties.Settings.Default["LeagueServer"].ToString(), null);
                TwitchChatManager.LolChat = LoLChat;
                TwitchChatManager.Initialize();

                ChatEngine = new IRC();
                ChatEngine.Initialize();
            }
            else
            {
                LoLChat.Disconnect();
                LoLChat = null;
                ChatEngine.Stop();
                ChatEngine = null;
                TwitchChatManager.Stop();
                //GC.Collect();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.ExitThread();
            Application.Exit();
            Environment.Exit(0);
        }

        private void ButtonWhitelistAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Whitelist_username.Text)) return;
            Whitelist.Rows.Add(Whitelist_username.Text);
            Whitelist_username.Text = "";
            Whitelist.Rows[Whitelist.Rows.Count - 1].ReadOnly = true;

            if(string.IsNullOrEmpty(Whitelist.Rows[0].Cells[0].Value.ToString()))
                Whitelist.Rows.RemoveAt(0);
            TwitchChatManager.Whitelist = Whitelist;
        }

        private void ButtonWhitelistRemove_Click(object sender, EventArgs e)
        {
            foreach(DataGridViewRow row in Whitelist.SelectedRows)
            {
                Whitelist.Rows.Remove(row);
            }
            TwitchChatManager.Whitelist = Whitelist;
        }

        private void ButtonBlacklistAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Blacklist_username.Text)) return;
            Blacklist.Rows.Add(Blacklist_username.Text);
            Blacklist_username.Text = "";
            Blacklist.Rows[Blacklist.Rows.Count - 1].ReadOnly = true;

            if (string.IsNullOrEmpty(Blacklist.Rows[0].Cells[0].Value.ToString()))
                Blacklist.Rows.RemoveAt(0);
            TwitchChatManager.Blacklist = Blacklist;
        }

        private void ButtonBlacklistRemove_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in Blacklist.SelectedRows)
            {
                Blacklist.Rows.Remove(row);
            }
            TwitchChatManager.Blacklist = Blacklist;
        }

        private void ButtonBannedwordsAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Bannedwords_textbox.Text)) return;
            if (string.IsNullOrEmpty(Bannedwords_pattern.Text)) return;
            Bannedwords.Rows.Add(Bannedwords_textbox.Text, Bannedwords_pattern.Text);
            Bannedwords_textbox.Text = "";
            Bannedwords.Rows[Bannedwords.Rows.Count - 1].ReadOnly = true;

            if (string.IsNullOrEmpty(Bannedwords.Rows[0].Cells[0].Value.ToString()))
                Bannedwords.Rows.RemoveAt(0);

            TwitchChatManager.Bannedwords = Bannedwords;
        }

        private void ButtonBannedwordsRemove_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in Bannedwords.SelectedRows)
            {
                Bannedwords.Rows.Remove(row);
            }
            TwitchChatManager.Bannedwords = Bannedwords;
        }

        private void FilterSetting_SelectedValueChanged(object sender, EventArgs e)
        {
            TwitchChatManager.FilterMode = FilterSetting.Text;
        }

        private void SettingsButton_Click(object sender, EventArgs e)
        {
            if (settingsForm == null || settingsForm.Disposing) settingsForm = new SettingsForm();
            settingsForm.ShowDialog();
        }
    }
}