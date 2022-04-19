using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TK_labs
{
    public class Common
    {
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

        public static Dictionary<char, float> GetFreqDictionary(string text)
        {
            Dictionary<char, float> dict = new Dictionary<char, float>();
            float value = (float) 1 / text.Length;
            foreach (char c in text)
            {
                if (dict.ContainsKey(c))
                    dict[c] += value;
                else
                    dict.Add(c, value);
            }
            dict.OrderBy(x => x.Value);
            return dict;
        }
    }
}
