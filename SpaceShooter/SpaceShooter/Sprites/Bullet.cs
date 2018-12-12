using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpaceShooter.Screens;

namespace SpaceShooter.Sprites
{
    /// <summary>
    /// A bullet in the game that is shot by a ship.
    /// </summary>
    public class Bullet : Sprite
    {
        // Game screen instance
        private GameScreen gameScreen;

        private SpriteEffects spriteEffects;

        /// <summary>The bullets damage.</summary>
        public int Damage { get; }

        /// <summary>Bullets parent (sprite that shot the bullet).</summary>
        public Sprite Parent { get; }

        /// <summary>Bullets speed.</summary>
        public float Speed { get; } = 675.0f;

        /// <summary>
        /// Construct a bullet with a parent.
        /// </summary>
        /// <param name="GameRoot"></param>
        /// <param name="gameScreen"></param>
        /// <param name="parent"></param>
        /// <param name="spriteEffects"></param>
        public Bullet(GameRoot GameRoot, GameScreen gameScreen, Sprite parent, SpriteEffects spriteEffects) : base(GameRoot)
        {
            this.gameScreen = gameScreen;
            this.Parent = parent;
            this.spriteEffects = spriteEffects;
            this.Texture = GameRoot.ResourceManager.GetTexture("SmallPlasmaBullet");
            this.Velocity = new Vector2(0, -Speed);
            this.Damage = 50;
        }

        /// <summary>
        /// Reset/remove the bullet.
        /// </summary>
        public override void Reset()
        {
            gameScreen.ComponentsToRemove.Add(this);

            base.Reset();
        }

        /// <summary>
        /// Destroys/removes the bullet.
        /// </summary>
        public override void Destroy()
        {
            // Add to the ComponentsToRemove list to remove at the end of the iteration
            gameScreen.ComponentsToRemove.Add(this);

            // TODO: Animation? sound effect?
        }

        /// <summary>
        /// Update the bullets location.
        /// </summary>
        /// <param name="GameRootTime"></param>
        public override void Update(GameTime GameRootTime)
        {
            Position += Velocity * (float)GameRootTime.ElapsedGameTime.TotalSeconds;

            base.Update(GameRootTime);
        }

        /// <summary>
        /// Draws the bullet
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Draw(GameTime gameTime)
        {
            var spriteBatch = GameRoot.SpriteBatch;

            spriteBatch.Begin();
            spriteBatch.Draw(Texture, Position, null, Color.White, 0.0f, Origin, 1.0f, spriteEffects, 1.0f);
            spriteBatch.End();
        }
    }
}
