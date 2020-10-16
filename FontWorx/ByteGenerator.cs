using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FontWorx
{
    public partial class ByteGenerator : Form
    {
        Main MainWindow;
        List<Character> Chars = new List<Character>();
        public ByteGenerator(Main sender, List<Character> CharInfo)
        {
            Chars.Clear();
            Chars.AddRange(CharInfo);
            MainWindow = sender;
            InitializeComponent();
        }

        private void ByteGenerator_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (singleArrayRadio.Checked)
            {
                string output = "";
                output += "uint8_t " + variableName.Text + "[" + (8 * Chars.Count).ToString() + "] = {\r\n";
                for(int C = 0; C < Chars.Count; ++C) // (Character C in Chars)
                {
                    for (int i = 0; i < 8; ++i)
                    {
                        output += "0x" + Chars[C].glyfData[i].ToString("X2");
                        if (i < 7) output += ", ";
                        else
                        {
                            if (C < Chars.Count - 1) output += ",";
                        }
                        
                    }
                    output += "\r\n";
                }
                output += "};";
                if (copyToClipboardRadio.Checked)
                {
                    Clipboard.SetText(output);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Write to file not implemented yet");
                }
            }
            else
            {//Double array
                string output = "";
                output += "uint8_t " + variableName.Text + "[" + Chars.Count.ToString() + "][8] = {\r\n";
                for(int C = 0; C < Chars.Count; ++C)
                {
                    output += "\t{/*ASCII: " + ((char)(C+32)) +" */";
                    output += "\r\n\t\t";
                    for(int i = 0; i < 8; ++i)
                    {
                        output += "0x" + Chars[C].glyfData[i].ToString("X2");
                        if (i < 7) output += ",";
                    }
                    output += "\r\n\t}";
                    if (C < Chars.Count - 1) output += "\r\n\t,\r\n";
                }
                output += "\r\n};";
                if (copyToClipboardRadio.Checked)
                {
                    Clipboard.SetText(output);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Write to file not implemented yet");
                }
            }
            
            
            
        }
    }
}
