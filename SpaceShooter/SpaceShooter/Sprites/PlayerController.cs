using Microsoft.Xna.Framework;
using SpaceShooter.Input;

namespace SpaceShooter.Sprites
{
    /// <summary>
    /// Controls the input of the player.
    /// </summary>
    public class PlayerController : GameComponent
    {
        private readonly Player player;
        private readonly KeyHandler keyHandler;

        private Vector2 tempPosition;
        private Vector2 direction;

        /// <summary>
        /// Construct the player controller.
        /// </summary>
        /// <param name="game"></param>
        /// <param name="player"></param>
        public PlayerController(GameRoot game, Player player) : base(game)
        {
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
        /// Handle the players input.
        /// </summary>
        public void HandleInput()
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
            if (keyHandler.IsKeyPressed(player.KeyBinds.Shoot))
            {
                if (player.CanShoot)
                {
                    player.Shoot();
                }
            }
        }

        /// <summary>
        /// Update the players position.
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            HandleInput();
            Move(gameTime);

            base.Update(gameTime);
        }
    }
}
