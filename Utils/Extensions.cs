namespace SbLogger.Utils
{
    /// <summary>
    /// Extension class
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Custom formatting for Param array
        /// </summary>
        /// <param name="array">Array of logging objects</param>
        /// <returns>Formatted string</returns>
        public static string ToStringLog(this Param[] array)
        {
            string retVal = string.Empty;
            if (array != null)
            {
                foreach (var item in array)
                {
                    retVal += string.Format("{0}{1} = {2}", string.IsNullOrEmpty(retVal) ? "" : ", ", item.Name, item.Value);
                }
            }
            return string.IsNullOrEmpty(retVal) ? "" : ". Parameters: { " + retVal + " }";
        }
    }
}
