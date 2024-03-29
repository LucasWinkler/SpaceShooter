﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpaceShooter.Interfaces;

namespace SpaceShooter.Sprites
{
    /// <summary>
    /// The base class for a drawable sprite in the game.
    /// </summary>
    public abstract class Sprite : DrawableGameComponent, IResetable
    {
        /// <summary>The instance of the game object.</summary>
        public GameRoot GameRoot { get; }

        /// <summary>The sprites texture.</summary>
        public Texture2D Texture { get; set; }

        /// <summary>The sprites position.</summary>
        public Vector2 Position { get; set; }

        /// <summary>The sprites origin.</summary>
        public Vector2 Origin { get; protected set; }

        /// <summary>The sprites velocity.</summary>
        public Vector2 Velocity { get; set; }

        /// <summary>The sprites axis-aligned bounding box.</summary>
        public Rectangle Bounds { get { return new Rectangle((int)Position.X, (int)Position.Y, Texture.Width, Texture.Height); } }

        /// <summary>
        /// Construct the sprite.
        /// </summary>
        /// <param name="game"></param>
        public Sprite(GameRoot game) : base(game)
        {
            this.GameRoot = game;
        }

        /// <summary>
        /// Used for resetting the sprite.
        /// </summary>
        public virtual void Reset()
        {
            Position = Vector2.Zero;
            Velocity = Vector2.Zero;
        }

        /// <summary>
        /// Destroyed/removes the sprite from the game.
        /// </summary>
        public abstract void Destroy();

        /// <summary>
        /// The default drawing method for the sprite.
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Draw(GameTime gameTime)
        {
            var spriteBatch = GameRoot.SpriteBatch;

            spriteBatch.Begin();
            spriteBatch.Draw(Texture, Position, Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
