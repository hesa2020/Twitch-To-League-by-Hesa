using System;
using System.Windows.Forms;

namespace TwitchToLeagueChat
{
    public partial class SettingsForm : Form
    {
        private BrowserForm _browserForm;

        public SettingsForm()
        {
            InitializeComponent();
            TwitchBotUsername.Text = Properties.Settings.Default["TwitchBotUsername"].ToString();
            TwitchBotKey.Text = Properties.Settings.Default["TwitchBotKey"].ToString();
            LeagueUsername.Text = Properties.Settings.Default["LeagueUsername"].ToString();
            LeaguePassword.Text = Properties.Settings.Default["LeaguePassword"].ToString();
            LeagueServer.Text = Properties.Settings.Default["LeagueServer"].ToString();
            TwitchMinimumLevel.Text = Properties.Settings.Default["TwitchMinimumLevel"].ToString();
            SummonerName.Text = Properties.Settings.Default["SummonerName"].ToString();
            GameDirectory.Text = Properties.Settings.Default["LeaguePath"].ToString();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default["TwitchBotUsername"] = TwitchBotUsername.Text;
            Properties.Settings.Default["TwitchBotKey"] = TwitchBotKey.Text;
            Properties.Settings.Default["LeagueUsername"] = LeagueUsername.Text;
            Properties.Settings.Default["LeaguePassword"] = LeaguePassword.Text;
            Properties.Settings.Default["LeagueServer"] = LeagueServer.Text;
            Properties.Settings.Default["TwitchMinimumLevel"] = TwitchMinimumLevel.Text;
            Properties.Settings.Default["SummonerName"] = SummonerName.Text;
            Properties.Settings.Default["LeaguePath"] = GameDirectory.Text;
            Properties.Settings.Default.Save(); // Saves settings in application configuration file
            if (sender != null) MessageBox.Show(@"Settings have been saved successfully.");
            Hide();
        }

        private void ButtonGrabKey_Click(object sender, EventArgs e)
        {
            _browserForm = new BrowserForm { AccessKeyTextBox = TwitchBotKey };
            _browserForm.ShowDialog();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if(folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                GameDirectory.Text = folderBrowserDialog1.SelectedPath;
            }
        }
    }
}
