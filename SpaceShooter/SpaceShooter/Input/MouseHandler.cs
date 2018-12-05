using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace SpaceShooter.Input
{
    /// <summary>
    /// Handles mouse input
    /// </summary>
    public class MouseHandler
    {
        // The previous state of the mouse
        private MouseState previousMouseState;

        /// <summary>The current state of the mouse</summary>
        public MouseState CurrentMouseState { get; private set; }

        /// <summary>The mouse bounds for collision</summary>
        public Rectangle GetBounds { get; private set; }

        /// <summary>
        /// Default Constructor
        /// </summary>
        public MouseHandler()
        {
            GetBounds = new Rectangle(CurrentMouseState.Position.X, CurrentMouseState.Position.Y, 1, 1);
        }

        /// <summary>
        /// Checks if the left mouse was clicked by comparing
        /// the current mouse state with the previous mouse state
        /// </summary>
        /// <returns>Returns true if the current key is down and was previously up</returns>
        public bool IsLeftMouseClicked() => CurrentMouseState.LeftButton == ButtonState.Pressed && previousMouseState.LeftButton == ButtonState.Released;

        /// <summary>
        /// Checks if the left mouse is held
        /// </summary>
        /// <returns>Returns true if the current key is down and was previously up</returns>
        public bool IsLeftMouseHeld() => CurrentMouseState.LeftButton == ButtonState.Pressed;

        /// <summary>
        /// Updates the mouses previous and current state
        /// </summary>
        public void Update()
        {
            previousMouseState = CurrentMouseState;
            CurrentMouseState = Mouse.GetState();
        }
    }
}
