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

    class Field {

        private Team teamHome;
        private Team teamOut;
        private Ball ball;
        //public Field() {
        //players = new LinkedList<FootballPlayer>();
        //players.AddFirst(new FootballPlayer("2d/sprite", new Vector2(300, 300), new Vector2(48, 48)));
        //}

        public Field(Team teamHome, Team teamOut, Ball ball)
        {
            this.teamHome = teamHome;
            this.teamOut = teamOut;
            this.ball = ball;
        }

        public void Update() {
            teamHome.Update();
            teamOut.Update();
            ball.Update();
        }

        public void Draw() {
            teamHome.Draw();
            teamOut.Draw();
            ball.Draw();
        }
    }
}
