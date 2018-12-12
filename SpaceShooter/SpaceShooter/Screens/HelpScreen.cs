using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using SpaceShooter.Input;
using SpaceShooter.Screens.Components;

namespace SpaceShooter.Screens
{
    /// <summary>
    /// The help screen that shows controls
    /// </summary>
    public class HelpScreen : Screen
    {
        private KeyHandler keyHandler;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="game"></param>
        public HelpScreen(GameRoot game) : base(game)
        {
            this.keyHandler = new KeyHandler();
        }

        /// <summary>
        /// Initialize the screen.
        /// </summary>
        public override void Initialize()
        {
            //Components.Add(new ScrollingBackground(GameRoot));
            Components.Add(new Title(GameRoot, "HELP"));

            Components.Add(new BasicText(GameRoot, "MOVEMENT KEYS", new Vector2(GameSettings.GAME_CENTER.X, GameSettings.GAME_CENTER.Y)));
            Components.Add(new InputKey(GameRoot, GameRoot.ResourceManager.GetTexture("BlackWKey"), new Vector2(GameSettings.GAME_CENTER.X - 112, GameSettings.GAME_CENTER.Y + 20)));
            Components.Add(new InputKey(GameRoot, GameRoot.ResourceManager.GetTexture("BlackAKey"), new Vector2(GameSettings.GAME_CENTER.X - 32, GameSettings.GAME_CENTER.Y + 20)));
            Components.Add(new InputKey(GameRoot, GameRoot.ResourceManager.GetTexture("BlackSKey"), new Vector2(GameSettings.GAME_CENTER.X + 48, GameSettings.GAME_CENTER.Y + 20)));
            Components.Add(new InputKey(GameRoot, GameRoot.ResourceManager.GetTexture("BlackDKey"), new Vector2(GameSettings.GAME_CENTER.X + 128, GameSettings.GAME_CENTER.Y + 20)));

            Components.Add(new BasicText(GameRoot, "SHOOTING KEY", new Vector2(GameSettings.GAME_CENTER.X, GameSettings.GAME_CENTER.Y + 125)));
            Components.Add(new InputKey(GameRoot, GameRoot.ResourceManager.GetTexture("BlackSpaceKey"), new Vector2(GameSettings.GAME_CENTER.X, GameSettings.GAME_CENTER.Y + 140)));

            Components.Add(new BasicText(GameRoot, "MAIN MENU KEY", new Vector2(GameSettings.GAME_CENTER.X, GameSettings.GAME_CENTER.Y + 250)));
            Components.Add(new InputKey(GameRoot, GameRoot.ResourceManager.GetTexture("BlackEscKey"), new Vector2(GameSettings.GAME_CENTER.X, GameSettings.GAME_CENTER.Y + 270)));

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
