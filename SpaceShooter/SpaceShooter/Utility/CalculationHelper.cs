using System;

namespace SpaceShooter.Utility
{
    public static class CalculationHelper
    {
        private static Random random = new Random();

        /// <summary>
        /// Gets a random float between two values since Random
        /// only works with integers and limited doubles.
        /// </summary>
        /// <param name="minimum"></param>
        /// <param name="maximum"></param>
        /// <returns></returns>
        public static float GetRandomFloat(float minimum, float maximum)
        {
            return (float)random.NextDouble() * (maximum - minimum) + minimum;
        }
    }
}
