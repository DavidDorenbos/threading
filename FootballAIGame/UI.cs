


using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FootballAIGame
{
    public class UI
    {
        public SpriteFont font;
        public UI()
        {
            font = Globals.content.Load<SpriteFont>("Fonts\\Arial16");
        }

        public void Update(Field field)
        {

        }

        public void Draw(Field field)
        {
            string tempStr = "Scored" + field.scoreBoard.HomeScore;
            Vector2 strDims = font.MeasureString(tempStr);
            Globals.spriteBatch.DrawString(font, tempStr, new Vector2(Globals.screenWidth/2 - strDims.X/2, Globals.screenHeight - 40), Color.Black);
        }
    }
}
