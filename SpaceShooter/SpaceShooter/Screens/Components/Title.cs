using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceShooter.Screens.Components
{
    public class Title : DrawableGameComponent
    {
        private GameRoot game;
        private SpriteFont titleFont;
        private Color titleColour = Color.White;
        private Vector2 titlePosition;

        public Title(GameRoot game) : base(game)
        {
            this.game = game;
        }

        protected override void LoadContent()
        {
            titleFont = game.ResourceManager.GetFont("Title");
            titlePosition = new Vector2((GameSettings.GAME_WIDTH / 2) - (titleFont.MeasureString(GameSettings.GAME_TITLE).X / 2), 315);

            base.LoadContent();
        }

        public override void Draw(GameTime gameTime)
        {
            var spriteBatch = game.SpriteBatch;

            spriteBatch.Begin();
            spriteBatch.DrawString(titleFont, GameSettings.GAME_TITLE, titlePosition, titleColour);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
