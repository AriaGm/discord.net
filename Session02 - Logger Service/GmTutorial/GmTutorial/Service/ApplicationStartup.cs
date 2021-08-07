using Discord.Addons.Hosting;
using Discord.WebSocket;
using GmTutorial.Context;
using GmTutorial.Utility;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GmTutorial.Enums;
namespace GmTutorial.Service
{
    public class ApplicationStartup
    {
        public static async Task RunAsync()
        {
            ApplicationDrawing.ShowNotify(ConsoleColor.Cyan, "----------------------------- Startup Log -----------------------------\n");

            var hostBuilder = new HostBuilder()
                .ConfigureAppConfiguration(x =>
                {
                    var configuration = new ConfigurationBuilder().SetBasePath(AppContext.BaseDirectory).AddJsonFile("appsettings.json", false, true).Build();
                    x.AddConfiguration(configuration);

                    ApplicationLogger.Log(LogSect.Guild, LogType.Info, ConsoleColor.White, "Configuration file initialized.");
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

                    ApplicationLogger.Log(LogSect.Guild, LogType.Info, ConsoleColor.White, "Socket client created.");
                })
                .UseCommandService((context, config) =>
                {
                    config.LogLevel = Discord.LogSeverity.Verbose;
                    config.CaseSensitiveCommands = false;
                    config.DefaultRunMode = Discord.Commands.RunMode.Async;

                    ApplicationLogger.Log(LogSect.Guild, LogType.Info, ConsoleColor.White, "Command service created.");
                })
                .ConfigureServices((context, services) =>
                {
                    services.AddHostedService<ApplicationContext>();

                    ApplicationLogger.Log(LogSect.Guild, LogType.Info, ConsoleColor.White, "Services are ready now.");
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
