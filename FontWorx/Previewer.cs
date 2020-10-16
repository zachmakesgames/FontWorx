using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace FontWorx
{
    public partial class Previewer : Form
    {
        List<Character> Chars = new List<Character>();
        Main callingForm;
        public Previewer(List<Character> CDat, Main Caller)
        {
            Chars.AddRange(CDat);
            InitializeComponent();
            callingForm = Caller;
        }

        public Previewer(Main caller)
        {
            InitializeComponent();
            callingForm = caller;
        }
        Bitmap img;
        Graphics G;

        Color BackColor = Color.White;
        Color ForeColor = Color.Black;
        Brush textBrush = new SolidBrush(Color.Black);
        private void Previewer_Load(object sender, EventArgs e)
        {
            img = new Bitmap(8 * 20, 8 * 20);
            G = Graphics.FromImage(img);
            G.Clear(BackColor);
            pictureBox1.Image = img;
            int index = 1;
            int yVal = 0;
            foreach(Character C in Chars)
            {
                if (index > (8 * 19))
                {
                    yVal += 10;
                    index = 1;
                }
                for(int i = 0; i < 8; ++i)
                {
                    for(int j = 8; j >= 0; --j)
                    {
                        int v = C.glyfData[i];
                        //if (v == 0xAA || v == 0x55) continue;
                        if((v & 1 << j) == 1 << j)
                        {
                            G.FillRectangle(Brushes.Black, index, j+yVal, 1, 1);
                            pictureBox1.Image = img;
                        }
                    }
                    ++index;
                }
            }
        }
        private void update()
        {
            G.Clear(BackColor);
            int index = 0;
            int yVal = 0;
            foreach (Character C in Chars)
            {
                if (index > (8 * 19))
                {
                    yVal += 10;
                    index = 0;
                }
                for (int i = 0; i < 8; ++i)
                {
                    for (int j = 8; j >= 0; --j)
                    {
                        int v = C.glyfData[i];
                        //if (v == 0xAA || v == 0x55) continue;
                        if ((v & 1 << j) == 1 << j)
                        {
                            G.FillRectangle(textBrush, index, j + yVal, 1, 1);
                            pictureBox1.Image = img;
                        }
                    }
                    ++index;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult DR = colorDialog1.ShowDialog();
            if(DR == DialogResult.OK)
            {
                BackColor = colorDialog1.Color;
                update();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult DR = colorDialog1.ShowDialog();
            if (DR == DialogResult.OK)
            {
                ForeColor = colorDialog1.Color;
                textBrush = new SolidBrush(ForeColor);
                update();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Color tmp = BackColor;

            BackColor = ForeColor;
            ForeColor = tmp;
            textBrush = new SolidBrush(ForeColor);
            update();
        }

        public void updateData(List<Character> CDat)
        {
            Chars.Clear();
            Chars.AddRange(CDat);
            update();
        }

        private void Previewer_FormClosing(object sender, FormClosingEventArgs e)
        {
            callingForm.previewClose();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            saveFileDialog1.AddExtension = true;
            saveFileDialog1.Filter = "Jpeg (.jpg)|*.jpg";
            DialogResult DR = saveFileDialog1.ShowDialog();
            if(DR == DialogResult.OK)
            {
                string path = saveFileDialog1.FileName;
                /*if (File.Exists(path))
                {
                    File.Create(path);
                }*/
                img.Save(path, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            
        }
    }
}
