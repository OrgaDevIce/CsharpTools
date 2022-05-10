namespace CsharpTools.Extensions
{
    public partial class IntExtension
    {
        private static readonly Random _random = new Random();

        public static int Random(int minValue, int maxValue)
        {
            return _random.Next(minValue, maxValue);
        }
    }
}
