using FootballAIGame.Source;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Framework;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Pickers;
using System;

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
        ScoreBoard board;

        public Main()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            board = new ScoreBoard();
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
            playerDims = new Vector2(48, 48);

            graphics.PreferredBackBufferWidth = 1000;
            graphics.PreferredBackBufferHeight = 500;

            graphics.ApplyChanges();

            this.field = new Field(new Team(new LinkedList<FootballPlayer>(), new LinkedList<Task>()),
                new Team(new LinkedList<FootballPlayer>(), new LinkedList<Task>()), new Ball());

            field.teamHome.players.AddFirst(new FootballPlayer(playerDims, new Vector2(0, 0),
                "humanplayer", 10, 10, 10, "2d/sprite", "human"));
            field.teamHome.players.AddLast(new FootballPlayer(playerDims, new Vector2(200, 60),
                "midfielder", 10, 10, 10, "2d/sprite", "midfielder"));
            field.teamHome.players.AddLast(new FootballPlayer(playerDims, new Vector2(200, 500),
                "midfielder", 10, 10, 10, "2d/sprite", "midfielder"));
            field.teamHome.players.AddLast(new FootballPlayer(playerDims, new Vector2(360, 60),
                "attacker", 10, 10, 10, "2d/sprite", "attacker"));
            SaveMatchHistory(board);
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

        public async void SaveMatchHistory(ScoreBoard gameBoard)
        {
            //Now score is set here, needs to be set when the game is finished
            gameBoard.OutScore = 7;
            gameBoard.HomeScore = 77;
            //string json = JsonConvert.SerializeObject(gameBoard);
            List<ScoreBoard> boards = new List<ScoreBoard>();
            boards.Add(gameBoard);
            boards.Add(gameBoard);
            string outputJSON = Newtonsoft.Json.JsonConvert.SerializeObject(boards, Newtonsoft.Json.Formatting.Indented);
            //string jsonBoards = JsonConvert.SerializeObject(boards, Formatting.Indented);
            var item = await ApplicationData.Current.LocalFolder.TryGetItemAsync("ScoreBoard.json");

            if (item != null)
            {
                String JSONtxt = File.ReadAllText(ApplicationData.Current.LocalFolder.Path + "/ScoreBoard.json");
                boards = JsonConvert.DeserializeObject<List<ScoreBoard>>(JSONtxt);
                

                //string outputJSON = Newtonsoft.Json.JsonConvert.SerializeObject(boards, Newtonsoft.Json.Formatting.Indented);
                var file = await ApplicationData.Current.LocalFolder.GetFileAsync("ScoreBoard.json");
                await FileIO.WriteTextAsync(file, outputJSON + Environment.NewLine);
            }
            else
            {
                var file = await ApplicationData.Current.LocalFolder.CreateFileAsync("ScoreBoard.json");
                await FileIO.WriteTextAsync(file, outputJSON);
            }




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