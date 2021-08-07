using Discord.Commands;
using Discord.WebSocket;
using GmTutorial.Context;
using GmTutorial.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GmTutorial.Service
{
    public class AppEventHandler
    {
        public static async Task OnBotReady()
        {
            await ApplicationContext.Client.SetStatusAsync(Discord.UserStatus.DoNotDisturb);
            await ApplicationContext.Client.SetGameAsync("Server requests...", null, Discord.ActivityType.Listening);
            ApplicationLogger.Log(Enums.LogSect.Guild, Enums.LogType.Info, ConsoleColor.Green, "Application Started successfully!");

            ApplicationDrawing.ShowNotify(ConsoleColor.Cyan, "\n----------------------------- Runtime Log -----------------------------\n");
        }

        public static async Task OnMessageReceived(SocketMessage arg)
        {
            var msg = arg as SocketUserMessage;
            var context = new SocketCommandContext(ApplicationContext.Client, msg);
            int pos = 0;

            if (arg.Channel.Id != 852177370341179392) return;
            if (arg.Source != Discord.MessageSource.User) return;
            if (!context.Message.HasStringPrefix(ApplicationContext.Config["prefix"], ref pos)) return;

            await ApplicationContext.Service.ExecuteAsync(context, pos, ApplicationContext.Provider);
        }
    }
}
