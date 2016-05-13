using System;
using System.Diagnostics;
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
        private BrowserForm _browserForm;

        public Form1()
        {
            InitializeComponent();
            TwitchBotUsername.Text = Properties.Settings.Default["TwitchBotUsername"].ToString();
            TwitchBotKey.Text = Properties.Settings.Default["TwitchBotKey"].ToString();
            LeagueUsername.Text = Properties.Settings.Default["LeagueUsername"].ToString();
            LeaguePassword.Text = Properties.Settings.Default["LeaguePassword"].ToString();
            LeagueServer.Text = Properties.Settings.Default["LeagueServer"].ToString();
            TwitchMinimumLevel.Text = Properties.Settings.Default["TwitchMinimumLevel"].ToString();
            SummonerName.Text = Properties.Settings.Default["SummonerName"].ToString();
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://twitch.tv/HesaHD");
        }
        private void button1_Click(object sender, System.EventArgs e)
        {
            Properties.Settings.Default["TwitchBotUsername"] = TwitchBotUsername.Text;
            Properties.Settings.Default["TwitchBotKey"] = TwitchBotKey.Text;
            Properties.Settings.Default["LeagueUsername"] = LeagueUsername.Text;
            Properties.Settings.Default["LeaguePassword"] = LeaguePassword.Text;
            Properties.Settings.Default["LeagueServer"] = LeagueServer.Text;
            Properties.Settings.Default["TwitchMinimumLevel"] = TwitchMinimumLevel.Text;
            Properties.Settings.Default["SummonerName"] = SummonerName.Text;
            Properties.Settings.Default.Save(); // Saves settings in application configuration file
            if(sender != null) MessageBox.Show(@"Settings have been saved successfully.");
        }

        private void buttonRun_Click(object sender, System.EventArgs e)
        {
            if (string.IsNullOrEmpty(TwitchBotUsername.Text)
                || string.IsNullOrEmpty(TwitchBotKey.Text)
                || string.IsNullOrEmpty(LeagueUsername.Text)
                || string.IsNullOrEmpty(LeaguePassword.Text)
                || string.IsNullOrEmpty(LeagueServer.Text)
                || string.IsNullOrEmpty(TwitchMinimumLevel.Text)
                || string.IsNullOrEmpty(SummonerName.Text)
            )
            {
                MessageBox.Show(@"Please fill all settings correctly.");
                return;
            }
            button1_Click(null, e);
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
        private void buttonGrabKey_Click(object sender, System.EventArgs e)
        {
            _browserForm = new BrowserForm {AccessKeyTextBox = TwitchBotKey};
            _browserForm.ShowDialog();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.ExitThread();
            Application.Exit();
            Environment.Exit(0);
        }
    }
}