using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TK_labs
{
    public class Code2_5 : Algorithm, ICoding
    {
        //00 00000 мин расст 3
        //01 01011 мин расст 3
        //10 10110 мин расст 3 
        //11 11101 мин расст 3 
        int[][] Matrix = new int[][] { 
            new int[]{1,0,1,1,0},
            new int[]{0,1,0,1,1}
        };
        int[][] CheckMatrix = new int[][] {
            new int[]{1,0,1,0,0},
            new int[]{1,1,0,1,0},
            new int[]{0,1,0,0,1}
        };
        int[][] A = new int[][]
        {
            new int[]{0,0,0,0,0},
            new int[]{0,0,0,0,1},
            new int[]{0,0,0,1,0},
            new int[]{0,1,0,0,0},
            new int[]{0,0,1,0,0},
            new int[]{0,0,1,0,1},
            new int[]{1,0,0,0,0},
            new int[]{1,0,0,0,1} 
        };

        public string input;

        public Code2_5(string text) : base(text)
        {
            input = InputText;
            if (InputText.Length == 2)
                EncodedText = Encode();
            else if (InputText.Length == 5)
                DecodedText = Decode();
        }

        public double CompressionRatio => throw new NotImplementedException();

        public string Decode()
        {
            var res = "";
            List<int[]> syndrs = new List<int[]>();
            for(int i = 0; i < input.Length - 4; i += 5) 
            { 
                int[] syndr = new int[] { 0, 0, 0 };
                int[] inputBits = new int[] { 0, 0,0,0,0 };
                int[] controlBits = new int[] { 0, 0,0 };
                for (int j = 0; j < 2; j++)
                    if (input[i + j] == '1')
                        inputBits[j] = 1;
                for (int j = 2; j < 5; j++)
                    if (input[i + j] == '1') 
                    { 
                        controlBits[j-2] = 1;
                        inputBits[j] = 1;
                    }
                int syndr2 = 0;
                int kr = 1;
                for (int j=0;j<3;j++)
                {
                    for (int k = 0; k < 5; k++)
                        syndr[j] ^= CheckMatrix[j][k] & inputBits[k];
                    syndr[j] &= 1;
                    if (syndr[j] != 0)
                        syndr2 += kr;
                    if(j<2)
                    syndr2 = syndr2<< 1;
                }
                syndrs.Add(syndr);

                syndr2 &= 7;
                for (int j = 0; j < 5; j++)
                    inputBits[j] ^= A[syndr2][j];
                
                for (int j = 0; j < 2; j++)
                    res+=inputBits[j] & 1;
            }
            res += ' ';
            for (int i = 0; i < syndrs.Count; i++) {
                for (int j = 0; j < 3; j++)
                    res += syndrs[i][j] & 1;
                res += ' ';
            }
            return res;
        }

        public string Encode()
        {
            var res = "";
            for(int i =0;i<input.Length-1;i+=2)
            {
                int[] resPart = new int[] { 0, 0, 0, 0, 0 };
                if (input[i] == '1')
                    for (int j = 0; j < 5; j++)
                        resPart[j] ^= Matrix[0][j];
                if (input[i+1]=='1')
                    for (int j = 0; j < 5; j++)
                        resPart[j] ^= Matrix[1][j];
                for (int j = 0; j < 5; j++)
                    res += resPart[j]&1;
            }
            return res;
        }

        public double GetCompressionRatio()
        {
            throw new NotImplementedException();
        }
    }
}
