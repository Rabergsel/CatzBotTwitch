using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;

namespace TwitchBot.DC
{
    public class StartDCBot
    {

        public static async Task StartDCBotAsync()
        {
            var slash = Presence.presence.UseSlashCommands();

            slash.RegisterCommands<SlashCommands>();
            ActionButtonManager.register();
            Presence.presence.ConnectAsync();
            DCManager.sendEmbed(DiscordColor.White, "DC Bot Started", "The Discord Bot started successfully.", "Started!");

            await Task.Delay(-1);
        }

        

    }

    public class SlashCommands : ApplicationCommandModule
    {
        [SlashCommand("setaslogchannel", "Sets the current channel as Log Channel")]
        [SlashCommandPermissions(Permissions.Administrator)]
        public async Task setAsChannel(InteractionContext ctx)
        {
            WinFormsApp1.Settings.model.DCChannel = ctx.Channel.Id;
            ctx.CreateResponseAsync("This channel has now been set to the streaming log channel. Everything that happens will be sent in here. **BEWARE THE CONTENT IS NOT CENSORED!**");
        }

        [SlashCommand("setmodeventping", "Sets the role to ping when something happens")]
        [SlashCommandPermissions(Permissions.Administrator)]
        public async Task setAsChannel(InteractionContext ctx,
            [Option("Role", "The role to ping")] DiscordRole role)
        {
            WinFormsApp1.Settings.model.EventModPingRole = role.Id;
            ctx.CreateResponseAsync("The ping has been set!");
        }
    }
}
