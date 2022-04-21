using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Rationals;

namespace TK_labs
{
    public class Arithmetic : Algorithm, ICoding
    {
        public double CompressionRatio { get { return GetCompressionRatio(); } }
        public Dictionary<char, Rational> RangeTable { get; private set; }
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
            Rational encoded = Rational.Parse(EncodedText);
            Rational currentUp = 1, currentDown = 0;
            KeyValuePair<char, Rational> c;
            while (currentDown != encoded)
            {
                SetRangeTable(currentDown, currentUp);
                c = FindRange((Rational)encoded);
                result.Append(c.Key);
                currentUp = RangeTable[c.Key];
                currentDown = RangeTable[c.Key] - (Rational)Frequency[c.Key] * (RangeTable.Last().Value - RangeTable.First().Value);
            }

            return result.ToString();
        }

        private KeyValuePair<char, Rational> FindRange(Rational current)
        {
            KeyValuePair<char, Rational> ret = new KeyValuePair<char, Rational>('1', -1);
            foreach (var el in RangeTable)
            {
                if (el.Value >= current)
                {
                    return el;
                }
            }
            return ret;
        }

        public string Encode()
        {
            Rational currentUp = 1, currentDown = 0;
            Frequency = GetFreqDictionary(InputText);
            
            foreach(var c in InputText)
            {
                    
                SetRangeTable(currentDown, currentUp);
                
                currentUp = RangeTable[c];
                currentDown = RangeTable[c] - (Rational)Frequency[c] * (RangeTable.Last().Value - RangeTable.First().Value);
            }
            return currentDown.ToString();
        }

        private void SetRangeTable(Rational left, Rational right)
        {
            RangeTable = new Dictionary<char, Rational>();
            Rational prev = left;
            foreach (var c in Frequency)
            {
                RangeTable.Add(c.Key, (Rational)c.Value * (right - left) + prev);
                prev += (Rational)c.Value * (right - left);
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
