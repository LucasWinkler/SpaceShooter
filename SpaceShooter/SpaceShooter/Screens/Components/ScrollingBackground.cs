using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceShooter.Screens.Components
{
    /// <summary>
    /// A scrolling background component.
    /// </summary>
    public class ScrollingBackground : DrawableGameComponent
    {
        private GameRoot game;
        private Texture2D background;
        private Vector2 position;
        private Vector2 secondaryPosition;

        private const float SCROLL_SPEED = 12.0f;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="game"></param>
        public ScrollingBackground(GameRoot game) : base(game)
        {
            this.game = game;
        }

        /// <summary>
        /// Load the background.
        /// </summary>
        protected override void LoadContent()
        {
            background = game.ResourceManager.GetTexture("Background");

            base.LoadContent();
        }

        /// <summary>
        /// Update the position of the scrolling background.
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            position.Y += SCROLL_SPEED * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (position.Y > background.Height)
            {
                position.Y = 0;
            }

            secondaryPosition.Y = position.Y - background.Height;

            base.Update(gameTime);
        }

        /// <summary>
        /// Draw the background.
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Draw(GameTime gameTime)
        {
            var spriteBatch = game.SpriteBatch;

            spriteBatch.Begin();

            spriteBatch.Draw(background, position, Color.White);
            spriteBatch.Draw(background, secondaryPosition, Color.White);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
