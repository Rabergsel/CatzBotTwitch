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
            ConnectionCredentials credentials = new ConnectionCredentials(Settings.channel_name, Settings.token);
            var clientOptions = new ClientOptions
            {
                MessagesAllowedInPeriod = 750,
                ThrottlingPeriod = TimeSpan.FromSeconds(30)
            };
            WebSocketClient customClient = new WebSocketClient(clientOptions);
            client = new TwitchClient(customClient);
            client.Initialize(credentials, Settings.channel_name);
            client.OnConnected += Client_OnConnected;
            client.OnMessageReceived += TTSMsg;
            client.OnMessageReceived += Counter;
            client.OnMessageReceived += stats;
            client.OnMessageReceived += checkMessage;
            

            try
            {
                api = new TwitchAPI();
                api.Settings.ClientId = Settings.APIclientID;
                api.Settings.AccessToken = Settings.APIsecret;
                Monitor = new LiveStreamMonitorService(api, 20);
                List<string> lst = new List<string> { Settings.channel_name };
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

            var msg = e.ChatMessage.Message.ToLower();
            bool mustBeDeleted = ChatFilter.containsBadWord(msg);

            if(mustBeDeleted)
            {
                client.DeleteMessage(Settings.channel_name, e.ChatMessage);
                client.TimeoutUser(Settings.channel_name, e.ChatMessage.Username, TimeSpan.FromMinutes(1), "It seems like you used a bad word. You now have been timeouted!");
            }


        }

        private void Client_OnConnected(object sender, OnConnectedArgs e)
        {
            client.SendMessage(Settings.channel_name, "Hey, THE BOT IS ONLINE!");
        }

        private void Counter(object sender, OnMessageReceivedArgs e)
        {
            if (e.ChatMessage.Message.ToLower().Trim() == "l") Settings.L_counter.addOccurence();
            if (e.ChatMessage.Message.ToLower().Trim() == "w") Settings.W_counter.addOccurence();
            if (e.ChatMessage.Message.ToLower().Trim() == "gg") Settings.GG_counter.addOccurence();
        }

        private void stats(object sender, OnMessageReceivedArgs e)
        {
            if (msgCounter.ContainsKey(e.ChatMessage.Username)) msgCounter[e.ChatMessage.Username]++;
            else msgCounter.Add(e.ChatMessage.Username, 0);
        }

        private void TTSMsg(object sender, OnMessageReceivedArgs e)
        {
            if(Settings.tts)
            {
                var synthesis = new System.Speech.Synthesis.SpeechSynthesizer();
                synthesis.Speak(e.ChatMessage.Username + ": " +  e.ChatMessage.Message);
            }
        }
    }
}
