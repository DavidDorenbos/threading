#region Includes
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
#endregion

namespace FootballAIGame { 
    public class Globals {
        public static ContentManager content;
        public static SpriteBatch spriteBatch;
        public static McKeyboard keyboard;
        public static int screenWidth;
        public static int screenHeight;
        public static Ball ball;
        public static float top = 50, bot = 450, left = 50, right = 950;

        public static bool OutOfBounds(Vector2 location)
        {
            if(location.Y <= top || location.Y >= bot || location.X <= left || location.X >= right) {
                return true;
            }
            return false;
        }
    }
}