using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using SpaceShooter.Input;
using SpaceShooter.Screens.Components;

namespace SpaceShooter.Screens
{
    /// <summary>
    /// The end/game over screen.
    /// </summary>
    public class EndScreen : Screen
    {
        private KeyHandler keyHandler;

        /// <summary>The ending score to be displayed.</summary>
        public EndScore EndScore { get; private set; }

        /// <summary>
        /// End screen constructor.
        /// </summary>
        /// <param name="game"></param>
        public EndScreen(GameRoot game) : base(game)
        {
            this.keyHandler = new KeyHandler();
        }

        /// <summary>
        /// Initialize the screen.
        /// </summary>
        public override void Initialize()
        {
            Components.Add(new Title(GameRoot, "GAME OVER"));
            Components.Add(EndScore = new EndScore(GameRoot));
            Components.Add(new BasicText(GameRoot, "PRESS ESCAPE TO RETURN TO THE MAIN MENU", new Vector2(GameSettings.GAME_WIDTH / 2, 400)));
            BackgroundMusic = GameRoot.ResourceManager.GetMusic("EndMusic");

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
                GameRoot.HideScreens();
                var startScreen = GameRoot.Services.GetService<StartScreen>();
                startScreen.SetActive(true);
                startScreen.PlayMusic();
            }

            base.Update(gameTime);
        }
    }
}
