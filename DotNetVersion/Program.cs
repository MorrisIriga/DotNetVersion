using System;
using Microsoft.Win32;

namespace DotNetVersion
{
    class Program
    {

        /* Main */
        static void Main(string[] args)
        {
            RegistryKey myKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\NET Framework Setup\NDP");

            if (myKey == null)
            {
                // If key is null, then there was an error retrieving the key
                Console.WriteLine("Error retrieving registry key!\n");
                return;
            }
            else
            {
                Boolean subkeyV4Exists = false;
                foreach (string subkey in myKey.GetSubKeyNames())
                {
                    if (subkey == "v4")
                    {
                        subkeyV4Exists = true;
                        break;
                    }
                }

                if (!subkeyV4Exists)
                {
                    myKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\NET Framework Setup\NDP\Full");
                    Console.WriteLine(".NET Framework Version: " + myKey.GetValue("Version") + "\n");
                }
                else
                {
                    myKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full");
                    Console.WriteLine(".NET Framework Version: " + myKey.GetValue("Release") + "\n");
                }
            }

        }

    }
}
