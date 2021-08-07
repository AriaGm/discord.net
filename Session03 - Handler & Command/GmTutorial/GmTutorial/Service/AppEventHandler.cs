using GmTutorial.Context;
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
        }
    }
}
