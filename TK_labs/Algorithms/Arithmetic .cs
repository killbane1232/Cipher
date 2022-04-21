using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
//using HigherArithmetics.Numerics;
using LinearNet.Structs.Fields;

namespace TK_labs
{
    public class Arithmetic : Algorithm, ICoding
    {
        public double CompressionRatio { get { return GetCompressionRatio(); } }
        public Dictionary<char, BigDecimal> RangeTable { get; private set; }
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
            BigDecimal encoded = BigDecimal.Parse(EncodedText);
            BigDecimal currentUp = 1, currentDown = 0;
            KeyValuePair<char, BigDecimal> c;
            while (currentDown != encoded)
            {
                SetRangeTable(currentDown, currentUp);
                c = FindRange((BigDecimal)encoded);
                result.Append(c.Key);
                currentUp = RangeTable[c.Key];
                currentDown = RangeTable[c.Key] - (BigDecimal)Frequency[c.Key] * (RangeTable.Last().Value - RangeTable.First().Value);
            }

            return result.ToString();
        }

        private KeyValuePair<char, BigDecimal> FindRange(BigDecimal current)
        {
            KeyValuePair<char, BigDecimal> ret = new KeyValuePair<char, BigDecimal>('1', -1);
            foreach (var el in RangeTable)
            {
                if (el.Value.CompareTo(current)>=0)
                {
                    return el;
                }
            }
            return ret;
        }

        public string Encode()
        {
            BigDecimal currentUp = 1, currentDown = 0;
            Frequency = GetFreqDictionary(InputText);
            
            foreach(var c in InputText)
            {
                    
                SetRangeTable(currentDown, currentUp);
                
                currentUp = RangeTable[c];
                currentDown = RangeTable[c] - (BigDecimal)Frequency[c] * (RangeTable.Last().Value - RangeTable.First().Value);
            }
            return currentDown.ToString();
        }

        private void SetRangeTable(BigDecimal left, BigDecimal right)
        {
            RangeTable = new Dictionary<char, BigDecimal>();
            BigDecimal prev = left;
            foreach (var c in Frequency)
            {
                RangeTable.Add(c.Key, (BigDecimal)c.Value * (right - left) + prev);
                prev += (BigDecimal)c.Value * (right - left);
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
