using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            player.key.Update();
            if (player.key.GetPress("w")) {
                
            }
        }

    }
}
