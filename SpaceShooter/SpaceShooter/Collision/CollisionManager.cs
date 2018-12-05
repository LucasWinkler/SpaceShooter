using Microsoft.Xna.Framework;
using SpaceShooter.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceShooter.Collision
{
    public class CollisionManager : GameComponent
    {
        private GameRoot game;
        private Player player;

        public CollisionManager(GameRoot game, Player player) : base(game)
        {
            this.game = game;
            this.player = player;
        }

        public override void Update(GameTime gameTime)
        {


            base.Update(gameTime);
        }
    }
}
