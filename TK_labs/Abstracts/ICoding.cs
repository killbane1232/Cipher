using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TK_labs
{
    interface ICoding
    {
        public double CompressionRatio { get; }
        public string Encode();
        public string Decode();
        public double GetCompressionRatio();
    }
}
