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

namespace FootballAIGame
{
    public class FootballPlayer
    {
        public Vector2 pos;
        public Vector2 dims;
        public Vector2 focus;
        public string name;
        public int speed;
        public int strength;
        public int price;
        public Texture2D mySprite;
        private delegate void Del(FootballPlayer player);
        private Del delegateMovement;
        public float direction;

        public FootballPlayer(Vector2 dims, Vector2 pos, string name, int speed,
            int strength, int price, string path, string playerType) {
            this.pos = pos;
            this.dims = dims;
            this.name = name;
            this.speed = speed;
            this.strength = strength;
            this.price = price;
            this.direction = 0;

            mySprite = Globals.content.Load<Texture2D>(path);
            SetDeligate(playerType);
        }

        private void SetDeligate(string playerType) {
            switch (playerType) {
                case "human":
                    delegateMovement = FootballTypes.HumanPlayer;
                    break;
                case "keeper":
                    delegateMovement = FootballTypes.KeeperAI;
                    break;
                case "defender":
                    delegateMovement = FootballTypes.DefenderAI;
                    break;
                case "midfielder":
                    delegateMovement = FootballTypes.MidfielderAI;
                    break;
                case "attacker":
                    delegateMovement = FootballTypes.AttackerAI;
                    break;
            }
        }
        //TODO: ask 
        public void move() {
            float x = 0, y = 0;
            if(direction <= 90) {
                x = 0 + direction / 90;
                y = (1 - direction / 90) * -1;
            }
            else if(direction <= 180) {
                x = 1 - (direction - 90) / 90;
                y = 0 + (direction - 90) / 90;
            }
            else if(direction <= 270) {
                x = 0 - (direction - 180) / 90;
                y = 1 - (direction - 180) / 90;
            }
            else if(direction <= 360) {
                x = (1 - (direction - 270) / 90) * -1;
                y = (0 + (direction - 270) / 90) * -1;
            }
            pos = new Vector2(pos.X + x, pos.Y + y);
        }

        public void AddDirection(float amount) {
            direction = direction + amount;
            if(direction < 0) {
                direction = 358;
            }
            else if(direction > 360) {
                direction = 2;
            }
        }
        //TODO: write out of bounds
        private Boolean OutOfBounds() {
            return true;
        }


        public void Update() { 
            delegateMovement(this);
        }

        public void Draw() {
            mySprite = Globals.content.Load<Texture2D>(path);
            if (mySprite != null) {
                //these 3 lines are 1 line
                Globals.spriteBatch.Draw(mySprite, new Rectangle((int)pos.X, (int)pos.Y, (int)dims.X, (int)dims.Y),
                    null, Color.White, direction * (float)Math.PI*2 / 360, new Vector2(mySprite.Bounds.Width / 2, mySprite.Bounds.Height / 2),
                    new SpriteEffects(), 0);
            }
        }
    }
}

