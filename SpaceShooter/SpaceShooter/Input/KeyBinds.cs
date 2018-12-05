using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceShooter.Input
{
    /// <summary>
    /// Contains keybinds for the players movement
    /// </summary>
    public class KeyBinds
    {
        /// <summary>Forward key</summary>
        public Keys Forwards { get; set; }

        /// <summary>Left key</summary>
        public Keys Left { get; set; }

        /// <summary>Backwards key</summary>
        public Keys Backwards { get; set; }

        /// <summary>Right key</summary>
        public Keys Right { get; set; }

        /// <summary>Shoot key</summary>
        public Keys Shoot { get; set; }
    }
}
