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

        /// <summary>
        /// Get the first day of the week of datetime (first day of the week => Monday)
        /// </summary>
        /// <param name="dateTime">The current datetime which would the first day of the week</param>
        /// <returns>The first day of the week</returns>
        public static DateTime GetFirstDayOfWeek(this DateTime dateTime)
        {
            var dayNumber = (int)dateTime.DayOfWeek;
            dayNumber = dayNumber == 0 ? 7 : dayNumber;

            var firstDayOfWeek = dateTime.AddDays(-1 * (dayNumber - 1));

            return firstDayOfWeek;
        }

        /// <summary>
        /// Get the last day of the week of datetime (last day of the week => Sunday)
        /// </summary>
        /// <param name="dateTime">The current datetime which would the last day of the week</param>
        /// <returns>The last day of the week</returns>
        public static DateTime GetLastDayOfWeek(this DateTime dateTime)
        {
            return dateTime.GetFirstDayOfWeek().AddDays(6);
        }
    }
}
