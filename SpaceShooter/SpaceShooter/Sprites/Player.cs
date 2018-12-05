﻿using Microsoft.Xna.Framework;
using SpaceShooter.Input;
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

        /// <summary>The players speed.</summary>
        public float Speed { get; } = 330.0f;

        /// <summary>The players keybinds.</summary>
        public KeyBinds KeyBinds { get; }

        /// <summary>
        /// Constructs the player object.
        /// </summary>
        /// <param name="game"></param>
        public Player(GameRoot game, KeyBinds keyBinds) : base(game)
        {
            this.KeyBinds = keyBinds;
            this.Texture = GameRoot.ResourceManager.GetTexture("BluePlayer");
        }

        /// <summary>
        /// Initializes the player.
        /// </summary>
        public override void Initialize()
        {
            StartPosition = new Vector2(STARTING_WIDTH_OFFSET - (Texture.Width / 2), STARTING_HEIGHT_OFFSET - (Texture.Height / 2));
            Reset();

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
        }

        public override void Destroy()
        {
            GameRoot.Components.Remove(this);
        }

        /// <summary>
        /// Updates the player.
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        /// <summary>
        /// Draws the player.
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}
