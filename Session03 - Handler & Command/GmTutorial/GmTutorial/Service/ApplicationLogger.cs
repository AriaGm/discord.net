using GmTutorial.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using GmTutorial.Utility;

namespace GmTutorial.Service
{
    public class ApplicationLogger
    {
        public static void Log(LogSect section, LogType type, ConsoleColor color, string content)
        {
            try
            {
                string targetPath = GetPath(section);

                if (String.IsNullOrEmpty(targetPath)) { return; }
                if (!File.Exists(targetPath)) { return; }

                string latestStr = String.Empty;
                using (StreamReader sr = new StreamReader(targetPath))
                {
                    latestStr = sr.ReadToEnd();
                }
                
                using StreamWriter writer = new StreamWriter(targetPath);
                writer.Write(latestStr);

                string newLog = $"[{DateTime.Now.ToString("dd/MM/yyyy - HH:mm:ss")}] [{type.ToString()}] {content}";
                writer.WriteLine(newLog);

                LogConsole(color, newLog);

                string GetPath(LogSect sect)
                {
                    if (sect == LogSect.Guild) { return $"{AppContext.BaseDirectory}log\\guild.txt"; }
                    else if (sect == LogSect.Command) { return $"{AppContext.BaseDirectory}log\\command.txt"; }
                    else { return String.Empty; }
                }
            }
            catch (Exception ex)
            {
                ApplicationDrawing.ShowNotify(ConsoleColor.Red, $"[{DateTime.Now.ToString("dd/MM/yyyy - HH:mm:ss")}] Exception throw | reason : {ex.Message}");
            }
        }

        public static void LogConsole(ConsoleColor color, string content)
        {
            ApplicationDrawing.ShowNotify(color, content);
        }
    }
}
