using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TK_labs
{
    public class RLE : Algorithm, ICoding
    {
        public double CompressionRatio { get { return GetCompressionRatio(); } }
        public RLE(string text):base(text)
        {
            EncodedText = Encode();
            DecodedText = Decode();
        }

        public RLE(string fileName, bool noMatter):base(fileName, noMatter)
        {
            EncodedText = Encode();
            DecodedText = Decode();
        }

        public string Decode()
        {
            StringBuilder result = new StringBuilder(), number = new StringBuilder();
            char ch;
            for(int i =0;i<EncodedText.Length;i++)
            {
                ch = EncodedText[i++];
                while (EncodedText[i] != '|')
                    number.Append(EncodedText[i++]);
                var num = int.Parse(number.ToString());
                for(int j=0;j<num;j++)
                    result.Append(ch);
                number = new StringBuilder();
            }
            return result.ToString();
        }

        public string Encode()
        {
            if (String.IsNullOrEmpty(InputText))
                throw new Exception("Input text is empty!");
            StringBuilder result = new StringBuilder();

            int cnt = 0;
            char ch = InputText[0];

            foreach (var c in InputText)
            {
                if (c == ch)
                    cnt++;
                else 
                { 
                    result.Append(ch);
                    result.Append(cnt);
                    result.Append('|');
                    ch = c;
                    cnt = 1;
                }
            }
            result.Append(ch);
            result.Append(cnt);
            result.Append('|');
            return result.ToString();
        }

        public double GetCompressionRatio()
        {
            return (double)(InputText.Length) / (EncodedText.Length);
        }
    }
}
