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

        public Bullet(GameRoot GameRoot, Sprite parent) : base(GameRoot)
        {
            this.Parent = parent;
            this.Texture = GameRoot.ResourceManager.GetTexture("SmallPlasmaBullet");
            this.Velocity = new Vector2(0, -Speed);
        }

        public override void Destroy()
        {
            GameRoot.Components.Remove(this);
        }

        public override void Update(GameTime GameRootTime)
        {
            var bullets = new List<Bullet>();
            foreach (var component in GameRoot.Components)
            {
                if (component is Bullet bullet)
                {
                    bullet.Position += bullet.Velocity * (float)GameRootTime.ElapsedGameTime.TotalSeconds;

                    // Remove the bullet from the GameRoot if it is no longer inside the screen
                    if (!GameRoot.GraphicsDevice.Viewport.Bounds.Contains(bullet.Bounds))
                    {
                        //bullet.Destroy();
                        bullets.Add(bullet);
                    }
                }
            }

            foreach (var b in bullets)
            {
                GameRoot.Components.Remove(b);
                b.Destroy();
            }

            bullets.Clear();

            base.Update(GameRootTime);
        }
    }
}
