using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceShooter.Screens.Components
{
    /// <summary>
    /// A key that the player uses for input
    /// </summary>
    public class InputKey : DrawableGameComponent
    {
        private GameRoot game;
        private Texture2D key;
        private Vector2 position;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="game"></param>
        /// <param name="key"></param>
        /// <param name="position"></param>
        public InputKey(GameRoot game, Texture2D key, Vector2 position) : base(game)
        {
            this.game = game;
            this.key = key;
            this.position = new Vector2(position.X - (key.Width / 2), position.Y);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Draw(GameTime gameTime)
        {
            var spriteBatch = game.SpriteBatch;

            spriteBatch.Begin();
            spriteBatch.Draw(key, position, Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
