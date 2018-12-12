using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using SpaceShooter.Input;
using SpaceShooter.Screens.Components;

namespace SpaceShooter.Screens
{
    /// <summary>
    /// The screen which displays the dev and any credits.
    /// </summary>
    public class CreditsScreen : Screen
    {
        private KeyHandler keyHandler;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="game"></param>
        public CreditsScreen(GameRoot game) : base(game)
        {
            this.keyHandler = new KeyHandler();
        }

        /// <summary>
        /// Initialize the screen.
        /// </summary>
        public override void Initialize()
        {
            Components.Add(new ScrollingBackground(GameRoot));
            Components.Add(new Title(GameRoot, "CREDITS"));
            Components.Add(new BasicText(GameRoot, "GAME CREATED BY: Lucas Winkler", new Vector2(GameSettings.GAME_CENTER.X, GameSettings.GAME_CENTER.Y)));
            Components.Add(new BasicText(GameRoot, "ASSETS CREATED BY: Pixel-boy, Kenney and many others.", new Vector2(GameSettings.GAME_CENTER.X, GameSettings.GAME_CENTER.Y + 20)));
            //BackgroundMusic = GameRoot.ResourceManager.GetMusic("MenuMusic");

            base.Initialize();
        }

        /// <summary>
        /// Update the screen.
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            keyHandler.Update();

            if (keyHandler.IsKeyPressed(Keys.Escape))
            {
                var startScreen = GameRoot.Services.GetService<StartScreen>();
                GameRoot.HideScreens();
                startScreen.SetActive(true);
            }

            base.Update(gameTime);
        }
    }
}
