using Microsoft.Xna.Framework;

namespace SpaceShooter
{
    /// <summary>
    /// The game/window settings (e.g. width and height)
    /// </summary>
    public class GameSettings
    {
        /// <summary>The title for the game</summary>
        public const string GAME_TITLE = "Space Defender";

        /// <summary>The games width</summary>
        public const int GAME_WIDTH = 700;

        /// <summary>The games height</summary>
        public const int GAME_HEIGHT = 800;

        /// <summary>Determines whether the game is fullscreen or windowed</summary>
        public const bool IS_FULLSCREEN = false;

        /// <summary>Determines whether the mouse is visible in the game</summary>
        public const bool IS_MOUSE_VISIBLE = true;

        /// <summary>The games center point</summary>
        public static Vector2 GAME_CENTER = new Vector2(GAME_WIDTH / 2, GAME_HEIGHT / 2);
    }
}