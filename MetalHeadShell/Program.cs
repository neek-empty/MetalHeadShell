using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetalHeadShell
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "MetalHeadShell";
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("Добро пожаловать в MetalHeadShell");
            Console.WriteLine("Напиши help чтобы получить первую помощь или clear чтобы нахуй всё очистить");

            while (true)
            {
                Console.Write(">> ");

                string input = Console.ReadLine();

                switch (input.ToLower())
                {
                    case "hello":
                        Console.WriteLine("Здарова, братюня!");
                        break;
                    case "time":
                        Console.WriteLine(DateTime.Now);
                        break;
                    case "clear":
                        Console.Clear();
                        break;
                    case "notepad":
                        Console.WriteLine("Аткрываю блокнот...");
                        Process.Start("notepad.exe");
                        break;
                    case "flstudio":
                        Console.WriteLine("Делай музло, брат");
                        Console.WriteLine("Аткрываю FL Studio...");
                        Process.Start(@"C:\Program Files\Image-Line\FL Studio 2024\FL64.exe");
                        break;
                    case "vscode":
                        Console.WriteLine("Программируй, братан");
                        Console.WriteLine("Аткрываю Visual Studio Code...");
                        Process.Start(@"C:\Users\Maksim Abdulin\AppData\Local\Programs\Microsoft VS Code\Code.exe");
                        break;
                    case "unity":
                        Console.WriteLine("Юнити, так юнити, брат");
                        Console.WriteLine("Аткрываю Unity Hub...");
                        Process.Start(@"C:\Program Files\Unity Hub\Unity Hub.exe");
                        break;
                    case "amplitube":
                        Console.WriteLine("Играй, брат");
                        Console.WriteLine("Аткрываю Amplitube...");
                        Process.Start(@"C:\Program Files\IK Multimedia\AmpliTube 5\AmpliTube 5.exe");
                        break;
                    case "open flprojects":
                        Console.WriteLine("Аткрываю папку с fl проэктами...");
                        Process.Start("explorer.exe", @"D:\Documents\fl_projects");
                        break;
                    case "exit":
                        Console.WriteLine("Пока, братишка.");
                        return;
                    default:
                        Console.WriteLine("Неизвестная команда.");
                        break;
                }
            }

        }
    }
}
