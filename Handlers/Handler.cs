using SbLogger.Filter;
using SbLogger.Format;

namespace SbLogger.Handlers
{
    /// <summary>
    /// A Handler object takes log messages from a Logger and exports them.
    /// It might for example, write them to a console or write them to a file.
    /// A Handler can be disabled by doing a setLevel(Level.OFF) and can be re-enabled by doing a setLevel with an appropriate level.
    /// </summary>
    public abstract class Handler
    {
        /// <summary>
        /// The current Filter for this Handler.
        /// </summary>
        public IFilter Filter { get; set; }

        /// <summary>
        /// The current Formatter for this Handler.
        /// </summary>
        public Formatter Formatter { get; set; }

        /// <summary>
        /// Writes a LogRecord.
        /// The logging request was made initially to a Logger object, which initialized the LogRecord and forwarded it here.
        /// The Handler is responsible for formatting the message, when and if necessary.
        /// </summary>
        /// <param name="record">Description of the log event</param>
        public abstract void Write(LogRecord record);
    }
}
