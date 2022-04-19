using System;
using TK_labs;

namespace ConsoleCheck
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var input = Common.ReadFromFile("anna.txt");
            foreach(var item in Common.GetFreqDictionary(input))
                Console.WriteLine(item);
            Shannon_Fano shf = new Shannon_Fano();
            foreach (var el in shf.GetEncoding("anna.txt"))
            {
                Console.WriteLine($"{el.Key} {el.Value}");
            }
        }
    }
}
