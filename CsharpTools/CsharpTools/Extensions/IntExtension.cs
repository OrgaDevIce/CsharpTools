namespace CsharpTools.Extensions;

public static class IntExtension
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

    /// <summary>
    /// Return true if value is null or equal 0
    /// </summary>
    /// <param name="value"></param>
    /// <returns>True if null or equal 0</returns>
    public static bool IsNullOrZero(this int? value)
    {
        return value == 0 || value == null;
    }
}

