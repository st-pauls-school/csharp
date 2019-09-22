using System;
using System.Collections.Generic;
using System.IO;

namespace october
{
    class HashedValues
    {
        public static int GenerateHash(string value, int mod = 128)
        {
            /* Set HashTotal to 0 
             * for each character in the string value
             *   get the ASCII/UTF16 code for the character
             *   multiply the ASCII value by the position of the character in the string (one-indexed, so the first character has position number 1)
             *   add the result to the hash total 
             * return the hash total mod 128 
             */
            int hash = 0;
            for(int i = 0; i < value.Length; i++)
            {
                hash += value[i] * (i + 1);
            }

            return hash % mod;
        }

        public static List<string> ReadFromFile()
        {
            string fileName = "hashedvalues.txt";
            bool b = File.Exists(fileName);
            if (!b)
                return new List<string>();
            return new List<string>(File.ReadAllLines(fileName)); 
        }

        public static void WriteToFile(string fileName, List<string> strings)
        {
            File.WriteAllLines(fileName, strings);
        }

        public static int HashedPosition(string v, List<string> hashedstrings)
        {
            throw new NotImplementedException();
        }
    }
}
