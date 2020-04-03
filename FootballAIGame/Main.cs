using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;


namespace FootballAIGame
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Main : Game
    {
        GraphicsDeviceManager graphics;
        Field field;
        Vector2 playerDims;

        public Main()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            base.Initialize();
            playerDims = new Vector2(60, 60);

            graphics.PreferredBackBufferWidth = 1000;
            graphics.PreferredBackBufferHeight = 500;

            graphics.ApplyChanges();

            this.field = new Field(new Team(new LinkedList<FootballPlayer>()), 
                new Team(new LinkedList<FootballPlayer>()), new Ball());

            field.teamHome.players.AddFirst(new FootballPlayer(playerDims, new Vector2(30, 30), 
                "humanplayer", 10, 10, 10, "2d/sprite", "human"));
            field.teamHome.players.AddLast(new FootballPlayer(playerDims, new Vector2(200, 60),
                "midfielder", 10, 10, 10, "2d/sprite", "midfielder"));
            field.teamHome.players.AddLast(new FootballPlayer(playerDims, new Vector2(200, 500),
                "midfielder", 10, 10, 10, "2d/sprite", "midfielder"));
            field.teamHome.players.AddLast(new FootballPlayer(playerDims, new Vector2(360, 60),
                "attacker", 10, 10, 10, "2d/sprite", "attacker"));

            field.teamOut.players.AddLast(new FootballPlayer(playerDims, new Vector2(600, 400),
    "attacker", 10, 10, 10, "2d/sprite", "attacker"));


            field.InitiateTasks();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            Globals.content = this.Content;
            Globals.spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            Globals.keyboard = new McKeyboard();
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // TODO: Add your update logic here
            Globals.keyboard.Update();
            field.Update();
            Globals.keyboard.UpdateOld();
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            Globals.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend);
            field.Draw();
            Globals.spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
