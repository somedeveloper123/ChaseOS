using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;
using Cosmos.System.FileSystem.VFS;
using Cosmos.System.FileSystem;
using System.Drawing;
using Cosmos.System.Graphics;
using Cosmos.System.Network;
using fixbuild.ChaseGraphicsAPI;

namespace fixbuild
{

    public class Kernel : Sys.Kernel
    {
        private static Graphics gui;
        public string cddefault;
        CosmosVFS FileManager = new Sys.FileSystem.CosmosVFS();
        protected override void BeforeRun()
        {
            Console.WriteLine("Welcome to ChaseOS, the calculator that can store files!");
            Console.WriteLine("preparing file system");
            Sys.FileSystem.VFS.VFSManager.RegisterVFS(FileManager);

            Console.WriteLine("filesys created");

            Console.WriteLine("loading UI");


            cddefault = @"0:\";

            
            
        }

        protected override void Run()
        {

            try
            {






                if (Kernel.gui != null)
                {
                    Kernel.gui.MouseHandler();
                    return;
                }
                Console.Write("Time: "+ DateTime.Now +" Path: "+ cddefault + " ChaseOS>");
                string cmd = Console.ReadLine();
                if (cddefault.EndsWith(@"\"))
                {

                }
                else
                {
                    cddefault = cddefault + @"\";
                }
                if (cmd == "graphics")
                {
                    Console.WriteLine("ALERT! Graphics mode is in beta, and may not work. Continue? Y/N");
                    string confirm = Console.ReadLine();
                    if (confirm == "Y")
                    {
                        Kernel.gui = new Graphics();

                    }
                }
                if (cmd == "clear")
                {
                    Console.Clear();
                }
                if (cmd == "shutdown")
                {
                    Sys.Power.Shutdown();
                }
                if (cmd == "restart")
                {
                    Sys.Power.Reboot();
                }
                if (cmd == "help")
                {
                    Console.WriteLine("cmds: version, calc, readfile, ls, createfile, editfile, deletefile, help, createdirectory, removedirectory, cd, cdfullpath, time, settings, pwd");
                }
                if (cmd == "pwd")
                {
                    Console.WriteLine(cddefault);
                }
                if (cmd == "version")
                {
                    Console.WriteLine("Version: 11.0.1, ChaseOS is an Operating system which is a small project, there is no gui design.");
                    Console.WriteLine("Credits to Reese or chickendad#3076 for being a developer. Owner: Chase or dff#1307");
                }
                if (cmd == "createdirectory")
                {
                    Console.WriteLine("directory name?");
                    string prefolder = Console.ReadLine();
                    FileManager.CreateDirectory(@cddefault + prefolder);
                    Console.WriteLine("Directory created.");
                }
                if (cmd == "cd")
                {
                    Console.WriteLine("Path to get to?");
                    string precd = Console.ReadLine();
                    cddefault = @cddefault + precd;
                    Console.WriteLine("Now in path directory");
                }
                if (cmd == "cdfullpath")
                {
                    Console.WriteLine("full path?");
                    string predest = Console.ReadLine();
                    cddefault = @predest;
                }
                if (cmd == "time")
                {
                    Console.WriteLine(DateTime.Now.ToString());

                }
                if (cmd == "settings")
                {
                    Console.WriteLine("What color for text color?");
                    string color = Console.ReadLine();
                    if (color.ToLower() == "blue")
                    {
 
                        Console.ForegroundColor = ConsoleColor.Blue;
                    }


                    if (color.ToLower() == "red")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    if (color.ToLower() == "yellow")
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                    if (color.ToLower() == "green")
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    if (color.ToLower() == "black")
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    if (color.ToLower() == "white")
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
                if (cmd == "calc")
                {
                    // Declare variables and then initialize to zero.
                    int num1 = 0; int num2 = 0;

                    // Display title as the C# console calculator app.
                    Console.WriteLine("Console Calculator in C#\r");
                    Console.WriteLine("------------------------\n");

                    // Ask the user to type the first number.
                    Console.WriteLine("Type a number, and then press Enter");


                    // Ask the user to choose an option.
                    Console.WriteLine("Choose an option from the following list:");
                    Console.WriteLine("\ta - Add");
                    Console.WriteLine("\ts - Subtract");
                    Console.WriteLine("\tm - Multiply");
                    Console.WriteLine("\td - Divide");
                    Console.WriteLine("\tsq - Square");
                    Console.Write("Which option do you want to do? ");

                    // Use a switch statement to do the math.
                    switch (Console.ReadLine())
                    {
                        case "a":
                            Console.WriteLine("Enter a number");
                            num1 = Convert.ToInt32(Console.ReadLine());
                            // Ask the user to type the second number.
                            Console.WriteLine("Type another number, and then press Enter");
                            num2 = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine($"Your result: {num1} + {num2} = " + (num1 + num2));
                            break;
                        case "s":
                            Console.WriteLine("Enter a number");
                            num1 = Convert.ToInt32(Console.ReadLine());

                            // Ask the user to type the second number.
                            Console.WriteLine("Type another number, and then press Enter");
                            num2 = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine($"Your result: {num1} - {num2} = " + (num1 - num2));
                            break;
                        case "m":
                            Console.WriteLine("Enter a number");
                            num1 = Convert.ToInt32(Console.ReadLine());

                            // Ask the user to type the second number.
                            Console.WriteLine("Type another number, and then press Enter");
                            num2 = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine($"Your result: {num1} * {num2} = " + (num1 * num2));
                            break;
                        case "d":
                            Console.WriteLine("Enter a number");
                            num1 = Convert.ToInt32(Console.ReadLine());

                            // Ask the user to type the second number.
                            Console.WriteLine("Type another number, and then press Enter");
                            num2 = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine($"Your result: {num1} / {num2} = " + (num1 / num2));
                            break;
                        case "sq":
                            Console.WriteLine("What number to square?");
                            num1 = Convert.ToInt32(Console.ReadLine());

                            // Ask the user to type the second number.
                            Console.WriteLine($"Your result: " + num1 + " * " + num1 + " = " + (num1 * num1));
                            break;
                    }
                    // Wait for the user to respond before closing.
                    Console.Write("Press any key to close the Calculator console app...");
                    Console.ReadKey();
                }
                if (cmd == "removedirectory")
                {
                    Console.WriteLine("Directory?");
                    string predir = Console.ReadLine();

                    FileManager.DeleteDirectory(FileManager.GetDirectory(@cddefault + predir));
                }
                if (cmd == "createfile")
                {
                    Console.WriteLine("filename");
                    string filename = Console.ReadLine();
                    Sys.FileSystem.VFS.VFSManager.CreateFile(@cddefault + filename);

                }
                if (cmd == "editfile")
                {
                    Console.WriteLine("filename");
                    string filename1 = Console.ReadLine();
                    var file = Sys.FileSystem.VFS.VFSManager.GetFile(@cddefault + filename1);
                    var filestream = file.GetFileStream();
                    Console.WriteLine("contents");
                    string contents = Console.ReadLine();
                    byte[] data = Encoding.ASCII.GetBytes(contents);
                    filestream.Write(data, 0, (int)contents.Length);
                    Console.WriteLine("file edited sucessfully");
                }
                if (cmd == "deletefile")
                {
                    Console.WriteLine("Enter the name of the file");
                    string prefilename2 = Console.ReadLine();
                    var preprefilename2 = Sys.FileSystem.VFS.VFSManager.GetFile(@cddefault + prefilename2);

                    FileManager.DeleteFile(preprefilename2);
                }
                if (cmd == "box")
                {
                    fixbuild.ChaseGraphicsAPI.Graphics.THE = true;
                }
                if (cmd == "ls")
                {
                    var directory_list = Sys.FileSystem.VFS.VFSManager.GetDirectoryListing(@cddefault);

                    foreach (var directoryEntry in directory_list)
                    {
                        Console.WriteLine(directoryEntry.mName);
                    }
                }
                if (cmd == "readfile")
                {
                    Console.WriteLine("filename");
                    var prefile = Console.ReadLine();
                    var file = Sys.FileSystem.VFS.VFSManager.GetFile(@cddefault + prefile).GetFileStream();
                    byte[] data = new byte[file.Length];
                    file.Read(data, 0, (int)file.Length);
                    Console.WriteLine(Encoding.Default.GetString(data));
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("oh no your code just got downed");
                Console.WriteLine("how to revive: fix " + e.ToString());

            }

        }
    } 
}
