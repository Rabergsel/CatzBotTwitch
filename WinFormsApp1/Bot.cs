using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TwitchLib.Client;
using TwitchLib.Client.Enums;
using TwitchLib.Client.Events;
using TwitchLib.Client.Extensions;
using TwitchLib.Client.Models;
using TwitchLib.Communication.Clients;
using TwitchLib.Communication.Models;

using TwitchLib.Api;
using TwitchLib.Api.Services;
using TwitchLib.Api.Services.Events;
using TwitchLib.Api.Services.Events.LiveStreamMonitor;

using System.IO;

namespace WinFormsApp1
{
    public class Bot
    {
        TwitchClient client;

        TwitchAPI api;
        private LiveStreamMonitorService Monitor;

        Dictionary<string, int> msgCounter = new Dictionary<string, int>();

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
                api.Settings.AccessToken = Settings.model.APIsecret;
                Monitor = new LiveStreamMonitorService(api, 20);
                List<string> lst = new List<string> { Settings.model.channel_name };
                Monitor.SetChannelsByName(lst);

                Monitor.Start();
            }
            catch
            {

            }
            client.Connect();

        }

        private void checkMessage(object sender, OnMessageReceivedArgs e)
        {
            try
            {
                if (!Settings.model.chatfilter) return;

                var msg = e.ChatMessage.Message.ToLower();
                bool mustBeDeleted = ChatFilter.containsBadWord(msg);

                if (mustBeDeleted)
                {
                    Logger.log("Deleting msg \"" + msg + "\" by " + e.ChatMessage.Username, "CHATFILTER");
                    client.TimeoutUser(client.JoinedChannels[0], e.ChatMessage.Username, TimeSpan.FromSeconds(10));
                    client.DeleteMessage(client.JoinedChannels[0], e.ChatMessage);
                    var secs = Punishment.punishUser(e.ChatMessage.Username, "BADWORD");
                    Logger.log("Taking action against " + e.ChatMessage.Username + ":\t" + secs, "ACTION");
                    if (secs == -1) client.BanUser(client.JoinedChannels[0], e.ChatMessage.Username, "You have violated the rules of this channel to often. You have been banned!");
                    else
                    {
                        client.SendMessage(client.JoinedChannels[0], "/timeout " + e.ChatMessage.Username + " " + secs);
                        client.TimeoutUser(client.JoinedChannels[0], e.ChatMessage.Username, TimeSpan.FromSeconds(secs));

                    }
                }
            }
            catch(Exception ex)
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
            if (e.ChatMessage.Message.ToLower().Trim() == "l") Settings.model.L_counter.addOccurence();
            if (e.ChatMessage.Message.ToLower().Trim() == "w") Settings.model.W_counter.addOccurence();
            if (e.ChatMessage.Message.ToLower().Trim() == "gg") Settings.model.GG_counter.addOccurence();
        }

        private void stats(object sender, OnMessageReceivedArgs e)
        {
            if (msgCounter.ContainsKey(e.ChatMessage.Username)) msgCounter[e.ChatMessage.Username]++;
            else msgCounter.Add(e.ChatMessage.Username, 0);
        }

        private void TTSMsg(object sender, OnMessageReceivedArgs e)
        {
            if(Settings.model.tts)
            {
                var synthesis = new System.Speech.Synthesis.SpeechSynthesizer();
                synthesis.Speak(e.ChatMessage.Username + ": " +  e.ChatMessage.Message);
            }
        }
    }
}
