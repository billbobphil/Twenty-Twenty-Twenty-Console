using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twenty_Twenty_Twenty_Console
{
    public static class MainMenu
    {
        public static void RunMainMenu()
        {
            HeaderProvider.RefreshScreenAndPrintAppHeader();

            Console.WriteLine(HeaderProvider.GetWelcomeMessage());

            Console.WriteLine(HeaderProvider.GetMainMenuHeader());

            Console.WriteLine(GetMainMenuOptions());

            for(; ; )
            {
                ConsoleKey menuKeyPressed = Console.ReadKey().Key;

                switch (menuKeyPressed)
                {
                    case ConsoleKey.Enter:
                    case ConsoleKey.Spacebar:
                        HeaderProvider.RefreshScreenAndPrintAppHeader();
                        Reminders.GetWaitingMessage();
                        Reminders.RunReminders();
                        break;

                    case ConsoleKey.S:
                        SettingsMenu.RunSettings();
                        break;

                    case ConsoleKey.End:
                        Environment.Exit(0);
                        break;

                    default:
                        UserInputUtilities.InvalidKeyResponse();
                        break;   
                }
            }
        }

        private static string GetMainMenuOptions()
        {
            return "Enter/Space -> Start your reminders & Minimize Twenty-Twenty-Twenty\n" +
                "S -> Settings\n" +
                "END -> Exit";
        }
    }
}
