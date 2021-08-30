using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twenty_Twenty_Twenty_Console
{
    public static class UserInputUtilities
    {
        public static void ClearInputBuffer()
        {
            while (Console.KeyAvailable)
            {
                Console.ReadKey(true);
            }
        }

        public static void InvalidKeyResponse()
        {
            Console.WriteLine("\nSorry that key was invalid, try again.");
        }
    }
}
