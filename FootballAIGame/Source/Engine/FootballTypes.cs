using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace FootballAIGame
{
    class FootballTypes
    {
        public static void DefenderAI(FootballPlayer player) {
            
        }

        public static void AttackerAI(FootballPlayer player) {

        }

        public static void MidfielderAI(FootballPlayer player) {
            
        }

        public static void KeeperAI(FootballPlayer player) {

        }

        public static void HumanPlayer(FootballPlayer player) {
            if(Globals.keyboard.GetPress("W")){
                player.move();
                player.move();
            }
            if (Globals.keyboard.GetPress("A")) {
                player.AddDirection(-2);
            }
            if (Globals.keyboard.GetPress("S")) {
                player.move();
            }
            if (Globals.keyboard.GetPress("D")) {
                player.AddDirection(2);
            }
        }

    }
}
