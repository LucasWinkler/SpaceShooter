using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceShooter.Screens.Components
{
    public class Score : DrawableGameComponent
    {
        private GameRoot game;
        private SpriteFont font;
        private Color colour;
        private Vector2 position;

        public Score(GameRoot game) : base(game)
        {
            this.game = game;
        }

        protected override void LoadContent()
        {
            font = game.ResourceManager.GetFont("Score");
            
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}
