using Microsoft.Xna.Framework.Input;

namespace SpaceShooter.Input
{
    /// <summary>
    /// Contains methods for checking if a key is being held or pressed.
    /// </summary>
    public class KeyHandler
    {
        // Contains the previous keyboard state
        private KeyboardState previousKeyboardState;

        /// <summary>Returns the current keyboard state.</summary>
        public KeyboardState CurrentKeyboardState { get; private set; }

        /// <summary>
        /// Checks if a key is being pressed by comparing
        /// the current keyboard state with the previous.
        /// </summary>
        /// <param name="key">The key being checked.</param>
        /// <returns>Returns true if the current key is down and was previously up.</returns>
        public bool IsKeyPressed(Keys key) => CurrentKeyboardState.IsKeyDown(key) && previousKeyboardState.IsKeyUp(key);

        /// <summary>
        /// Checks if a key is being held down.
        /// </summary>
        /// <param name="key">The key being checked</param>
        /// <returns>Returns true if the current key is down.</returns>
        public bool IsKeyHeld(Keys key) => CurrentKeyboardState.IsKeyDown(key);

        /// <summary>
        /// Checks if a key is up.
        /// </summary>
        /// <param name="key">The key being checked</param>
        /// <returns>Returns true if the current key is up.</returns>
        public bool IsKeyUp(Keys key) => CurrentKeyboardState.IsKeyUp(key);

        /// <summary>
        /// Updates the keyboards previous and current state.
        /// </summary>
        public void Update()
        {
            previousKeyboardState = CurrentKeyboardState;
            CurrentKeyboardState = Keyboard.GetState();
        }
    }
}
