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
            pos = new Vector2(100, 100);
            dims = new Vector2(30, 30);
            mySprite = Globals.content.Load<Texture2D>("2d/Ball");
        }

        public void Update()
        {

        }

        public void Draw() {
            if (mySprite != null) {
                //these 3 lines are 1 line
                Globals.spriteBatch.Draw(mySprite, new Rectangle((int)pos.X, (int)pos.Y, (int)dims.X, (int)dims.Y),
                    null, Color.White, 0.0f, new Vector2(mySprite.Bounds.Width / 2, mySprite.Bounds.Height / 2),
                    new SpriteEffects(), 0);
            }
        }
    }
}
