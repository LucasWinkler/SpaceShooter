using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpaceShooter.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceShooter.Screens.Components
{
    public class HealthBar : DrawableGameComponent, IResetable
    {
        // Instance of the game and game screen
        private GameRoot game;
        private GameScreen gameScreen;

        // Health bars textures
        private Texture2D healthBar;
        private Texture2D healthBarColour;

        // The healthBarColour's source rectangle
        private Rectangle healthBarColourSource;

        /// <summary>
        /// Health bar constructor
        /// </summary>
        /// <param name="game"></param>
        /// <param name="gameScreen"></param>
        public HealthBar(GameRoot game, GameScreen gameScreen) : base(game)
        {
            this.game = game;
            this.gameScreen = gameScreen;
            this.gameScreen.Player.Damaged += Player_Damaged;
        }

        /// <summary>
        /// Resets the health bar
        /// </summary>
        public void Reset()
        {
            
        }

        protected override void LoadContent()
        {
            healthBar = game.ResourceManager.GetTexture("HealthBar");
            healthBarColour = game.ResourceManager.GetTexture("HealthBarColour");

            base.LoadContent();
        }

        private void Player_Damaged(object sender, EventArgs e)
        {
            // TODO: Shrink source rect of HealthBarColour
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            var spriteBatch = game.SpriteBatch;

            spriteBatch.Begin();



            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
