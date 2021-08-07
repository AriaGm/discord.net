using Discord.Addons.Hosting;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GmTutorial.Context
{
    public class ApplicationContext : InitializedService
    {
        public static IServiceProvider provider;
        public static DiscordSocketClient client;
        public static CommandService service;
        public static IConfiguration config;

        public ApplicationContext(IServiceProvider _provider, DiscordSocketClient _client, CommandService _service, IConfiguration _config)
        {
            provider = _provider;
            client = _client;
            service = _service;
            config = _config;
        }

        public override Task InitializeAsync(CancellationToken cancellationToken) => Task.CompletedTask;
    }
}
