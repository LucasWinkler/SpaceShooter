using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using SpaceShooter.Collision;
using SpaceShooter.Input;
using SpaceShooter.Screens.Components;
using SpaceShooter.Spawners;
using SpaceShooter.Sprites;
using System.Collections.Generic;

namespace SpaceShooter.Screens
{
    /// <summary>
    /// The screen where all the gameplay happens.
    /// </summary>
    public class GameScreen : Screen
    {
        private KeyHandler keyHandler;

        /// <summary>The player instance.</summary>
        public Player Player { get; }

        /// <summary>Checks for collision for each sprite in the game.</summary>
        public EnemySpawner EnemySpawner { get; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="game">The game instance.</param>
        public GameScreen(GameRoot game) : base(game)
        {
            //Components.Add(new ScrollingBackground(GameRoot));
            Components.Add(new CollisionManager(GameRoot, this));
            Components.Add(Player = new Player(GameRoot, this, new KeyBinds
            {
                Forwards = Keys.W,
                Left = Keys.A,
                Backwards = Keys.S,
                Right = Keys.D,
                Shoot = Keys.Space
            }));
            Components.Add(EnemySpawner = new EnemySpawner(GameRoot, this, new List<string>()
            {
                "StandardGreenEnemy",
                "StandardRedEnemy",
                "StandardTealEnemy",
                "AdvancedGreenEnemy",
                "AdvancedRedEnemy",
                "AdvancedTealEnemy"
            }));
            Components.Add(new HealthBar(GameRoot, this));
            Components.Add(new Score(GameRoot, this));

            keyHandler = new KeyHandler();
        }

        /// <summary>
        /// Load the game screens content.
        /// </summary>
        protected override void LoadContent()
        {
            BackgroundMusic = GameRoot.ResourceManager.GetMusic("GameMusic");

            base.LoadContent();
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
                GameRoot.HideScreens();
                var startScreen = GameRoot.Services.GetService<StartScreen>();
                startScreen.SetActive(true);
                startScreen.PlayMusic();
            }

            base.Update(gameTime);
        }
    }
}
