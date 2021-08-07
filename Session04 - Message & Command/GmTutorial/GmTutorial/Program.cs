using System;
using System.Threading.Tasks;
using GmTutorial.Utility;
using GmTutorial.Service;

namespace GmTutorial
{
    class Program
    {
        static async Task Main(string[] args)
        {
            ApplicationDrawing.SetMetaData();
            ApplicationDrawing.ShowIntro();

            await ApplicationStartup.RunAsync();

            Console.ReadKey();
        }
    }
}
