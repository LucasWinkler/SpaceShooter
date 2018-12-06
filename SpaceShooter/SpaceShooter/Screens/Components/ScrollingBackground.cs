using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceShooter.Screens.Components
{
    public class ScrollingBackground : DrawableGameComponent
    {
        private GameRoot game;

        private Texture2D background;
        private Texture2D secondaryBackground;

        private Vector2 position;
        private Vector2 secondaryPosition;

        private const float SCROLL_SPEED = 12.0f;

        public ScrollingBackground(GameRoot game) : base(game)
        {
            this.game = game;
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            background = secondaryBackground = game.ResourceManager.GetTexture("Background");

            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            position.Y += SCROLL_SPEED * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (position.Y > background.Height)
            {
                position.Y = -background.Height;
            }

            secondaryPosition.Y = position.Y - background.Height;

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            var spriteBatch = game.SpriteBatch;

            spriteBatch.Begin();

            spriteBatch.Draw(background, position, null, Color.White, 0.0f, Vector2.Zero, 1.0f, SpriteEffects.None, GameSettings.BACKGROUND_LAYER);
            spriteBatch.Draw(secondaryBackground, secondaryPosition, null, Color.White, 0.0f, Vector2.Zero, 1.0f, SpriteEffects.None, GameSettings.BACKGROUND_LAYER);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
