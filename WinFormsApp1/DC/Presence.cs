using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DSharpPlus;
using DSharpPlus.Entities;

using WinFormsApp1;

namespace TwitchBot.DC
{
    public class Presence
    {

        public static DiscordClient presence = new DiscordClient(
            new DiscordConfiguration()
            {
                Token = Settings.model.DiscordToken,
                Intents = DiscordIntents.All
            });
    }
}
