using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceShooter.Sprites
{
    /// <summary>
    /// The base class for a drawable sprite in the game.
    /// </summary>
    public abstract class Sprite : DrawableGameComponent
    {
        /// <summary>The instance of the game object.</summary>
        public GameRoot GameRoot { get; }

        /// <summary>The sprites texture.</summary>
        public Texture2D Texture { get; protected set; }

        /// <summary>The sprites position.</summary>
        public Vector2 Position { get; protected set; }

        /// <summary>The sprites origin.</summary>
        public Vector2 Origin { get; protected set; }

        /// <summary>The sprites velocity.</summary>
        public Vector2 Velocity { get; protected set; }

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
        public abstract void Reset();

        /// <summary>
        /// The default drawing method for the sprite.
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Draw(GameTime gameTime)
        {
            GameRoot.SpriteBatch.Draw(Texture, Position, Color.White);

            base.Draw(gameTime);
        }
    }
}
