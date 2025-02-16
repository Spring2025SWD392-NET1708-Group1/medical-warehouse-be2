namespace Common.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Capitalizes the first letter of a string.
        /// </summary>
        public static string CapitalizeFirstLetter(this string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return str;

            return char.ToUpper(str[0]) + str.Substring(1);
        }
    }
}
