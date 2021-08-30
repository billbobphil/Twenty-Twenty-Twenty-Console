using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Twenty_Twenty_Twenty_Console
{
    public static class Reminders
    {
        public static void RunReminders()
        {
            for (; ; )
            {
                PromptWindowUtilities.Minimize();
                
                #if DEBUG
                    Thread.Sleep(ConfigurationManager.MinutesBetweenReminders * 1000);
                #else
                    Thread.Sleep(ConfigurationManager.MinutesBetweenReminders * 60000);
                #endif

                UserInputUtilities.ClearInputBuffer();

                HeaderProvider.RefreshScreenAndPrintAppHeader();

                Console.WriteLine(GetLookAwayMessage());

                PromptWindowUtilities.Maximize();

                ConsoleKey keyPressed = Console.ReadKey().Key;

                if (keyPressed == ConsoleKey.End)
                {
                    Environment.Exit(0);
                }
                else if (keyPressed == ConsoleKey.Home)
                {
                    MainMenu.RunMainMenu();
                }

                HeaderProvider.RefreshScreenAndPrintAppHeader();
                Console.WriteLine(GetWaitingMessage());
            }
        }

        private static string GetLookAwayMessage()
        {
            return $"It's been {ConfigurationManager.MinutesBetweenReminders} minutes! Time to look away.\n" +
                   "Press END to exit.\n" +
                   "Press HOME to head back to the Main Menu\n" +
                   "Press any other key to get back to work!\n";
        }

        public static string GetWaitingMessage()
        {
            return $"Got it (We're counting again). Happy Computing.";
        }

    }
}
