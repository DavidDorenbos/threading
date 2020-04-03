using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace FootballAIGame {

    class Team {

        public LinkedList<FootballPlayer> players { get; }
        public bool hasBall = false;

        public Team(LinkedList<FootballPlayer> players) {
            this.players = players;
        }

       
        public void Update() {
            foreach(FootballPlayer player in players) {
                player.Update();
            }
        }

        public void Draw() {
            foreach(FootballPlayer player in players) {
                player.Draw();
            }
        }
    }
}
