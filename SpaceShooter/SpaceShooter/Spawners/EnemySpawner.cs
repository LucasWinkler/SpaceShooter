using Microsoft.Xna.Framework;
using SpaceShooter.Screens;
using SpaceShooter.Sprites;
using System;

namespace SpaceShooter.Spawners
{
    /// <summary>
    /// Handles the spawning of enemies into the game screen.
    /// </summary>
    public class EnemySpawner : GameComponent
    {
        // Instance of the game object
        private readonly GameRoot game;

        // Instance of the game screen
        private readonly GameScreen gameScreen;

        private readonly Random random = new Random();

        // Enemy spawn rate (seconds) and timer
        private float spawnRate = 1.0f;
        private float spawnTimer = 0.0f;

        // The limit on enemies
        private const int MAX_ENEMIES = 15;

        // A growing limit on the amount of enemies that can be on the screen at a time
        private int maxEnemiesOnScreen = 5;

        // The amount of enemies currently on the screen
        private int enemiesOnScreen = 0;

        // Difficulty timer
        private float difficultyTimer = 0;

        // The amount of time game time until the difficulty is raised (seconds)
        private const float DIFFICULTY_INCREASE_TIME = 20;

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="game"></param>
        /// <param name="gameScreen"></param>
        public EnemySpawner(GameRoot game, GameScreen gameScreen) : base(game)
        {
            this.game = game;
            this.gameScreen = gameScreen;
        }

        private void IncreaseDifficulty(float delta)
        {
            difficultyTimer += delta;

            if (difficultyTimer > DIFFICULTY_INCREASE_TIME)
            {
                if (maxEnemiesOnScreen < MAX_ENEMIES)
                {
                    spawnRate += 0.2f;
                    maxEnemiesOnScreen++;
                }

                difficultyTimer = 0;
            }
        }

        private void SpawnEnemy(float delta)
        {
            spawnTimer += delta;

            if (spawnTimer > spawnRate)
            {
                var enemy = new Enemy(game, gameScreen);

                enemy.StartPosition = new Vector2(random.Next(0, GameSettings.GAME_WIDTH - enemy.Texture.Width), 0 - enemy.Texture.Height);

                gameScreen.Components.Add(enemy);
                spawnTimer = 0;
            }
        }

        /// <summary>
        /// Update the enemy spawner.
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            float delta = (float)gameTime.ElapsedGameTime.TotalSeconds;

            SpawnEnemy(delta);
            IncreaseDifficulty(delta);

            base.Update(gameTime);
        }
    }
}
