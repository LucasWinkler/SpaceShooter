using Microsoft.Xna.Framework;
using SpaceShooter.Screens;
using SpaceShooter.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceShooter.Collision
{
    public class CollisionManager : GameComponent
    {
        private GameRoot game;
        private GameScreen gameScreen;

        public CollisionManager(GameRoot game, GameScreen gameScreen) : base(game)
        {
            this.game = game;
            this.gameScreen = gameScreen;
        }

        private bool IsColliding(Sprite sprite, Sprite other) => sprite.Bounds.Intersects(other.Bounds);

        private void CheckBulletCollision()
        {
            foreach (var component in gameScreen.Components)
            {
                if (component is Bullet bullet)
                {
                    foreach (var otherComponent in gameScreen.Components)
                    {
                        if (otherComponent is Ship ship)
                        {
                            if (IsColliding(ship, bullet) && bullet.Parent != ship)
                            {
                                ship.Damage(bullet.Damage);
                                bullet.Destroy();
                            }
                        }
                    }
                }
            }
        }

        private void CheckOutOfScreenSprites()
        {
            foreach (var component in gameScreen.Components)
            {
                if (component is Bullet bullet)
                {
                    if (!game.GraphicsDevice.Viewport.Bounds.Contains(bullet.Bounds))
                    {
                        bullet.Destroy();
                    }
                }
                else if (component is Enemy enemy)
                {
                    if (enemy.Position.Y > GameSettings.GAME_HEIGHT - enemy.Texture.Height)
                    {
                        enemy.Destroy();
                    }
                }
            }
        }

        public override void Update(GameTime gameTime)
        {
            CheckOutOfScreenSprites();
            CheckBulletCollision();

            base.Update(gameTime);
        }
    }
}
