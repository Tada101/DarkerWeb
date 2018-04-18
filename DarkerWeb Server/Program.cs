using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DarkerWeb_Server
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "DarkerWeb Server";
            if (Directory.Exists("SiteFiles"))
            {
                VerifyFiles();
            }
            else
            {
                Console.WriteLine("Directory 'SiteFiles' not found.", Console.BackgroundColor = ConsoleColor.Red);
                Console.BackgroundColor = ConsoleColor.Black;
            }
            while (true) { }
        }

        static void VerifyFiles()
        {
            if (Directory.GetFiles("SiteFiles").Count() > 0)
            {
                Console.WriteLine("Booting DarkWeb Server.");
                StartServer();
            }
            else
            {
                Console.WriteLine("index.html Was not found.");
                Console.WriteLine("Creating index.html now.");
                var close = File.Create(@"Sitefiles\index.html");
                close.Close();
                File.WriteAllText(@"Sitefiles\index.html", new WebClient().DownloadString("https://pastebin.com/raw/0b62gVAJ"));
                VerifyFiles();
            }
        }

        static void StartServer()
        {

        }

    }
}
