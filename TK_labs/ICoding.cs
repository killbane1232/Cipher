using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TK_labs
{
    interface ICoding
    {
        public Dictionary<char, string> GetEncoding(string fileName);
        public string Encode(string text);
        public string Decode(string text);
        public int GetCompressionRatio(Dictionary<char, string> encoding, Dictionary<char, float> freqDict);
    }
}
