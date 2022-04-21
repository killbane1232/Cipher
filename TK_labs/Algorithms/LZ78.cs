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
            var dictionary = new List<string>();
            dictionary.Add("");
            for (int i = 0; i < EncodedText.Length; i++)
            {
                var indexStr = new StringBuilder();
                while(InputText[i]!='|')
                    indexStr.Append(EncodedText[i++]);
                var index =int.Parse(indexStr.ToString());
                i++;
                result.Append(dictionary[index]);
                result.Append(EncodedText[i]);
            }
            return result.ToString();
        }

        public string Encode()
        {
            if (String.IsNullOrEmpty(InputText))
                throw new Exception("Input text is empty!");
            StringBuilder result = new StringBuilder();
            var dictionary = new List<string>();
            dictionary.Add("");
            for (int i = 0; i < InputText.Length; i++)
            {
                int index = 0;
                int len = 0;
                for (int j = 1; j < dictionary.Count; j++)
                {
                    if (dictionary[j].Length <= len)
                        continue;
                    bool flag = true;
                    for(int k =0;k<dictionary[j].Length;k++)
                        if(dictionary[j][k] != InputText[i+k])
                        {
                            flag = false;
                        }
                    if (flag)
                    {
                        len = dictionary[j].Length;
                        index = j;
                    }
                }
                i += len;
                result.Append($"{index}|{InputText[i]}");
                dictionary.Add(dictionary[index] + InputText[i]);
            }

            return result.ToString();
        }

        public double GetCompressionRatio()
        {
            return (double)(InputText.Length) / (EncodedText.Length);
        }
    }
}
