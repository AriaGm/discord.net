using Discord.Commands;
using Discord.WebSocket;
using GmTutorial.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GmTutorial.Service
{
    public class ApplicationInitializer
    {
        public static async Task InitialCommandModules(CommandService service, IServiceProvider provider)
        {
            await service.AddModulesAsync(Assembly.GetEntryAssembly(), provider);
        }

        public static void InitialApplication(IServiceProvider provider, DiscordSocketClient client)
        {
            client.Ready += AppEventHandler.OnBotReady;
            client.MessageReceived += AppEventHandler.OnMessageReceived;
        }
    }
}
