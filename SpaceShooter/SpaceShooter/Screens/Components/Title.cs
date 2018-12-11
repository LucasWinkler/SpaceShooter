using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceShooter.Screens.Components
{
    /// <summary>
    /// Simple component for drawing a title.
    /// </summary>
    public class Title : DrawableGameComponent
    {
        private GameRoot game;
        private SpriteFont font;
        private Color colour;
        private Vector2 position;
        private string text;

        /// <summary>
        /// Title constructor
        /// </summary>
        /// <param name="game"></param>
        /// <param name="text"></param>
        public Title(GameRoot game, string text) : base(game)
        {
            this.game = game;
            this.colour = Color.White;
            this.text = string.IsNullOrEmpty(text) ? "Placeholder" : text;
        }

        /// <summary>
        /// Loads the titles content
        /// </summary>
        protected override void LoadContent()
        {
            font = game.ResourceManager.GetFont("Title");
            position = new Vector2((GameSettings.GAME_WIDTH / 2) - (font.MeasureString(text).X / 2), 315);

            base.LoadContent();
        }

        /// <summary>
        /// Draws the title.
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
