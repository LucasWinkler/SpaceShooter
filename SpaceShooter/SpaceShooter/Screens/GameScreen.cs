using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SpaceShooter.Collision;
using SpaceShooter.Input;
using SpaceShooter.Screens.Components;
using SpaceShooter.Spawners;
using SpaceShooter.Sprites;

namespace SpaceShooter.Screens
{
    /// <summary>
    /// The screen where all the gameplay happens.
    /// </summary>
    public class GameScreen : Screen
    {
        private KeyHandler keyHandler;
        private Texture2D background;

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="game">The game instance.</param>
        public GameScreen(GameRoot game) : base(game)
        {
            Components.Add(new ScrollingBackground(GameRoot));
            Components.Add(new CollisionManager(GameRoot, this));
            Components.Add(new Player(GameRoot, this, new KeyBinds
            {
                Forwards = Keys.W,
                Left = Keys.A,
                Backwards = Keys.S,
                Right = Keys.D,
                Shoot = Keys.Space
            }));

            Components.Add(new EnemySpawner(GameRoot, this));

            keyHandler = new KeyHandler();
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
        public override void Reset() { }

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
