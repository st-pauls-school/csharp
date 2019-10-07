using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileIOConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            string fn = "textfile.txt";

            bool present = File.Exists(fn);

            if (present)
            {
                string contents;
                using (StreamReader sr = new StreamReader(fn))
                {
                    while((contents = sr.ReadLine()) != null)                   
                    {
                        Console.WriteLine(contents);

                    }
                }
            }
            Console.ReadKey();

            using (StreamWriter sw = new StreamWriter("outputfile.txt", true))
            {
                sw.WriteLine("first line - another new");
                sw.WriteLine("second line");
                sw.WriteLine("third line");
            }

        }
    }
}
