using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceShooter.Screens.Components
{
    /// <summary>
    /// A component that draws text.
    /// </summary>
    public class BasicText : DrawableGameComponent
    {
        private GameRoot game;
        private SpriteFont font;
        private Color colour;
        private Vector2 position;
        private string text;

        /// <summary>
        /// Score constructor
        /// </summary>
        /// <param name="game"></param>
        /// <param name="text"></param>
        /// <param name="position"></param>
        public BasicText(GameRoot game, string text, Vector2 position) : base(game)
        {
            this.game = game;
            this.text = text;
            this.position = position;
            this.colour = Color.White;
        }

        /// <summary>
        /// Loads the font
        /// </summary>
        protected override void LoadContent()
        {
            font = game.ResourceManager.GetFont("BasicText");
            position.X = position.X - (font.MeasureString(text).X / 2);

            base.LoadContent();
        }

        /// <summary>
        /// Draws the score
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Draw(GameTime gameTime)
        {
            var spriteBatch = game.SpriteBatch;

            spriteBatch.Begin();
            spriteBatch.DrawString(font, text, position, colour);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
