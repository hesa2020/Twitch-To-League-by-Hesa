using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using TwitchToLeagueChat.Managers;

namespace TwitchToLeagueChat.Objects
{
// ReSharper disable once InconsistentNaming
    public class IRC
    {
        public void SendPing()
        {
            if (_writer == null) return;
            _writer.WriteLine("PING");
            _writer.Flush();
        }
        public bool Initialized;
        //Client vars
        TcpClient _client;
        NetworkStream _nwStream;
        StreamReader _reader;
        StreamWriter _writer;
        private int _tickCount;

        //Handling Threads
        //private Thread _handleMessages;
        //public List<string> Responses = new List<string>();

        //Special vars
        Dictionary<string, bool> _pollOpen;
        Dictionary<string, Dictionary<string, Dictionary<string, int>>> _pollVotes;
        Dictionary<string, bool> _antiSpoil;
        Dictionary<string, Dictionary<string, int>> _blackList;

        //Listen thread
        Thread _listen;

        /*public void HandleResponses()
        {
            while (true)
            {
                if (Responses.Count > 0)
                {
                    SendMessage(Responses[0]);
                    Responses.RemoveAt(0);
                }
                Thread.Sleep(1500);
            }
        }*/

        //Initialize
        public void Initialize()
        {
            TwitchChatManager.ChatManager = this;
            var botusername = Properties.Settings.Default["TwitchBotUsername"].ToString();
            var botpassword = Properties.Settings.Default["TwitchBotKey"].ToString();
            //var chatnickname = SettingsManager.GetSetting("chat_nickname");

            //Opens connection to the twitch IRC
            _client = new TcpClient("irc.twitch.tv", 6667);
            _nwStream = _client.GetStream();
            _reader = new StreamReader(_nwStream, Encoding.GetEncoding("UTF-8"));
            _writer = new StreamWriter(_nwStream, Encoding.GetEncoding("UTF-8"));

            //Special vars initialized
            _pollOpen = new Dictionary<string, bool>();
            _pollVotes = new Dictionary<string, Dictionary<string, Dictionary<string, int>>>();
            _antiSpoil = new Dictionary<string, bool>();
            _blackList = new Dictionary<string, Dictionary<string, int>>();
            //_handleResponses = new Thread(HandleMessages);
            //_handleMessages = new Thread(HandleResponses);
            //_handleResponses.Start();
            _handleMessages.Start();
            //Writes userdata to twitch - remember your username and password!
            _writer.WriteLine("USER " + botusername + "tmi twitch :" + botusername);
            _writer.Flush();
            _writer.WriteLine("PASS " + "oauth:" + botpassword.Replace("oauth:", ""));
            _writer.Flush();
            _writer.WriteLine("NICK " + botusername);
            _writer.Flush();
            //Initialize Channel
            _pollOpen["#" + botusername] = false;
            _pollVotes["#" + botusername] = null;
            _antiSpoil["#" + botusername] = false;

            _writer.WriteLine("JOIN #" + botusername.ToLower());
            _writer.Flush();

            //Starts a thread that reads all data from IRC
            _listen = new Thread(Listen);
            _listen.Start();
            Initialized = true;
        }
        [SecurityPermissionAttribute(SecurityAction.Demand, ControlThread = true)]
        public void Stop()
        {
            _listen.Abort();

        }
        //Reads all the data from the IRC server
        public void Listen()
        {
            string Data = "";
            try
            {
                while ((Data = _reader.ReadLine()) != null)
                {
                    //Initializing vars
                    string _nick = "";
                    string _type = "";
                    string _channel = "";
                    string _message = "";
                    string[] ex;

                    //Writes to console and main terminal
                    Console.WriteLine(Data);

                    //Respond PINGs with PONGs and the same message
                    ex = Data.Split(new char[] { ' ' }, 5);
                    if (ex[0] == "PING")
                    {
                        var pingpongmsg = "PONG " + ex[1] + "\r\n";
                        _writer.WriteLine(pingpongmsg);
                        _writer.Flush();
                        Console.WriteLine(pingpongmsg);
                    }
                    //Splitting message and the meta data
                    string[] split1 = Data.Split(':');
                    if (ex[0] != "PING" && split1.Length > 1)
                    {
                        //Splitting nick, type, chan and message
                        string[] split2 = split1[1].Split(' ');

                        //Nick consists of various things - we only want the nick itself
                        if (split2[0] != null)
                        {
                            _nick = split2[0];
                            _nick = _nick.Split('!')[0];
                        }
                        if (split2[1] != null)
                            //Type = PRIVMSG for normal messages. Only thing we need
                            _type = split2[1];

                        if (split2[2] != null)
                            //Channel posted to
                            _channel = split2[2];

                        //Get message
                        if (split1.Length > 2)
                        {
                            for (var i = 2; i < split1.Length; i++)
                            {
                                if (i == 2)
                                    _message += split1[i] + " ";
                                else
                                    _message += ":" + split1[i] + " ";
                            }
                        }
                        if (_nick != "tmi.twitch.tv" && _nick != Properties.Settings.Default["TwitchBotUsername"].ToString().ToLower()+".tmi.twitch.tv")
                            TwitchChatManager.HandleChatMessage(_nick, _message);
                    }
                }
            }
            catch (Exception e)
            {
                Console.Write(e.ToString());
                //_listen.Abort();
            }
        }
        //Sends a message and adds it to the mainform
        public void SendMessage(string message)
        {
            message = "PRIVMSG #" + Properties.Settings.Default["TwitchBotUsername"].ToString().ToLower() + " :" + message.Replace("\n", " ");
            _writer.WriteLine(message);
            _writer.Flush();
        }
    }
}