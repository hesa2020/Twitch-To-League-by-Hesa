﻿using System;
using System.Collections.Generic;
using System.Linq;
using JabberNet.jabber.client;
using System.ComponentModel;
using System.Security;
using System.Timers;
using TwitchToLeagueChat.Objects;
using System.IO;
using TwitchToLeagueChat.Properties;
using System.Windows.Forms;

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

        readonly System.Timers.Timer _durationTimer = new System.Timers.Timer(30000);

        public RiotAuthToken AuthCred;

        public LolChatManager()
        {
            _c.OnConnect += C_OnConnect;
            _c.OnPresence += C_OnPresence;
            _c.OnInvalidCertificate += C_OnInvalidCertificate;
            _c.OnLoginRequired += C_OnLoginRequired;
            _k.OnRosterItem += K_OnRosterItem;
            _k.OnRosterEnd += K_OnRosterEnd;
            _c.OnMessage += C_OnMessage;
            _c.OnDisconnect += C_OnDisconnect;
            _c.OnAuthenticate += C_OnAuthenticate;
            _c.OnAuthError += C_OnAuthError;
            _c.OnError += C_OnError;
            
            _durationTimer.Elapsed += DurationTimer_Elapsed;
            _durationTimer.Start();
        }

        private void C_OnAuthenticate(object sender)
        {
            
        }

        private void C_OnLoginRequired(object sender)
        {
            //((JabberClient)sender).Write($"<auth xmlns=\"urn:ietf:params:xml:ns:xmpp-sasl\" mechanism=\"X-Riot-RSO-PAS\">{_c.Password}</auth>");
        }

        private void C_OnConnect(object sender, JabberNet.jabber.connection.StanzaStream stream)
        {
        }

        void C_OnError(object sender, Exception ex)
        {
            OnError?.Invoke(ex.Message);
        }

        void DurationTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            foreach (var user in TheUsers)
            {
                if (UserChanged != null)
                {
                    /*if (_c.InvokeControl != null)
                    {
                        _c.InvokeControl.Invoke(UserChanged, new object[] { user });
                    }*/
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

        public bool Initialize(string username, string password, string server, ISynchronizeInvoke si)
        {
            try
            {
                if (!File.Exists(Path.Combine(Settings.Default.LeaguePath, "system.yaml")))
                {
                    MessageBox.Show("system.yaml does not exists in league of legends folder, pleasy verify your path setting");
                    return false;
                }
                var Rso = AuthClass.GetOpenIdConfig();
                if (Rso == null)
                {
                    MessageBox.Show("Unable to get OpenId config from league of legends servers");
                    return false;
                }
                var regionData = AuthClass.ReadSystemRegionData(Path.Combine(Settings.Default.LeaguePath, "system.yaml"), server.ToUpper());
                if (regionData == null)
                {
                    MessageBox.Show("Unable to read system region data from system.yaml, the file structure may have changed.");
                    return false;
                }
                AuthCred = AuthClass.GetLoginToken(username, password, regionData, Rso);
                if (AuthCred.Result != RiotAuthResult.Success)
                {
                    if (AuthCred.Result == RiotAuthResult.BadProxy) MessageBox.Show("Unable to authenticate with account credentials reason: Bad proxy.");
                    if (AuthCred.Result == RiotAuthResult.Banned) MessageBox.Show("Unable to authenticate with account credentials reason: Banned.");
                    if (AuthCred.Result == RiotAuthResult.ConProblem) MessageBox.Show("Unable to authenticate with account credentials reason: Connection problem.");
                    if (AuthCred.Result == RiotAuthResult.InvalidCredentials) MessageBox.Show("Unable to authenticate with account credentials reason: Invalid credentials.");
                    if (AuthCred.Result == RiotAuthResult.TooManyReq) MessageBox.Show("Unable to authenticate with account credentials reason: Too many requests.");
                    if (AuthCred.Result == RiotAuthResult.UnknownReason) MessageBox.Show("Unable to authenticate with account credentials reason: Unknown.");
                    return false;
                }
                var userData = AuthClass.GetUserData(AuthCred);
                if (userData == null)
                {
                    MessageBox.Show("Unable to get user data from league of legends servers");
                    return false;
                }
                var entiltlementsToken = AuthClass.GetEntitlementsToken(AuthCred);
                var pasToken = AuthClass.GetChatPasToken(AuthCred);
                if (pasToken == null)
                {
                    MessageBox.Show("Unable to get unique token from league of legends chat server");
                    return false;
                }

                //_c.InvokeControl = si;
                //_c.Resource = "xiff";
                _c.Resource = "RC-2374418390";
                _c.User = regionData.Rso.Token;// AuthCred.RegionData.Rso.Token;
                _c.Password = pasToken;// AuthCred.AccessTokenJson.AccessToken;
                _c.Server = regionData.PlatformId.ToString() + ".pvp.net";
                _c.NetworkHost = AuthCred.RegionData.Servers.Chat.ChatHost;
                _c.Port = AuthCred.RegionData.Servers.Chat.ChatPort;
                _c.SSL = true;
                _c.AutoRoster = true;
                _c.AutoLogin = true;
                _c.AutoPresence = true;
                _c["sasl.mechanisms"] = "X-Riot-RSO-PAS";
                _c.RequiresSASL = true;

                _k.Stream = _c;

                Users.Clear();
                TheUsers.Clear();

                _c.Connect();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            return true;
        }

        bool C_OnInvalidCertificate(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certificate, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }

        void C_OnAuthError(object sender, System.Xml.XmlElement rp)
        {
            Console.WriteLine(rp.ToString());
            OnError?.Invoke("Wrong username or password");
            OnDisconnect?.Invoke();
        }

        void C_OnDisconnect(object sender)
        {
            OnDisconnect?.Invoke();
        }

        void K_OnRosterEnd(object sender)
        {
            OnConnect?.Invoke();
        }

        void C_OnMessage(object sender, JabberNet.jabber.protocol.client.Message msg)
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

        void K_OnRosterItem(object sender, JabberNet.jabber.protocol.iq.Item ri)
        {
            if (Users.ContainsKey(ri.JID.User))
            {
                if (ri.Subscription == JabberNet.jabber.protocol.iq.Subscription.remove)
                {
                    Users[ri.JID.User].Status = null;
                    UserChanged?.Invoke(Users[ri.JID.User]);
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

        void C_OnPresence(object sender, JabberNet.jabber.protocol.client.Presence pres)
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
                UserChanged?.Invoke(Users[pres.From.User]);
            }
        }
    }
}