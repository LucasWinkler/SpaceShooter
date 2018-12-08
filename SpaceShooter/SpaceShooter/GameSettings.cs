using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceShooter
{
    /// <summary>
    /// The game/window settings (e.g. width and height)
    /// </summary>
    public class GameSettings
    {
        /// <value>The title for the game</value>
        public const string GAME_TITLE = "Space Defender";

        /// <value>The games width</value>
        public const int GAME_WIDTH = 700;

        /// <value>The games height</value>
        public const int GAME_HEIGHT = 800;

        /// <value>Determines whether the game is fullscreen or windowed</value>
        public const bool IS_FULLSCREEN = false;

        /// <value>Determines whether the mouse is visible in the game</value>
        public const bool IS_MOUSE_VISIBLE = true;

        /// <value>The games center point</value>
        public static Vector2 GAME_CENTER = new Vector2(GAME_WIDTH / 2, GAME_HEIGHT / 2);
    }
}