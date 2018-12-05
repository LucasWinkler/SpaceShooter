using Microsoft.Xna.Framework;
using SpaceShooter.Sprites;
using System.Collections.Generic;

namespace SpaceShooter.Controllers
{
    public class BulletController : GameComponent
    {
        private GameRoot game;

        public BulletController(GameRoot game) : base(game)
        {
            this.game = game;
        }

        public override void Update(GameTime gameTime)
        {
            var bullets = new List<Bullet>();
            foreach(var component in game.Components)
            {
                if (component is Bullet bullet)
                {
                    bullet.Position += bullet.Velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;

                    // Remove the bullet from the game if it is no longer inside the screen
                    if (!game.GraphicsDevice.Viewport.Bounds.Contains(bullet.Bounds))
                    {
                        //bullet.Destroy();
                        bullets.Add(bullet);
                    }
                }
            }

            foreach(var b in bullets)
            {
                game.Components.Remove(b);
                System.Console.WriteLine("gone");
            }

            bullets.Clear();

            base.Update(gameTime);
        }
    }
}
