using System;
using System.Text;

namespace TK_labs
{
    public class LZ77 : Algorithm, ICoding
    {
        public double CompressionRatio { get => GetCompressionRatio(); }

        public LZ77(string text) : base(text)
        {
            EncodedText = Encode();
            DecodedText = Decode();
        }

        public LZ77(string fileName, bool noMatter) : base(fileName, noMatter)
        {
            EncodedText = Encode();
            DecodedText = Decode();
        }

        public string Decode()
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < EncodedText.Length; i++)
            {
                var dispStr = new StringBuilder();
                while(EncodedText[i] !=',')
                    dispStr.Append(EncodedText[i++]);
                var disp = int.Parse(dispStr.ToString());
                i++;
                var cntStr = new StringBuilder();
                while (EncodedText[i] != ',')
                    cntStr.Append(EncodedText[i++]);
                var cnt = int.Parse(cntStr.ToString());
                var ch = EncodedText[++i];
                i++;
                if (cnt != 0 && disp != 0)
                {
                    int position = result.Length - disp;
                    for (int j = 0; j< cnt; j++)
                        result.Append(result[position+j]);
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

            int length  = InputText.Length;
            InputText += " ";
            for (int i = 0; i < length; i++)
            {
                int maxLen = 0;
                int index = 0;
                for (int j = 0; j < i; j++)
                {
                    int len = 0;
                    if(InputText[j]!=InputText[i])
                        continue;
                    for (int k = j; k < i; k++)
                        if (i + k - j< InputText.Length && InputText[k] == InputText[i + k - j])
                        {
                            len++;
                        }
                    if(len> maxLen)
                    {
                        maxLen = len;
                        index = i-j;
                    }
                }
                i += maxLen;
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
