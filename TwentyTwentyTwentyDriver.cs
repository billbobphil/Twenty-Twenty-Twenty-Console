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
    static class TwentyTwentyTwentyDriver
    {
        static void Main(string[] args)
        {
            PromptWindowUtilities.Maximize();
            ConfigurationManager.InitializeConfiguration();
            MainMenu.RunMainMenu();
        }
    }
}
