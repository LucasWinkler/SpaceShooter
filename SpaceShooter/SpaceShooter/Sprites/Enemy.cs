using Microsoft.Xna.Framework;
using SpaceShooter.Screens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceShooter.Sprites
{
    public class Enemy : Ship
    {
        public float Speed { get; set; }

        public Enemy(GameRoot game, GameScreen gameScreen) : base(game, gameScreen)
        {
            this.Texture = GameRoot.ResourceManager.GetTexture("StandardGreenEnemy");
            this.Speed = 90.0f;
        }

        public override void Initialize()
        {
            Velocity = new Vector2(0, Speed);
            Position = StartPosition;

            base.Initialize();
        }

        public override void Reset()
        {
            GameScreen.ComponentsToRemove.Add(this);

            base.Reset();
        }

        public override void Destroy()
        {
            GameScreen.ComponentsToRemove.Add(this);
            GameScreen.EnemySpawner.EnemiesOnScreen--;

            base.Destroy();
        }

        public override void Update(GameTime gameTime)
        {
            this.Position += Velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;

            base.Update(gameTime);
        }
    }
}
