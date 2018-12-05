using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using SpaceShooter.Sprites;

namespace SpaceShooter.Screens
{
    /// <summary>
    /// The screen where all the gameplay happens.
    /// </summary>
    public class GameScreen : Screen
    {
        // The games player
        private Player player;

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="game">The game instance.</param>
        public GameScreen(GameRoot game) : base(game)
        {
            player = new Player(GameRoot);
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
            base.Update(gameTime);
        }
    }
}
