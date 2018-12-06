using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SpaceShooter.Camera;
using SpaceShooter.Controllers;
using SpaceShooter.Input;
using SpaceShooter.Screens.Components;
using SpaceShooter.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceShooter.Screens
{
    /// <summary>
    /// The screen where all the gameplay happens.
    /// </summary>
    public class GameScreen : Screen
    {
        // The games player
        private Player player;

        private KeyHandler keyHandler;

        private Texture2D background;

        // The controller which handles the players input
        private readonly PlayerController playerController;

        private readonly BulletController bulletController;

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="game">The game instance.</param>
        public GameScreen(GameRoot game) : base(game)
        {
            this.Components.Add(new ScrollingBackground(GameRoot));

            this.Components.Add(player = new Player(GameRoot,
                new KeyBinds
                {
                    Forwards = Keys.W,
                    Left = Keys.A,
                    Backwards = Keys.S,
                    Right = Keys.D,
                    Shoot = Keys.Space
                }));

            this.Components.Add(playerController = new PlayerController(GameRoot, player));
            this.Components.Add(bulletController = new BulletController(GameRoot));

            this.keyHandler = new KeyHandler();
        }

        /// <summary>
        /// Initialize the game screen.
        /// </summary>
        public override void Initialize()
        {
            Reset();

            base.Initialize();
        }

        /// <summary>
        /// Load the game screens content.
        /// </summary>
        protected override void LoadContent()
        {
            background = GameRoot.ResourceManager.GetTexture("Background");

            base.LoadContent();
        }

        /// <summary>
        /// Resets the game screen.
        /// </summary>
        public void Reset()
        {
            player.Reset();
        }

        /// <summary>
        /// Update the game screen.
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            keyHandler.Update();

            if (keyHandler.IsKeyPressed(Keys.Escape))
            {
                var startScreen = GameRoot.Services.GetService<StartScreen>();
                GameRoot.HideScreens();
                startScreen.SetActive(true);
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// Draws the game screen.
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Draw(GameTime gameTime)
        {
            var spriteBatch = GameRoot.SpriteBatch;

            spriteBatch.Begin();
            spriteBatch.Draw(background, Vector2.Zero, Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
