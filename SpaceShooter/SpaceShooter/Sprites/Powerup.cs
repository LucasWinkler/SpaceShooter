using SpaceShooter.Screens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceShooter.Sprites
{
    public class Powerup : Sprite
    {
        private readonly GameScreen gameScreen;

        /// <summary>
        /// Powerup constructor.
        /// </summary>
        /// <param name="game"></param>
        public Powerup(GameRoot game, GameScreen gameScreen) : base(game)
        {
            this.gameScreen = gameScreen;
        }

        /// <summary>
        /// Removes the item from the game.
        /// </summary>
        public override void Destroy()
        {
            
        }
    }
}
