using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpaceShooter.Interfaces;
using SpaceShooter.Screens;
using System;

namespace SpaceShooter.Animations
{
    /// <summary>
    /// The base class for animations
    /// </summary>
    public class Animation : DrawableGameComponent, IResetable
    {
        private GameScreen gameScreen;
        private int frameIndex;
        private float animationTimer;
        private Rectangle sourceRectangle;

        /// <summary>The game instance.</summary>
        protected GameRoot GameRoot { get; }

        /// <summary>The animations spritesheet.</summary>
        public Texture2D SpriteSheet { get; }

        /// <summary>The animations position.</summary>
        public Vector2 Position { get; set; }

        /// <summary>The animations frame width (assumed to be a square).</summary>
        public int FrameWidth { get { return SpriteSheet.Height; } }

        /// <summary>The animations frame height.</summary>
        public int FrameHeight { get { return SpriteSheet.Height; } }

        /// <summary>Should the animation loop.</summary>
        public bool ShouldLoop { get; protected set; }

        /// <summary>The amount of time a frame will be played for.</summary>
        public float FrameTime { get; protected set; }

        /// <summary>The amount of frames in the animation.</summary>
        public int FrameCount { get { return SpriteSheet.Width / FrameWidth; } }

        /// <summary>
        /// Animation constructor.
        /// </summary>
        /// <param name="game"></param>
        /// <param name="gameScreen"></param>
        /// <param name="spriteSheet"></param>
        /// <param name="frameTime"></param>
        /// <param name="shouldLoop"></param>
        public Animation(GameRoot game, GameScreen gameScreen, Texture2D spriteSheet, float frameTime, bool shouldLoop) : base(game)
        {
            this.GameRoot = game;
            this.gameScreen = gameScreen;
            this.SpriteSheet = spriteSheet;
            this.FrameTime = frameTime;
            this.ShouldLoop = shouldLoop;
        }

        /// <summary>
        /// Remove the animation.
        /// </summary>
        public void Reset()
        {
            gameScreen.ComponentsToRemove.Add(this);
        }

        /// <summary>
        /// Updates the current frame.
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            if (frameIndex == (FrameCount - 1) && !ShouldLoop)
            {
                gameScreen.ComponentsToRemove.Add(this);
            }

            animationTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            while (animationTimer > FrameTime)
            {
                animationTimer -= FrameTime;

                if (ShouldLoop)
                {
                    frameIndex = (frameIndex + 1) % FrameCount;
                }
                else
                {
                    frameIndex = Math.Min(frameIndex + 1, FrameCount - 1);
                }
            }

            // Calculate the source rectangle for the current frame
            sourceRectangle = new Rectangle(frameIndex * SpriteSheet.Height, 0, SpriteSheet.Height, SpriteSheet.Height);

            base.Update(gameTime);
        }

        /// <summary>
        /// Draws the current frame.
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Draw(GameTime gameTime)
        {
            var spriteBatch = GameRoot.SpriteBatch;

            spriteBatch.Begin();
            spriteBatch.Draw(SpriteSheet, Position, sourceRectangle, Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
