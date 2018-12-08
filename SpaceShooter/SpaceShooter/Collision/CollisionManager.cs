using Microsoft.Xna.Framework;
using SpaceShooter.Screens;
using SpaceShooter.Sprites;

namespace SpaceShooter.Collision
{
    public class CollisionManager : GameComponent
    {
        private GameRoot game;
        private GameScreen gameScreen;

        // Score per kill
        private const int SCORE_PER_KILL = 20;
        
        // Score per enemy that goes off screen
        private const int SCORE_PENALTY = 10;

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
                            if (IsColliding(ship, bullet) && bullet.Parent != ship && bullet.Parent.GetType() != ship.GetType())
                            {
                                if (ship.GetType() == typeof(Enemy))
                                    gameScreen.Player.Score += SCORE_PER_KILL;

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
                    if (enemy.Position.Y > GameSettings.GAME_HEIGHT)
                    {
                        enemy.Destroy();
                        gameScreen.Player.Score -= SCORE_PENALTY;
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
