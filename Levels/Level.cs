namespace SbLogger.Levels
{
    /// <summary>
    /// The Level class defines a set of standard logging levels that can be used to control logging output. 
    /// The logging Level objects are ordered and are specified by ordered integers. 
    /// Enabling logging at a given level also enables logging at all higher levels.
    /// The levels in descending order are:
    /// SEVERE (highest value)
    /// WARNING
    /// INFO
    /// CONFIG
    /// FINE (lowest value)
    /// In addition there is a level OFF that can be used to turn off logging, and a level ALL that can be used to enable logging of all messages.
    /// It is possible for third parties to define additional logging levels by subclassing Level.
    /// </summary>
    public class Level
    {
        #region Level types
        /// <summary>
        /// ALL indicates that all messages should be logged.
        /// </summary>
        public static readonly Level ALL = new Level("ALL", int.MinValue);

        /// <summary>
        /// SEVERE is a message level indicating a serious failure.
        /// </summary>
        public static readonly Level SEVERE = new Level("SEVERE", 1000);

        /// <summary>
        /// WARNING is a message level indicating a potential problem.
        /// </summary>
        public static readonly Level WARNING = new Level("WARNING", 900);

        /// <summary>
        /// INFO is a message level for informational messages.
        /// </summary>
        public static readonly Level INFO = new Level("INFO", 800);

        /// <summary>
        /// CONFIG is a message level for static configuration messages.
        /// </summary>
        public static readonly Level CONFIG = new Level("CONFIG", 700);

        /// <summary>
        /// FINE is a message level providing tracing information.
        /// </summary>
        public static readonly Level FINE = new Level("FINE", 500);

        /// <summary>
        /// OFF is a special level that can be used to turn off logging.
        /// </summary>
        public static readonly Level OFF = new Level("OFF", int.MaxValue);
        #endregion

        /// <summary>
        /// The value for the level.
        /// </summary>
        public int Value { get; private set; }

        /// <summary>
        /// The name of the level.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Create a named Level with a given integer value and a given name.
        /// </summary>
        /// <param name="name">The name of the Level, for example "SEVERE".</param>
        /// <param name="value">An integer value for the level.</param>
        protected Level(string name, int value)
        {
            Name = name;
            Value = value;
        }

        /// <summary>
        /// Returns a string representation of this Level.
        /// </summary>
        /// <returns>The non-localized name of the Level, for example "INFO".</returns>
        public override string ToString()
        {
            return Name;
        }
    }
}
