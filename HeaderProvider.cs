using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twenty_Twenty_Twenty_Console
{
    public static class HeaderProvider
    {
        public static string GetTwentyTwentyTwentyHeader()
        {
            return @"
 _____                  _           _____                  _           _____                  _         
|_   _|                | |         |_   _|                | |         |_   _|                | |        
  | |_      _____ _ __ | |_ _   _    | |_      _____ _ __ | |_ _   _    | |_      _____ _ __ | |_ _   _ 
  | \ \ /\ / / _ \ '_ \| __| | | |   | \ \ /\ / / _ \ '_ \| __| | | |   | \ \ /\ / / _ \ '_ \| __| | | |
  | |\ V  V /  __/ | | | |_| |_| |   | |\ V  V /  __/ | | | |_| |_| |   | |\ V  V /  __/ | | | |_| |_| |
  \_/ \_/\_/ \___|_| |_|\__|\__, |   \_/ \_/\_/ \___|_| |_|\__|\__, |   \_/ \_/\_/ \___|_| |_|\__|\__, |
                             __/ |                              __/ |                              __/ |
                            |___/                              |___/                              |___/ 
            ";
        }

        public static string GetMainMenuHeader()
        {
            return @"
___  ___                 
|  \/  |                 
| .  . | ___ _ __  _   _ 
| |\/| |/ _ \ '_ \| | | |
| |  | |  __/ | | | |_| |
\_|  |_/\___|_| |_|\__,_|
                         
______________________________                        
";
        }

        public static string GetSettingsMenuHeader()
        {
            return @"
 _____      _   _   _                 
/  ___|    | | | | (_)                
\ `--.  ___| |_| |_ _ _ __   __ _ ___ 
 `--. \/ _ \ __| __| | '_ \ / _` / __|
/\__/ /  __/ |_| |_| | | | | (_| \__ \
\____/ \___|\__|\__|_|_| |_|\__, |___/
                             __/ |    
                            |___/     
____________________________________________
            ";
        }

        public static void RefreshScreenAndPrintAppHeader()
        {
            Console.Clear();
            Console.WriteLine(GetTwentyTwentyTwentyHeader());
        }

        public static string GetWelcomeMessage()
        {
            return $"Welcome to Twenty-Twenty-Twenty.\n" +
                $"Reminding you to look 20 feet away for 20 seconds, every {ConfigurationManager.MinutesBetweenReminders} minutes.\n" +
                $"In {ConfigurationManager.MinutesBetweenReminders} minutes this window will pop-up and require a key-press. Feel free to minimize this window, but don't close it!";
        }
    }
}
