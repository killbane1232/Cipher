﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TK_labs
{
    interface ICoding
    {
        public Dictionary<char, string> Encoding { get; }
        public Dictionary<char, float> Frequency { get; }
        public string InputText { get; }
        public string EncodedText { get; }
        public string DecodedText { get; }
        public string InputFile { get; }
        public float CompressionRatio { get; }
        public void GetEncoding();
        public string Encode();
        public string Decode();
        public float GetCompressionRatio();
    }
}
