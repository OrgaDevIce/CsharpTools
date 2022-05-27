namespace CsharpTools.Extensions;

public static class StringExtension
{
    /// <summary>
    /// Check if string is null or content just one space
    /// </summary>
    /// <param name="value">Current string</param>
    /// <returns>True if is null or white space</returns>
    public static bool IsNullOrWhiteSpace(this string value)
    {
        return string.IsNullOrWhiteSpace(value);
    }

    /// <summary>
    /// Convert value to Int32
    /// </summary>
    /// <param name="value">String value</param>
    /// <returns>The content of value in Int32</returns>
    public static int ToInt(this string value)
    {
        int.TryParse(value, out var result);

        return result;
    }
}
