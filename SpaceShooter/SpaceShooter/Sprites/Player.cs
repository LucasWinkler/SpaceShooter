using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceShooter.Sprites
{
    /// <summary>
    /// The player in the game.
    /// </summary>
    public class Player : Sprite
    {
        /// <summary>
        /// Constructs the player object.
        /// </summary>
        /// <param name="game"></param>
        public Player(GameRoot game) : base(game)
        {

        }

        /// <summary>
        /// Initializes the player.
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();
        }

        /// <summary>
        /// Loads the players content.
        /// </summary>
        protected override void LoadContent()
        {
            base.LoadContent();
        }

        public override void Reset()
        {
            Console.WriteLine("Resetting Player");
        }

        /// <summary>
        /// Updates the player.
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        /// <summary>
        /// Draws the player.
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}
