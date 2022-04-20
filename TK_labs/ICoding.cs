using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TK_labs
{
    interface ICoding
    {
        public Dictionary<char, string> Encoding { get; }
        public Dictionary<char, double> Frequency { get; }
        public string InputText { get; }
        public string EncodedText { get; }
        public string DecodedText { get; }
        public string InputFile { get; }
        public double CompressionRatio { get; }
        public void GetEncoding();
        public string Encode();
        public string Decode();
        public double GetCompressionRatio();
    }
}
