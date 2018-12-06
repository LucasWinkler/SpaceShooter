using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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
            this.Components.Add(new ScrollingBackground(GameRoot));

            this.Components.Add(new Title(GameRoot));

            // Add a menu selector so that screens can be switched.
            this.Components.Add(new MenuSelector(GameRoot, menuItems,
                new Vector2(GraphicsDevice.Viewport.Width / 2, GraphicsDevice.Viewport.Height / 2)));

            this.SetActive(true);
            base.Initialize();
        }

        /// <summary>
        /// Loads any content needed for the start screen
        /// </summary>
        protected override void LoadContent()
        {
            base.LoadContent();
        }

        /// <summary>
        /// Updates the start screen.
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        /// <summary>
        /// Draws the start screen.
        /// </summary> 
        /// <param name="gameTime"></param>
        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}
