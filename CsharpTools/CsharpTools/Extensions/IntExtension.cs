namespace CsharpTools.Extensions
{
    public partial class IntExtension
    {
        private static readonly Random _random = new Random();

        /// <summary>
        /// This method generate a random int value
        /// </summary>
        /// <param name="minValue">Minimum value (included)</param>
        /// <param name="maxValue">Maximum value (included)</param>
        /// <returns>A random int between minValue (included) and maxValue (included)</returns>
        public static int Random(int minValue, int maxValue)
        {
            return _random.Next(minValue, maxValue + 1);
        }
    }
}
