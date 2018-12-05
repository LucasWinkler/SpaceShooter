using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;

namespace SpaceShooter.Resources
{
    /// <summary>
    /// Loads all the content/resources in the game and allows them to be accessed via a dictionary.
    /// </summary>
    public class ResourceManager
    {
        // New content manager using the game services
        private ContentManager contentManager;

        // List to store all of the resources/content
        private readonly List<Resource> resources;

        // Dictionaries to store all textures, fonts, sound effects and music
        private readonly Dictionary<string, Texture2D> textures = new Dictionary<string, Texture2D>();
        private readonly Dictionary<string, SpriteFont> fonts = new Dictionary<string, SpriteFont>();
        private readonly Dictionary<string, SoundEffect> sounds = new Dictionary<string, SoundEffect>();
        private readonly Dictionary<string, Song> music = new Dictionary<string, Song>();

        /// <summary>
        /// Constructs the resource manager object with a new 
        /// content manager and a list of resources to be loaded. 
        /// </summary>
        /// <param name="gameResources"></param>
        public ResourceManager(GameRoot game, List<Resource> resources)
        {
            this.contentManager = new ContentManager(game.Services, "Content");
            this.resources = resources;
        }

        /// <summary>
        /// Loads all game content.
        /// </summary>
        public void LoadContent()
        {
            if (resources == null) return;

            // Lopps through each resource in the list
            foreach (Resource resource in resources)
            {
                // Makes sure each dictionary does not already have the content before loading
                if (textures.ContainsKey(resource.Name)) continue;
                if (sounds.ContainsKey(resource.Name)) continue;
                if (music.ContainsKey(resource.Name)) continue;
                if (fonts.ContainsKey(resource.Name)) continue;

                // Adds a resource to the dictionary by key and stores the loaded content
                try
                {
                    switch (resource.Type)
                    {
                        case ResourceType.Texture:
                            textures.Add(resource.Name, contentManager.Load<Texture2D>(resource.Path));
                            break;
                        case ResourceType.Font:
                            fonts.Add(resource.Name, contentManager.Load<SpriteFont>(resource.Path));
                            break;
                        case ResourceType.Sound:
                            sounds.Add(resource.Name, contentManager.Load<SoundEffect>(resource.Path));
                            break;
                        case ResourceType.Music:
                            music.Add(resource.Name, contentManager.Load<Song>(resource.Path));
                            break;
                    }
                    Console.WriteLine($"Added {resource.Type}: \"{resource.Name}\"{Environment.NewLine}\t\t Path: \"{resource.Path}\"");
                }
                catch (Exception e)
                {
                    Console.WriteLine($"----------------------{Environment.NewLine}Error: Resource unable to load. Type: '{resource.Type}' Name: '{resource.Name}' Path: '{resource.Path}'{Environment.NewLine}Exception: {e}{Environment.NewLine}----------------------");
                }
            }
        }

        /// <summary>
        /// Unloads all game content by disposing all dictionary values
        /// </summary>
        public void UnloadContent()
        {
            foreach (var value in textures.Values) { value.Dispose(); }
            textures.Clear();

            foreach (var value in fonts.Values) { value.Texture.Dispose(); }
            fonts.Clear();

            foreach (var value in sounds.Values) { value.Dispose(); }
            sounds.Clear();

            foreach (var value in music.Values) { value.Dispose(); }
            music.Clear();
        }

        /// <summary>
        /// Gets a texture from the dictionary.
        /// </summary>
        /// <param name="key">Used to get the value from the dictionary.</param>
        /// <returns>Returns a texture 2d.</returns>
        public Texture2D GetTexture(string key) => textures[key];

        /// <summary>
        /// Gets a font from the dictionary.
        /// </summary>
        /// <param name="key">Used to get the value from the dictionary.</param>
        /// <returns>Returns sprite font.</returns>
        public SpriteFont GetFont(string key) => fonts[key];

        /// <summary>
        /// Gets a sound effect from the dictionary.
        /// </summary>
        /// <param name="key">Used to get the value from the dictionary.</param>
        /// <returns>Returns a sound effect instance.</returns>
        public SoundEffect GetSound(string key) => sounds[key];

        /// <summary>
        /// Gets a song from the dictionary.
        /// </summary>
        /// <param name="key">Used to get the value from the dictionary.</param>
        /// <returns>Returns a song.</returns>
        public Song GetMusic(string key) => music[key];
    }
}
