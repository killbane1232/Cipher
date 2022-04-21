﻿using System;
using TK_labs;

namespace ConsoleCheck
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string fileName = "simple.txt";
            try
            {
                Shannon_Fano shf = new Shannon_Fano(fileName, true);
                Console.WriteLine(shf.EncodedText);
                Console.WriteLine(shf.DecodedText);
                Console.WriteLine(shf.CompressionRatio);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            try
            {
                Huffman h = new Huffman(fileName, true);
                Console.WriteLine(h.EncodedText);
                Console.WriteLine(h.DecodedText);
                Console.WriteLine(h.CompressionRatio);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            try
            {
                Arithmetic a = new Arithmetic(fileName, true);
                Console.WriteLine(a.EncodedText);
                Console.WriteLine(a.DecodedText);
                Console.WriteLine(a.CompressionRatio);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            try
            {
                LZ77 lz77 = new LZ77(fileName, true);
                Console.WriteLine(lz77.EncodedText);
                Console.WriteLine(lz77.DecodedText);
                Console.WriteLine(lz77.CompressionRatio);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            try
            {
                LZ78 lz78 = new LZ78(fileName, true);
                Console.WriteLine(lz78.EncodedText);
                Console.WriteLine(lz78.DecodedText);
                Console.WriteLine(lz78.CompressionRatio);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            try
            {
                BTW btw = new BTW(fileName, true);
                Console.WriteLine(btw.EncodedText);
                Console.WriteLine(btw.DecodedText);
                Console.WriteLine(btw.CompressionRatio);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            RLE rle = new RLE(fileName, true);
            Console.WriteLine(rle.EncodedText);
            Console.WriteLine(rle.DecodedText);
            Console.WriteLine(rle.CompressionRatio);
        }
    }
}