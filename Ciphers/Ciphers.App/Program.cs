using System;
using System.Text;

namespace Ciphers.App
{
    class Program
    {
        static void Main(string[] args)
        {
            string phrase = "Pomegranate";
            int offset = 7;
            bool compress = true;
            string enciphered = Caesar(phrase, offset, compress);
            string deciphered = Caesar(enciphered, -offset, compress);
            Console.WriteLine("{0}: {1} -> {2}", phrase, enciphered, deciphered);

            string vigenerekey = "hello";
            string vEnciphered = Vigenere(phrase, vigenerekey, true, compress);
            string vDeciphered = Vigenere(vEnciphered, vigenerekey, false, compress);
            Console.WriteLine("{0} [{1}]: {2} -> {3}", phrase, vigenerekey, vEnciphered, vDeciphered);

        }

        static string Vigenere(string phrase, string vigenerekey, bool encrypt, bool compress)
        {
            int offset = 0;
            string ciphered = string.Empty;
            for(int i = 0; i < phrase.Length; ++i)
            {
                char basis = GetBasis(phrase[i]);
                if (basis == 0)
                {
                    if (!compress)
                    {
                        ciphered = ciphered + phrase[i];
                    }
                }
                else
                {
                    int keyoffset = vigenerekey[offset] - GetBasis(vigenerekey[offset]);
                    string e = Caesar(phrase[i].ToString(), keyoffset * (encrypt ? 1 : -1), false);
                    ciphered += e;
                    offset = (offset + 1)%vigenerekey.Length;
                }

            }
            return ciphered;
        }

        static string Caesar(string enciphered, int v, bool compress)
        {
            string s = string.Empty;
            foreach(char c in enciphered)
            {
                char basis = GetBasis(c);
                if (basis == 0)
                {
                    if (!compress)
                    {
                        s = s + c;
                    }
                }
                else
                {
                    char e = (char)((c - basis + v + 26) % 26 + basis);
                    s = s + e;
                }

            }
            return s;
        }

        private static char GetBasis(char c)
        {
            char basis = (char)0;
            if (c >= 'a' && c <= 'z')
                basis = 'a';
            if (c >= 'A' && c <= 'Z')
                basis = 'A';
            return basis;
        }
    }
}
