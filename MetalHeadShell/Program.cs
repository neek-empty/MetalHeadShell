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
            Console.WriteLine("");
            Console.WriteLine("Welcome to MetalHeadShell");
            Console.WriteLine("Type help to get help or clear to clean up this fucking console");
            Console.WriteLine("");
			Console.WriteLine("To change language to English type: lang en");
			Console.WriteLine("Чтобы сменить язык на русский, напиши: lang ru");

			while (true)
			{
				Console.Write(">> ");
				string command = Console.ReadLine();

				if (command.StartsWith("lang "))
				{
					string langCode = command.Split(' ')[1];
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
				else if(command.StartsWith("open "))
				{
					string[] parts = command.Split(' ', (char)2);
					if (parts.Length == 2)
					{
						string targetApp = parts[1];
						OpenApplicationOrFolder(targetApp);
					}
					else
					{
						Console.WriteLine(resMan.GetString("openusing",currentCulture));
					}
				}
				else
				{
					switch (command.ToLower())
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
						case "exit":
							Console.WriteLine(resMan.GetString("exit", currentCulture));
							return;
						case "motq":
                            Console.WriteLine(resMan.GetString("motivation", currentCulture));
							break;
						default:
							Console.WriteLine(resMan.GetString("unknowncommand", currentCulture));
							break;
					}
				}	

				void OpenApplicationOrFolder(string appName)
				{
					string path = "";

					switch (appName.ToLower())
					{
						case "vscode":
							path = @"C:\Users\Maksim Abdulin\AppData\Local\Programs\Microsoft VS Code\Code.exe";
							break;
						case "notepad":
							path = "notepad.exe";
							break;
						case "notepad++":
							path = @"C:\Program Files\Notepad++\notepad++.exe ";
							break;
						case "flstudio":
							path = @"C:\Program Files\Image-Line\FL Studio 2024\FL64.exe";
                            break;
						case "unity":
							path = @"C:\Program Files\Unity Hub\Unity Hub.exe";
							break;
						case "amplitube":
							path = @"C:\Program Files\IK Multimedia\AmpliTube 5\AmpliTube 5.exe";
							break;
						case "guitarpro":
							path = @"C:\Program Files\Arobas Music\Guitar Pro 8\GuitarPro.exe";
							break;
                        case "steam":
							path = @"D:\Programs\Steam\steam.exe";
							break;
						case "vs":
							path = @"C:\Program Files\Microsoft Visual Studio\2022\Community\Common7\IDE\devenv/exe";
							break;
						case "foobar":
							path = @"C:\Program Files\foobar2000\foobar2000.exe";
							break;
						case "git":
							path = @"C:\Program Files\Git\git-bash.exe";
							break;
                        case "firefox":
							path = @"C:\Program Files\Mozilla Firefox\firefox.exe";
							break;
						case "video":
							path = @"D:\Downloads\Video";
							break;
                        case "downloads":
							path = @"C:\Users\Maksim Abdulin\Downloads";
							break;
						case "downloadsd":
							path = @"D:\Downloads";
							break;
						case "codes":
							path = @"D:\Codes";
							break;
						case "projects":
							path = @"D:\Codes\Projects";
							break;
						case "games":
							path = @"D:\Games";
							break;
                        case "documents":
							path = @"D:\Documents";
							break;
						case "flprojects":
							path = @"D:\Documents\fl_projects";
							break;
                    }

					try
					{
						Process.Start(new ProcessStartInfo(path) { UseShellExecute = true });
						Console.WriteLine(resMan.GetString("openingfile", currentCulture), $"{appName}...");
					}
					catch (Exception ex)
					{
						Console.WriteLine(resMan.GetString("errorwithopening", currentCulture));
					}
				}
			}
		}
	}
}
