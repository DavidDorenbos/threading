using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace FootballAIGame {

    class Team {

        LinkedList<FootballPlayer> players;
        LinkedList<Task> tasks;

        public Team(LinkedList<FootballPlayer> players, LinkedList<Task> tasks)
        {
            this.players = players;
            this.tasks = tasks;
            players.AddFirst(new FootballPlayer(new Vector2(48, 48), new Vector2(300, 300), "humanplayer", 10, 10, 10, "2d/sprite", "human"));
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
