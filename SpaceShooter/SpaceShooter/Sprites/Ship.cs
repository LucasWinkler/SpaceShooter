using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceShooter.Sprites
{
    public class Ship : Sprite
    {
        /// <summary>The ships active bullets.</summary>
        public List<Bullet> Bullets { get; set; }

        /// <summary>The ships starting position.</summary>
        public Vector2 StartPosition { get; set; }

        /// <summary>The ships direction.</summary>
        public Vector2 Direction { get; set; }

        public float ShootDelay { get; set; } = 0.2222f;
        public float ShootTimer { get; set; }

        /// <summary>
        /// Construct the ship object
        /// </summary>
        /// <param name="game"></param>
        public Ship(GameRoot game) : base(game)
        {
            Bullets = new List<Bullet>();
        }

        /// <summary>
        /// Construct the ship object with a texture
        /// </summary>
        /// <param name="game"></param>
        public Ship(GameRoot game, Texture2D texture) : base(game)
        {
            Bullets = new List<Bullet>();
            this.Texture = texture;
        }

        public override void Destroy()
        {

        }

        public override void Update(GameTime gameTime)
        {
            ShootTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            base.Update(gameTime);
        }
    }
}
