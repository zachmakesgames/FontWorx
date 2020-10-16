using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FontWorx
{
    [Serializable]
    public class Character
    {
        public char ID = (char)0;
        public int[] glyfData;
        string glyfString = "";

        public Character(char _ID)
        {
            ID = _ID;
            glyfData = new int[8];
            for (int i = 0; i < 8; ++i) glyfData[i] = 0;//clear the glyf data
            glyfString = "0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00";
        }
        public Character(char _ID, int[] newGlyf)
        {
            ID = _ID;
            glyfData = newGlyf;
        }

        public Character(char _ID, string newGlyfString)
        {
            ID = _ID;
            glyfString = newGlyfString;
        }
    }
}
