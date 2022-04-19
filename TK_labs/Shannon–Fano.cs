using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TK_labs
{
    public class Shannon_Fano : ICoding
    {
        public Dictionary<char, string> Encoding { get; private set; }
        public Dictionary<char, float> Frequency { get; }
        public string InputText { get; }
        public string EncodedText { get; }
        public string DecodedText { get; }
        public string InputFile { get; }
        public float CompressionRatio { get { return GetCompressionRatio(); } }

        public Shannon_Fano(string text) 
        { 
            InputText = text;
            Frequency = Common.GetFreqDictionary(InputText);
            GetEncoding();
            EncodedText = Encode();
            DecodedText = Decode();
        }

        public Shannon_Fano(string fileName, bool noMatter)
        {
            InputFile = fileName;
            InputText = Common.ReadFromFile(InputFile);
            Frequency = Common.GetFreqDictionary(InputText);
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
                    //Хз какой из этих вариантов лучше, на глаз работают одинаково.
                    //Надо будет подумать над другим способом получть ключ по значению, ибо это капец как долго.
                    //encoding.Where(x => x.Value == symbol.ToString()).First().Key
                    //(from pair in encoding where pair.Value == symbol.ToString() select pair).First().Key
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
            Split("", Frequency);
            return;
        }

        public float GetCompressionRatio()
        {
            float S0, SC;
            S0 = InputText.Length * 8;
            SC = EncodedText.Length;
            return (float) S0/(SC + 1);
        }

        private char GetMedium(Dictionary<char, float> dict)
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

        private void Split(string branch, Dictionary<char, float> dict)
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
            Dictionary<char, float> left, right;
            if (dict.Count != 2)
            {
                var center = GetMedium(dict);
                left = new Dictionary<char, float>(dict.TakeWhile(el => el.Key != center));
                right = new Dictionary<char, float>(dict.TakeLast(dict.Count - left.Count));
            }
            else
            {
                left = new Dictionary<char, float>(dict.Take(1));
                right = new Dictionary<char, float>(dict.TakeLast(1));
            }
            Split("0", left);
            Split("1", right);
        }
    }
}
