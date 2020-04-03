using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace FootballAIGame.Source
{
    public class TeamManagement
    {
        Vector2 playerDims;
        Field field;
        public List<FootballPlayer> OwnedPlayers { get; set; }
        public TeamManagement()
        {
            OwnedPlayers = new List<FootballPlayer>();
            SetDefaultTeam();
        }
 

        public void SetDefaultTeam()
        {
            playerDims = new Vector2(48, 48);
            OwnedPlayers = new List<FootballPlayer>();
            OwnedPlayers.Add(new FootballPlayer(playerDims, new Vector2(0, 0),
                "humanplayer", 10, 10, 10, "2d/sprite", "human"));
            OwnedPlayers.Add(new FootballPlayer(playerDims, new Vector2(200, 60),
                "midfielder", 10, 10, 10, "2d/sprite", "midfielder"));
            OwnedPlayers.Add(new FootballPlayer(playerDims, new Vector2(200, 500),
                "midfielder", 10, 10, 10, "2d/sprite", "midfielder"));
            OwnedPlayers.Add(new FootballPlayer(playerDims, new Vector2(360, 60),
                "attacker", 10, 10, 10, "2d/sprite", "attacker"));
        }
    }
}
