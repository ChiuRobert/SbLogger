using SbLogger.Filter;
using SbLogger.Handlers;

namespace SbLogger
{
    /// <summary>
    /// Concrete implementation of a SLogger
    /// By default it will implement a FileHandler and a LevelFilter
    /// </summary>
    internal class ConcreteSLogger : SLogger
    {
        /// <summary>
        /// Construct a concrete logger with the given name.
        /// Initialize a FileHandler and a LevelFilter
        /// </summary>
        /// <param name="name">Logger name</param>
        /// <param name="path">The path where the log will be created</param>
        internal ConcreteSLogger(string name, string path = "") : base(name)
        {
            if (Handler == null)
            {
                Handler = new FileHandler(path);
                Filter = new LevelFilter();
            }
        }
    }
}
