using System;
using System.IO;

namespace BitmapFiles.App
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[] logo = File.ReadAllBytes("sps.bmp");
            byte first = logo[0];
            byte second = logo[1];

            char b = 'B';
            char m = 'M';

            int res1 = first ^ (byte)b;
            int res2 = second ^ (byte)m;

            byte[] sizeinbytes = new byte[4];
            for(int i = 0 ; i < 4 ; ++i)
            {
                sizeinbytes[i] = logo[2 + i];
            }
            int logosize = 0;
            logosize += sizeinbytes[3] << 24;
            logosize += sizeinbytes[2] << 16;
            logosize += sizeinbytes[1] << 8;
            logosize += sizeinbytes[0] << 0;

        }
    }
}
