using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace TK_labs
{
    public abstract class Algorithm
    {
        public Dictionary<char, string> Encoding { get; set; }
        public Dictionary<char, double> Frequency { get; set; }
        public string InputText { get; set; }
        public string EncodedText { get; set; }
        public string DecodedText { get; set; }
        public string InputFile { get; set; }

        public Algorithm(string text)
        {
            InputText = text;
            Frequency = GetFreqDictionary(InputText);
        }

        public Algorithm(string fileName, bool noMatter)
        {
            InputFile = fileName;
            InputText = ReadFromFile(InputFile);
            Frequency = GetFreqDictionary(InputText);
        }

        public static string ReadFromFile(string fileName)
        {
            using (var sr = new StreamReader(fileName))
            {
                return sr.ReadToEnd();
            }
        }

        public static void WriteToFile(string outputText, string fileName)
        {
            using (var sw = new StreamWriter(fileName))
            {
                sw.WriteLine(outputText);
            }
        }

        public static Dictionary<char, double> GetFreqDictionary(string text)
        {
            Dictionary<char, double> dict = new Dictionary<char, double>();
            double value = (double)1 / text.Length;
            foreach (char c in text)
            {
                if (dict.ContainsKey(c))
                    dict[c] += value;
                else
                    dict.Add(c, value);
            }
            dict = new Dictionary<char, double>(dict.OrderByDescending(x => x.Value));
            return dict;
        }

    }
}
