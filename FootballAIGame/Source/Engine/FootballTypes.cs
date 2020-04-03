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
            player.pos = player.move(player.pos);
        }

        public static void MidfielderAI(FootballPlayer player) {
            
        }

        public static void KeeperAI(FootballPlayer player) {

        }

        public static void HumanPlayer(FootballPlayer player) {
            if(Globals.keyboard.GetPress("W")){
                player.pos = player.move(player.pos);
                player.pos = player.move(player.pos);
                player.moving = true;
            }
            else {
                player.moving = false;
            }
            if (Globals.keyboard.GetPress("A")) {
                player.AddDirection(-2);
            }
            if (Globals.keyboard.GetPress("S")) {
                player.pos = player.move(player.pos);
            }
            if (Globals.keyboard.GetPress("D")) {
                player.AddDirection(2);
            }
            if (Globals.keyboard.GetPress("Space"))
            {
                player.Shoot(player);
            }
        }
    }
}
