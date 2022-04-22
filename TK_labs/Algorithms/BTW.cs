using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace TK_labs
{
    public class BTW :Algorithm, ICoding
    {
        public double CompressionRatio { get { return GetCompressionRatio(); } }
        public BTW(string text):base(text)
        {
            EncodedText = Encode();
            DecodedText = Decode();
        }

        public BTW(string fileName, bool noMatter):base(fileName, noMatter)
        {
            EncodedText = Encode();
            DecodedText = Decode();
        }

        public string Decode()
        {
            var indexStr = new StringBuilder();

            var len = EncodedText.Length;
            int i = 0;
            while (EncodedText[i] != '|')
                indexStr.Append(EncodedText[i++]);
            i++;
            int index = int.Parse(indexStr.ToString());
            var beginers = new List<char>();
            var strings = new List<string>();
            for (; i < len; i++)
            {
                beginers.Add(EncodedText[i]);
                strings.Add(EncodedText[i].ToString());
            }
            strings.Sort();
            var newLen = strings.Count;
            while (strings[0].Length < newLen)
            {
                for (int j = 0; j < strings.Count; j++)
                {
                    strings[j] = beginers[j] + strings[j];
                }
                strings.Sort();
            }
            return strings[index];
        }

        public string Encode()
        {
            var len = InputText.Length;
            var list = new List<StringBuilder>(len);
            for(var i =0;i<len;i++)
            {
                list.Add(new StringBuilder(len));
                list[i].Append(InputText[i]);
                for (var j = 1; j < InputText.Length; j++)
                    list[i].Append(InputText[(i + j) % len]);
            }
            var listStrs = new List<string>(len);
            for(int i= 0; i < len; i++)
                listStrs.Add(list[i].ToString());
            listStrs.Sort();
            var result = new StringBuilder();
            var index = len / 2;
            var step = len / 2;
            while (listStrs[index] != InputText)
            {
                switch (listStrs[index].CompareTo(InputText))
                {
                    case 1:
                        step /= 2;
                        index -=step;
                        break;
                    case 0:
                        break;
                    case -1:
                        step /= 2;
                        index += step;
                        break;
                }
            }
            result.Append(index);
            result.Append('|');
            for (int i = 0;i<len;i++)
                result.Append(listStrs[i].Last());
            return result.ToString();
        }

        public double GetCompressionRatio()
        {
            return 1;
        }
    }
}
