using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceShooter.Camera
{
    /// <summary>
    /// A game camera to for two-dimensional spaces.
    /// </summary>
    public class Camera2D : GameComponent
    {
        // Instance of the game
        private readonly GameRoot gameRoot;

        // Camera position related fields
        private Vector2 position = GameSettings.GAME_CENTER;
        private Vector2 origin = GameSettings.GAME_CENTER;

        private readonly float rotation = 0;
        private readonly float SCALE = 1.0f;

        // Camera shake related fields
        private bool shouldShakeCamera = false;
        private float shakeRadius = 15.0f;
        private float shakeStartAngle = 0.0f;
        private const float shakeDuration = 2.0f;

        /// <summary>Cameras transformation matrix</summary>
        public Matrix Transform { get; private set; }

        /// <summary>
        /// Constructor that needs the game instance
        /// </summary>
        /// <param name="spaceGame"></param>
        public Camera2D(GameRoot game) : base(game) => this.gameRoot = game;

        /// <summary>
        /// Shakes the games camera/game screen
        /// </summary>
        private void ShakeCamera(GameTime gameTime)
        {
            var rand = new Random();
            var offset = new Vector2((float)(Math.Sin(shakeStartAngle) * shakeRadius), (float)(Math.Cos(shakeStartAngle) * shakeRadius));

            shakeRadius -= 0.25f;
            shakeStartAngle += 150 + rand.Next(60);

            if (gameTime.TotalGameTime.TotalSeconds - gameTime.ElapsedGameTime.TotalSeconds > shakeDuration || shakeRadius <= 0)
                shouldShakeCamera = false;

            position += offset;
        }

        /// <summary>
        /// Updates the cameras position
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            // Creates a transformation matrix used by spriteBatch.Begin
            Transform = Matrix.Identity *
                        Matrix.CreateTranslation(-position.X, -position.Y, 0) *
                        Matrix.CreateRotationZ(rotation) *
                        Matrix.CreateTranslation(origin.X, origin.Y, 0) *
                        Matrix.CreateScale(new Vector3(SCALE, SCALE, SCALE));

            // Reset the camera position to the middle of the screen
            position = GameSettings.GAME_CENTER;

            // If the shouldShakeCamera bool is true then shake the camera
            if (shouldShakeCamera)
                ShakeCamera(gameTime);

            base.Update(gameTime);
        }
    }
}
