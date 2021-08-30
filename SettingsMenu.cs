using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Twenty_Twenty_Twenty_Console
{
    public static class SettingsMenu
    {
        public static void RunSettings()
        {
            Console.Clear();
            Console.WriteLine(HeaderProvider.GetTwentyTwentyTwentyHeader());
            Console.WriteLine(HeaderProvider.GetSettingsMenuHeader());

            Console.WriteLine("1 -> Change minutes between reminders");
            Console.WriteLine("0 -> Return to Main Menu");

            for(; ; )
            {
                ConsoleKey keyPressed = Console.ReadKey().Key;

                switch (keyPressed)
                {
                    case ConsoleKey.D1:
                        RunMinutesDelayChange();
                        break;

                    case ConsoleKey.D0:
                        MainMenu.RunMainMenu();
                        break;

                    default:
                        UserInputUtilities.InvalidKeyResponse();
                        break;
                }
            }
        }

        private static void RunMinutesDelayChange()
        {
            Console.WriteLine($"\nCurrent minutes between reminders {ConfigurationManager.MinutesBetweenReminders}");
            Console.WriteLine("How many minutes would you like to wait between being interrupted? Press 0 to cancel.");
            string userResponseRaw = Console.ReadLine();
            
            if (string.IsNullOrWhiteSpace(userResponseRaw) || !int.TryParse(userResponseRaw, out int userResponse) || userResponse < 1)
            {
                RunSettings();
                return;
            }

            bool isValidInput = false;
            
            while (!isValidInput)
            {
                Console.WriteLine($"You said wait {userResponse} minutes, are you sure? (Y/N)");
                ConsoleKey keyPressed = Console.ReadKey().Key;

                //TODO: include looping functionality so that you don't hard break out of this section after a bad input

                if (keyPressed == ConsoleKey.D0)
                {
                    isValidInput = true;
                    RunSettings();
                }
                else if (keyPressed == ConsoleKey.Y)
                {
                    isValidInput = true;

                    Console.WriteLine("\nYour change has been saved. (0 to return to menu)");

                    ConfigurationManager.MinutesBetweenReminders = userResponse;

                    //TODO: save minutes between reminders to file
                    string json = JsonConvert.SerializeObject(new Configuration() {MinutesToWait = userResponse});
                    System.IO.File.WriteAllText(@$"{Directory.GetCurrentDirectory()}\twentyConfig.json", json);
                }
                else if (keyPressed == ConsoleKey.N)
                {
                    isValidInput = true;
                    RunMinutesDelayChange();
                }
                else
                {
                    Console.WriteLine("\nInput was invalid - please try again.");
                }
            }
        }
    }
}
