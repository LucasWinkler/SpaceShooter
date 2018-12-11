using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using SpaceShooter.Screens;
using SpaceShooter.Utility;
using System;
namespace SpaceShooter.Sprites
{
    /// <summary>
    /// 
    /// </summary>
    public class Enemy : Ship
    {
        private readonly Random random;

        private const float MIN_SHOOT_DELAY = 0.85f;
        private const float MAX_SHOOT_DELAY = 1.65f;

        /// <summary>
        /// Enemy constructor
        /// </summary>
        /// <param name="game"></param>
        /// <param name="gameScreen"></param>
        public Enemy(GameRoot game, GameScreen gameScreen) : base(game, gameScreen)
        {
            this.Texture = GameRoot.ResourceManager.GetTexture("StandardGreenEnemy");
            this.shootingSound = GameRoot.ResourceManager.GetSound("EnemyShoot");
            this.random = new Random();
            this.ShootDelay = 1.2f;
        }

        /// <summary>
        /// Initialize the enemy.
        /// </summary>
        public override void Initialize()
        {
            Velocity = new Vector2(0, Speed);
            Position = StartPosition;

            base.Initialize();
        }

        /// <summary>
        /// Removes the enemy from the game since an enemy
        /// will never be reset. Used to remove all when a 
        /// new screen is loaded.
        /// </summary>
        public override void Reset()
        {
            GameScreen.ComponentsToRemove.Add(this);

            base.Reset();
        }

        /// <summary>
        /// Silently removes an enemy from the game.
        /// </summary>
        public void Remove()
        {
            GameScreen.ComponentsToRemove.Add(this);
            GameScreen.EnemySpawner.EnemiesOnScreen--;
        }

        /// <summary>
        /// Destroys this enemy.
        /// </summary>
        public override void Destroy()
        {
            GameScreen.ComponentsToRemove.Add(this);
            GameScreen.EnemySpawner.EnemiesOnScreen--;

            base.Destroy();
        }

        /// <summary>
        /// Shoots a bullet from the enemy.
        /// </summary>
        protected override void Shoot()
        {
            // Shoots as long as the timer has passed the delay
            if (ShootTimer >= ShootDelay)
            {
                // Create a new bullet and give it the game instance as well as the player as a parent
                var bullet = new Bullet(GameRoot, GameScreen, this);

                bullet.Velocity = -bullet.Velocity;

                var startPosition = Position;

                // Modifiy the starting position to be infront of the player and centered
                startPosition.X += (Texture.Width / 2) - (bullet.Texture.Width / 2);
                startPosition.Y += Texture.Height;

                // Give the bullet the new position
                bullet.Position = startPosition;

                // Add the bullet to the components to be updated and drawn
                GameScreen.Components.Add(bullet);

                shootingSound.Play();

                // Reset the shooting timer
                ShootTimer = 0;

                // Randomize the shooting delay
                ShootDelay = CalculationHelper.GetRandomFloat(MIN_SHOOT_DELAY, MAX_SHOOT_DELAY);
            }
        }

        /// <summary>
        /// Updates the enemies position.
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {

            this.Position += Velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;
            Shoot();

            base.Update(gameTime);
        }
    }
}
