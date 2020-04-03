


using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FootballAIGame
{
    public class UI
    {
        public SpriteFont font;
        private ScoreBoard board;
        public UI()
        {
            font = Globals.content.Load<SpriteFont>("Fonts\\Arial16");
            board = new ScoreBoard();
        }

        public void Update()
        {

        }

        public void goalHome()
        {
            board.HomeScore += 1;
        }

        public void goalOut()
        {
            board.OutScore += 1;
        }

        public void Draw()
        {
            Globals.spriteBatch.DrawString(font, ("Score: Home " + board.HomeScore + " : Out " + board.OutScore ), new Vector2(10, 100), Color.Black);
        }
    }
}
