using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FontWorx
{
    [Serializable]
    public class CharacterSet
    {
        public string Name;
        public List<Character> Chars = new List<Character>();

        public CharacterSet(String newName)
        {
            Name = newName;
        }

        public CharacterSet(String newName, List<Character> Characters)
        {
            Name = newName;
            Chars.AddRange(Characters);
        }

        public CharacterSet()
        {
            Name = "";
        }

        public bool loadFromFile(string fileName)
        {
            try
            {
                List<string> lines = new List<string>();
                if (!File.Exists(fileName))
                {
                    MessageBox.Show("File does not exist!");
                    return false;
                }
                if (Path.GetExtension(fileName).ToLower() == ".fwx")
                {
                    try
                    {
                        IFormatter formatter = new BinaryFormatter();
                        using (FileStream fs = File.OpenRead(fileName))
                        {
                            CharacterSet temp = (CharacterSet)formatter.Deserialize(fs);
                            Name = temp.Name;
                            Chars = temp.Chars;
                        }
                        return true;
                    }
                    catch
                    {
                        //MessageBox.Show("An error occured while opening the file");
                        return false;
                    }

                }
                StreamReader SR = new StreamReader(fileName);
                string l = "";
                while ((l = SR.ReadLine()) != null)
                {
                    if (l.Trim() != "") lines.Add(l);
                }
                if (lines[0][0] != '{')
                {
                    MessageBox.Show("Bad File Start Syntax");
                    return false;
                }
                if (lines[1][0] != '[')
                {
                    MessageBox.Show("Missing font name or bad syntax");
                    return false;
                }

                string name = lines[1];
                name = name.TrimStart('[').TrimEnd(']');
                name = name.Trim(' ');
                Name = name;
                int id = 0;
                foreach (string ln in lines)
                {
                    if (ln[0] == '{' || ln[0] == '[' || ln[0] == '#') continue;//Skip over line starts
                    Character tmp = new Character((char)(id++));
                    string line = "";
                    if (ln.Contains("//"))
                    {
                        line = ln.Split('/')[0];
                    }
                    else line = ln;

                    string[] vals = line.Split(',');
                    int[] glyfDat = new int[8];
                    int i = 0;
                    foreach (string s in vals)
                    {
                        string tmpVal = s.Trim(',');
                        tmpVal = tmpVal.Trim(' ');
                        tmpVal = tmpVal.Split('x')[1];
                        glyfDat[i++] = Convert.ToInt32(tmpVal, 16);
                    }
                    tmp.glyfData = glyfDat;
                    Chars.Add(tmp);
                }
                SR.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
