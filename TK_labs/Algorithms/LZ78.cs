using System;
using System.Text;
using System.Collections.Generic;

namespace TK_labs
{
    internal class LZ78 : Algorithm, ICoding
    {
        public double CompressionRatio { get => GetCompressionRatio(); }

        public LZ78(string text) : base(text)
        {
            EncodedText = Encode();
            DecodedText = Decode();
        }

        public LZ78(string fileName, bool noMatter) : base(fileName, noMatter)
        {
            EncodedText = Encode();
            DecodedText = Decode();
        }

        public string Decode()
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < InputText.Length; i++)
            {
                var dispStr = new StringBuilder();
                dispStr.Append(InputText[i]);
                while (InputText[i] != ',')
                    dispStr.Append(InputText[i++]);
                var disp = int.Parse(dispStr.ToString());
                i++;
                var cntStr = new StringBuilder();
                cntStr.Append(InputText[i]);
                while (InputText[i] != ',')
                    cntStr.Append(InputText[i++]);
                var cnt = int.Parse(cntStr.ToString());
                var ch = InputText[++i];
                i++;
                if (cnt != 0 && disp != 0)
                {
                    int position = result.Length - disp;
                    for (int j = 0; j < cnt; j++)
                        result.Append(result[position + j]);
                }
                result.Append(ch);
            }
            return result.ToString();
        }

        public string Encode()
        {
            if (String.IsNullOrEmpty(InputText))
                throw new Exception("Input text is empty!");
            StringBuilder result = new StringBuilder();
            var dictionary = new List<string>();

            for (int i = 0; i < InputText.Length; i++)
            {
                int maxLen = 0;
                int index = 0;
                for (int j = 0; j < i; j++)
                {
                    int len = 0;
                    for (int k = j; k < i; k++)
                        if (InputText[k] == InputText[i + k - j])
                        {
                            len++;
                        }
                    if (len > maxLen)
                    {
                        maxLen = len;
                        index = i - j;
                    }
                }
                result.Append($"{index},{maxLen},{InputText[i]}|");
            }

            return result.ToString();
        }

        public double GetCompressionRatio()
        {
            return (double)(InputText.Length) / (EncodedText.Length);
        }
    }
}
