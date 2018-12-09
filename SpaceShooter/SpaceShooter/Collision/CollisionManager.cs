using Microsoft.Xna.Framework;
using SpaceShooter.Screens;
using SpaceShooter.Sprites;
using System;

namespace SpaceShooter.Collision
{
    public class CollisionManager : GameComponent
    {
        // Instances of the game and game screen
        private GameRoot game;
        private GameScreen gameScreen;

        // Score per kill
        private const int SCORE_PER_KILL = 20;

        // Score per enemy that goes off screen
        private const int SCORE_PENALTY = 15;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="game"></param>
        /// <param name="gameScreen"></param>
        public CollisionManager(GameRoot game, GameScreen gameScreen) : base(game)
        {
            this.game = game;
            this.gameScreen = gameScreen;
        }

        /// <summary>
        /// Checks if a sprites bounds is colliding/intersecting
        /// with another sprites bounds.
        /// </summary>
        /// <param name="sprite"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        private bool IsColliding(Sprite sprite, Sprite other) => sprite.Bounds.Intersects(other.Bounds);

        /// <summary>
        /// Compares a ship and a bullet.
        /// If the bullets parent type is not
        /// the same as the ships type then
        /// they are enemies.
        /// </summary>
        /// <param name="bullet"></param>
        /// <param name="ship"></param>
        /// <returns></returns>
        private bool IsEnemy(Bullet bullet, Ship ship) => bullet.Parent.GetType() != ship.GetType();

        /// <summary>
        /// Compares two ships to check
        /// if they are enemies.
        /// </summary>
        /// <param name="ship"></param>
        /// <param name="otherShip"></param>
        /// <returns></returns>
        private bool IsEnemy(Ship ship, Ship otherShip) => ship.GetType() != otherShip.GetType();

        /// <summary>
        /// Checks if a sprite is within the screen.
        /// </summary>
        /// <param name="sprite"></param>
        /// <returns></returns>
        private bool InBounds(Sprite sprite) => game.GraphicsDevice.Viewport.Bounds.Intersects(sprite.Bounds);

        /// <summary>
        /// Removes any sprites that are outside of the screen.
        /// </summary>
        private void CheckOutOfScreenSprites()
        {
            foreach (var component in gameScreen.Components)
            {
                if (component is Bullet bullet)
                {
                    if (!InBounds(bullet))
                    {
                        gameScreen.ComponentsToRemove.Add(bullet);
                    }
                }
                else if (component is Enemy enemy)
                {
                    if (enemy.Position.Y > GameSettings.GAME_HEIGHT)
                    {
                        enemy.Remove();
                        gameScreen.Player.Score -= SCORE_PENALTY;
                    }
                }
            }
        }

        /// <summary>
        /// Checks collision on each bullet in the game
        /// </summary>
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
                            // If the ship which shot the bullet is not an enemy of 
                            // the ship being checked continue to next iteration
                            if (!IsEnemy(bullet, ship))
                                continue;

                            // Makes sure that the ship is within the screen before checking collision
                            if (!InBounds(ship))
                                continue;

                            // If the ship and bullet are colliding
                            if (IsColliding(ship, bullet))
                            {
                                // If the ship which shot the bullet is the player then 
                                // the player has just killed an enemy so increase the score.
                                if (bullet.Parent.GetType() == typeof(Player)) // && ship.GetType() == typeof(Enemy)
                                {
                                    gameScreen.Player.Score += SCORE_PER_KILL;
                                }

                                ship.Damage(bullet.Damage);
                                bullet.Destroy();
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Checks collision on each ship in the game
        /// </summary>
        private void CheckShipCollision()
        {
            foreach (var component in gameScreen.Components)
            {
                if (component is Ship ship)
                {
                    foreach (var otherComponent in gameScreen.Components)
                    {
                        if (otherComponent is Ship otherShip)
                        {
                            // If the ships are not enemies of each other then continue to next iteration
                            if (!IsEnemy(ship, otherShip))
                                continue;

                            // If the ships are colliding
                            if (IsColliding(ship, otherShip))
                            {
                                ship.Destroy();
                                otherShip.Destroy();
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Checks if the sprites have collided
        /// or are out of the screen each tick.
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            CheckOutOfScreenSprites();
            CheckShipCollision();
            CheckBulletCollision();

            base.Update(gameTime);
        }
    }
}
