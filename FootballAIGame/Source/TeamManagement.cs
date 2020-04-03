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
            this.field = new Field(new Team(new LinkedList<FootballPlayer>(), new LinkedList<Task>()),
       new Team(new LinkedList<FootballPlayer>(), new LinkedList<Task>()), new Ball());
            playerDims = new Vector2(48, 48);
            OwnedPlayers = new List<FootballPlayer>();
            field.teamHome.players.AddFirst(new FootballPlayer(playerDims, new Vector2(0, 0),
                "humanplayer", 10, 10, 10, "2d/sprite", "human"));
            field.teamHome.players.AddLast(new FootballPlayer(playerDims, new Vector2(200, 60),
                "midfielder", 10, 10, 10, "2d/sprite", "midfielder"));
            field.teamHome.players.AddLast(new FootballPlayer(playerDims, new Vector2(200, 500),
                "midfielder", 10, 10, 10, "2d/sprite", "midfielder"));
            field.teamHome.players.AddLast(new FootballPlayer(playerDims, new Vector2(360, 60),
                "attacker", 10, 10, 10, "2d/sprite", "attacker"));
        }
    }
}
