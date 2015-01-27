using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace EmergencyExit
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class GameRoot : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        public SpriteFont font;

        Matrix SpriteScale;

        public ObstacleManager obMgr;

        Floor floor;

        GameOver gameOver;
        PauseMenu pauseMenu;
        About about;


        public static GameRoot Instance { get; private set; }
        public static Viewport Viewport { get { return Instance.GraphicsDevice.Viewport; } }
        public static Vector2 ScreenSize { get { return new Vector2(Viewport.Width, Viewport.Height); } }

        public enum GameState 
        {
            MainMenu, 
            PauseMenu,
            Playing,
            GameOver,
            LevelDone,
            About,
        }
        public static GameState gameState = GameState.MainMenu;

        MainMenu mainMenu;

        public GameRoot()
        {
            graphics = new GraphicsDeviceManager(this);

            Content.RootDirectory = "Content";

            graphics.IsFullScreen = true;
            graphics.SupportedOrientations = DisplayOrientation.LandscapeLeft;

            Instance = this;
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

            about = new About();
            gameOver = new GameOver();
            mainMenu = new MainMenu();
            pauseMenu = new PauseMenu();
            EntityManager.Add(Player.Instance);
            EntityManager.Add(Fire.Instance);

            obMgr = new ObstacleManager();

            floor = new Floor();

            float screenscaleX =
                (((float)graphics.PreferredBackBufferWidth / 1920)); 
            float screenscaleY =
                (((float)graphics.PreferredBackBufferHeight / 1080));
            SpriteScale = Matrix.CreateScale(screenscaleX, screenscaleY, 1);
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            font = Content.Load<SpriteFont>("spriteFont1");



            Art.Load(Content);

        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        /// 
        public static void ResetGame()
        {
            EntityManager.entities.Clear();
            EntityManager.addedEntities.Clear();
   
            EntityManager.Add(Player.Instance);
            EntityManager.Add(Fire.Instance);
        }

        protected override void Update(GameTime gameTime)
        {
            

            switch (gameState)
            {
                case GameState.Playing:
                    {
                        Input.Update();

                        // TODO: Add your update logic here

                        EntityManager.Update(gameTime);
                        obMgr.Update(gameTime);

                        floor.Update();
                    } 
                    break;

                case GameState.MainMenu:
                    {
                        mainMenu.Update(gameTime);
                    }
                    break;

                case GameState.GameOver:
                    {
                         gameOver.Update();
                    }
                    break;

                case GameState.PauseMenu:
                    {
                        pauseMenu.Update();
                    }
                    break;

                case GameState.About:
                    {
                        about.Update();
                    }
                    break;

            }


            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            graphics.GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin(0, // to use the scaling depending on the resolution
                                 null, null,
                                 null, null,
                                 null, SpriteScale);
            switch (gameState)
            {
                case GameState.Playing:
                    {
                        spriteBatch.Draw(Art.Background, new Vector2(0, 0), Color.White);

                        floor.Draw(spriteBatch);
                        EntityManager.Draw(spriteBatch);
                        ButtonManager.instance.jumpButton.Draw(spriteBatch);
                        ButtonManager.instance.pauseButton.Draw(spriteBatch);
                        //spriteBatch.DrawString(font, "EAFKQEF: " + ButtonManager.instance.pauseButton.type.ToString(), new Vector2(500, 500), Color.White);
                    }
                    break;

                case GameState.MainMenu:
                    {
                        mainMenu.Draw(spriteBatch);
                    }
                    break;

                case GameState.GameOver:
                    {
                        spriteBatch.Draw(Art.Background, new Vector2(0, 0), Color.White);

                        floor.Draw(spriteBatch);
                        EntityManager.Draw(spriteBatch);
                        ButtonManager.instance.jumpButton.Draw(spriteBatch);
                        ButtonManager.instance.pauseButton.Draw(spriteBatch);
                        gameOver.Draw(spriteBatch);
                    }
                    break;

                case GameState.PauseMenu:
                    {
                        spriteBatch.Draw(Art.Background, new Vector2(0, 0), Color.White);

                        floor.Draw(spriteBatch);
                        EntityManager.Draw(spriteBatch);
                        ButtonManager.instance.jumpButton.Draw(spriteBatch);
                        ButtonManager.instance.pauseButton.Draw(spriteBatch);
                        pauseMenu.Draw(spriteBatch);
                    }
                    break;

                case GameState.About:
                    {
                        spriteBatch.Draw(Art.Background, new Vector2(0, 0), Color.White);

                        floor.Draw(spriteBatch);
                        EntityManager.Draw(spriteBatch);
                        ButtonManager.instance.jumpButton.Draw(spriteBatch);
                        ButtonManager.instance.pauseButton.Draw(spriteBatch);
                        about.Draw(spriteBatch);
                    }
                    break;
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
