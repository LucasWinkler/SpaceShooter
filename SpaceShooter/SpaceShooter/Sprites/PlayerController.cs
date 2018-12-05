using Microsoft.Xna.Framework;
using SpaceShooter.Input;

namespace SpaceShooter.Sprites
{
    /// <summary>
    /// Controls the input of the player.
    /// </summary>
    public class PlayerController : GameComponent
    {
        private GameRoot game;
        private readonly Player player;
        private readonly KeyHandler keyHandler;

        private Vector2 direction;

        /// <summary>
        /// Construct the player controller.
        /// </summary>
        /// <param name="game"></param>
        /// <param name="player"></param>
        public PlayerController(GameRoot game, Player player) : base(game)
        {
            this.game = game;
            this.player = player;
            this.keyHandler = new KeyHandler();
        }

        /// <summary>
        /// Move the player.
        /// </summary>
        /// <param name="gameTime"></param>
        public void Move(GameTime gameTime)
        {
            if (direction.Length() > 0)
                direction.Normalize();

            player.Velocity = direction * player.Speed;
            player.Position += player.Velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }

        /// <summary>
        /// Shoots a bullet from the player
        /// </summary>
        public void Shoot()
        {
            // Shoots as long as the timer has passed the delay and the max shells hasn't been reached
            if (player.ShootTimer >= player.ShootDelay)
            {
                // Create a new bullet and give it the game instance as well as the player as a parent
                var bullet = new Bullet(game, player);

                // Set the startPosition to the players position
                var startPosition = player.Position;

                // Modifiy the starting position to be infront of the player and centered
                startPosition.X += (player.Texture.Width / 2) - (bullet.Texture.Width / 2);
                startPosition.Y -= bullet.Texture.Height;

                // Give the bullet the new position
                bullet.Position = startPosition;

                // Add the bullet to the components to be updated and drawn
                game.Components.Add(bullet);

                // Reset the shooting timer
                player.ShootTimer = 0;
            }
        }

        /// <summary>
        /// Handle the players input.
        /// </summary>
        public void HandleInput(float delta)
        {
            keyHandler.Update();

            // Move the player on the appropriate axis
            if (keyHandler.IsKeyHeld(player.KeyBinds.Forwards))
            {
                direction.Y = -1;
            }
            if (keyHandler.IsKeyHeld(player.KeyBinds.Left))
            {
                direction.X = -1;
            }
            if (keyHandler.IsKeyHeld(player.KeyBinds.Backwards))
            {
                direction.Y = 1;
            }
            if (keyHandler.IsKeyHeld(player.KeyBinds.Right))
            {
                direction.X = 1;
            }

            // Stops moving the player on the appropriate axis
            if (keyHandler.IsKeyUp(player.KeyBinds.Forwards) && keyHandler.IsKeyUp(player.KeyBinds.Backwards))
            {
                direction.Y = 0;
            }
            if (keyHandler.IsKeyUp(player.KeyBinds.Left) && keyHandler.IsKeyUp(player.KeyBinds.Right))
            {
                direction.X = 0;
            }

            // Handles the players shooting
            if (keyHandler.IsKeyHeld(player.KeyBinds.Shoot))
            {
                Shoot();
            }
        }

        /// <summary>
        /// Update the players position.
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
