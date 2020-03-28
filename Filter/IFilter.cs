namespace SbLogger.Filter
{
    /// <summary>
    /// A Filter can be used to provide fine grain control over what is logged, beyond the control provided by log levels.
    /// Each Logger and each Handler can have a filter associated with it. The Logger or Handler will call the IsLoggable method to check if a given LogRecord should be written.
    /// </summary>
    public interface IFilter
    {
        /// <summary>
        /// Check if the log record should be written.
        /// </summary>
        /// <param name="log">The LogRecord to be filtered</param>
        /// <returns>true if the level will be logged, false otherwise</returns>
        bool IsLoggable(LogRecord log);
    }
}
