using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FontWorx
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        Previewer FontPreview = null;

        Bitmap img;// = new Bitmap(8, 8);
        Graphics G;// = Graphics.FromImage(img);

        bool mouseDown = false;
        bool setPixel = true;

        bool[,] datArray = new bool[8, 8];
        int scale = 40;

        List<Character> CData = new List<Character>();
        int currentChar = 0;

        string filePath = "";

        private void clearImage(Bitmap B)
        {
            try
            {
                for (int i = 0; i < 8; ++i)
                {
                    for (int j = 0; j < 8; ++j)
                    {
                        datArray[i, j] = false;
                    }
                }

                using (Graphics Gr = Graphics.FromImage(B))
                {
                    Gr.Clear(Color.White);
                    Gr.DrawRectangle(Pens.Black, 0, 0, 8 * scale, 8 * scale);
                    for (int i = 0; i < 8; ++i)
                    {

                        Gr.DrawLine(Pens.Black, i * (scale), 0, i * (scale), 8 * scale + 1);
                        Gr.DrawLine(Pens.Black, 0, i * (scale), 8 * scale + 1, i * (scale));
                    }
                }
                pictureBox1.Image = img;
            }
            catch { }
        }

        
        private void Form1_Load(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Text = "V 1.0.0.0";
            for(int i = 32; i < 127; ++i)
            {
                if(i == 32)listBox1.Items.Add("Space");
                else listBox1.Items.Add((char)i);
                CData.Add(new Character((char)i));
            }
            listBox1.SelectedIndex = 0;
            for(int i = 0; i< 8; ++i)
            {
                for(int j = 0; j < 8; ++j)
                {
                    datArray[i,j] = false;
                }
            }
            img = new Bitmap(8*scale+1, 8*scale+1);
            
            //img.SetResolution(10, 10);
            G = Graphics.FromImage(img);
            G.Clear(Color.White);
            G.DrawRectangle(Pens.Black, 0, 0, 8*scale, 8*scale);
            for (int i = 0; i < 8; ++i)
            {

                G.DrawLine(Pens.Black, i*(scale), 0, i*(scale), 8 * scale + 1);
                G.DrawLine(Pens.Black, 0, i * (scale), 8 * scale + 1, i * (scale));
            }
            pictureBox1.Image = img;
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            /*
            if (e.X > 8 * scale) return;
            if (e.Y > 8 * scale) return;

            int x = getCoord(e.X);
            int y = getCoord(e.Y);
            if (x == -1 || y == -1) return;
            //MessageBox.Show("Coord is: " + x + ", " + y);
            if(datArray[x,y] == true)
            {//set to false
                datArray[x, y] = false;
                G.FillRectangle(Brushes.White, scale * x+1, scale * y+1, scale-1, scale-1);
            }
            else
            {//set to true
                datArray[x, y] = true;
                G.FillRectangle(Brushes.Red, scale * x+1, scale * y+1, scale-1, scale-1);
            }

            //G.FillRectangle(Brushes.Black, e.X, e.Y, 1, 1);
            pictureBox1.Image = img;*/
            if (e.X > 8 * scale) return;
            if (e.Y > 8 * scale) return;

            int x = getCoord(e.X);
            int y = getCoord(e.Y);
            if (x == -1 || y == -1) return;
            
            //MessageBox.Show("Coord is: " + x + ", " + y);
            if (setPixel)
            {
                datArray[x, y] = true;
                G.FillRectangle(Brushes.Red, scale * x + 1, scale * y + 1, scale - 1, scale - 1);
            }
            else
            {
                datArray[x, y] = false;
                G.FillRectangle(Brushes.White, scale * x + 1, scale * y + 1, scale - 1, scale - 1);
            }
            /* if (datArray[x, y] == true)
             {//set to false
                 datArray[x, y] = false;
                 G.FillRectangle(Brushes.White, scale * x + 1, scale * y + 1, scale - 1, scale - 1);
             }
             else
             {//set to true
                 datArray[x, y] = true;
                 G.FillRectangle(Brushes.Red, scale * x + 1, scale * y + 1, scale - 1, scale - 1);
             }*/

            //G.FillRectangle(Brushes.Black, e.X, e.Y, 1, 1);
            pictureBox1.Image = img;
            textBox1.Text = compileImage();
            int[] bytes = new int[8];
            for (int i = 0; i < 8; ++i)
            {
                int val = 0;
                for (int j = 0; j < 8; ++j)
                {
                    if (datArray[i, j])
                    {
                        val |= (1 << j);
                    }
                }
                bytes[i] = val;
            }
            CData[currentChar].glyfData = bytes;
            if (FontPreview != null && FontPreview.IsDisposed == false) FontPreview.updateData(CData);
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            clearImage(img);
        }

        private int getCoord(int raw)
        {
            if (raw >= 1 && raw <= scale) return 0;
            if (raw >= scale+2 && raw <= scale*2) return 1;
            if (raw >= (scale * 2)+2 && raw <= scale * 3) return 2;
            if (raw >= (scale*3)+2 && raw <= scale*4) return 3;
            if (raw >= (scale*4)+2 && raw <= scale*5) return 4;
            if (raw >= (scale * 5) + 2 && raw <= scale * 6) return 5;
            if (raw >= (scale * 6) + 2 && raw <= scale * 7) return 6;
            if (raw >= (scale * 7) + 2 && raw <= scale * 8) return 7;
            return -1;
        }

        private int getYCoord(int raw)
        {
            return 0;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
            
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                if (e.X > 8 * scale) return;
                if (e.Y > 8 * scale) return;

                int x = getCoord(e.X);
                int y = getCoord(e.Y);
                if (x == -1 || y == -1) return;
                //MessageBox.Show("Coord is: " + x + ", " + y);
                if (setPixel)
                {
                    datArray[x, y] = true;
                    G.FillRectangle(Brushes.Red, scale * x + 1, scale * y + 1, scale - 1, scale - 1);
                }
                else
                {
                    datArray[x, y] = false;
                    G.FillRectangle(Brushes.White, scale * x + 1, scale * y + 1, scale - 1, scale - 1);
                }
                   /* if (datArray[x, y] == true)
                    {//set to false
                        datArray[x, y] = false;
                        G.FillRectangle(Brushes.White, scale * x + 1, scale * y + 1, scale - 1, scale - 1);
                    }
                    else
                    {//set to true
                        datArray[x, y] = true;
                        G.FillRectangle(Brushes.Red, scale * x + 1, scale * y + 1, scale - 1, scale - 1);
                    }*/
                    
                //G.FillRectangle(Brushes.Black, e.X, e.Y, 1, 1);
                pictureBox1.Image = img;
            }
            textBox1.Text = compileImage();
            int[] bytes = new int[8];
            for (int i = 0; i < 8; ++i)
            {
                int val = 0;
                for (int j = 0; j < 8; ++j)
                {
                    if (datArray[i, j])
                    {
                        val |= (1 << j);
                    }
                }
                bytes[i] = val;
            }
            CData[currentChar].glyfData = bytes;
            if(FontPreview != null && FontPreview.IsDisposed == false) FontPreview.updateData(CData);
        }

      private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            
            //MessageBox.Show("Key down! \r\n " + e.KeyCode.ToString());
            if(e.KeyCode == Keys.Q)
            {//Clear
                setPixel = false;
               
            }
            if(e.KeyCode == Keys.W)
            {//Set
                setPixel = true;
                
            }
        }


        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            setPixel = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            setPixel = false;
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if(e.KeyChar == 'q') setPixel = false;
            
            //if (e.KeyChar == 'w') setPixel = true;
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ByteGenerator BG = new ByteGenerator(this, CData);
            BG.Show();
        }

        private string compileImage()
        {
            string tmp = "";
            int[] bytes = new int[8];
            for (int i = 0; i < 8; ++i)
            {
                int val = 0;
                for (int j = 0; j < 8; ++j)
                {
                    if (datArray[i, j])
                    {
                        val |= (1 << j);
                    }
                }
                tmp+= "0x" + val.ToString("X2");
                if (i < 7) tmp += ", ";
            }
            return tmp;
        }

        private void setImgByte(int B, int Col)
        {
            if (B > 255 || B < 0) return;
            if (Col > 7 || Col < 0) return;

            for(int i = 0; i < 8; ++i)
            {
                try
                {
                    if (((B & 1 << i) >> i) == 1)
                    {
                        datArray[Col, i] = true;
                        G.FillRectangle(Brushes.Red, scale * Col + 1, scale * i + 1, scale - 1, scale - 1);
                    }
                    else
                    {
                        datArray[Col, i] = false;
                        G.FillRectangle(Brushes.White, scale * Col + 1, scale * i + 1, scale - 1, scale - 1);
                    }
                }
                catch { }
            }
            pictureBox1.Image = img;
        }

        private void showSelectedGlyf()
        {
            clearImage(img);
            currentChar = listBox1.SelectedIndex;

            for (int i = 0; i < 8; ++i)
            {
                setImgByte(CData[currentChar].glyfData[i], i);
            }

            textBox1.Text = compileImage();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            //Save current Character first then load selected character
            int[] bytes = new int[8];
            for (int i = 0; i < 8; ++i)
            {
                int val = 0;
                for (int j = 0; j < 8; ++j)
                {
                    if (datArray[i, j])
                    {
                        val |= (1 << j);
                    }
                }
                bytes[i] = val;
            }
            CData[currentChar].glyfData = bytes;

            //Clear image and load selected
            clearImage(img);
            currentChar = listBox1.SelectedIndex;

            for (int i = 0; i < 8; ++i)
            {
                setImgByte(CData[currentChar].glyfData[i], i);
            }

            textBox1.Text = compileImage();
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Text Files (.txt)|*.txt|Font Worx Files (.fwx)|*.fwx|All Files(*.*)|*.*";
            openFileDialog1.Multiselect = false;
            DialogResult openFileResult = openFileDialog1.ShowDialog();
            if(openFileResult == DialogResult.OK)
            {
                CharacterSet tmp = new CharacterSet();
                filePath = openFileDialog1.FileName;
                if (tmp.loadFromFile(filePath))
                {
                    this.Text = "FontWorx " + filePath;
                    CData.Clear();
                    CData.AddRange(tmp.Chars);
                    showSelectedGlyf();
                    textBox2.Text = tmp.Name;
                }
                else
                {
                    filePath = "";
                    MessageBox.Show("Failed to load file. Is it corrupt?");
                }
                if (FontPreview != null && FontPreview.IsDisposed == false) FontPreview.updateData(CData);
            }
        }

        private void textToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //SaveAsText
            saveFileDialog1.Filter = "Text Files (.txt)|*.txt";
            saveFileDialog1.FileName = textBox2.Text;
            //openFileDialog1.Multiselect = false;
            DialogResult saveFileResult = saveFileDialog1.ShowDialog();
            if(saveFileResult == DialogResult.OK)
            {
                string path = saveFileDialog1.FileName;
                if (File.Exists(path))
                {//prompt to overwrite
                    MessageBox.Show("File exists!");
                }
                else
                {
                    saveAsText(path);
                }
            }
        }

        private void saveAsText(string fileName)
        {
            StreamWriter SW = File.CreateText(fileName);
            SW.WriteLine("{ Font }");
            SW.WriteLine("[ " + textBox2.Text + "]");
            SW.WriteLine();
            int ascii = 32;
            foreach (Character C in CData)
            {
                string bytes = "";
                for (int i = 0; i < 8; ++i)
                {
                    bytes += "0x" + C.glyfData[i].ToString("X2");
                    if (i < 7) bytes += ", ";
                }
                bytes += "//ASCII " + ascii.ToString() + ": " + ((char)ascii++).ToString();
                SW.WriteLine(bytes);
            }

            SW.Flush();
            SW.Close();
            filePath = fileName;
            this.Text = "FontWorx " + filePath;
        }

        private void saveAsFWX(string fileName)
        {
            IFormatter formatter = new BinaryFormatter();
            CharacterSet tmp = new FontWorx.CharacterSet(textBox2.Text, CData);
            using (FileStream FS = File.Create(fileName))
            {
                formatter.Serialize(FS, tmp);
            }
            filePath = fileName;
            this.Text = "FontWorx " + filePath;
        }

        private void fWXToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //SaveAsFWX
            saveFileDialog1.FileName = textBox2.Text;
            saveFileDialog1.Filter = "Font Worx Files (.fwx)|*.fwx";
            //openFileDialog1.Multiselect = false;
            DialogResult saveFileResult = saveFileDialog1.ShowDialog();
            if (saveFileResult == DialogResult.OK)
            {
                string path = saveFileDialog1.FileName;
                if (File.Exists(path))
                {
                    MessageBox.Show("File exists!");
                }
                else
                {
                    saveAsFWX(path);
                }
            }
        }

        private void saveToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (filePath == "")
            {
                //Promt save as
                saveFileDialog1.FileName = textBox2.Text;
                saveFileDialog1.Filter = "Text (.txt)|*.txt|Font Worx (.fwx)|*.fwx";
                DialogResult DR = saveFileDialog1.ShowDialog();
                if(DR == DialogResult.OK)
                {
                    string file = saveFileDialog1.FileName;
                    if(Path.GetExtension(file).ToLower() == ".fwx")
                    {
                        //save as fwx
                       
                            saveAsFWX(file);
                        
                    }
                    else
                    {
                        //save as txt
                        
                       
                            saveAsText(file);
                        
                    }
                }

            }
            else
            {
                /*if (File.Exists(filePath)) File.Delete(filePath);
                //File.Create(filePath);
                StreamWriter SW = File.CreateText(filePath);
                SW.WriteLine("{ Font }");
                SW.WriteLine("[ " + textBox2.Text + "]");
                SW.WriteLine();
                int ascii = 32;
                foreach (Character C in CData)
                {
                    string bytes = "";
                    for (int i = 0; i < 8; ++i)
                    {
                        bytes += "0x" + C.glyfData[i].ToString("X2");
                        if (i < 7) bytes += ", ";
                    }
                    bytes += "//ASCII " + ascii.ToString() + ": " + ((char)ascii++).ToString();
                    SW.WriteLine(bytes);
                }

                SW.Flush();
                SW.Close();*/
                if(Path.GetExtension(filePath).ToLower() == ".fwx")
                {
                    saveAsFWX(filePath);
                }
                else
                {
                    saveAsText(filePath);
                }
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //prompt to save
            clearImage(img);
            CData.Clear();
            filePath = "";
            this.Text = "Font Worx (Unsaved File)";
            textBox2.Text = "New Font";
            for (int i = 32; i < 127; ++i)
            {
                CData.Add(new Character((char)i));
            }
            listBox1.SelectedIndex = 0;
            for (int i = 0; i < 8; ++i)
            {
                for (int j = 0; j < 8; ++j)
                {
                    datArray[i, j] = false;
                }
            }
            if (FontPreview != null && FontPreview.IsDisposed == false) FontPreview.updateData(CData);
        }

        private void invertButton_Click(object sender, EventArgs e)
        {
            invert();
            if (FontPreview != null && FontPreview.IsDisposed == false) FontPreview.updateData(CData);
        }

        private void invert()
        {
            for (int i = 0; i < 8; ++i)
            {
                for (int j = 0; j < 8; ++j)
                {
                    if (datArray[i, j] == true) datArray[i, j] = false;
                    else datArray[i, j] = true;
                }
            }
            textBox1.Text = compileImage();
            //int[] bytes = new int[8];
            for (int i = 0; i < 8; ++i)
            {
                int val = 0;
                for (int j = 0; j < 8; ++j)
                {
                    if (datArray[i, j])
                    {
                        val |= (1 << j);
                    }
                }
                setImgByte(val, i);
            }
            int[] bytes = new int[8];
            for (int i = 0; i < 8; ++i)
            {
                int val = 0;
                for (int j = 0; j < 8; ++j)
                {
                    if (datArray[i, j])
                    {
                        val |= (1 << j);
                    }
                }
                bytes[i] = val;
            }
            CData[currentChar].glyfData = bytes;

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Written By Zach Thompson \r\nSubmit all bugs to FontWorx@gmail.com");
            AboutPage AP = new FontWorx.AboutPage();
            AP.Show();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //SystemSounds.Asterisk.Play();
            SystemSounds.Hand.Play();
            MessageBox.Show("Help!!!");
        }

        private void invertAllButton_Click(object sender, EventArgs e)
        {
            int curSelect = listBox1.SelectedIndex;
            int idx = 0;
            foreach(Character c in CData)
            {
                listBox1.SetSelected(idx++, true);
                invert();
            }
            listBox1.SetSelected(curSelect, true);
            if (FontPreview != null && FontPreview.IsDisposed == false) FontPreview.updateData(CData);
        }

        private void Main_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(FontPreview != null)
            {
                if (FontPreview.IsDisposed)
                {
                    FontPreview = new Previewer(CData, this);
                    FontPreview.Show();
                    testImageButton.Text = "Update Preview";
                }
                else
                {
                    FontPreview.BringToFront();
                    FontPreview.updateData(CData);
                }
            }
            else
            {
                FontPreview = new Previewer(CData, this);
                FontPreview.Show();
                testImageButton.Text = "Update Preview";

            }
            //Previewer P = new FontWorx.Previewer(CData);
            //P.Show();
        }

        public void previewClose()
        {
            testImageButton.Text = "Generate Test IMG";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //If the text is changed, generate the character from the text
            
        }
    }
}


