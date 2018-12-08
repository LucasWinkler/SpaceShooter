using Microsoft.Xna.Framework;
using SpaceShooter.Screens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceShooter.Sprites
{
    public class Enemy : Ship
    {
        // Random number generator to decide if the enemy should drop an item
        private readonly Random random;

        /// <summary>The enemies speed.</summary>
        public float Speed { get; set; }

        /// <summary>
        /// Enemy constructor
        /// </summary>
        /// <param name="game"></param>
        /// <param name="gameScreen"></param>
        public Enemy(GameRoot game, GameScreen gameScreen) : base(game, gameScreen)
        {
            this.Texture = GameRoot.ResourceManager.GetTexture("StandardGreenEnemy");
            this.random = new Random();
            this.Speed = 90.0f;
        }

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
        /// Destroys this enemy.
        /// </summary>
        public override void Destroy()
        {
            GameScreen.ComponentsToRemove.Add(this);
            GameScreen.EnemySpawner.EnemiesOnScreen--;
            DropItem();

            base.Destroy();
        }

        private void DropItem()
        {

        }

        /// <summary>
        /// Updates the enemies position.
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            this.Position += Velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;

            base.Update(gameTime);
        }
    }
}
