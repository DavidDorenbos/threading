using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace FootballAIGame {

    public class Team {

        public LinkedList<FootballPlayer> players { get; set; }
        LinkedList<Task> tasks;

        public Team(LinkedList<FootballPlayer> players, LinkedList<Task> tasks)
        {
            this.players = players;
            this.tasks = tasks;
        }

        public void SetTasks() {

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
