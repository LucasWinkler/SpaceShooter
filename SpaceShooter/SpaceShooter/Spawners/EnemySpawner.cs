﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpaceShooter.Interfaces;
using SpaceShooter.Screens;
using SpaceShooter.Sprites;
using System;
using System.Collections.Generic;

namespace SpaceShooter.Spawners
{
    /// <summary>
    /// Handles the spawning of enemies into the game screen.
    /// </summary>
    public class EnemySpawner : GameComponent, IResetable
    {
        // Instance of the game object
        private readonly GameRoot game;

        // Instance of the game screen
        private readonly GameScreen gameScreen;

        // Random generator for enemy stats
        private readonly Random random;
        // List of textures an enemy can be by string/key
        private readonly List<string> enemyTextureKeys;

        // Enemy spawn rate
        private float spawnRate;
        private float spawnTimer;

        // A growing limit on the amount of enemies that can be on the screen at a time
        private float maxEnemiesOnScreen;

        // Difficulty timer
        private float difficultyTimer;

        // Modifier for the enemies speed
        private float enemySpeedModifier;

        // Min/max enemy speed modifiers
        private const float MIN_ENEMY_SPEED_MOD = 90.0f;
        private const float MAX_ENEMY_SPEED_MOD = 115.0f;

        // The max limit on enemies
        private const int MAX_ENEMIES = 15;

        // The spawn rate modifiers
        private const float MIN_SPAWN_RATE = 0.02f;
        private const float SPAWN_RATE_MOD = 0.08f;

        // The amount of time game time until the difficulty is raised (seconds)
        private const float DIFFICULTY_INCREASE_TIME = 10;

        // The amount of enemies currently on the screen
        public int EnemiesOnScreen { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="game"></param>
        /// <param name="gameScreen"></param>
        public EnemySpawner(GameRoot game, GameScreen gameScreen, List<string> enemyTextureKeys) : base(game)
        {
            this.game = game;
            this.gameScreen = gameScreen;
            this.enemyTextureKeys = enemyTextureKeys;
            this.random = new Random();
        }

        /// <summary>
        /// Resets the enemy spawner to default values
        /// </summary>
        public void Reset()
        {
            spawnRate = 2.25f;
            maxEnemiesOnScreen = 3;
            enemySpeedModifier = 1f;
            spawnTimer = 0.0f;
            EnemiesOnScreen = 0;
            difficultyTimer = 0;
        }

        /// <summary>
        /// Gets a random float between two values since Random
        /// only works with integers and limited doubles.
        /// </summary>
        /// <param name="minimum"></param>
        /// <param name="maximum"></param>
        /// <returns></returns>
        private float GetRandomFloat(float minimum, float maximum)
        {
            return (float)random.NextDouble() * (maximum - minimum) + minimum;
        }

        /// <summary>
        /// Gets a random texture for the spawned enemy.
        /// </summary>
        /// <returns></returns>
        private Texture2D GetRandomTexture()
        {
            return game.ResourceManager.GetTexture(enemyTextureKeys[random.Next(0, enemyTextureKeys.Count)]);
        }

        /// <summary>
        /// Increases the game difficulty over time
        /// </summary>
        /// <param name="delta"></param>
        private void IncreaseDifficulty(float delta)
        {
            difficultyTimer += delta;

            if (difficultyTimer > DIFFICULTY_INCREASE_TIME)
            {
                if (maxEnemiesOnScreen < MAX_ENEMIES)
                {
                    if (spawnRate > MIN_SPAWN_RATE)
                        spawnRate -= SPAWN_RATE_MOD;

                    enemySpeedModifier += 0.007f;
                    maxEnemiesOnScreen += 0.5f;
                    difficultyTimer = 0;
                }
            }
        }

        /// <summary>
        /// Spawns enemies if the criteria is met.
        /// </summary>
        /// <param name="delta"></param>
        private void SpawnEnemy(float delta)
        {
            spawnTimer += delta;

            if (spawnTimer > spawnRate && EnemiesOnScreen < maxEnemiesOnScreen)
            {
                var enemy = new Enemy(game, gameScreen)
                {
                    Texture = GetRandomTexture(),
                    Speed = GetRandomFloat(MIN_ENEMY_SPEED_MOD * enemySpeedModifier, MAX_ENEMY_SPEED_MOD * enemySpeedModifier)
                };
                enemy.StartPosition = new Vector2(random.Next(0, GameSettings.GAME_WIDTH - enemy.Texture.Width), 0 - enemy.Texture.Height);

                gameScreen.Components.Add(enemy);
                EnemiesOnScreen++;
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
