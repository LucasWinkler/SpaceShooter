using Microsoft.Xna.Framework;
using SpaceShooter.Input;
using SpaceShooter.Screens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceShooter.Sprites
{
    /// <summary>
    /// The player in the game.
    /// </summary>
    public class Player : Ship
    {
        // The offsets for the players starting position
        private const float STARTING_WIDTH_OFFSET = GameSettings.GAME_WIDTH / 2;
        private const float STARTING_HEIGHT_OFFSET = GameSettings.GAME_HEIGHT - 100;

        private const int MAX_HEALTH = 150;

        // Movement related vectors
        private Vector2 direction;
        private Vector2 newPosition;

        // Handle the players keyboard input
        private KeyHandler keyHandler;

        // Event called when the player is damaged
        public event EventHandler Damaged;

        /// <summary>The players speed.</summary>
        public float Speed { get; } = 320.0f;

        /// <summary>The players score.</summary>
        public int Score { get; set; }

        /// <summary>The players keybinds.</summary>
        public KeyBinds KeyBinds { get; }

        /// <summary>
        /// Constructs the player object.
        /// </summary>
        /// <param name="game"></param>
        public Player(GameRoot game, GameScreen GameScreen, KeyBinds keyBinds) : base(game, GameScreen)
        {
            this.KeyBinds = keyBinds;
            this.keyHandler = new KeyHandler();

            // The players texture is set here instead of load 
            // content because the StartPosition requires the textures size
            this.Texture = GameRoot.ResourceManager.GetTexture("BluePlayer");
            this.Health = MAX_HEALTH;
        }

        /// <summary>
        /// Initializes the 
        /// </summary>
        public override void Initialize()
        {
            StartPosition = new Vector2(STARTING_WIDTH_OFFSET - (Texture.Width / 2), STARTING_HEIGHT_OFFSET - (Texture.Height / 2));

            base.Initialize();
        }

        /// <summary>
        /// Resets the player
        /// </summary>
        public override void Reset()
        {
            Position = StartPosition;
            Velocity = Vector2.Zero;
            ShootTimer = 0.0f;
            Health = MAX_HEALTH;
            Score = 0;
        }

        /// <summary>
        /// Destroys the player object
        /// </summary>
        public override void Destroy()
        {
            // TODO: Play animation, sound effect and show game over screen.
        }

        public override void Damage(int damage)
        {
            base.Damage(damage);
            Damaged?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Move the 
        /// </summary>
        /// <param name="gameTime"></param>
        public void Move(GameTime gameTime)
        {
            // Normalize the vector if the length is > 0 to prevent diagonal movement from increasing the overall player speed
            if (direction.Length() > 0)
                direction.Normalize();

            Velocity = direction * Speed;

            // Calculate the new position
            newPosition = Position + Velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;

            // Make sure the new position is within the game screen
            newPosition.X = MathHelper.Clamp(newPosition.X, 0, GameSettings.GAME_WIDTH - Texture.Width);
            newPosition.Y = MathHelper.Clamp(newPosition.Y, 0, GameSettings.GAME_HEIGHT - Texture.Height);

            // Finally set the players position to the new position
            Position = newPosition;
        }

        /// <summary>
        /// Shoots a bullet from the player
        /// </summary>
        public void Shoot()
        {
            // Shoots as long as the timer has passed the delay
            if (ShootTimer >= ShootDelay)
            {
                // Create a new bullet and give it the game instance as well as the player as a parent
                var bullet = new Bullet(GameRoot, GameScreen, this);

                // Set the startPosition to the players position
                var startPosition = Position;

                // Modifiy the starting position to be infront of the player and centered
                startPosition.X += (Texture.Width / 2) - (bullet.Texture.Width / 2);
                startPosition.Y -= bullet.Texture.Height;

                // Give the bullet the new position
                bullet.Position = startPosition;

                // Add the bullet to the components to be updated and drawn
                GameScreen.Components.Add(bullet);

                // Reset the shooting timer
                ShootTimer = 0;
            }
        }

        /// <summary>
        /// Handle the players input.
        /// </summary>
        public void HandleInput(float delta)
        {
            keyHandler.Update();

            // Move the player on the appropriate axis
            if (keyHandler.IsKeyHeld(KeyBinds.Forwards))
            {
                direction.Y = -1;
            }
            if (keyHandler.IsKeyHeld(KeyBinds.Left))
            {
                direction.X = -1;
            }
            if (keyHandler.IsKeyHeld(KeyBinds.Backwards))
            {
                direction.Y = 1;
            }
            if (keyHandler.IsKeyHeld(KeyBinds.Right))
            {
                direction.X = 1;
            }

            // Stops moving the player on the appropriate axis
            if (keyHandler.IsKeyUp(KeyBinds.Forwards) && keyHandler.IsKeyUp(KeyBinds.Backwards))
            {
                direction.Y = 0;
            }
            if (keyHandler.IsKeyUp(KeyBinds.Left) && keyHandler.IsKeyUp(KeyBinds.Right))
            {
                direction.X = 0;
            }

            // Handles the players shooting
            if (keyHandler.IsKeyHeld(KeyBinds.Shoot))
            {
                Shoot();
            }
        }

        /// <summary>
        /// Updates the 
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            HandleInput((float)gameTime.ElapsedGameTime.TotalSeconds);
            Move(gameTime);

            base.Update(gameTime);
        }
    }
}
