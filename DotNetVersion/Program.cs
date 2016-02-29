/*
The MIT License(MIT)

Copyright(c) 2016 Morris Iriga Muthui

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/
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
