using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using SpaceShooter.Animations;
using SpaceShooter.Screens;

namespace SpaceShooter.Sprites
{
    /// <summary>
    /// A ship in the game.
    /// </summary>
    public abstract class Ship : Sprite
    {
        private Animation explosionAnimation;

        /// <summary>The ships shooting sound.</summary>
        protected SoundEffect shootingSound;

        /// <summary>The ships shooting sound.</summary>
        protected SoundEffect explosionSound;

        /// <summary>The time that the player hasnt shot..</summary>
        protected float ShootTimer { get; set; }

        /// <summary>Game screen instance.</summary>
        public GameScreen GameScreen { get; }

        /// <summary>The ships starting position.</summary>
        public Vector2 StartPosition { get; set; }

        /// <summary>The ships direction.</summary>
        public Vector2 Direction { get; set; }

        /// <summary>The ships speed.</summary>
        public float Speed { get; set; }

        /// <summary>The ships shooting delay.</summary>
        public float ShootDelay { get; set; }

        /// <summary>The ships health.</summary>
        public int Health { get; set; }

        /// <summary>The ships maximum health.</summary>
        public int MaxHealth { get; protected set; }

        /// <summary>Returns true if health is greater than zero.</summary>
        public bool IsAlive => Health > 0;

        /// <summary>
        /// Construct the ship object with a texture.
        /// </summary>
        /// <param name="game"></param>
        /// <param name="gameScreen"></param>
        public Ship(GameRoot game, GameScreen gameScreen) : base(game)
        {
            this.GameScreen = gameScreen;
            this.explosionSound = GameRoot.ResourceManager.GetSound("Explosion");
            this.ShootDelay = 0.5f;
            this.MaxHealth = 50;
            this.Health = MaxHealth;
            this.Speed = 90.0f;
            this.ShootTimer = ShootDelay;
            this.explosionAnimation = new Animation(GameRoot, GameScreen,  GameRoot.ResourceManager.GetTexture("ExplosionAnimation"), 0.01f, false);
        }

        /// <summary>
        /// Destroy the ship
        /// </summary>
        public override void Destroy()
        {
            explosionSound.Play(0.08f, 0.0f, 0.0f);
            explosionAnimation.Position = Position;
            GameScreen.Components.Add(explosionAnimation);
        }

        /// <summary>
        /// Damage the ship
        /// </summary>
        /// <param name="damage"></param>
        public virtual void Damage(int damage)
        {
            Health = MathHelper.Clamp(Health - damage, 0, MaxHealth);

            if (!IsAlive) Destroy();
        }

        /// <summary>The method which allows the ship to shoot.</summary>
        protected abstract void Shoot();

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
