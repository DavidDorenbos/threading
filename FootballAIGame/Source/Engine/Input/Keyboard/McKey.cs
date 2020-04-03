#region Includes
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Media;
#endregion

namespace FootballAIGame
{
    public class McKey
    {
        public int state;
        public string key, print, display;


        public McKey(string KEY, int STATE)
        {
            key = KEY;
            state = STATE;
            MakePrint(key);
        }

        public virtual void Update()
        {
            state = 2;

        }


        public void MakePrint(string KEY)
        {
            display = KEY;

            string tempStr = "";

            if (KEY == "A" || KEY == "B" || KEY == "C" || KEY == "D" || KEY == "E" || KEY == "F" || KEY == "G" || KEY == "H" || KEY == "I" || KEY == "J" || KEY == "K" || KEY == "L" || KEY == "M" || KEY == "N" || KEY == "O" || KEY == "P" || KEY == "Q" || KEY == "R" || KEY == "S" || KEY == "T" || KEY == "U" || KEY == "V" || KEY == "W" || KEY == "X" || KEY == "Y" || KEY == "Z")
            {
                tempStr = KEY;
            }
            if (KEY == "Space")
            {
                tempStr = " ";
            }
            print = tempStr;
        }
    }
}