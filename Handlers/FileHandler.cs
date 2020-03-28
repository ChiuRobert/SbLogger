using SbLogger.Filter;
using SbLogger.Format;
using SbLogger.Utils;
using System.IO;

namespace SbLogger.Handlers
{
    /// <summary>
    /// A Handler subclass.
    /// Writes the log to a file.
    /// </summary>
    internal class FileHandler : Handler
    {
        /// <summary>
        /// Path to save the log.
        /// </summary>
        public string FilePath { get; set; }

        /// <summary>
        /// Default constructor.
        /// It initializes a LevelFilter and a DefaultFormatter
        /// </summary>
        public FileHandler() : this(new LevelFilter(), new DefaultFormatter())
        {
            DefaultPath();
        }

        /// <summary>
        /// Construct a FileHandler with a custom path
        /// </summary>
        /// <param name="path">The path where the log will be created</param>
        public FileHandler(string path) : this(new LevelFilter(), new DefaultFormatter())
        {
            DefaultPath(path);
        }

        /// <summary>
        /// Construct a FileHandler given the specific Filter and the Formatter
        /// </summary>
        /// <param name="filter">Log filter</param>
        /// <param name="formatter">Log formatter</param>
        public FileHandler(IFilter filter, Formatter formatter)
        {
            DefaultPath();
            Filter = filter;
            Formatter = formatter;
        }

        /// <summary>
        /// Writes a LogRecord to the file.
        /// </summary>
        /// <param name="record">Description of the log event</param>
        public override void Write(LogRecord record)
        {
            var directory = Directory.CreateDirectory(Path.GetDirectoryName(FilePath));

            if (File.Exists(FilePath))
            {
                File.OpenText(FilePath).Dispose();
            }
            else
            {
                File.CreateText(FilePath).Dispose();
            }

            using (TextWriter writer = new StreamWriter(FilePath, true))
            {
                if (Filter.IsLoggable(record))
                {
                    writer.Write(Formatter.Format(record));
                }
            }
        }

        /// <summary>
        /// Sets the default path
        /// </summary>
        private void DefaultPath(string path = "")
        {
            if (path.Equals(""))
            {
                FilePath = Consts.FILE_PATH;
            }
            else
            {
                FilePath = path;
            }
        }
    }
}
