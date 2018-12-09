using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceShooter.Screens.Components
{
    public class Score : DrawableGameComponent
    {
        private GameRoot game;
        private GameScreen gameScreen;
        private SpriteFont font;
        private Color colour;
        private Vector2 position;

        private string ConcatenatedScore { get { return $"Score: {gameScreen.Player.Score}"; } }

        // Offset for positioning
        private const int OFFSET = 5;

        /// <summary>
        /// Score constructor
        /// </summary>
        /// <param name="game"></param>
        /// <param name="gameScreen"></param>
        public Score(GameRoot game, GameScreen gameScreen) : base(game)
        {
            this.game = game;
            this.gameScreen = gameScreen;
            this.colour = Color.White;
            this.DrawOrder = int.MaxValue;
        }

        /// <summary>
        /// Loads the font
        /// </summary>
        protected override void LoadContent()
        {
            font = game.ResourceManager.GetFont("Score");
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            position = new Vector2(GameSettings.GAME_WIDTH - font.MeasureString(ConcatenatedScore).X - OFFSET, OFFSET);
            base.Update(gameTime);
        }

        /// <summary>
        /// Draws the score
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Draw(GameTime gameTime)
        {
            var spriteBatch = game.SpriteBatch;

            spriteBatch.Begin();
            spriteBatch.DrawString(font, ConcatenatedScore, position, colour);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
