using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace FootballAIGame.Source
{
    public class TeamManagement
    {
        Vector2 playerDims;
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
                "Frits", 10, 10, 10, "2d/sprite", "human"));
            OwnedPlayers.Add(new FootballPlayer(playerDims, new Vector2(200, 60),
                "Jan", 10, 10, 10, "2d/sprite", "midfielder"));
            OwnedPlayers.Add(new FootballPlayer(playerDims, new Vector2(200, 500),
                "Pieter", 10, 10, 10, "2d/sprite", "midfielder"));
            OwnedPlayers.Add(new FootballPlayer(playerDims, new Vector2(360, 60),
                "Kees", 10, 10, 10, "2d/sprite", "attacker"));
        }
    }
}
