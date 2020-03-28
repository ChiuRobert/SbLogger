using SbLogger.Levels;

namespace SbLogger.Filter
{
    /// <summary>
    /// Concrete filter that writes only the logs that passes a certain level threshold.
    /// </summary>
    public class LevelFilter : IFilter
    {
        /// <summary>
        /// The logging message level, for example Level.SEVERE.
        /// </summary>
        public Level Level { get; set; }

        /// <summary>
        /// Construct a LevelFilter the given level as a threshold
        /// </summary>
        /// <param name="level">The threshold level</param>
        public LevelFilter(Level level)
        {
            Level = level;
        }

        /// <summary>
        /// Empty constructor.
        /// By default the level is Level.ALL
        /// </summary>
        public LevelFilter()
        {
            Level = Level.ALL;
        }

        /// <summary>
        /// Check if the log record should be written.
        /// </summary>
        /// <param name="log">The LogRecord to be filtered</param>
        /// <returns>true if the level will be logged, false otherwise</returns>
        public bool IsLoggable(LogRecord log)
        {
            return Level.Value <= log.Level.Value ? true : false;
        }
    }
}
