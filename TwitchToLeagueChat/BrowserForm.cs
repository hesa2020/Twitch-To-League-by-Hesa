using System.Windows.Forms;

namespace TwitchToLeagueChat
{
    public partial class BrowserForm : Form
    {
        public TextBox AccessKeyTextBox;

        public BrowserForm()
        {
            InitializeComponent();
            //webBrowser1.Navigate(new System.Uri("https://api.twitch.tv/kraken/oauth2/authorize?response_type=token&client_id=7ij5crf8xor3hxnkes3atm93vj96bzi&redirect_uri=https://twitchapps.com/tmi/&scope=user_read+user_follows_edit+channel_subscriptions+user_subscriptions+channel_check_subscription+chat_login&state=1"));
        }

        private void webBrowser1_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            const string startWith = "https://twitchapps.com/tmi/#access_token=";
            const char endWith = '&';
            if (!webBrowser1.Url.ToString().StartsWith(startWith)) return;

            var token = webBrowser1.Url.ToString().Replace(startWith, "").Split(endWith)[0];
            AccessKeyTextBox.Text = token;
            Close();
        }

        private void webBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            const string startWith = "https://twitchapps.com/tmi/#access_token=";
            const char endWith = '&';
            if (!webBrowser1.Url.ToString().StartsWith(startWith)) return;

            var token = webBrowser1.Url.ToString().Replace(startWith, "").Split(endWith)[0];
            AccessKeyTextBox.Text = token;
            Close();
        }
    }
}