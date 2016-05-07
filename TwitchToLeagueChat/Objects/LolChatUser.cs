using System;
using System.ComponentModel;
using System.Globalization;
using System.Net;
using System.Text.RegularExpressions;
namespace TwitchToLeagueChat.Objects
{
    public class LolChatUser : INotifyPropertyChanged
    {
        private string _profileIcon;
        private string _statusMsg;
        private string _level;
        private string _wins;
        private string _leaves;
        private string _queueType;
        private string _rankedWins;
        private string _rankedLosses;
        private string _rankedRating;
        private string _tier;
        private string _skinname;
        private string _gameStatus;
        private string _timeStamp;

        private string _nickname;
        private string _group;

        public bool IsOnline;
        public jabber.protocol.iq.Item Item;
        private string _status;
        public WebClient C = new WebClient();
        public event PropertyChangedEventHandler PropertyChanged;

        public LolChatUser(string jid, string nickname, string @group, string status, jabber.protocol.iq.Item item)
        {
            Item = item;
            Jid = jid;
            _nickname = nickname;
            _group = @group;
            _status = status;
        }

        public System.Drawing.Image Image;
        public string State
        {
            get
            {
                if (GameStatus == "outOfGame")
                {
                    return "outOfGame";
                }
                if (GameStatus == "inQueue")
                {
                    return "inQueue";
                }
                if ((GameStatus != null) && (Skinname != null))
                {
                    return Skinname.Replace(".", "").Replace(" ", "-").Replace("`", "").Replace("'", "").ToLower();
                }
                if (Status == null) return "";
                if (Nickname == "") return "offline";
                return "outOfGame";
            }
        }
        public string Nickname { get { return _nickname; } set { _nickname = value; NotifyPropertyChanged("Nickname"); } }
        public string ProfileIcon { get { return _profileIcon; } set { _profileIcon = value; NotifyPropertyChanged("profileIcon"); } }
        public string StatusMsg { get { return _statusMsg; } set { _statusMsg = value; NotifyPropertyChanged("statusMsg"); } }
        public string Level { get { return _level; } set { _level = value; NotifyPropertyChanged("level"); } }
        public string Wins { get { return _wins; } set { _wins = value; NotifyPropertyChanged("wins"); } }
        public string Leaves { get { return _leaves; } set { _leaves = value; NotifyPropertyChanged("leaves"); } }
        public string QueueType { get { return _queueType; } set { _queueType = value; NotifyPropertyChanged("queueType"); } }
        public string RankedWins { get { return _rankedWins; } set { _rankedWins = value; NotifyPropertyChanged("rankedWins"); } }
        public string RankedLosses { get { return _rankedLosses; } set { _rankedLosses = value; NotifyPropertyChanged("rankedLosses"); } }
        public string RankedRating { get { return _rankedRating; } set { _rankedRating = value; NotifyPropertyChanged("rankedRating"); } }
        public string Tier { get { return _tier; } set { _tier = value; NotifyPropertyChanged("tier"); } }
        public string Skinname { get { return _skinname; } set { _skinname = value; NotifyPropertyChanged("skinname"); } }
        public string GameStatus { get { return _gameStatus; } set { _gameStatus = value; NotifyPropertyChanged("gameStatus"); } }
        public string TimeStamp { get { return _timeStamp; } set { _timeStamp = value; NotifyPropertyChanged("timeStamp"); } }
        public string Jid { get; set; }

        public void CalcDuration()
        {
            NotifyPropertyChanged("duration");
        }

        public string Duration
        {
            get
            {
                if (TimeStamp == null)
                    return "0";
                var origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
                DateTime parsed = origin.AddSeconds(double.Parse(_timeStamp) / 1000);
                var k = (Math.Round((DateTime.UtcNow - parsed).TotalMinutes) + 1);
                if (k < 0) { k = 0; }
                return k.ToString(CultureInfo.InvariantCulture);
            }
        }

        public string Group
        {
            get { return _group; }
            set
            {
                _group = value;
                NotifyPropertyChanged("Group");
            }
        }

        readonly Regex _statreg = new Regex("<(\\w*)>(.*?)</");
        public string Status
        {
            get { return _status; }
            set
            {
                if (_status != value)
                {
                    _status = value;
                    if (_status != null)
                    {
                        foreach (Match m in _statreg.Matches(_status))
                        {
                            string thename = m.Groups[1].Value;
                            string thevalue = m.Groups[2].Value;
                            switch (thename)
                            {
                                case "profileIcon": ProfileIcon = thevalue; break;
                                case "statusMsg": StatusMsg = thevalue; break;
                                case "level": Level = thevalue; break;
                                case "wins": Wins = thevalue; break;
                                case "leaves": Leaves = thevalue; break;
                                case "queueType ": QueueType = thevalue; break;
                                case "rankedWins": RankedWins = thevalue; break;
                                case "rankedLosses": RankedLosses = thevalue; break;
                                case "rankedRating": RankedRating = thevalue; break;
                                case "tier": Tier = thevalue; break;
                                case "skinname": Skinname = thevalue; break;
                                case "gameStatus": GameStatus = thevalue; break;
                                case "timeStamp": TimeStamp = thevalue; break;

                            }
                        }

                        IsOnline = (Nickname != "");
                    }
                    else
                    {
                        IsOnline = false;
                    }
                    NotifyPropertyChanged("status");
                    NotifyPropertyChanged("profileImageUrl");
                    NotifyPropertyChanged("duration");
                    NotifyPropertyChanged("State");
                }
            }
        }

        private void NotifyPropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
}