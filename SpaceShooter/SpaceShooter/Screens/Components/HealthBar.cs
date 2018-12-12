using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceShooter.Screens.Components
{
    /// <summary>
    /// The players health bar component.
    /// </summary>
    public class HealthBar : DrawableGameComponent
    {
        // Instance of the game and game screen
        private GameRoot game;
        private readonly GameScreen gameScreen;

        // Health bar textures
        private Texture2D healthBar;
        private Texture2D healthBarColour;

        // Health bar position
        private Vector2 position;

        // Health bar positional offset
        private const int X_OFFSET = 9;
        private const int Y_OFFSET = 7;

        // Health bar calculations
        private int FullHeathBar { get { return healthBarColour.Width; } }
        private float HealthBarPercentage { get { return (float)gameScreen.Player.Health / gameScreen.Player.MaxHealth; } }
        private int HealthBarWidth { get { return (int)(FullHeathBar * HealthBarPercentage); } }

        /// <summary>
        /// Health bar constructor
        /// </summary>
        /// <param name="game"></param>
        /// <param name="gameScreen"></param>
        /// <param name="position"></param>
        public HealthBar(GameRoot game, GameScreen gameScreen, Vector2 position) : base(game)
        {
            this.game = game;
            this.gameScreen = gameScreen;
            this.position = position;
            this.DrawOrder = int.MaxValue;

            // Health bar textures
            healthBar = game.ResourceManager.GetTexture("HealthBar");
            healthBarColour = game.ResourceManager.GetTexture("HealthBarColour");
        }

        /// <summary>
        /// Draws the health bar.
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Draw(GameTime gameTime)
        {
            var spriteBatch = game.SpriteBatch;

            spriteBatch.Begin();
            spriteBatch.Draw(healthBar, position, Color.White);
            spriteBatch.Draw(healthBarColour, new Rectangle((int)position.X + X_OFFSET, (int)position.Y + Y_OFFSET, HealthBarWidth, healthBarColour.Height), null, Color.White, 0.0f, Vector2.Zero, SpriteEffects.None, 0);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
