using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TK_labs
{
    public class Shannon_Fano : ICoding
    {
        public Shannon_Fano() { }

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
            Split(ref result, "", dict, 1);
            return result;
        }

        public int GetCompressionRatio(Dictionary<char, string> encoding, Dictionary<char, float> freqDict)
        {
            throw new NotImplementedException();
        }

        private char GetMedium(Dictionary<char, float> dict, int step)
        {
            var sum = dict.Sum(x => x.Value);
            double value = 0, half = (float)sum / 2;
            if (dict.First().Value > half)
                return dict.Take(2).Last().Key;
            foreach (var el in dict)
            {
                value += el.Value;
                if (value > half)
                {
                    return el.Key;
                }
            }
            return 0.ToString()[0];
        }

        private void Split(ref Dictionary<char, string> encoding, string branch, Dictionary<char, float> dict, int step)
        {
            if (dict.Count == 1)
            {
                foreach(var el in dict)
                    encoding[el.Key] += branch;
                return;
            }
            if (dict.Count != encoding.Count)
                foreach(var el in dict)
                    encoding[el.Key] += branch;
            Dictionary<char, float> left, right;
            if (dict.Count != 2)
            {
                var center = GetMedium(dict, step);
                left = new Dictionary<char, float>(dict.TakeWhile(el => el.Key != center));
                right = new Dictionary<char, float>(dict.TakeLast(dict.Count - left.Count));
            }
            else
            {
                left = new Dictionary<char, float>(dict.Take(1));
                right = new Dictionary<char, float>(dict.TakeLast(1));
            }
            Split(ref encoding, "0", left, step + 1);
            Split(ref encoding, "1", right, step + 1);
        }
    }
}
