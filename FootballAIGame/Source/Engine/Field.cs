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
using System.Diagnostics;
using FootballAIGame.Source;
using Windows.UI.Xaml;
#endregion

//TODO: add debug key ;
namespace FootballAIGame {

    public class Field {

        public Team teamHome;
        public Team teamOut;
        private Ball ball;
        private Texture2D goal;
        private Dictionary<string, Node> tasks = new Dictionary<string, Node>();
        //public Field() {
        //players = new LinkedList<FootballPlayer>();
        //players.AddFirst(new FootballPlayer("2d/sprite", new Vector2(300, 300), new Vector2(48, 48)));
        //}


        public Field(Team teamHome, Team teamOut, Ball ball)
        {
            this.teamHome = teamHome;
            this.teamOut = teamOut;
            this.ball = ball;
            _debug();
            goal = Globals.content.Load<Texture2D>("2d/Goal");
        }
        public LinkedList<FootballPlayer> AllPlayers() {
            LinkedList<FootballPlayer> players = new LinkedList<FootballPlayer>();
            foreach(FootballPlayer player in teamHome.players) {
                players.AddLast(player);
            }
            foreach (FootballPlayer player in teamOut.players) {
                players.AddLast(player);
            }
            return players;
        }
        public void InitiateTasks() {
            tasks.Add("human", new Node());
            tasks.Add("keeper", new Node());
            tasks.Add("defender", new Node());
            tasks.Add("midfielder", new Node());
            tasks.Add("attacker", new Node());
            SetTasks(teamHome.players);
            SetTasks(teamOut.players);
        }
        private void SetTasks(LinkedList<FootballPlayer> players)
        {
            foreach(FootballPlayer player in players) {
                tasks.TryGetValue(player.playerType, out Node node);
                node.players.AddLast(player);
            }
        }
        private void _debug() {
            foreach(KeyValuePair<string, Node> entry in tasks)
            {
                Debug.WriteLine("Key: {0} ValueCount: {1} ", entry.Key, entry.Value.players.Count);
            }
        }
        public ScoreBoard Board { get; set; }
        public void Update() {
            foreach (KeyValuePair<string, Node> entry in tasks) {
                entry.Value.RunTask();
            }
            Task.Run(() => { PlayerOnBall(); });
            ball.Update();
        }



        private void PlayerOnBall() {
            if (!teamHome.hasBall) {
                foreach(FootballPlayer player in teamHome.players) {
                    if (Globals.ball.GetDistance(player.pos) < 5f && player.hadDistance && !Globals.ball.shot) {
                        player.hasBall = true;
                        player.hadDistance = false;
                        teamHome.hasBall = true;
                        teamOut.hasBall = false;
                        TakeBall(teamOut);
                        Globals.ball.taken = true;
                    }
                    player.setHadDistance();
                }
            }
            if(!teamOut.hasBall) {
                foreach(FootballPlayer player in teamOut.players) {
                    if (Globals.ball.GetDistance(player.pos) < 5f && player.hadDistance && !Globals.ball.shot)
                    {
                        player.hasBall = true;
                        player.hadDistance = false;
                        teamHome.hasBall = false;
                        teamOut.hasBall = true;
                        TakeBall(teamHome);
                        Globals.ball.taken = true;
                    }
                    player.setHadDistance();
                }
            }
        }
        private void TakeBall(Team team)
        {
            foreach(FootballPlayer player in team.players) {
                player.hasBall = false;
            }
        }
        
        private void hasShot()
        {
            if (Globals.ball.shot) {
                foreach(FootballPlayer player in teamHome.players)
                {
                    player.hasBall = false;
                    player.hadDistance = true;
                }
                foreach(FootballPlayer player in teamOut.players)
                {
                    player.hasBall = false;
                    player.hadDistance = true;
                }
                teamHome.hasBall = false;
                teamOut.hasBall = false;
            }
        }
        public void drawGoal(Vector2 pos)
        {
            Vector2 dims = new Vector2(50, 145);
            //these 3 lines are 1 line
            Globals.spriteBatch.Draw(goal, new Rectangle((int)pos.X, (int)pos.Y, (int)dims.X, (int)dims.Y),
                null, Color.White, 0.0f, new Vector2(goal.Bounds.Width / 2, goal.Bounds.Height / 2),
                new SpriteEffects(), 0);

        }
        public void Draw() {
            teamHome.Draw();
            teamOut.Draw();
            ball.Draw();
            hasShot();
            drawGoal(new Vector2(25, 50));
        }
    }
}
