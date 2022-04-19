using System;
using TK_labs;

namespace ConsoleCheck
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var input = Common.ReadFromFile("anna.txt");
            //Console.WriteLine(input);
            foreach(var el in Common.GetFreqDictionary(input))
            {
                Console.WriteLine($"{el.Key} {el.Value}");
            }
            Common.WriteToFile(input, "out.txt");
        }
    }
}
