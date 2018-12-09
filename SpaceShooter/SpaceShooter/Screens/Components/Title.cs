using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceShooter.Screens.Components
{
    public class Title : DrawableGameComponent
    {
        private GameRoot game;
        private SpriteFont font;
        private Color colour;
        private Vector2 position;

        public Title(GameRoot game) : base(game)
        {
            this.game = game;
            this.colour = Color.White;
        }

        protected override void LoadContent()
        {
            font = game.ResourceManager.GetFont("Title");
            position = new Vector2((GameSettings.GAME_WIDTH / 2) - (font.MeasureString(GameSettings.GAME_TITLE).X / 2), 315);

            base.LoadContent();
        }

        public override void Draw(GameTime gameTime)
        {
            var spriteBatch = game.SpriteBatch;

            spriteBatch.Begin();
            spriteBatch.DrawString(font, GameSettings.GAME_TITLE, position, colour);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
