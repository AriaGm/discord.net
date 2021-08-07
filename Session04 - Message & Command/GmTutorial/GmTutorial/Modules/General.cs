using Discord.Commands;
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
            await Context.Channel.SendMessageAsync("Welcome to our server!");
        }
    }
}
