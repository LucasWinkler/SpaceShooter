using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpaceShooter.Interfaces;
using SpaceShooter.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceShooter.Screens.Components
{
    public class HealthBar : DrawableGameComponent
    {
        // Instance of the game and game screen
        private GameRoot game;
        private readonly GameScreen gameScreen;

        // Health bar textures
        private Texture2D healthBar;
        private Texture2D healthBarColour;

        // Health bar position
        private Vector2 healthBarPosition;

        // Health bar positional offset
        private const int X_OFFSET = 9;
        private const int Y_OFFSET = 7;

        // Health bar calculations
        private int FullHeathBar { get { return healthBarColour.Width; } }
        private float HealthBarPercentage { get { return (float)gameScreen.Player.Health / Player.MAX_HEALTH; } }
        private int HealthBarWidth { get { return (int)(FullHeathBar * HealthBarPercentage); } }

        /// <summary>
        /// Health bar constructor
        /// </summary>
        /// <param name="game"></param>
        /// <param name="gameScreen"></param>
        public HealthBar(GameRoot game, GameScreen gameScreen) : base(game)
        {
            this.game = game;
            this.gameScreen = gameScreen;
            this.healthBarPosition = new Vector2(5);
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
            spriteBatch.Draw(healthBar, healthBarPosition, Color.White);
            spriteBatch.Draw(healthBarColour, new Rectangle((int)healthBarPosition.X + X_OFFSET, (int)healthBarPosition.Y + Y_OFFSET, HealthBarWidth, healthBarColour.Height), null, Color.White, 0.0f, Vector2.Zero, SpriteEffects.None, 0);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
