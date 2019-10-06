using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Twenty_Twenty_Twenty_Console
{
    class Program
    {
        
        public static Int32 MinutesBetweenReminders = 20;

        static void Main(string[] args)
        {
            Maximize();

            GetHeader();
            
            RunMenu();
        }

        private static void GetHeader()
        {
            Console.WriteLine(@"
 _____                  _           _____                  _           _____                  _         
|_   _|                | |         |_   _|                | |         |_   _|                | |        
  | |_      _____ _ __ | |_ _   _    | |_      _____ _ __ | |_ _   _    | |_      _____ _ __ | |_ _   _ 
  | \ \ /\ / / _ \ '_ \| __| | | |   | \ \ /\ / / _ \ '_ \| __| | | |   | \ \ /\ / / _ \ '_ \| __| | | |
  | |\ V  V /  __/ | | | |_| |_| |   | |\ V  V /  __/ | | | |_| |_| |   | |\ V  V /  __/ | | | |_| |_| |
  \_/ \_/\_/ \___|_| |_|\__|\__, |   \_/ \_/\_/ \___|_| |_|\__|\__, |   \_/ \_/\_/ \___|_| |_|\__|\__, |
                             __/ |                              __/ |                              __/ |
                            |___/                              |___/                              |___/ 
            ");
        }

        private static void RunMenu()
        {
            Console.Clear();
            GetHeader();
            Console.WriteLine("Welcome to Twenty-Twenty-Twenty.");
            Console.WriteLine($"Reminding you to look 20 feet away for 20 seconds, every {MinutesBetweenReminders} minutes.");
            Console.WriteLine("In 20 minutes this window will pop-up and require a key-press. Feel free to minimize this window, but don't close it!");

            Console.WriteLine(
                @"
___  ___                 
|  \/  |                 
| .  . | ___ _ __  _   _ 
| |\/| |/ _ \ '_ \| | | |
| |  | |  __/ | | | |_| |
\_|  |_/\___|_| |_|\__,_|
                         
______________________________                        
");

            Console.WriteLine("Enter/Space -> Start your reminders & Minimize Twenty-Twenty-Twenty");
            //Console.WriteLine("S -> Settings");
            Console.WriteLine("Escape -> Exit");

            Boolean validKey = false;

            while(!validKey)
            {
                ConsoleKey menuKeyPressed = Console.ReadKey().Key;

                if (menuKeyPressed == ConsoleKey.Enter || menuKeyPressed == ConsoleKey.Spacebar)
                {
                    validKey = true;
                    Console.Clear();
                    GetHeader();
                    Console.WriteLine("Got it (We're counting). Happy Computing.");
                    RunReminders();
                }
                //else if (menuKeyPressed == ConsoleKey.S)
                //{
                //    RunSettings();
                //}
                else if (menuKeyPressed == ConsoleKey.Escape)
                {
                    validKey = true;
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("\nSorry, that key was invalid, try again.");
                }
            }
           

        }

        public static void RunReminders()
        {
            Minimize();


            Thread.Sleep(MinutesBetweenReminders * 60000);
            Console.Clear();
            GetHeader();
            Console.WriteLine($"It's been {MinutesBetweenReminders} minutes! Time to look away.");
            Console.WriteLine("Press Enter or the Spacebar to get back to work! Or Press Escape to exit.");

            Maximize();

            Boolean validKey = false;
            ConsoleKey keyPressed = Console.ReadKey().Key;
            
            while(!validKey)
            {
                if (keyPressed == ConsoleKey.Escape)
                {
                    Environment.Exit(0);
                }
                else if (keyPressed == ConsoleKey.Enter || keyPressed == ConsoleKey.Spacebar)
                {
                    Console.Clear();
                    GetHeader();
                    Console.WriteLine("Got it (We're counting again). Happy Computing.");
                    RunReminders();
                }
                else
                {
                    Console.WriteLine("\nSorry, that key was invalid, try again.");
                }
            }
        }

        public static void RunSettings()
        {
            Console.Clear();
            GetHeader();
            Console.WriteLine(@"
 _____      _   _   _                 
/  ___|    | | | | (_)                
\ `--.  ___| |_| |_ _ _ __   __ _ ___ 
 `--. \/ _ \ __| __| | '_ \ / _` / __|
/\__/ /  __/ |_| |_| | | | | (_| \__ \
\____/ \___|\__|\__|_|_| |_|\__, |___/
                             __/ |    
                            |___/     
____________________________________________
            ");
            Console.WriteLine($"Current minutes between reminders {MinutesBetweenReminders}");
            Console.WriteLine("1 -> Change minutes between reminders");
            Console.WriteLine("2 -> Save Changes");
            Console.WriteLine("0 -> Return to Main Menu");

            ConsoleKey keyPressed = Console.ReadKey().Key;

            switch (keyPressed)
            {
                case ConsoleKey.D1:

                    break;
                case ConsoleKey.D2:

                    break;
                case ConsoleKey.D0:
                    RunMenu();
                    break;
            }
        }

        [DllImport("user32.dll")]
        public static extern bool ShowWindow(System.IntPtr hWnd, int cmdShow);

        private static void Maximize()
        {
            Process p = Process.GetCurrentProcess();
            ShowWindow(p.MainWindowHandle, 3); //SW_MAXIMIZE = 3
        }

        private static void Minimize()
        {
            Process p = Process.GetCurrentProcess();
            ShowWindow(p.MainWindowHandle, 2); //SW_MINIMIZE = 2
        }
    }
}
