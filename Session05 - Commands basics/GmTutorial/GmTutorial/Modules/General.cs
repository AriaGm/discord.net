using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GmTutorial.Modules
{
    public class General : ModuleBase
    {
        [Command("test")]
        public async Task Test()
        {
            if (Context.Channel.Id != 852177370341179392) return;
            await Context.Channel.SendMessageAsync("Welcome to our server!");
        }

        [Command("hello")]
        public async Task Hello(string firstName, string lastName)
        {
            await Context.Channel.SendMessageAsync($"Hello {firstName} {lastName}");
        }

        [Command("msg")]
        public async Task Msg(SocketTextChannel channel, SocketGuildUser user)
        {
            await channel.SendMessageAsync($"Welcome {MentionUtils.MentionUser(user.Id)}");
        }

        ///////////////////////////    Command Attrs //////////////////////////
        
        [Command("attr")]
        [RequireBotPermission(ChannelPermission.SendMessages)]
        [RequireNsfw]
        [RequireOwner]
        [RequireUserPermission(ChannelPermission.SendMessages)]
        public async Task Attr()
        {
            await Task.Delay(0);
        }
    }
}