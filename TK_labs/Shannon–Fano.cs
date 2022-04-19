using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TK_labs
{
    public class Shannon_Fano : ICoding
    {
        public string Encode(string text)
        {
            return null;
        }

        public string Decode(string text)
        {
            return null;
        }

        public Dictionary<char, string> GetEncoding(string fileName)
        {
            Dictionary<char, string> result = new Dictionary<char, string>();
            var input = Common.ReadFromFile(fileName);
            var dict = Common.GetFreqDictionary(input);
            foreach(var el in dict)
            {
                result.Add(el.Key, "");
            }
            
            return null;
        }

        public int GetCompressionRatio(Dictionary<char, string> encoding, Dictionary<char, float> freqDict)
        {
            throw new NotImplementedException();
        }

        private char GetMedium(Dictionary<char, float> dict, int step)
        {
            double value = 0;
            foreach (var el in dict)
            {
                value += el.Value;
                if (value > (float) 1 / Math.Pow(2, step))
                    return el.Key;
            }
            return 0.ToString()[0];
        }

        private void Split(ref Dictionary<char, string> encoding, int branch, Dictionary<char, float> dict, int step)
        {
            if (dict.Count == 1)
                return;
            foreach(var el in dict)
                encoding[el.Key] += branch.ToString();
            var center = GetMedium(dict, step);
            var left = new Dictionary<char, float>(dict.TakeWhile(el => el.Key != center));
        }
    }
}
