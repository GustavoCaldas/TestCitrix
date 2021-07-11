using Microsoft.Win32;
using System;
using System.Linq;

namespace CS_Setup
{
    class Program
    {
        static void Main(string[] args)
        {
            string registry_key = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
            string registry64_key = @"SOFTWARE\WOW6432Node\Microsoft\Windows\CurrentVersion\Uninstall";
            RegistryKey key = Registry.LocalMachine.OpenSubKey(registry_key);
            RegistryKey key64 = Registry.LocalMachine.OpenSubKey(registry64_key);

            foreach (string subkey_name in key.GetSubKeyNames())
            {
                RegistryKey subkey = key.OpenSubKey(subkey_name);
                if (subkey.GetValue("DisplayName") != null && subkey.GetValue("DisplayName").ToString().Contains("IDGo"))
                {
                    Console.WriteLine(subkey.GetValue("DisplayName"));
                }
            }
            Console.WriteLine("##############################################################");
            foreach (string subkey64_name in key64.GetSubKeyNames())
            {
                RegistryKey subkey64 = key64.OpenSubKey(subkey64_name);
                if (subkey64.GetValue("DisplayName") != null && subkey64.GetValue("DisplayName").ToString().Contains("Citrix"))
                {
                    Console.WriteLine(subkey64.GetValue("DisplayName"));
                }
            }
        }
    }
}
