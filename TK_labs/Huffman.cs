using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TK_labs
{
    public class Huffman : ICoding
    {
        public Dictionary<char, string> Encoding { get; private set; }
        public Dictionary<char, float> Frequency { get; }
        public string InputText { get; }
        public string EncodedText { get; }
        public string DecodedText { get; }
        public string InputFile { get; }
        public float CompressionRatio { get { return GetCompressionRatio(); } }

        public Huffman(string text)
        {
            InputText = text;
            Frequency = Common.GetFreqDictionary(InputText);
            GetEncoding();
            EncodedText = Encode();
            DecodedText = Decode();
        }

        public Huffman(string fileName, bool noMatter)
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
            foreach (var c in InputText)
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

        public float GetCompressionRatio()
        {
            float S0, SC;
            S0 = InputText.Length * 8;
            SC = EncodedText.Length;
            return (float)S0 / (SC + 1);
        }

        public void GetEncoding()
        {
            Encoding = new Dictionary<char, string>();
            foreach (var el in Frequency)
            {
                Encoding.Add(el.Key, "");
            }

            var freq_str = new Dictionary<string, float>(from el in Frequency select new KeyValuePair<string, float>(el.Key.ToString(), el.Value));
            while (freq_str.Count != 1)
            {
                var min1 = freq_str.Last();
                freq_str.Remove(min1.Key);
                var min2 = freq_str.Last();
                freq_str.Remove(min2.Key);
                foreach (var c in min1.Key)
                {
                    Encoding[c] = "1" + Encoding[c];
                }
                foreach (var c in min2.Key)
                {
                    Encoding[c] = "0" + Encoding[c];
                }
                freq_str.Add(min1.Key + min2.Key, min1.Value + min2.Value);
                freq_str = new Dictionary<string, float>(freq_str.OrderByDescending(x => x.Value));
            }
        }
    }
}
