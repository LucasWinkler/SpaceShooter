using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceShooter.Sprites
{
    public class Enemy : Ship
    {
        public Enemy(GameRoot game) : base(game)
        {
            this.Texture = GameRoot.ResourceManager.GetTexture("StandardGreenEnemy");
        }

        public override void Update(GameTime gameTime)
        {

            base.Update(gameTime);
        }
    }
}
