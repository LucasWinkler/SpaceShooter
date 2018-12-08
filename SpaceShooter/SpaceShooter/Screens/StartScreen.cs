using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using SpaceShooter.Screens.Components;
using SpaceShooter.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceShooter.Screens
{
    /// <summary>
    /// The selectable items in the main menu
    /// </summary>
    public enum SelectableMenuItems
    {
        Play,
        Help,
        Credits,
        Quit
    }

    /// <summary>
    /// The starting menu screen for the game.
    /// </summary>
    public class StartScreen : Screen
    {
        private readonly List<string> menuItems;

        /// <summary>
        /// Constructs the start screen.
        /// </summary>
        /// <param name="game"></param>
        public StartScreen(GameRoot game) : base(game)
        {
            menuItems = new List<string>()
            {
                "Play",
                "Help",
                "Credits",
                "Quit"
            };
        }

        /// <summary>
        /// Initializes the start screen.
        /// </summary>
        public override void Initialize()
        {
            Components.Add(new ScrollingBackground(GameRoot));
            Components.Add(new Title(GameRoot));
            Components.Add(new MenuSelector(GameRoot, menuItems, new Vector2(GraphicsDevice.Viewport.Width / 2, GraphicsDevice.Viewport.Height / 2)));
            BackgroundMusic = GameRoot.ResourceManager.GetMusic("MenuMusic");

            SetActive(true);

            base.Initialize();
        }
    }
}
