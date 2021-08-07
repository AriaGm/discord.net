using Discord.Addons.Hosting;
using Discord.Commands;
using Discord.WebSocket;
using GmTutorial.Service;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using GmTutorial.Enums;

namespace GmTutorial.Context
{
    public class ApplicationContext : InitializedService
    {
        private static IServiceProvider _provider;
        private static DiscordSocketClient _client;
        private static CommandService _service;
        private static IConfiguration _config;

        public static IServiceProvider Provider { get { return _provider; } }
        public static DiscordSocketClient Client { get { return _client; } }
        public static CommandService Service { get { return _service; } }
        public static IConfiguration Config { get { return _config; } }

        public ApplicationContext(IServiceProvider provider, DiscordSocketClient client, CommandService service, IConfiguration config)
        {
            _provider = provider;
            _client = client;
            _service = service;
            _config = config;

            ApplicationLogger.Log(LogSect.Guild, LogType.Info, ConsoleColor.White, "Application context created successfully!");
        }

        public override async Task InitializeAsync(CancellationToken cancellationToken)
        {
            ApplicationInitializer.InitialApplication(Provider, Client);
            await ApplicationInitializer.InitialCommandModules(Service, Provider);
        }
    }
}
