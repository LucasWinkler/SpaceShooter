﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SpaceShooter.Resources;
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
                new Resource(ResourceType.Texture, "Background", "GFX/Background"),

                new Resource(ResourceType.Texture, "BluePlayer", "GFX/Player/PlayerBlue_Frame_01"),
                new Resource(ResourceType.Texture, "RedPlayer", "GFX/Player/PlayerRed_Frame_01"),

                new Resource(ResourceType.Texture, "StandardGreenEnemy", "GFX/Enemy/Enemy02_Green_Frame_1"),
                new Resource(ResourceType.Texture, "StandardRedEnemy", "GFX/Enemy/Enemy02_Red_Frame_1"),
                new Resource(ResourceType.Texture, "StandardTealEnemy", "GFX/Enemy/Enemy02_Teal_Frame_1"),

                new Resource(ResourceType.Texture, "AdvancedGreenEnemy", "GFX/Enemy/Enemy01_Green_Frame_1"),
                new Resource(ResourceType.Texture, "AdvancedRedEnemy", "GFX/Enemy/Enemy01_Red_Frame_1"),
                new Resource(ResourceType.Texture, "AdvancedTealEnemy", "GFX/Enemy/Enemy01_Teal_Frame_1"),
            });

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

            // Load all the resources.
            ResourceManager.LoadContent();
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
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
