using System;
using System.Collections.Generic;
using System.Linq;
using jabber.client;
using System.ComponentModel;
using System.Security;
using System.Timers;
using TwitchToLeagueChat.Objects;
namespace TwitchToLeagueChat.Managers
{
    public class LolChatManager
    {
        public Dictionary<string, LolChatUser> Users = new Dictionary<string, LolChatUser>();
        public BindingList<LolChatUser> TheUsers = new BindingList<LolChatUser>();
        readonly JabberClient _c = new JabberClient();
        readonly RosterManager _k = new RosterManager();

        public delegate void UserChangedHandler(LolChatUser e);
        public event UserChangedHandler UserChanged;
        public delegate void MsgHandler(LolChatUser @from, string message, DateTime date);
        public event MsgHandler OnMessage;
        public delegate void ErrorHandler(string error);
        public event ErrorHandler OnError;

        public delegate void ConnectedHandler();
        public event ConnectedHandler OnConnect;
        public event ConnectedHandler OnDisconnect;

        readonly Timer _durationTimer = new Timer(30000);

        public LolChatManager()
        {
            _c.OnPresence += c_OnPresence;
            _c.OnInvalidCertificate += c_OnInvalidCertificate;
            _k.OnRosterItem += k_OnRosterItem;
            _k.OnRosterEnd += k_OnRosterEnd;
            _c.OnMessage += c_OnMessage;
            _c.OnDisconnect += c_OnDisconnect;
            _c.OnAuthError += c_OnAuthError;
            _c.OnError += c_OnError;
            _durationTimer.Elapsed += durationTimer_Elapsed;
            _durationTimer.Start();
        }
        void c_OnError(object sender, Exception ex)
        {
            if (OnError != null)
                OnError(ex.Message);

        }

        void durationTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            foreach (var user in TheUsers)
            {
                if (UserChanged != null)
                {
                    if (_c.InvokeControl != null)
                    {
                        _c.InvokeControl.Invoke(UserChanged, new object[] { user });
                    }

                }
            }
        }
        public void Disconnect()
        {
            _c.Close(true);
        }

        static readonly byte[] Entropy = System.Text.Encoding.Unicode.GetBytes("Salt Is Not A Password");

        public static string EncryptString(SecureString input)
        {
            byte[] encryptedData = System.Security.Cryptography.ProtectedData.Protect(
                System.Text.Encoding.Unicode.GetBytes(ToInsecureString(input)),
                Entropy,
                System.Security.Cryptography.DataProtectionScope.CurrentUser);
            return Convert.ToBase64String(encryptedData);
        }

        public static SecureString DecryptString(string encryptedData)
        {
            try
            {
                byte[] decryptedData = System.Security.Cryptography.ProtectedData.Unprotect(
                    Convert.FromBase64String(encryptedData),
                    Entropy,
                    System.Security.Cryptography.DataProtectionScope.CurrentUser);
                return ToSecureString(System.Text.Encoding.Unicode.GetString(decryptedData));
            }
            catch
            {
                return new SecureString();
            }
        }

        public static SecureString ToSecureString(string input)
        {
            var secure = new SecureString();
            foreach (char c in input)
            {
                secure.AppendChar(c);
            }
            secure.MakeReadOnly();
            return secure;
        }

        public static string ToInsecureString(SecureString input)
        {
            string returnValue;
            IntPtr ptr = System.Runtime.InteropServices.Marshal.SecureStringToBSTR(input);
            try
            {
                returnValue = System.Runtime.InteropServices.Marshal.PtrToStringBSTR(ptr);
            }
            finally
            {
                System.Runtime.InteropServices.Marshal.ZeroFreeBSTR(ptr);
            }
            return returnValue;
        }

        public void Initialize(string username, string password, string server, ISynchronizeInvoke si)
        {
            _c.InvokeControl = si;
            _c.User = username;
            _c.Password = "AIR_" + password;
            _c.Port = 5223;
            _c.SSL = true;
            _c.AutoRoster = true;
            _c.AutoLogin = true;
            _c.AutoPresence = true;
            switch (server)
            {
                case "NA":
                    _c.NetworkHost = "chat.na2.lol.riotgames.com";
                    break;
                case "EU West":
                    _c.NetworkHost = "chat.euw1.lol.riotgames.com";
                    break;
                case "EU Nordic":
                    _c.NetworkHost = "chat.eun1.lol.riotgames.com";
                    break;
                case "Public Beta Environment":
                    _c.NetworkHost = "chat.pbe1.lol.riotgames.com";
                    break;
                case "Oceania":
                    _c.NetworkHost = "chat.oc1.lol.riotgames.com";
                    break;
                case "Brazil":
                    _c.NetworkHost = "chat.br.lol.riotgames.com";
                    break;
                case "Turkey":
                    _c.NetworkHost = "chat.tr.lol.riotgames.com";
                    break;
                case "Russia":
                    _c.NetworkHost = "chat.ru.lol.riotgames.com";
                    break;
                case "Latin America North":
                    _c.NetworkHost = "chat.la1.lol.riotgames.com";
                    break;
                case "Latin America South":
                    _c.NetworkHost = "chat.la2.lol.riotgames.com";
                    break;
                case "Taiwan":
                    _c.NetworkHost = "chat.na2.lol.riotgames.com";
                    break;
                case "Thailand":
                    _c.NetworkHost = "chattw.lol.garenanow.com";
                    break;
                case "Vietnamn":
                    _c.NetworkHost = "chatvn.lol.garenanow.com";
                    break;
                case "Phillipines":
                    _c.NetworkHost = "chatph.lol.garenanow.com";
                    break;
            }
            _c.Server = "pvp.net";
            _k.Stream = _c;

            Users.Clear();
            TheUsers.Clear();

            _c.Connect();
        }

        bool c_OnInvalidCertificate(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certificate, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }

        void c_OnAuthError(object sender, System.Xml.XmlElement rp)
        {
            if (OnError != null) OnError("Wrong username or password");
            if (OnDisconnect != null)
            {
                OnDisconnect();
            }
        }

        void c_OnDisconnect(object sender)
        {
            if (OnDisconnect != null)
            {
                OnDisconnect();
            }
        }

        void k_OnRosterEnd(object sender)
        {

            if (OnConnect != null)
            {
                OnConnect();
            }
        }

        void c_OnMessage(object sender, jabber.protocol.client.Message msg)
        {
            if ((OnMessage != null) && (!msg.Body.StartsWith("<body>")))
            {
                if (Users.ContainsKey(msg.From.User))
                {
                    OnMessage(Users[msg.From.User], msg.Body, DateTime.Now);
                }
            }
            else if (!msg.Body.StartsWith("<body>"))
            {
                if (Users.ContainsKey(msg.From.User))
                {
                    if (GetLolChatUser == Users[msg.From.User])
                    {
                        TwitchChatManager.HandleChatMessage("", msg.Body, false);
                    }
                    else
                        TwitchChatManager.HandleChatMessage(Users[msg.From.User].Nickname, msg.Body, false);
                }
            }
        }
        void k_OnRosterItem(object sender, jabber.protocol.iq.Item ri)
        {

            if (Users.ContainsKey(ri.JID.User))
            {
                if (ri.Subscription == jabber.protocol.iq.Subscription.remove)
                {
                    Users[ri.JID.User].Status = null;

                    if (UserChanged != null)
                        UserChanged(Users[ri.JID.User]);
                    Users.Remove(ri.JID.User);

                }
                else
                {
                    LolChatUser us = Users[ri.JID.User];
                    us.Nickname = ri.Nickname;
                    us.Group = ri.GetGroups().First().GroupName;
                    us.Item = ri;
                }
            }
            else
            {
                var us = new LolChatUser(ri.JID.User, ri.Nickname, ri.GetGroups().First().GroupName, "", ri);
                Users.Add(ri.JID.User, us);
            }
        }

        public void SendMessage(string text, LolChatUser u)
        {
            if (u == null) return;
            _c.Message(u.Item.JID, text);
        }

        public LolChatUser GetLolChatUser
        {
            get
            {
                if (TheUsers.Count == 0) return null;
                var user = TheUsers.FirstOrDefault(x => x.Nickname.ToLower().Equals(Properties.Settings.Default["SummonerName"].ToString().ToLower()));
                return user;
            }
        }

        void c_OnPresence(object sender, jabber.protocol.client.Presence pres)
        {
            if (Users.ContainsKey(pres.From.User))
            {
                Users[pres.From.User].Status = pres.Status;
            }
            else
            {
                var us = new LolChatUser(pres.From.User, "", "", pres.Status, null);
                Users.Add(pres.From.User, us);
                TheUsers.Add(us);
            }
            if (Users[pres.From.User].State == "offline")
            {
                Users[pres.From.User].IsOnline = false;
                if (TheUsers.Contains(Users[pres.From.User]))
                    TheUsers.Remove(Users[pres.From.User]);

            }
            else
            {
                Users[pres.From.User].IsOnline = (Users[pres.From.User].Nickname != "");
                if (!TheUsers.Contains(Users[pres.From.User]))
                    TheUsers.Add(Users[pres.From.User]);
            }
            if (TheUsers.Contains(Users[pres.From.User]))
            {
                if (UserChanged != null)
                    UserChanged(Users[pres.From.User]);
            }
        }
    }
}