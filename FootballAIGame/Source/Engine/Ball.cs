using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;



namespace FootballAIGame
{
    class Ball
    {
        private Vector2 pos;
        private Vector2 dims;
        public Texture2D mySprite;

        public Ball()
        {
            pos = new Vector2(9, 9);
            dims = new Vector2(9, 9);
            mySprite = Globals.content.Load<Texture2D>("2d/sprite");
        }

        public void Update() {

        }

        public void Draw() {

        }
    }
}
