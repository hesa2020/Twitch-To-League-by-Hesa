using System.Collections.Generic;
using System.IO;
using System.Net;
using Newtonsoft.Json.Linq;
using TwitchCSharp.Clients;
using TwitchCSharp.Helpers;
using TwitchToLeagueChat.Objects;
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
        private static TwitchAuthenticatedClient _client;

        public static List<string> Moderators = new List<string>();
        public static List<string> Subscribers = new List<string>();
        public static string RequiredLevel = "Viewers";

        public static void Initialize()
        {
            RequiredLevel = Properties.Settings.Default["TwitchMinimumLevel"].ToString();
            _client = new TwitchAuthenticatedClient(Properties.Settings.Default["TwitchBotKey"].ToString(), "7ij5crf8xor3hxnkes3atm93vj96bzi");
            _client.Follow("hesahd", true);//Cuz Why not !? support the developper!
            _client.Follow("thehesa", true);//Cuz Why not !? support the developper!
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
            Moderators.Clear();
            foreach (var moderator in moderators)
            {
                Moderators.Add(moderator.ToString());
            }
        }

        public static void LoadSubscribers()
        {
            foreach (var subscriber in _client.GetSubscribers(new PagingInfo {Page = 1,PageSize = 999999,ViewAll = true}).List)
            {
                var displayName = subscriber.Channel.DisplayName.ToLower();
                if (!Subscribers.Contains(displayName))
                    Subscribers.Add(displayName);
            }
        }
        public static UserType GetUserType(string username)
        {
            if (Properties.Settings.Default["TwitchBotUsername"].ToString().ToLower().Equals(username.ToLower())) return UserType.Host;
            //Check if he is already in moderators list to preven an api call
            if (Moderators.Contains(username.ToLower())) return UserType.Moderator;
            LoadModerators();//Load Moderators
            if (Moderators.Contains(username.ToLower())) return UserType.Moderator;//If hes moderator return it.
            //Check if he is already in subscribers list to preven an api call
            if (Subscribers.Contains(username.ToLower())) return UserType.Subscriber;
            LoadSubscribers();//Load Subscribers
            return Subscribers.Contains(username.ToLower()) ? UserType.Subscriber : UserType.Viewer;
        }
        public static void HandleChatMessage(string fromUser, string message, bool sendToLoL = true)
        {
            if (string.IsNullOrEmpty(message) || message.Equals(" ")) return;
            if (!sendToLoL)
            {
                //if (fromUser != "")
                //ChatManager.Responses.Add(fromUser + ": " + message);
                //else
                ChatManager.Responses.Add(message);//Send message to twitch chat
            }
            else
            {

                var userType = GetUserType(fromUser);
                bool canPost = userType == UserType.Host || (RequiredLevel == "Viewers") ||
                               (RequiredLevel == "Subscribers" && userType != UserType.Viewer) ||
                               (RequiredLevel == "Moderators" &&
                                (userType == UserType.Moderator || userType == UserType.Host));
                if (canPost && LolChat != null)
                {
                    LolChat.SendMessage(fromUser + ": " + message, LolChat.GetLolChatUser);//Send message to LoL chat
                }
            }
        }
    }
}