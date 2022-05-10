namespace CsharpTools.Extensions
{
    public static class DateTimeExtension
    {
        /// <summary>
        /// This method allow us to know if one date is include between 2 other date
        /// </summary>
        /// <param name="dateTime">Our current date used to compare</param>
        /// <param name="rangeBeggin"></param>
        /// <param name="rangeEnd"></param>
        /// <returns>True if our date is between rangeBeggin and rangeEnd</returns>
        public static bool IsBetween(this DateTime dateTime, DateTime rangeBeggin, DateTime rangeEnd)
        {
            return dateTime.Ticks >= rangeBeggin.Ticks && dateTime.Ticks <= rangeEnd.Ticks;
        }
    }
}
