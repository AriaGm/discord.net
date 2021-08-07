using Discord.Addons.Hosting;
using Discord.WebSocket;
using GmTutorial.Context;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GmTutorial.Service
{
    public class ApplicationStartup
    {
        public static async Task RunAsync()
        {
            var hostBuilder = new HostBuilder()
                .ConfigureAppConfiguration(x =>
                {
                    var configuration = new ConfigurationBuilder().SetBasePath(AppContext.BaseDirectory).AddJsonFile("appsettings.json", false, true).Build();
                    x.AddConfiguration(configuration);
                })
                .ConfigureDiscordHost<DiscordSocketClient>((context, config) =>
                {
                    config.SocketConfig = new DiscordSocketConfig()
                    {
                        LogLevel = Discord.LogSeverity.Verbose,
                        MessageCacheSize = 200,
                        AlwaysDownloadUsers = true
                    };

                    config.Token = context.Configuration["token"];
                })
                .UseCommandService((context, config) =>
                {
                    config.LogLevel = Discord.LogSeverity.Verbose;
                    config.CaseSensitiveCommands = false;
                    config.DefaultRunMode = Discord.Commands.RunMode.Async;
                })
                .ConfigureServices((context, services) =>
                {
                    services.AddHostedService<ApplicationContext>();
                })
                .UseConsoleLifetime();

            var host = hostBuilder.Build();

            using (host)
            {
                await host.RunAsync();
            }
        }
    }
}
