using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GmTutorial.Utility
{
    public class ApplicationDrawing
    {
        public static void SetMetaData()
        {
            Console.Title = "Gm Tutorial Discord Bot | Youtube Playlist";
            Console.OutputEncoding = Encoding.UTF8;
        }

        public static void ShowIntro()
        {
            string textArt = "\n  ██████╗ ███╗   ███╗ ████████╗██╗   ██╗████████╗ █████╗ ██████╗ ██╗ █████╗ ██╗     \n" +
                               " ██╔════╝ ████╗ ████║ ╚══██╔══╝██║   ██║╚══██╔══╝██╔══██╗██╔══██╗██║██╔══██╗██║     \n" +
                               " ██║  ███╗██╔████╔██║    ██║   ██║   ██║   ██║   ██║  ██║██████╔╝██║███████║██║     \n" +
                               " ██║   ██║██║╚██╔╝██║    ██║   ██║   ██║   ██║   ██║  ██║██╔══██╗██║██╔══██║██║     \n" +
                               " ╚██████╔╝██║ ╚═╝ ██║    ██║   ╚██████╔╝   ██║   ╚█████╔╝██║  ██║██║██║  ██║███████╗\n" +
                               "  ╚═════╝ ╚═╝     ╚═╝    ╚═╝    ╚═════╝    ╚═╝    ╚════╝ ╚═╝  ╚═╝╚═╝╚═╝  ╚═╝╚══════╝\n\n" +
                               "                      ╭━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━╮                        \n" +
                               "                      ┃                                    ┃                        \n" +
                               "                      ┃    developer : Aria Golmohamadi    ┃                        \n" +
                               "                      ┃        Server : Discord.Net        ┃                        \n" +
                               "                      ┃        Interface : Tutorial        ┃                        \n" +
                               "                      ┃                                    ┃                        \n" +
                               "                      ╰━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━╯                        \n\n\n\n";

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(textArt);
            Console.ResetColor();
        }

        public static void ShowNotify(ConsoleColor color, string content)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(content);
            Console.ResetColor();
        }
    }
}
