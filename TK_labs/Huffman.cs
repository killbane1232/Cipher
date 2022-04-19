using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TK_labs
{
    public class Huffman : ICoding
    {
        public Dictionary<char, string> Encoding { get; }
        public Dictionary<char, float> Frequency { get; }
        public string InputText { get; }
        public string EncodedText { get; }
        public string DecodedText { get; }
        public string InputFile { get; }
        public float CompressionRatio { get; }

        public string Decode()
        {
            throw new NotImplementedException();
        }

        public string Encode()
        {
            throw new NotImplementedException();
        }

        public float GetCompressionRatio()
        {
            throw new NotImplementedException();
        }

        public void GetEncoding()
        {
            throw new NotImplementedException();
        }
    }
}
