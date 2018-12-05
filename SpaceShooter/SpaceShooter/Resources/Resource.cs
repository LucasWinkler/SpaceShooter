using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceShooter.Resources
{
    /// <summary>
    /// The resources type (texture, music, etc...)
    /// </summary>
    public enum ResourceType
    {
        /// <summary>A texture2d in the game</summary>
        Texture,
        /// <summary>A font in the game</summary>
        Font,
        /// <summary>A sound in the game</summary>
        Sound,
        /// <summary>Music in the game</summary>
        Music,
    }

    /// <summary>
    /// A resource/loadable content that is used by the ResourceManager
    /// </summary>
    public struct Resource
    {
        /// <summary>Tthe resources type.</summary>
        public ResourceType Type { get; }

        /// <summary>The resources name/key.</summary>
        public string Name { get; }

        /// <summary>The resources path.</summary>
        public string Path { get; }

        /// <summary>
        /// Creates a new resource with a name and path
        /// </summary>
        /// <param name="type">The type</param>
        /// <param name="name">The name/key</param>
        /// <param name="path">The path</param>
        public Resource(ResourceType type, string name, string path)
        {
            this.Type = type;
            this.Name = name;
            this.Path = path;
        }
    }
}
