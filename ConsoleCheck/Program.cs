using System;
using TK_labs;

namespace ConsoleCheck
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Shannon_Fano shf = new Shannon_Fano("anna.txt", true);
            Console.WriteLine(shf.EncodedText);
            Console.WriteLine(shf.DecodedText);
            Console.WriteLine(shf.CompressionRatio);
        }
    }
}
