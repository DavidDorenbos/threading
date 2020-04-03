using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace FootballAIGame {

    public class Team {

        public LinkedList<FootballPlayer> players { get; set; }
        public bool hasBall = false;
        public Vector2 scoreLocation { get; set; }

        public Team(LinkedList<FootballPlayer> players) {
            this.players = players;
        }

       
        public void Update() {
            foreach(FootballPlayer player in players) {
                player.Update();
            }
        }

        public void setTeam()
        {
            foreach(FootballPlayer player in players)
            {
                player.team = this;
            }
        }
        public void Draw() {
            foreach(FootballPlayer player in players) {
                player.Draw();
            }
        }
    }
}
