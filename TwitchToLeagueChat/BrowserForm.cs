using System.Windows.Forms;

namespace TwitchToLeagueChat
{
    public partial class BrowserForm : Form
    {
        public TextBox AccessKeyTextBox;

        public BrowserForm()
        {
            InitializeComponent();
        }
        private void webBrowser1_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            const string startWith = "http://twitchtoleague.pcriot.com/signin-Twitch/#access_token=";
            const char endWith = '&';
            if (!webBrowser1.Url.ToString().StartsWith(startWith)) return;

            var token = webBrowser1.Url.ToString().Replace(startWith, "").Split(endWith)[0];
            AccessKeyTextBox.Text = token;
            Close();
        }

        private void webBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            const string startWith = "http://twitchtoleague.pcriot.com/signin-Twitch/#access_token=";
            const char endWith = '&';
            if (!webBrowser1.Url.ToString().StartsWith(startWith)) return;

            var token = webBrowser1.Url.ToString().Replace(startWith, "").Split(endWith)[0];
            AccessKeyTextBox.Text = token;
            Close();
        }
    }
}