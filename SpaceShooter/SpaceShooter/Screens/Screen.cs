using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace SpaceShooter.Screens
{
    /// <summary>
    /// The base class for a drawable game screen.
    /// </summary>
    public abstract class Screen : DrawableGameComponent
    {
        /// <summary>The instance of the game object.</summary>
        public GameRoot GameRoot { get; }

        /// <summary>The list of components in the screen.</summary>
        public List<GameComponent> Components { get; private set; }

        /// <summary>
        /// Constructs a screen and gets the game instance.
        /// The screen is disabled by default.
        /// </summary>
        /// <param name="game">The game instance.</param>
        public Screen(GameRoot game) : base(game)
        {
            this.GameRoot = game;
            this.Components = new List<GameComponent>();
            this.SetActive(false);
        }

        /// <summary>
        /// Initializes the screen by sending the screen components 
        /// to the games component collection to be automatically handled.
        /// </summary>
        public override void Initialize()
        {
            foreach (var component in Components)
            {
                if (GameRoot.Components.Contains(component))
                    continue;

                GameRoot.Components.Add(component);
            }

            base.Initialize();
        }

        /// <summary>
        /// Forces the screen and it's components to start or 
        /// stop updating/drawing. This depends on the boolean
        /// passed through to the method.
        /// </summary>
        /// <param name="isActive">Should the screen be active or not.</param>
        public void SetActive(bool isActive)
        {
            this.Enabled = this.Visible = isActive;

            foreach (var component in Components)
            {
                component.Enabled = isActive;

                if (component is DrawableGameComponent drawableComponent)
                    drawableComponent.Visible = isActive;
            }
        }
    }
}
