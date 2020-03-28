namespace SbLogger.Format
{
    /// <summary>
    /// A Formatter provides support for formatting LogRecords.
    /// Typically each logging Handler will have a Formatter associated with it. The Formatter takes a LogRecord and converts it to a string.
    /// </summary>
    public abstract class Formatter
    {
        /// <summary>
        /// Construct a new formatter.
        /// </summary>
        protected Formatter() { }

        /// <summary>
        /// Format the given log record and return the formatted string.
        /// </summary>
        /// <param name="record">The log record to be formatted.</param>
        /// <returns>The formatted log record.</returns>
        public abstract string Format(LogRecord record);
    }
}
