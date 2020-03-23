﻿#region Includes
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
    class FootballPlayer
    {
        public Vector2 pos;
        public Vector2 dims;
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

        public void move() {
            float x = 0, y = 0;
            if(direction <= 100) {
                x = 0 + direction / 100;
                y = (1 - direction / 100) * -1;
            }
            else if(direction <= 200) {
                x = 1 - (direction - 100) / 100;
                y = 0 + (direction - 100) / 100;
            }
            else if(direction <= 300) {
                x = 0 - (direction - 200) / 100;
                y = 1 - (direction - 200) / 100;
            }
            else if(direction <= 400) {
                x = (1 - (direction - 300) / 100) * -1;
                y = (0 + (direction - 300) / 100) * -1;
            }
            pos = new Vector2(pos.X + x, pos.Y + y);
        }

        public void AddDirection(float amount) {
            direction = direction + amount;
            if(direction < 0) {
                direction = 398;
            }
            else if(direction > 400) {
                direction = 2;
            }
        }

        public void Update() { 
            delegateMovement(this);
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