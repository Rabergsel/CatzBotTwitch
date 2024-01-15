using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WinFormsApp1;

namespace TwitchBot.DC
{
    public class ActionButtonManager
    {
        public static void register()
        {
            UndoTimeout();
        }

        public static void UndoTimeout()
        {
            Presence.presence.ComponentInteractionCreated += async (s, e) =>
            {
                if(e.Id.StartsWith("undoto_"))
                {
                    Bot.api.Helix.Moderation.UnbanUserAsync(Settings.model.broadcasterID, Settings.model.broadcasterID, e.Id.Replace("undoto_", ""));
                    DCManager.sendEmbed(DSharpPlus.Entities.DiscordColor.Blurple, "UNDO TIMEOUT/BAN", "Trying to revoke ban or timeout of user id " + e.Id.Replace("undoto_", ""), "Sent request to Twitch API.\nThis is not a success message");
                }
            };
        }

    }
}
