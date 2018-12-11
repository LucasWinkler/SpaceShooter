using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceShooter.Screens.Components
{
    /// <summary>
    /// A component to show score at the end of the game.
    /// </summary>
    public class EndScore : DrawableGameComponent
    {
        private GameRoot game;
        private SpriteFont font;
        private Color colour;
        private string score = "";

        private const int yPosition = 375;
        private Vector2 Position { get { return new Vector2((GameSettings.GAME_WIDTH / 2) - (font.MeasureString(score).X / 2), 375); } }

        /// <summary>
        /// Set the score
        /// </summary>
        public string Score
        {
            set { score = $"Score: {value}"; }
        }

        /// <summary>
        /// Score constructor
        /// </summary>
        /// <param name="game"></param>
        public EndScore(GameRoot game) : base(game)
        {
            this.game = game;
            this.colour = Color.White;
        }

        /// <summary>
        /// Loads the font
        /// </summary>
        protected override void LoadContent()
        {
            font = game.ResourceManager.GetFont("Score");

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
            spriteBatch.DrawString(font, score, Position, colour);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
