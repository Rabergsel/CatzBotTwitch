
using TwitchLib.Api;
using TwitchLib.Api.Services;
using TwitchLib.Client;
using TwitchLib.Client.Events;
using TwitchLib.Client.Extensions;
using TwitchLib.Client.Models;
using TwitchLib.Communication.Clients;
using TwitchLib.Communication.Models;

namespace WinFormsApp1
{
    public class Bot
    {
        private TwitchClient client;
        private TwitchAPI api;
        private LiveStreamMonitorService Monitor;
        private Dictionary<string, int> msgCounter = new Dictionary<string, int>();

        public Bot()
        {
            ConnectionCredentials credentials = new ConnectionCredentials(Settings.model.channel_name, Settings.model.token);
            var clientOptions = new ClientOptions
            {
                MessagesAllowedInPeriod = 750,
                ThrottlingPeriod = TimeSpan.FromSeconds(30)
            };
            WebSocketClient customClient = new WebSocketClient(clientOptions);
            client = new TwitchClient(customClient);
            client.Initialize(credentials, Settings.model.channel_name);
            client.OnConnected += Client_OnConnected;
            client.OnMessageReceived += TTSMsg;
            client.OnMessageReceived += Counter;
            client.OnMessageReceived += stats;
            client.OnMessageReceived += checkMessage;


            try
            {
                api = new TwitchAPI();
                api.Settings.ClientId = Settings.model.APIclientID;
                api.Settings.AccessToken = Settings.model.APIaccess;


                Monitor = new LiveStreamMonitorService(api, 20);
                List<string> lst = new List<string> { Settings.model.channel_name };
                Monitor.SetChannelsByName(lst);
                Monitor.Start();

                Logger.log("API started without any problems!", "SYSTEM");
            }
            catch (Exception ex)
            {
                Logger.log("API had problems to connect! " + ex, "ERROR");
            }
            client.Connect();

        }

        private void checkMessage(object sender, OnMessageReceivedArgs e)
        {
            try
            {
                Logger.log("Checking msg " + e.ChatMessage.Message, "DEBUG");
                var msg = e.ChatMessage.Message.ToLower();
                bool mustBeDeleted = false;

                if (Settings.model.chatfilter)
                {
                    mustBeDeleted = ChatFilter.containsBadWord(msg);
                }

                if (Settings.model.useDisguisedBadwordDetector & !mustBeDeleted)
                {
                    mustBeDeleted = ChatFilter.containsDisguisedBadWord(msg, Settings.model.LevenshteinDistanceThreshold);
                }

                string broadcasterID = Settings.model.broadcasterID;


                if (Settings.model.botIsBroadcaster & e.ChatMessage.IsBroadcaster)
                {
                    broadcasterID = e.ChatMessage.UserId;
                    if (Settings.model.broadcasterID != broadcasterID)
                    {
                        Settings.model.broadcasterID = broadcasterID;
                        client.SendMessage(client.JoinedChannels[0], "The broadcaster ID has now been set.\nThis means that the chatfilter is now active!");
                    }
                }
                if (mustBeDeleted)
                {
                    api.Helix.Moderation.DeleteChatMessagesAsync(broadcasterID, broadcasterID, e.ChatMessage.Id, Settings.model.APIaccess);
                    var secs = Punishment.punishUser(e.ChatMessage.Username, "BADWORD");

                    if (secs == -1)
                    {
                        client.BanUser(client.JoinedChannels[0], e.ChatMessage.Username, "You have violated the rules of this channel to often. You have been banned!");
                    }
                    else
                    {
                        api.Helix.Moderation.BanUserAsync(broadcasterID, broadcasterID, new TwitchLib.Api.Helix.Models.Moderation.BanUser.BanUserRequest()
                        {
                            Duration = Math.Max(30, secs),
                            UserId = e.ChatMessage.UserId,
                            Reason = "Penalty for violating rules"
                        }, Settings.model.APIaccess);
                    }
                    Logger.log("Deleting msg \"" + msg + "\" by " + e.ChatMessage.Username, "CHATFILTER");
                    Logger.log("Taking action against " + e.ChatMessage.Username + ":\t" + secs, "ACTION");
                }
            }
            catch (Exception ex)
            {
                Logger.log(ex.ToString(), "ERROR");
            }


        }

        private void Client_OnConnected(object sender, OnConnectedArgs e)
        {
            client.SendMessage(Settings.model.channel_name, "Hey, THE BOT IS ONLINE!");
        }

        private void Counter(object sender, OnMessageReceivedArgs e)
        {
            if (e.ChatMessage.Message.ToLower().Trim() == "l")
            {
                Settings.model.L_counter.addOccurence();
            }

            if (e.ChatMessage.Message.ToLower().Trim() == "w")
            {
                Settings.model.W_counter.addOccurence();
            }

            if (e.ChatMessage.Message.ToLower().Trim() == "gg")
            {
                Settings.model.GG_counter.addOccurence();
            }
        }

        private void stats(object sender, OnMessageReceivedArgs e)
        {
            if (msgCounter.ContainsKey(e.ChatMessage.Username))
            {
                msgCounter[e.ChatMessage.Username]++;
            }
            else
            {
                msgCounter.Add(e.ChatMessage.Username, 0);
            }
        }

        private void TTSMsg(object sender, OnMessageReceivedArgs e)
        {
            if (Settings.model.tts)
            {
                var synthesis = new System.Speech.Synthesis.SpeechSynthesizer();
                synthesis.Speak(e.ChatMessage.Username + ": " + e.ChatMessage.Message);
            }
        }
    }
}
