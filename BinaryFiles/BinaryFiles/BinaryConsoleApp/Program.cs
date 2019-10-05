using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[] logo = File.ReadAllBytes(Properties.Settings.Default.filename);
            byte first = logo[0];
            byte second = logo[1];

            int res1 = first & (byte)'B';
            int res2 = second & (byte)'M';


            Console.ReadKey();
        }
    }
}
