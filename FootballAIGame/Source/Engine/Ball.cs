using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;



namespace FootballAIGame
{
    public class Ball
    {
        public Vector2 pos;
        private Vector2 dims;
        public Texture2D mySprite;
        public static float playerDistance = 8f;
        public bool taken;
        public bool shot;
        public float shotSpeed;
        public float direction;
        private bool bounceBool;
        public Ball()
        {
            pos = new Vector2(100, 100);
            dims = new Vector2(20, 20);
            Globals.ball = this;
            taken = false;
            shotSpeed = 0f;
            bounceBool = false;
            
        }
        public void Shoot(float direction) {
            if (taken){
                taken = false;
                shotSpeed = 12f;
                this.direction = direction;
                shot = true;
                Task a = new Task(() => {
                    shot = false;
                });
                a.Wait(50);
                a.Start();
            }
        }

        public void Update() {
            if (!taken) {
                moveShot();
                if (shotSpeed > 0) {
                    shotSpeed -= 0.1f;
                }
                else {
                    shotSpeed = 0f;
                }
            }
            else {
                shotSpeed = 0f;
            }
        }

        private void moveShot()
        {
            float x = 0, y = 0;
            if (direction <= 90)
            {
                x = 0 + direction / 90;
                y = (1 - direction / 90) * -1;
            }
            else if (direction <= 180)
            {
                x = 1 - (direction - 90) / 90;
                y = 0 + (direction - 90) / 90;
            }
            else if (direction <= 270)
            {
                x = 0 - (direction - 180) / 90;
                y = 1 - (direction - 180) / 90;
            }
            else if (direction <= 360)
            {
                x = (1 - (direction - 270) / 90) * -1;
                y = (0 + (direction - 270) / 90) * -1;
            }
            x *= shotSpeed;
            y *= shotSpeed;
            if (bounce())
            {
                moveShot();
            }
            else
            {
                pos = new Vector2(pos.X + x, pos.Y + y);
            }
        }
        private bool bounce()
        {
            
            if (Globals.OutOfBounds(pos) && !bounceBool)
            {
                bounceBool = true;
                if(pos.Y <= Globals.top) {
                    if(direction <= 180){
                        direction = 180 - direction;
                    }
                    else {
                        float plus = 360 - direction;
                        direction = 180 + plus;
                    }
                } 
                else if(pos.Y >= Globals.bot)
                {
                    float min = direction - 180;
                    direction = 360 - min;
                }
                else if (pos.X <= Globals.left)
                {
                    float dif = direction - 90;
                    float min = 360 - dif;                       
                    direction = 270 + min;
                }
                else if (pos.X >= Globals.right)
                {
                    float dif = direction + 90;
                    float min = 360 - dif;
                    direction = 90 + min;
                }
                if (direction > 360)
                {
                    direction -= 360;
                }
                if(direction < 0)
                {
                    direction += 360;
                }
                return true;
            }
            bounceBool = false;
            return false;
        }



        public float GetDistance(Vector2 target)
        {
            return (float)Math.Sqrt(Math.Pow(pos.X - target.X, 2) + Math.Pow(pos.Y - target.Y, 2));
        }

        public void Draw() {
            mySprite = Globals.content.Load<Texture2D>("2d/Ball");
            if (mySprite != null) {
                //these 3 lines are 1 line
                Globals.spriteBatch.Draw(mySprite, new Rectangle((int)pos.X, (int)pos.Y, (int)dims.X, (int)dims.Y),
                    null, Color.White, 0.0f, new Vector2(mySprite.Bounds.Width / 2, mySprite.Bounds.Height / 2),
                    new SpriteEffects(), 0);
            }
        }
    }
}
