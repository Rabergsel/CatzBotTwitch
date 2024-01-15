
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
        public static TwitchClient client;
        public static TwitchAPI api;
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
            client.OnMessageReceived += linkCommands;
            client.OnMessageReceived += checkOnModeratorAction;
            client.OnMessageReceived += DCLogger;
            

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


        private void DCLogger(object sender, OnMessageReceivedArgs e)
        {
            TwitchBot.DC.DCManager.accumulator("CHAT MESSAGE", e.ChatMessage.Username + ":\t" + e.ChatMessage.Message);
        }

        private void checkOnModeratorAction(object sender, OnMessageReceivedArgs e)
        {
            try
            {

                float rate = (Settings.model.spamCounter.occurencesInTimeSpan(60) / (float)Settings.model.msgCounter.occurencesInTimeSpan(60)) * 100f;
                float spams = Settings.model.spamCounter.occurencesInTimeSpan(60);
                bool currentFollwerOn = Settings.model.isFollowerOnlyChatOn;

                

                if(Settings.model.FollowerChatRelative)
                {
                    if(!currentFollwerOn & (rate > Settings.model.FollowerChatOnSpamValue))
                    {
                        client.FollowersOnlyOn(client.JoinedChannels[0], TimeSpan.FromDays(1));
                        client.SendMessage(client.JoinedChannels[0], "Follower only chat has been switched on due to high spam rate");
                        Settings.model.isFollowerOnlyChatOn = true;
                        api.Helix.Chat.UpdateChatSettingsAsync(Settings.model.broadcasterID, Settings.model.broadcasterID,
                                new TwitchLib.Api.Helix.Models.Chat.ChatSettings.ChatSettings()
                                {
                                    FollowerMode = true,
                                    FollowerModeDuration = 3600
                                });
                        // MessageBox.Show($"Overview:\nRate: {rate}\nspams:{spams}\nSwitched on!");
                        TwitchBot.DC.DCManager.sendEmbed(DSharpPlus.Entities.DiscordColor.Red, "Moderation Action Taken!", "Due to increased spam," +
                            " the follwer-only chat has been activated. This will go on until the spam rate falls below the specified limit.", "Follwer-Only Chat activated");
                    }
                    if(currentFollwerOn & (rate < Settings.model.FollowerChatOffSpamValue))
                    {
                        client.FollowersOnlyOff(client.JoinedChannels[0]);
                        client.SendMessage(client.JoinedChannels[0], "Follower only chat has been switched off due to declined spam rate");
                        Settings.model.isFollowerOnlyChatOn = false;
                        api.Helix.Chat.UpdateChatSettingsAsync(Settings.model.broadcasterID, Settings.model.broadcasterID,
                            new TwitchLib.Api.Helix.Models.Chat.ChatSettings.ChatSettings()
                            {
                                FollowerMode = false,
                                FollowerModeDuration = 3600
                            });
                        TwitchBot.DC.DCManager.sendEmbed(DSharpPlus.Entities.DiscordColor.Green, "Moderation Action Undone!", "The spam rate has fallen significantly, so the follwer-only chat has been deactivated", "Follwer-Chat deactivated");

                        // MessageBox.Show($"Overview:\nRate: {rate}\nspams:{spams}\nSwitched off!");
                    }
                }
                else
                {
                    if (!currentFollwerOn & (spams > Settings.model.FollowerChatOnSpamValue))
                    {
                        client.FollowersOnlyOn(client.JoinedChannels[0], TimeSpan.FromDays(1));
                        client.SendMessage(client.JoinedChannels[0], "Follower only chat has been switched on due to high spam rate");
                        Settings.model.isFollowerOnlyChatOn = true;

                        api.Helix.Chat.UpdateChatSettingsAsync(Settings.model.broadcasterID, Settings.model.broadcasterID,
                            new TwitchLib.Api.Helix.Models.Chat.ChatSettings.ChatSettings()
                            {
                                FollowerMode = true,
                                FollowerModeDuration = 3600
                            });

                        TwitchBot.DC.DCManager.sendEmbed(DSharpPlus.Entities.DiscordColor.Red, "Moderation Action Taken!", "Due to increased spam," +
                        " the follwer-only chat has been activated. This will go on until the spam rate falls below the specified limit.", "Follwer-Only Chat activated");
                        //MessageBox.Show($"Overview:\nRate: {rate}\nspams:{spams}\nSwitched on!");
                    }
                    if (currentFollwerOn & (spams < Settings.model.FollowerChatOffSpamValue))
                    {
                        client.FollowersOnlyOff(client.JoinedChannels[0]);
                        client.SendMessage(client.JoinedChannels[0], "Follower only chat has been switched off due to declined spam rate");
                        Settings.model.isFollowerOnlyChatOn = false;
                        api.Helix.Chat.UpdateChatSettingsAsync(Settings.model.broadcasterID, Settings.model.broadcasterID,
                            new TwitchLib.Api.Helix.Models.Chat.ChatSettings.ChatSettings()
                                {
                                    FollowerMode = false,
                                    FollowerModeDuration = 3600
                                });

                        TwitchBot.DC.DCManager.sendEmbed(DSharpPlus.Entities.DiscordColor.Green, "Moderation Action Undone!", "The spam rate has fallen significantly, so the follwer-only chat has been deactivated", "Follwer-Chat deactivated");

                        // MessageBox.Show($"Overview:\nRate: {rate}\nspams:{spams}\nSwitched off!");
                    }
                }

                //MessageBox.Show($"Ran through:\nRate: {rate}\nspams:{spams}\nFollower On Tick: {Settings.model.isFollowerOnlyChatOn}");

            }
            catch(Exception ex)
            {
                TwitchBot.DC.DCManager.sendEmbed(DSharpPlus.Entities.DiscordColor.DarkRed, "ERROR WHILE TAKING ACTION", "An error occured while executing the moderation action check!\n\n" + ex, "" +
                    "Ignored Error, trying to function normally. If this error occures often, please report to the developer!");
            }
        }

        private void checkMessage(object sender, OnMessageReceivedArgs e)
        {
            try
            {
                Settings.model.msgCounter.addOccurence();
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
                    Settings.model.spamCounter.addOccurence();

                    var secs = Punishment.punishUser(e.ChatMessage.Username, "BADWORD");

                    if (secs == -1)
                    {
                        client.BanUser(client.JoinedChannels[0], e.ChatMessage.Username, "You have violated the rules of this channel to often. You have been banned!");
                        TwitchBot.DC.DCManager.sendEmbed(DSharpPlus.Entities.DiscordColor.DarkRed, "PUNISHMENT", $"A user has been punished!\nUsername: {e.ChatMessage.Username}\nMessage: {e.ChatMessage.Message}\nReason: BADWORD", "" +
                        "Banned user for violating the rules to often (set punishment)\nDeleted Message", e.ChatMessage.UserId);
                    }
                    else
                    {
                        api.Helix.Moderation.BanUserAsync(broadcasterID, broadcasterID, new TwitchLib.Api.Helix.Models.Moderation.BanUser.BanUserRequest()
                        {
                            Duration = Math.Max(30, secs),
                            UserId = e.ChatMessage.UserId,
                            Reason = "Penalty for violating rules"
                        }, Settings.model.APIaccess);
                        TwitchBot.DC.DCManager.sendEmbed(DSharpPlus.Entities.DiscordColor.DarkRed, "PUNISHMENT", $"A user has been punished!\nUsername: {e.ChatMessage.Username}\nMessage: {e.ChatMessage.Message}\nReason: BADWORD", "" +
                            "Timed out user for "+ secs + " seconds (set punishment)\nDeleted Message", e.ChatMessage.UserId);
                    }
                    Logger.log("Deleting msg \"" + msg + "\" by " + e.ChatMessage.Username, "CHATFILTER");
                    Logger.log("Taking action against " + e.ChatMessage.Username + ":\t" + secs, "ACTION");
                }
            }
            catch (Exception ex)
            {
                Logger.log(ex.ToString(), "ERROR");
                TwitchBot.DC.DCManager.sendEmbed(DSharpPlus.Entities.DiscordColor.DarkRed, "ERROR WHILE CHAT FILTERING", "An error occured while executing the chat filter!\n\n" + ex, "" +
                    "Ignored Error, trying to function normally. If this error occures often, please report to the developer!");
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

        private void linkCommands(object sender, OnMessageReceivedArgs e)
        {
            if (e.ChatMessage.Message.StartsWith($"{Settings.model.commandPrefix}dc") ||
                e.ChatMessage.Message.StartsWith($"{Settings.model.commandPrefix}discord")
                )
            {
                client.SendMessage(client.JoinedChannels[0], Settings.model.dcLink);
            }

            if (e.ChatMessage.Message.StartsWith($"{Settings.model.commandPrefix}yt") ||
                e.ChatMessage.Message.StartsWith($"{Settings.model.commandPrefix}youtube")
                )
            {
                client.SendMessage(client.JoinedChannels[0], Settings.model.ytLink);
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
            if (Settings.model.tts
                & !e.ChatMessage.Message.StartsWith(Settings.model.commandPrefix)
                )
            {
                var synthesis = new System.Speech.Synthesis.SpeechSynthesizer();

                if (e.ChatMessage.Message.Contains("www.")
                    || e.ChatMessage.Message.Contains(".com"))
                {
                    synthesis.Speak(e.ChatMessage.Username + ": URL Link");
                }
                else if(e.ChatMessage.Message.Length < 2)
                {
                    //Leave empty, don't read!
                }
                else if(e.ChatMessage.Message.Length > 150)
                {
                    synthesis.Speak(e.ChatMessage.Username + ": Long Message");
                }
                else
                {
                    synthesis.Speak(e.ChatMessage.Username + ": " + e.ChatMessage.Message);
                }
                
                
            }
        }
    }
}
