using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpaceShooter.Resources;
using SpaceShooter.Screens;
using SpaceShooter.Screens.Components;
using System.Collections.Generic;

namespace SpaceShooter
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class GameRoot : Game
    {
        private readonly GraphicsDeviceManager graphics;

        /// <summary>The games spritebatch for drawing.</summary>
        public SpriteBatch SpriteBatch { get; private set; }

        /// <summary>
        /// The games resource manager for accessing
        /// content/resources via keys instead of paths.
        /// </summary>
        public ResourceManager ResourceManager { get; private set; }

        /// <summary>
        /// The games default constructor.
        /// Used for instantiating the graphics device manager.
        /// </summary>
        public GameRoot()
        {
            graphics = new GraphicsDeviceManager(this)
            {
                PreferredBackBufferWidth = GameSettings.GAME_WIDTH,
                PreferredBackBufferHeight = GameSettings.GAME_HEIGHT,
                IsFullScreen = GameSettings.IS_FULLSCREEN
            };

            // Set the games title and the mouse visibility
            Window.Title = GameSettings.GAME_TITLE;

            // Positions the game window in the middle of the screen.
            // Dividing the width and height by 2 will not be accurate on certain resolutions and monitors.
            // Therfore this extra calculation using the default adapter is needed.
            Window.Position = new Point(
                (GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width / 2) - (graphics.PreferredBackBufferWidth / 2),
                (GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height / 2) - (graphics.PreferredBackBufferHeight / 2));

            IsMouseVisible = GameSettings.IS_MOUSE_VISIBLE;

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
            // Give the resource manager a list of resources
            ResourceManager = new ResourceManager(this, new List<Resource>()
            {
                #region Backgrounds
                new Resource(ResourceType.Texture, "Background", "GFX/Background"),
                #endregion

                #region Players
                new Resource(ResourceType.Texture, "BluePlayer", "GFX/Player/PlayerBlue_Frame_01"),
                new Resource(ResourceType.Texture, "RedPlayer", "GFX/Player/PlayerRed_Frame_01"),
                #endregion

                #region Enemies
                new Resource(ResourceType.Texture, "StandardGreenEnemy", "GFX/Enemy_02/Enemy02_Green_Frame_1"),
                new Resource(ResourceType.Texture, "StandardRedEnemy", "GFX/Enemy_02/Enemy02_Red_Frame_1"),
                new Resource(ResourceType.Texture, "StandardTealEnemy", "GFX/Enemy_02/Enemy02_Teal_Frame_1"),

                new Resource(ResourceType.Texture, "AdvancedGreenEnemy", "GFX/Enemy_01/Enemy01_Green_Frame_1"),
                new Resource(ResourceType.Texture, "AdvancedRedEnemy", "GFX/Enemy_01/Enemy01_Red_Frame_1"),
                new Resource(ResourceType.Texture, "AdvancedTealEnemy", "GFX/Enemy_01/Enemy01_Teal_Frame_1"),
                #endregion

                #region Bullets
                new Resource(ResourceType.Texture, "SmallPlasmaBullet", "GFX/Bullets/Plasma_Small"),
                #endregion

                #region Animations
                new Resource(ResourceType.Texture, "ExhaustAnimation", "GFX/Exhaust/exhaustSheet"),
                new Resource(ResourceType.Texture, "ExplosionAnimation", "GFX/Explosions/explosionSheet"),
                #endregion

                #region HUD
                new Resource(ResourceType.Texture, "HealthBar", "GFX/HUD/HealthBar"),
                new Resource(ResourceType.Texture, "HealthBarColour", "GFX/HUD/HealthBarColor"),
                #endregion

                #region Keys
                new Resource(ResourceType.Texture, "BlackWKey", "GFX/Keys/Keyboard_Black_W"),
                new Resource(ResourceType.Texture, "BlackAKey", "GFX/Keys/Keyboard_Black_A"),
                new Resource(ResourceType.Texture, "BlackSKey", "GFX/Keys/Keyboard_Black_S"),
                new Resource(ResourceType.Texture, "BlackDKey", "GFX/Keys/Keyboard_Black_D"),
                new Resource(ResourceType.Texture, "BlackSpaceKey", "GFX/Keys/Keyboard_Black_Space"),
                new Resource(ResourceType.Texture, "BlackPKey", "GFX/Keys/Keyboard_Black_P"),
                new Resource(ResourceType.Texture, "BlackEscKey", "GFX/Keys/Keyboard_Black_Esc"),

                new Resource(ResourceType.Texture, "WhiteWKey", "GFX/Keys/Keyboard_White_W"),
                new Resource(ResourceType.Texture, "WhiteAKey", "GFX/Keys/Keyboard_White_A"),
                new Resource(ResourceType.Texture, "WhiteSKey", "GFX/Keys/Keyboard_White_S"),
                new Resource(ResourceType.Texture, "WhiteDKey", "GFX/Keys/Keyboard_White_D"),
                new Resource(ResourceType.Texture, "WhiteSpaceKey", "GFX/Keys/Keyboard_White_Space"),
                new Resource(ResourceType.Texture, "WhitePKey", "GFX/Keys/Keyboard_White_P"),
                new Resource(ResourceType.Texture, "WhiteEscKey", "GFX/Keys/Keyboard_White_Esc"),
                #endregion

                #region Fonts
                new Resource(ResourceType.Font, "StandardMenuItem", "Fonts/standardMenuItemFont"),
                new Resource(ResourceType.Font, "SelectedMenuItem", "Fonts/highlightedMenuItemFont"),
                new Resource(ResourceType.Font, "Title", "Fonts/titleFont"),
                new Resource(ResourceType.Font, "Score", "Fonts/scoreFont"),
                new Resource(ResourceType.Font, "BasicText", "Fonts/basicText"),
                #endregion

                #region Sound Effects
                new Resource(ResourceType.Sound, "PlayerShoot", "SFX/PlayerShoot"),
                new Resource(ResourceType.Sound, "EnemyShoot", "SFX/EnemyShoot"),
                new Resource(ResourceType.Sound, "Destroy", "SFX/Destroy"),
                new Resource(ResourceType.Sound, "Explosion", "SFX/Explosion2"),
                new Resource(ResourceType.Sound, "Shoot", "SFX/Laser_Shoot16"),
                #endregion

                #region Music
                new Resource(ResourceType.Music, "GameMusic", "Music/GameMusic"),
                new Resource(ResourceType.Music, "MenuMusic", "Music/MenuMusic"),
                new Resource(ResourceType.Music, "EndMusic", "Music/EndMusic"),
                #endregion
            });

            /* This should probably be called in this.LoadContent()
             * but DrawableGameComponent.LoadContent() will be called
             * before this.LoadContent() meaning the resources/content wont be ready.
             */
            ResourceManager.LoadContent();

            // Add a scrolling background behind each screen
            Components.Add(new ScrollingBackground(this));

            // Add the game screen to the game.
            GameScreen gameScreen = new GameScreen(this);
            Components.Add(gameScreen);
            Services.AddService(gameScreen);

            // Add the end screen to the game.
            EndScreen endScreen = new EndScreen(this);
            Components.Add(endScreen);
            Services.AddService(endScreen);

            // Add the credits screen to the game.
            CreditsScreen creditsScreen = new CreditsScreen(this);
            Components.Add(creditsScreen);
            Services.AddService(creditsScreen);

            // Add the help screen to the game.
            HelpScreen helpScreen = new HelpScreen(this);
            Components.Add(helpScreen);
            Services.AddService(helpScreen);

            // Add the start screen to the game.
            StartScreen startScreen = new StartScreen(this);
            Components.Add(startScreen);
            Services.AddService(startScreen);

            // Initialize all components
            base.Initialize();

            // Hide all the screens and set the start screen to the active screen
            HideScreens();
            startScreen.SetActive(true);
            startScreen.PlayMusic();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            SpriteBatch = new SpriteBatch(GraphicsDevice);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            ResourceManager.UnloadContent();
        }

        /// <summary>
        /// Hides all the game screens
        /// </summary>
        public void HideScreens()
        {
            foreach (var component in Components)
            {
                if (component is Screen screen)
                {
                    screen.SetActive(false);
                }
            }
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            base.Draw(gameTime);
        }
    }
}
