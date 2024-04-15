using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.Entities;

namespace TwitchBot.DC
{
    public class DCManager
    {
        static string accu = "";

        static DiscordWebhook webhook = null;

        public static void sendMessageAsWebhook(string message, string author)
        {
            try
            {
                DiscordChannel channel;


               if(WinFormsApp1.Settings.model.CrossChatChannel != 0)
                {
                    channel = Presence.presence.GetChannelAsync(WinFormsApp1.Settings.model.CrossChatChannel).Result;


                    if (webhook == null)
                    {
                         webhook = channel.CreateWebhookAsync("Crosschat").Result;
                    }

                    var msg = new DiscordWebhookBuilder()
                        .WithContent(message)
                        .WithUsername(author)
                        .SendAsync(webhook)
                        .Result;

                }
            }
            catch(Exception ex)
            {
                accumulator("ERROR", "Crosschat did not work: " + ex);
            }
        }

        public static void sendEmbed(DiscordColor color, string title, string content, string action, string undoTimoutUserID = "")
        {
            try
            {
                var channel = Presence.presence.GetChannelAsync(WinFormsApp1.Settings.model.DCChannel).Result;
                var embed = new DiscordEmbedBuilder()
                    .WithTitle(title)
                    .WithColor(color)
                    .WithDescription(content)
                    .AddField("Action taken: ", action);

                var msg = new DiscordMessageBuilder();
                msg.AddEmbed(embed);
                
                if(WinFormsApp1.Settings.model.EventModPingRole != 0)
                {
                    msg.WithContent($"<@&{WinFormsApp1.Settings.model.EventModPingRole}>");
                }
                
                if(undoTimoutUserID != "")
                {
                    msg.AddComponents(new DiscordButtonComponent(ButtonStyle.Danger, "undoto_" + undoTimoutUserID, "Undo Timeout/Ban"));
                }
                channel.SendMessageAsync(msg);
                
            }
            catch
            {

            }
        }

        public static void accumulator(string prefix, string text)
        {
            var st = $"<t:{DateTimeOffset.Now.ToUnixTimeSeconds()}> **[{prefix}]** {text}\n";
            if (accu.Length + st.Length > 1000) SendAccumulator();
            accu += st;
        }

        public static void SendAccumulator()
        {
            try
            {
                if (accu.Length < 2) return;
                var channel = Presence.presence.GetChannelAsync(WinFormsApp1.Settings.model.DCChannel).Result;
                Presence.presence.SendMessageAsync(channel, accu);
                accu = "";
            }
            catch
            {

            }
        }

    }
}
