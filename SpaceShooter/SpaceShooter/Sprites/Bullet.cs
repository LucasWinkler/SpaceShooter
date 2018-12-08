using Microsoft.Xna.Framework;
using SpaceShooter.Interfaces;
using SpaceShooter.Screens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceShooter.Sprites
{
    public class Bullet : Sprite
    {
        private GameScreen gameScreen;

        /// <summary>Bullets parent (sprite that shot the bullet).</summary>
        public Sprite Parent { get; }

        /// <summary>Bullets speed.</summary>
        public float Speed { get; } = 675.0f;

        /// <summary>Bullets damage.</summary>
        public int Damage { get; } = 50;

        /// <summary>
        /// Construct a bullet with a parent.
        /// </summary>
        /// <param name="GameRoot"></param>
        /// <param name="parent"></param>
        public Bullet(GameRoot GameRoot, GameScreen gameScreen, Sprite parent) : base(GameRoot)
        {
            this.gameScreen = gameScreen;
            this.Parent = parent;
            this.Texture = GameRoot.ResourceManager.GetTexture("SmallPlasmaBullet");
            this.Velocity = new Vector2(0, -Speed);
        }
        public override void Reset()
        {
            gameScreen.ComponentsToRemove.Add(this);

            base.Reset();
        }
        /// <summary>
        /// Destroys/removes the bullet.
        /// </summary>
        public override void Destroy()
        {
            // Add to the ComponentsToRemove list to remove at the end of the iteration
            gameScreen.ComponentsToRemove.Add(this);

            // TODO: Animation? sound effect?
        }

        /// <summary>
        /// Update the bullets location.
        /// </summary>
        /// <param name="GameRootTime"></param>
        public override void Update(GameTime GameRootTime)
        {
            Position += Velocity * (float)GameRootTime.ElapsedGameTime.TotalSeconds;

            base.Update(GameRootTime);
        }
    }
}
