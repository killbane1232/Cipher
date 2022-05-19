using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TK_labs;

namespace WinForm
{
    public partial class Form1 : Form
    {
        private Algorithm algo;

        public Form1()
        {
            InitializeComponent();
        }

        private void OpenFileButton_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog();
            ofd.ShowDialog();
            if (string.IsNullOrEmpty(ofd.FileName))
                MessageBox.Show("File not selected! Please, try again");
            else
                InputTextBox.Text = Algorithm.ReadFromFile(ofd.FileName);
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            var sfd = new SaveFileDialog();
            sfd.ShowDialog();
            if (string.IsNullOrEmpty(sfd.FileName))
                MessageBox.Show("File not selected! Please, try again");
            else
                Algorithm.WriteToFile(OutputTextBox.Text, sfd.FileName);
        }

        private void EncodeButton_Click(object sender, EventArgs e)
        {
            if (algo != null)
                OutputTextBox.Text = algo.EncodedText;
            else
                MessageBox.Show("Choose algorithm and try again!");
        }

        private void DecodeButton_Click(object sender, EventArgs e)
        {
            if (algo != null)
                OutputTextBox.Text = algo.DecodedText;
            else
                MessageBox.Show("Choose algorithm and try again!");
        }

        private void MoveButton_Click(object sender, EventArgs e)
        {
            InputTextBox.Text = OutputTextBox.Text;
        }

        private void AlgoName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                algo = AlgoName.Text switch
                {
                    "Shannon-Fano" => new Shannon_Fano(InputTextBox.Text),
                    "Huffman" => new Huffman(InputTextBox.Text),
                    "Arithmetic" => new Arithmetic(InputTextBox.Text),
                    "LZ77" => new LZ77(InputTextBox.Text),
                    "LZ78" => new LZ78(InputTextBox.Text),
                    "BW" => new BTW(InputTextBox.Text),
                    "RLE" => new RLE(InputTextBox.Text),
                    _ => throw new Exception("Choose algorithm and try again!")
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void EncodeButtonP2_Click(object sender, EventArgs e)
        {
            algo = AlgoNameP2.Text switch
            { 
                "Hamming (7,4)" => new Hamming_7_4_(InputTextBox.Text),
                "Linear (5,2)" => new Code2_5(InputTextBox.Text),
                _ => throw new Exception("Choose algorithm and try again!")
            };

            OutputTextBox.Text = algo.EncodedText;
        }

        private void DecodeButtonP2_Click(object sender, EventArgs e)
        {
            algo = AlgoNameP2.Text switch
            {
                "Hamming (7,4)" => new Hamming_7_4_(InputTextBox.Text),
                "Linear (5,2)" => new Code2_5(InputTextBox.Text),
                _ => throw new Exception("Choose algorithm and try again!")
            };

            OutputTextBox.Text = algo.DecodedText;
        }
    }
}
