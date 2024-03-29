﻿using DSharpPlus.SlashCommands;

namespace Icarus.Discord.Commands
{
    public partial class Admin
    {
        [SlashCommand("restart", "Restarts the bot.")]
        public async Task RestartCommand(InteractionContext ctx)
        {
            Logger.LogWarning("Disconnecting bot on slash command.");
            await ctx.CreateResponseAsync("Restarting bot...", true);
            await ctx.Client.DisconnectAsync();
            ctx.Client.Dispose();
            Thread.Sleep(2000);
            Environment.Exit(0);
        }
    }
}
