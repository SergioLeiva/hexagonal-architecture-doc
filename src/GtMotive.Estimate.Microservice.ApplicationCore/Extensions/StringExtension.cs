namespace GtMotive.Estimate.Microservice.ApplicationCore.Extensions
{
    /// <summary>
    /// Extensions to string type.
    /// </summary>
    public static class StringExtension
    {
        /// <summary>
        /// Clean a string and return it in uppercase.
        /// </summary>
        /// <param name="value">Value to clean.</param>
        /// <returns>Clean value.</returns>
        public static string UpperClean(this string value)
        {
            return string.IsNullOrWhiteSpace(value) ? string.Empty : value.ToUpperInvariant().Trim();
        }
    }
}
