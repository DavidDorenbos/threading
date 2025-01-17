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
    public class FootballPlayer
    {
        public Vector2 pos;
        public Vector2 startLocation;
        public Vector2 dims;
        public Vector2 focus;
        public string name;
        public int speed;
        public int strength;
        public int price;
        private string path;
        public Texture2D mySprite;
        private delegate void Del(FootballPlayer player);
        private Del delegateMovement;
        public float direction;
        public string playerType;
        public bool hasBall;
        public bool hadDistance;
        public bool moving;
        public Team team { get; set; }
        

        public string NamePropertyBinding { get; set; }
        public string PlayerTypePropertyBinding { get; set; }
        public int SpeedPropertyBinding { get; set; }
        public int StrengthPropertyBinding { get; set; }
        public int PricePropertyBinding { get; set; }

        public FootballPlayer(Vector2 dims, Vector2 pos, string name, int speed,
            int strength, int price, string path, string playerType) {
            this.pos = pos;
            this.dims = dims;
            this.name = name;
            this.speed = speed;
            this.strength = strength;
            this.price = price;
            this.direction = 0;
            hasBall = false;
            this.path = path;
            SetDeligate(playerType);
            this.playerType = playerType;
            hadDistance = true;


            this.NamePropertyBinding = name;
            this.PlayerTypePropertyBinding = playerType;
            this.SpeedPropertyBinding = speed;
            this.StrengthPropertyBinding = speed;
            this.PricePropertyBinding = price;


            startLocation = new Vector2(pos.X, pos.Y);

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
        public Vector2 move(Vector2 pos) {
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
            return Globals.OutOfBounds(new Vector2(pos.X + x, pos.Y + y)) ? pos : new Vector2(pos.X + x, pos.Y + y);
        }

        public Vector2 scoreLocation()
        {
            return team.scoreLocation;
        }

        public void AddDirection(float amount) {
            direction = direction + amount;
            if(direction < 0) {
                direction = 360 - direction;
            }
            else if(direction > 360) {
                direction = direction - 360;
            }
        }

        public float GetDistanceFromStart()
        {
            return (float)Math.Sqrt(Math.Pow(startLocation.X - pos.X, 2) + Math.Pow(startLocation.Y - pos.Y, 2));
        }


        public void setHadDistance()
        {
            if(!hadDistance && Globals.ball.GetDistance(this.pos) > 50f) {
                hadDistance = true;
            }
        }
        public void Shoot(FootballPlayer player)
        {
            if(player.hasBall) {
                Globals.ball.Shoot(player.direction);
                player.hasBall = false;
            }
        }
        
        public void GetBall()
        {
            if(Globals.ball.GetDistance(this.pos) < 10f && hadDistance) {
                hasBall = true;
            }
            else {
                hasBall = false;
            }
        }


        private void MoveBall()
        {
            if (hasBall && Globals.ball.GetDistance(pos) < 15f && moving) {
                Globals.ball.pos = move(Globals.ball.pos);
                Globals.ball.pos = move(Globals.ball.pos);
            }
        }

        public void Update() { 
            delegateMovement(this);
            MoveBall();
        }

        public void Draw() {
            mySprite = Globals.content.Load<Texture2D>(path);
            if (mySprite != null) {
                Globals.spriteBatch.Draw(mySprite, new Rectangle((int)pos.X, (int)pos.Y, (int)dims.X, (int)dims.Y),
                    null, Color.White, direction * (float)Math.PI*2 / 360, new Vector2(mySprite.Bounds.Width / 2, mySprite.Bounds.Height / 2),
                    new SpriteEffects(), 0);
            }
        }
    }
}

