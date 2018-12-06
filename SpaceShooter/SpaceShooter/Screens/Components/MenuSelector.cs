using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SpaceShooter.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceShooter.Screens.Components
{
    /// <summary>
    /// A menu selector component.
    /// </summary>
    public class MenuSelector : DrawableGameComponent
    {
        // Game instance
        private readonly GameRoot game;

        // Handles key input
        private readonly KeyHandler keyHandler;

        // The selectors position on the screen
        private Vector2 position;

        // The selectors items
        private readonly List<string> menuItems;

        // The active menu item font and colour
        private SpriteFont currentItemFont;
        private Color currentItemColour;

        // Menu item fonts
        private SpriteFont standardItemFont;
        private SpriteFont selectedItemFont;

        // Menu item colours
        private Color standardItemColour = Color.White;
        private Color selectedItemColour = Color.Yellow;

        private const int MENU_ITEM_OFFSET = 64;

        // The selected menu item index
        public int SelectedItem { get; private set; }

        /// <summary>
        /// Constructs a menu selector with specific 
        /// menu items at a specific position.
        /// </summary>
        /// <param name="game"></param>
        /// <param name="menuItems"></param>
        /// <param name="position"></param>
        public MenuSelector(GameRoot game, List<string> menuItems, Vector2 position) : base(game)
        {
            this.game = game;
            this.menuItems = menuItems;
            this.position = position;
            this.keyHandler = new KeyHandler();
        }

        /// <summary>
        /// Initialize the menu selector.
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            standardItemFont = game.ResourceManager.GetFont("StandardMenuItem");
            selectedItemFont = game.ResourceManager.GetFont("SelectedMenuItem");

            base.LoadContent();
        }

        private void SwitchToSelectedScreen()
        {
            // Hide all the game screens
            game.HideScreens();

            switch ((SelectableMenuItems)SelectedItem)
            {
                case SelectableMenuItems.Play:
                    game.Services.GetService<GameScreen>().SetActive(true);
                    break;
                case SelectableMenuItems.Help:
                    // Switch to the start screen as a backup
                    game.Services.GetService<StartScreen>().SetActive(true);
                    break;
                case SelectableMenuItems.Credits:
                    // Switch to the start screen as a backup
                    game.Services.GetService<StartScreen>().SetActive(true);
                    break;
                case SelectableMenuItems.Quit:
                    game.Exit();
                    break;
                default:
                    // Switch to the start screen as a backup
                    game.Services.GetService<StartScreen>().SetActive(true);
                    break;
            }
        }

        public override void Update(GameTime gameTime)
        {
            keyHandler.Update();

            if (keyHandler.IsKeyPressed(Keys.A) || keyHandler.IsKeyPressed(Keys.Left))
            {
                if (SelectedItem > 0)
                {
                    SelectedItem--;
                }
            }

            if (keyHandler.IsKeyPressed(Keys.D) || keyHandler.IsKeyPressed(Keys.Right))
            {
                if (SelectedItem < menuItems.Count - 1)
                {
                    SelectedItem++;
                }
            }

            if (keyHandler.IsKeyPressed(Keys.Enter))
            {
                SwitchToSelectedScreen();
            }

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            var spriteBatch = game.SpriteBatch;
            var itemPosition = new Vector2((position.X / 2) - (MENU_ITEM_OFFSET / 1.5f), GameSettings.GAME_HEIGHT / 2 + MENU_ITEM_OFFSET / 2);

            spriteBatch.Begin();

            for (int i = 0; i < menuItems.Count; i++)
            {
                currentItemFont = standardItemFont;
                currentItemColour = standardItemColour;

                if (SelectedItem == i)
                {
                    currentItemColour = selectedItemColour;
                }
                else
                {
                    currentItemColour *= 0.45f;
                }

                spriteBatch.DrawString(currentItemFont, menuItems[i], itemPosition, currentItemColour);
                itemPosition.X += currentItemFont.MeasureString(menuItems[i]).X + MENU_ITEM_OFFSET;
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
