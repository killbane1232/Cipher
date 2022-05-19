using MathNet.Numerics.LinearAlgebra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TK_labs
{
    public class Hamming_7_4_ : Algorithm, ICoding
    {
        int[,] H, HT, G, R;
        public Hamming_7_4_(string text) : base(text)
        {
            InputText = text;

            G = new int[4, 7]
            {
                { 1, 1, 1, 0, 0, 0, 0},
                { 1, 0, 0, 1, 1, 0, 0},
                { 0, 1, 0, 1, 0, 1, 0},
                { 1, 1, 0, 1, 0, 0, 1}
            };

            H = new int[3, 7] {
                {0, 0, 0, 1, 1, 1, 1}, 
                {0, 1, 1, 0, 0, 1, 1}, 
                {1, 0, 1, 0, 1, 0, 1}
            };

            HT = new int[7, 3]
            {
                { 0, 0, 1 },
                { 0, 1, 0 },
                { 0, 1, 1 },
                { 1, 0, 0 },
                { 1, 0, 1 },
                { 1, 1, 0 },
                { 1, 1, 1 }
            };

            R = new int[4, 7]
            {
                { 0, 0, 1, 0, 0, 0, 0},
                { 0, 0, 0, 0, 1, 0, 0},
                { 0, 0, 0, 0, 0, 1, 0},
                { 0, 0, 0, 0, 0, 0, 1}
            };

            if (InputText.Length == 4)
                EncodedText = Encode(InputText);
            else if (InputText.Length == 7)
                DecodedText = Decode(InputText);
        }

        public double CompressionRatio => throw new NotImplementedException();

        public string Decode()
        {
            throw new NotImplementedException();
        }

        public string Encode(string s)
        {
            string answer = "";
            for (int i = 0; i < 7; i++)
            {
                int val = 0;
                for (int j = 0; j < 4; j++)
                {
                    val += (int.Parse(s[j].ToString()) * G[j, i]);
                }
                answer += (val % 2).ToString();
            }
            return answer;
        }

        public string Decode(string s)
        {
            string answer = "";
            var correct = Check(s);
            for (int i = 0; i < 4; i++)
            {
                int val = 0;
                for (int j = 0; j < 7; j++)
                {
                    val += (R[i, j] * int.Parse(correct[j].ToString()));
                }
                answer += (val % 2).ToString();
            }
            return answer;
        }

        public string Check(string s)
        {
            var scpy = new StringBuilder(s);
            int syndrome = 0;
            for (int i = 0; i < 3; i++)
            {
                int val = 0;
                for (int j = 0; j < 7; j++)
                {
                    
                    val += (int.Parse(s[j].ToString()) * HT[j, i]);
                }
                syndrome += (val % 2) * (int)Math.Pow(2, 2 - i);
            }
            if (syndrome == 0)
                return s;
            else
            {
                syndrome--;
                if (s[syndrome] == '0')
                    scpy[syndrome] = '1';
                else
                    scpy[syndrome] = '0';
                return scpy.ToString();
            }
        }

        public double GetCompressionRatio()
        {
            throw new NotImplementedException();
        }

        public string Encode()
        {
            throw new NotImplementedException();
        }
    }
}
