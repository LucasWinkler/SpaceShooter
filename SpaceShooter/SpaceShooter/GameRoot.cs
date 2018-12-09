using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SpaceShooter.Resources;
using SpaceShooter.Screens;
using SpaceShooter.Sprites;
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

                #region HUD
                new Resource(ResourceType.Texture, "HealthBar", "GFX/HUD/HealthBar"),
                new Resource(ResourceType.Texture, "HealthBarColour", "GFX/HUD/HealthBarColor"),
                #endregion

                #region Fonts
                new Resource(ResourceType.Font, "StandardMenuItem", "Fonts/standardMenuItemFont"),
                new Resource(ResourceType.Font, "SelectedMenuItem", "Fonts/highlightedMenuItemFont"),
                new Resource(ResourceType.Font, "Title", "Fonts/titleFont"),
                new Resource(ResourceType.Font, "Score", "Fonts/scoreFont"),
                #endregion

                #region Powerups
                new Resource(ResourceType.Texture, "HealthPowerup", "GFX/Powerups/Powerup_Health"),
                new Resource(ResourceType.Texture, "ShieldPowerup", "GFX/Powerups/Powerup_Shields"),
                #endregion

                #region Sound Effects
                new Resource(ResourceType.Sound, "PlayerShoot", "SFX/PlayerShoot"),
                new Resource(ResourceType.Sound, "EnemyShoot", "SFX/EnemyShoot"),
                new Resource(ResourceType.Sound, "Destroy", "SFX/Destroy"),
                #endregion

                #region Music
                new Resource(ResourceType.Music, "GameMusic", "Music/GameMusic"),
                new Resource(ResourceType.Music, "MenuMusic", "Music/MenuMusic"),
                #endregion
            });

            /* This should probably be called in this.LoadContent()
             * but DrawableGameComponents.LoadContent() method will be called
             * before this.LoadContent() meaning the resources/content wont be ready.
             */
            ResourceManager.LoadContent();

            // Add the game screen to the game.
            GameScreen gameScreen = new GameScreen(this);
            Components.Add(gameScreen);
            Services.AddService(gameScreen);

            // Add the start screen to the game.
            StartScreen startScreen = new StartScreen(this);
            Components.Add(startScreen);
            Services.AddService(startScreen);

            this.HideScreens();

            Services.GetService<StartScreen>().SetActive(true);

            base.Initialize();
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
