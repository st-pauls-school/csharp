using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigConsole
{
    class Program
    {
        static void Main(string[] args)
        {

            int x = Properties.Settings.Default.MySettingValue;
            string val = Properties.Settings.Default.ChangableSetting;
            Properties.Settings.Default.ChangableSetting = "new value";
            Properties.Settings.Default.MySettingValue = 76;

            ConfigurationManager.AppSettings[key];
        }
    }
}
