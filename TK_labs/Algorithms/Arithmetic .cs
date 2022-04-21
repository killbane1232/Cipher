using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TK_labs
{
    public class Arithmetic : Algorithm, ICoding
    {
        public double CompressionRatio { get { return GetCompressionRatio(); } }
        public Dictionary<char, double> RangeTable { get; private set; }

        public Arithmetic(string text):base(text)
        {
            EncodedText = Encode();
            DecodedText = Decode();
        }

        public Arithmetic(string fileName, bool noMatter):base(fileName, noMatter)
        {
            EncodedText = Encode();
            DecodedText = Decode();
        }

        public string Decode()
        {
            StringBuilder result = new StringBuilder();
            double encoded = Convert.ToDouble(EncodedText);
            double currentUp = 1, currentDown = 0, prevUp = -1, prevDown = -1;

            while (currentDown != encoded)
            {
                SetRangeTable(currentDown, currentUp);
                var c = FindRange((double)encoded);
                result.Append(c.Key);
                prevDown = currentDown;
                prevUp = currentUp;
                currentUp = RangeTable[c.Key];
                currentDown = RangeTable[c.Key] - Frequency[c.Key] * (RangeTable.Last().Value - RangeTable.First().Value);
            }

            return result.ToString();
        }

        private KeyValuePair<char, double> FindRange(double current)
        {
            KeyValuePair<char, double> ret = new KeyValuePair<char, double>('1', -1);
            foreach (var el in RangeTable)
            {
                if (el.Value > current)
                {
                    return el;
                }
            }
            return ret;
        }

        public string Encode()
        {
            double currentUp = 1, currentDown = 0, prevUp = 1, prevDown = 0;
            
            foreach(var c in InputText)
            {
                SetRangeTable(currentDown, currentUp);
                
                prevDown = currentDown;
                prevUp = currentUp;
                currentUp = RangeTable[c];
                currentDown = RangeTable[c] - Frequency[c] * (RangeTable.Last().Value - RangeTable.First().Value);
            }
            return currentDown.ToString();
        }

        private void SetRangeTable(double left, double right)
        {
            RangeTable = new Dictionary<char, double>();
            double prev = left;
            foreach (var c in Frequency)
            {
                RangeTable.Add(c.Key, c.Value * (right - left) + prev);
                prev += c.Value * (right - left);
            }
        }

        public double GetCompressionRatio()
        {
            Int64 number = Convert.ToInt64(EncodedText.Replace("0,",""));
            string result = "";
            while(number != 0)
            {
                result = (number % 2).ToString() + result;
                number /= 2;
            }
            return (double)(InputText.Length * 8) / result.Length;
        }
    }
}
