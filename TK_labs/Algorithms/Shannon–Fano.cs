using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TK_labs
{
    public class Shannon_Fano :Algorithm, ICoding
    {
        public double CompressionRatio { get { return GetCompressionRatio(); } }

        public Shannon_Fano(string text) :base(text)
        { 
            GetEncoding();
            EncodedText = Encode();
            DecodedText = Decode();
        }

        public Shannon_Fano(string fileName, bool noMatter):base(fileName, noMatter)
        {
            GetEncoding();
            EncodedText = Encode();
            DecodedText = Decode();
        }

        public string Encode()
        {
            if (String.IsNullOrEmpty(InputText))
                throw new Exception("Input text is empty!");
            StringBuilder result = new StringBuilder();
            foreach(var c in InputText)
            {
                result.Append(Encoding[c]);
            }
            return result.ToString();
        }

        public string Decode()
        {
            StringBuilder result = new StringBuilder(), symbol = new StringBuilder();
            foreach (var c in EncodedText)
            {
                symbol.Append(c);
                if (Encoding.ContainsValue(symbol.ToString()))
                {
                    result.Append(Encoding.Where(x => x.Value == symbol.ToString()).First().Key);
                    symbol = new StringBuilder();
                }
            }
            return result.ToString();
        }

        public void GetEncoding()
        {
            Encoding = new Dictionary<char, string>();
            foreach(var el in Frequency)
            {
                Encoding.Add(el.Key, "");
            }
            Split("0", Frequency);
            return;
        }

        public double GetCompressionRatio()
        {
            return (double)(InputText.Length * 8) / (EncodedText.Length);
        }

        private char GetMedium(Dictionary<char, double> dict)
        {
            var sum = dict.Sum(x => x.Value);
            double value = 0, half = (double)sum / 2;
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

        private void Split(string branch, Dictionary<char, double> dict)
        {
            if (dict.Count == 1)
            {
                foreach(var el in dict)
                    Encoding[el.Key] += branch;
                return;
            }
            if (dict.Count != Encoding.Count)
                foreach(var el in dict)
                    Encoding[el.Key] += branch;
            Dictionary<char, double> left, right;
            if (dict.Count != 2)
            {
                var center = GetMedium(dict);
                left = new Dictionary<char, double>(dict.TakeWhile(el => el.Key != center));
                right = new Dictionary<char, double>(dict.TakeLast(dict.Count - left.Count));
            }
            else
            {
                left = new Dictionary<char, double>(dict.Take(1));
                right = new Dictionary<char, double>(dict.TakeLast(1));
            }
            Split("0", left);
            Split("1", right);
        }
    }
}
