using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceShooter.Sprites
{
    public class Bullet : Sprite
    {
        public Sprite Parent { get; }

        public float Speed { get; } = 500.0f;

        public Bullet(GameRoot game, Sprite parent) : base(game)
        {
            this.Parent = parent;
            this.Texture = game.ResourceManager.GetTexture("SmallPlasmaBullet");
            this.Velocity = new Vector2(0, -Speed);
        }

        public override void Destroy()
        {
            GameRoot.Components.Remove(this);
        }

        public override void Update(GameTime gameTime)
        {
            Position += Velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;

            // Remove the bullet from the game if it is no longer inside the screen
            if (!GameRoot.GraphicsDevice.Viewport.Bounds.Contains(Bounds))
            {
                Parent.
                GameRoot.Components.Remove(this);
            }
           
            base.Update(gameTime);
        }
    }
}
