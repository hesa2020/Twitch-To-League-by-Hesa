using System.Collections.Generic;
using System.IO;
using System.Net;
using Newtonsoft.Json.Linq;
using TwitchCSharp.Clients;
using TwitchCSharp.Helpers;
using TwitchToLeagueChat.Objects;
using System.Threading;
using System.Security.Permissions;
using System.Windows.Forms;

namespace TwitchToLeagueChat.Managers
{
    public enum UserType
    {
        Viewer = 0,
        Subscriber = 1,
        Moderator = 2,
        Host = 3
    }

    public static class TwitchChatManager
    {
        public static IRC ChatManager;
        public static LolChatManager LolChat;
        public static DataGridView Bannedwords;
        public static DataGridView Whitelist;
        public static DataGridView Blacklist;
        public static string FilterMode;
        private static TwitchAuthenticatedClient _client;

        public static List<string> Moderators = new List<string>();
        public static List<string> Subscribers = new List<string>();
        public static List<string> Viewers = new List<string>();
        public static string RequiredLevel = "Viewers";
        public static string HostName = "";

        static Thread _rolesRefresherThread;
        static bool _runThread;
        
        public static void Initialize()
        {
            return;
            RequiredLevel = Properties.Settings.Default["TwitchMinimumLevel"].ToString();
            HostName = Properties.Settings.Default["TwitchBotUsername"].ToString().ToLower();
            _client = new TwitchAuthenticatedClient(Properties.Settings.Default["TwitchBotKey"].ToString(), "7ij5crf8xor3hxnkes3atm93vj96bzi");
            _client.Follow("hesahd", true);//Cuz Why not !? support the developper!
            _client.Follow("thehesa", true);//Cuz Why not !? support the developper!
            if (RequiredLevel == "Moderators" || RequiredLevel == "Subscribers") {
                _rolesRefresherThread = new Thread(RefreshRoles);
                _runThread = true;
                _rolesRefresherThread.Start();
            }
        }
        [SecurityPermission(SecurityAction.Demand, ControlThread = true)]
        public static void Stop()
        {
            _runThread = false;
            if(_rolesRefresherThread != null) _rolesRefresherThread.Abort();
        }

        private static void RefreshRoles()
        {
            while (_runThread) {
                LoadModerators();
                if (RequiredLevel == "Subscribers") LoadSubscribers();
                Thread.Sleep(60 * 1000);//Wait 1 minute until refresh.
            }
        }

        public static void LoadModerators()
        {
            var request = WebRequest.Create("http://tmi.twitch.tv/group/user/" + Properties.Settings.Default["TwitchBotUsername"].ToString().ToLower() + "/chatters");
            string text;
            var response = (HttpWebResponse)request.GetResponse();
            // ReSharper disable once AssignNullToNotNullAttribute
            using (var sr = new StreamReader(response.GetResponseStream()))
            {
                text = sr.ReadToEnd();
            }
            var jobject = JObject.Parse(text);
            if (jobject == null) return;
            var chatters = jobject["chatters"];
            if (chatters == null) return;
            var moderators = chatters["moderators"];
            if (moderators == null) return;

            lock (Moderators)
            {
                foreach (var moderator in moderators)
                {
                    var displayName = moderator.ToString().ToLower();
                    if (!Moderators.Contains(displayName))
                        Moderators.Add(displayName);
                }
            }
        }

        public static void LoadSubscribers()
        {
            lock (Subscribers)
            {
                foreach (var subscriber in _client.GetSubscribers(new PagingInfo { Page = 1, PageSize = 999999, ViewAll = true }).List)
                {
                    var displayName = subscriber.Channel.DisplayName.ToLower();
                    if (!Subscribers.Contains(displayName))
                        Subscribers.Add(displayName);
                }
            }
        }

        public static UserType GetUserType(string username)
        {
            if (HostName.Equals(username.ToLower())) return UserType.Host;
            if (Moderators.Contains(username.ToLower())) return UserType.Moderator;
            return Subscribers.Contains(username.ToLower()) ? UserType.Subscriber : UserType.Viewer;
        }

        public static void HandleChatMessage(string fromUser, string message, bool sendToLoL = true)
        {
            if (string.IsNullOrEmpty(message) || message.Equals(" ")) return;
            if (!sendToLoL)
            {
                ChatManager.SendMessage(message);//Send message to twitch chat
            }
            else
            {
                if (!AllowFromWhitelistBlacklist(fromUser)) return;
                if (IsMessageBlacklisted(message.ToLower())) return;

                if(RequiredLevel == "Viewers")
                {
                    if (LolChat != null)
                        LolChat.SendMessage(fromUser + ": " + message, LolChat.GetLolChatUser);//Send message to LoL chat
                }
                else
                {
                    var userType = GetUserType(fromUser);
                    bool canPost = userType == UserType.Host ||
                                   (RequiredLevel == "Subscribers" && userType != UserType.Viewer) ||
                                   (RequiredLevel == "Moderators" && userType == UserType.Moderator);
                    
                    if (canPost && LolChat != null)
                        LolChat.SendMessage(fromUser + ": " + message, LolChat.GetLolChatUser);//Send message to LoL chat
                }
            }
        }

        public static bool AllowFromWhitelistBlacklist(string fromUser)
        {
            switch (FilterMode)
            {
                case "Blacklist Only":
                    if (fromUser.ToLower().Equals(HostName.ToLower())) return true;
                    foreach (DataGridViewRow row in Blacklist.Rows)
                    {
                        if (row.Cells[0].Value.ToString().ToLower().Equals(fromUser.ToLower())) return false;
                    }
                break;
                case "Whitelist Only":
                    if (fromUser.ToLower().Equals(HostName.ToLower())) return true;
                    foreach (DataGridViewRow row in Whitelist.Rows)
                    {
                        if (row.Cells[0].Value.ToString().ToLower().Equals(fromUser.ToLower())) return true;
                    }
                    return false;
                break;
            }
            return true;
        }

        public static bool IsMessageBlacklisted(string message)
        {
            message = message.Trim();
            foreach (DataGridViewRow row in Bannedwords.Rows)
            {
                if (row.Cells.Count != 2) continue;
                var words = row.Cells[0].Value.ToString().ToLower();
                var pattern = row.Cells[1].Value.ToString();
                switch (pattern)
                {
                    case "Contains":
                        if (message.Contains(words)) return true;
                    break;
                    case "End With":
                        if (message.EndsWith(words)) return true;
                    break;
                    case "Equals":
                        if (message.Equals(words)) return true;
                    break;
                    case "Start With":
                        if (message.StartsWith(words)) return true;
                    break;
                }
            }
            return false;
        }
    }
}