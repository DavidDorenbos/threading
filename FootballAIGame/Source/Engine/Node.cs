using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
namespace FootballAIGame
{
    class Node
    {
        public LinkedList<FootballPlayer> players = new LinkedList<FootballPlayer>();
        public void RunTask() {
            Task task = Task.Run(() => { 
                foreach(FootballPlayer player in players) {
                    player.Update();
                }
            });
        }
    }
}
