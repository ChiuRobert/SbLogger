using SbLogger.Utils;

namespace SbLogger.Format
{
    /// <summary>
    /// Default formatter
    /// Format: [dd-MM-yyyy HH:mm:ss] Level - ClassName(LineNumber):MethodName - Message
    /// </summary>
    public class DefaultFormatter : Formatter
    {
        /// <summary>
        /// Format the given log record and return the formatted string.
        /// </summary>
        /// <param name="record">The log record to be formatted.</param>
        /// <returns>The formatted log record.</returns>
        public override string Format(LogRecord record)
        {
            return "[" + record.Time.ToString("dd-MM-yyyy HH:mm:ss") + "] " + record.Level
                + " - " + record.ClassName + "(" + record.LineNumber + "):" + record.MethodName + " - "
                + record.Message + record.Objs.ToStringLog()
                + record.ExceptionMessage + "\n";
        }
    }
}
