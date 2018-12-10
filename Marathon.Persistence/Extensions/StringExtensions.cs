namespace Marathon.Persistence.Extensions
{
    /// <summary>
    /// Extension methods for strings
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Trims quotes and white spaces of target string
        /// </summary>
        /// <param name="strWithQuotes">Target string which may contain quotes and white spaces</param>
        /// <returns>String without quotes and white spaces</returns>
        public static string TrimQuotes(this string strWithQuotes)
        {
            return strWithQuotes.Trim('"').Trim();
        }
    }
}
