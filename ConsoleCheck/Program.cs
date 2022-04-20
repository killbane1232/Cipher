using System;
using TK_labs;

namespace ConsoleCheck
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Shannon_Fano shf = new Shannon_Fano("aabcb.txt", true);
            Console.WriteLine(shf.EncodedText);
            Console.WriteLine(shf.DecodedText);
            Console.WriteLine(shf.CompressionRatio);
            Huffman h = new Huffman("aabcb.txt", true);
            Console.WriteLine(h.EncodedText);
            Console.WriteLine(h.DecodedText);
            Console.WriteLine(h.CompressionRatio);
            Arithmetic a = new Arithmetic("aabcb.txt", true);
            Console.WriteLine(a.EncodedText);
            Console.WriteLine(a.DecodedText);
            Console.WriteLine(a.CompressionRatio);
        }
    }
}
