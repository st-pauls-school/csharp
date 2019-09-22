using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace october
{
    class HashedValues
    {
        public static int GenerateHash(string value)
        {
            /* Set HashTotal to 0 
             * for each character in the string value
             *   get the ASCII/UTF16 code for the character
             *   multiply the ASCII value by the position of the character in the string (one-indexed, so the first character has position number 1)
             *   add the result to the hash total 
             * return the hash total mod 128 
             */

            return;
        }

        public static List<string> ReadFromFile()
        {
            string fileName = "hashedvalues.txt";
            bool b = File.Exists(fileName);
            if (!b)
                return new List<string>();
            return new List<string>(File.ReadAllLines(fileName));
        }

        public static int HashedPosition(string soughtValue, List<string> hashedstrings)
        {
            /* The hash calculated by the GenerateHash function can be used to find the corresponding location in the List of hashedstrings 
             * If the soughtValueis not found at the location given by the hash *and* the location is not empty: 
             *   compare the soughtValue with the next location 
             *   until the soughtValue is found or an empty location is found 
             * if an empty location is found then the function should return -1 
             * if the soughtValue is found, return the index of the location 
             */
            throw new NotImplementedException();
        }

    }
}
