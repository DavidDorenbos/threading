using FootballAIGame.Source;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Framework;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Threading;
using Windows.Storage;
using Windows.Storage.Pickers;
using System;
using System.Diagnostics;

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
            playerDims = new Vector2(60, 60);

            graphics.PreferredBackBufferWidth = 1000;
            graphics.PreferredBackBufferHeight = 500;

            graphics.ApplyChanges();

            this.field = new Field(new Team(new LinkedList<FootballPlayer>()), 
                new Team(new LinkedList<FootballPlayer>()), new Ball());

            field.teamHome.players.AddFirst(new FootballPlayer(playerDims, new Vector2(60, 60), 

                "Frits", 10, 10, 10, "2d/sprite", "human"));
            field.teamHome.players.AddLast(new FootballPlayer(playerDims, new Vector2(200, 60),
                "Jan", 10, 10, 10, "2d/sprite", "midfielder"));
            field.teamHome.players.AddLast(new FootballPlayer(playerDims, new Vector2(200, 500),
                "Pieter", 10, 10, 10, "2d/sprite", "midfielder"));
            field.teamHome.players.AddLast(new FootballPlayer(playerDims, new Vector2(360, 60),

                "Kees", 10, 10, 10, "2d/sprite", "attacker"));

 

            field.teamOut.players.AddLast(new FootballPlayer(playerDims, new Vector2(600, 400),
                "attacker", 10, 10, 10, "2d/sprite", "attacker"));



            field.InitiateTasks();

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
            List<ScoreBoard> boards = new List<ScoreBoard>();
            boards.Add(gameBoard);
            boards.Add(gameBoard);
            string outputJSON = Newtonsoft.Json.JsonConvert.SerializeObject(boards, Newtonsoft.Json.Formatting.Indented);

            var item = await ApplicationData.Current.LocalFolder.TryGetItemAsync("ScoreBoard.json");

            if (item != null)
            {
                String JSONtxt = File.ReadAllText(ApplicationData.Current.LocalFolder.Path + "/ScoreBoard.json");
                boards = JsonConvert.DeserializeObject<List<ScoreBoard>>(JSONtxt);
                boards.Add(gameBoard);
                string jsonBoards = JsonConvert.SerializeObject(boards, Formatting.Indented);

               // string outputJSONN = Newtonsoft.Json.JsonConvert.SerializeObject(boards, Newtonsoft.Json.Formatting.Indented);
                var file = await ApplicationData.Current.LocalFolder.GetFileAsync("ScoreBoard.json");
                await FileIO.WriteTextAsync(file, jsonBoards + Environment.NewLine);
            }
            else
            {
                var file = await ApplicationData.Current.LocalFolder.CreateFileAsync("ScoreBoard.json");
                await FileIO.WriteTextAsync(file, outputJSON);
            }



        }

        private void Goal() {
            if(Globals.ball.pos.Y > 250-70 && Globals.ball.pos.Y < 250 + 70) {
                if(Globals.ball.pos.X <= 50) {
                    board.OutScore += 1;
                    Debug.WriteLine("Score: Home{0},  Out{1}", board.HomeScore, board.OutScore);
                }
                else if(Globals.ball.pos.X >= 950) {
                    board.HomeScore += 1;
                    Debug.WriteLine("Score: Home{0},  Out{1}", board.HomeScore, board.OutScore);
                }
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
            Goal();
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