using System;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
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

            ResourceManager resMan = new ResourceManager("MetalHeadShell.Strings", typeof(Program).Assembly);
            CultureInfo currentCulture = CultureInfo.CurrentCulture;


            Console.WriteLine("Добро пожаловать в MetalHeadShell");
			Console.WriteLine("Напиши help чтобы получить первую помощь или clear чтобы нахуй всё очистить");
            Console.WriteLine("To change language to English type: lang en");
            Console.WriteLine("Чтобы сменить язык на русский, напиши: lang ru");

			while (true)
			{
				Console.Write(">> ");
				string input = Console.ReadLine();

                if (input.StartsWith("lang "))
                {
                    string langCode = input.Split(' ')[1];
                    try
                    {
                        currentCulture = new CultureInfo(langCode);
                        Console.WriteLine(resMan.GetString("LangSet", currentCulture));
                    }
                    catch
                    {
                        Console.WriteLine("Unsupported language code");
                    }
                }
				else
				{
						switch (input.ToLower())
					{
						case "help":
							Console.WriteLine(resMan.GetString("help", currentCulture));
							break;
						case "hello":
							Console.WriteLine(resMan.GetString("hello", currentCulture));
							break;
						case "time":
							Console.WriteLine(DateTime.Now);
							break;
						case "clear":
							Console.Clear();
							break;
						case "notepad":
							Console.WriteLine(resMan.GetString("notepad", currentCulture));
							Process.Start("notepad.exe");
							break;
						case "notepad++":
							Console.WriteLine(resMan.GetString("notepad__", currentCulture));
							Process.Start(@"C:\Program Files\Notepad++\notepad++.exe");
							break;
						case "flstudio":
							Console.WriteLine(resMan.GetString("flstudio", currentCulture));
							Process.Start(@"C:\Program Files\Image-Line\FL Studio 2024\FL64.exe");
							break;
						case "vscode":
							Console.WriteLine(resMan.GetString("vscode", currentCulture));
							Process.Start(@"C:\Users\Maksim Abdulin\AppData\Local\Programs\Microsoft VS Code\Code.exe");
							break;
						case "unity":
							Console.WriteLine(resMan.GetString("unity", currentCulture));
							Process.Start(@"C:\Program Files\Unity Hub\Unity Hub.exe");
							break;
						case "amplitube":
							Console.WriteLine(resMan.GetString("amplitube", currentCulture));
							Process.Start(@"C:\Program Files\IK Multimedia\AmpliTube 5\AmpliTube 5.exe");
							break;
						case "open flprojects":
							Console.WriteLine(resMan.GetString("flprojects", currentCulture));
							Process.Start("explorer.exe", @"D:\Documents\fl_projects");
							break;
						case "exit":
							Console.WriteLine(resMan.GetString("exit", currentCulture));
							return;
						default:
							Console.WriteLine(resMan.GetString("unknowncommand", currentCulture));
							break;
					}
				}	
			}
		}
	}
}
