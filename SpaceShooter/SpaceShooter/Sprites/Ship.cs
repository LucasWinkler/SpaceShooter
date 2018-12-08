﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpaceShooter.Screens;

namespace SpaceShooter.Sprites
{
    public class Ship : Sprite
    {
        // The time that the player hasnt shot.
        protected float ShootTimer;

        /// <summary>Game screen instance.</summary>
        public GameScreen GameScreen { get; }

        /// <summary>The ships starting position.</summary>
        public Vector2 StartPosition { get; set; }

        /// <summary>The ships direction.</summary>
        public Vector2 Direction { get; set; }

        /// <summary>The ships shooting delay.</summary>
        public float ShootDelay { get; set; } = 0.2222f;

        /// <summary>The ships health (default is 50).</summary>
        public int Health { get; set; }

        /// <summary>Returns true if health is greater than zero.</summary>
        public bool IsAlive => Health > 0;

        /// <summary>
        /// Construct the ship object with a texture
        /// </summary>
        /// <param name="game"></param>
        public Ship(GameRoot game, GameScreen gameScreen) : base(game)
        {
            this.GameScreen = gameScreen;
            this.Health = 50;
        }

        /// <summary>
        /// Destroy the ship
        /// </summary>
        public override void Destroy() { }

        /// <summary>
        /// Damage the ship
        /// </summary>
        /// <param name="damage"></param>
        public virtual void Damage(int damage)
        {
            if (Health > 0) Health -= damage;
            if (!IsAlive) Destroy();
        }

        /// <summary>
        /// Update the ship
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            ShootTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            base.Update(gameTime);
        }
    }
}
