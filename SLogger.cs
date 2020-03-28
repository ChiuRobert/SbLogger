using SbLogger.Filter;
using SbLogger.Handlers;
using SbLogger.Levels;
using System;
using System.Diagnostics;

namespace SbLogger
{
    /// <summary>
    /// A Logger object is used to log messages for a specific system or application component. 
    /// Logging messages will be forwarded to registered Handler objects, which can forward the messages to a variety of destinations, including consoles, files, OS logs, etc.
    /// Each Logger has a Level associated with it. This reflects a minimum Level that this logger cares about.
    /// </summary>
    public abstract class SLogger
    {
        /// <summary>
        /// Current name of the logger.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Current Handler associated with this logger.
        /// </summary>
        public Handler Handler { get; set; }

        /// <summary>
        /// Current Filter associated with this logger.
        /// </summary>
        public IFilter Filter
        {
            get
            {
                return Handler.Filter;
            }
            set
            {
                Handler.Filter = value;
            }
        }

        /// <summary>
        /// Create a logger for a named subsystem.
        /// </summary>
        /// <param name="name">Logger name</param>
        /// <returns>SLogger</returns>
        public static SLogger GetLogger(string name)
        {
            return new ConcreteSLogger(name);
        }

        /// <summary>
        /// Create a logger for a named subsystem.
        /// </summary>
        /// <param name="name">Logger name</param>
        /// <param name="path">The path where the log will be created</param>
        /// <returns>SLogger</returns>
        public static SLogger GetLogger(string name, string path)
        {
            return new ConcreteSLogger(name, path);
        }

        /// <summary>
        /// Constructor used by subclasses.
        /// </summary>
        /// <param name="name">Logger name</param>
        protected SLogger(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Get the log Level that has been specified for this Logger.
        /// </summary>
        /// <returns>Level</returns>
        public Level GetLevel()
        {
            LevelFilter levelFilter = Filter as LevelFilter;
            return levelFilter != null ? levelFilter.Level : null;
        }

        /// <summary>
        /// Check if a message of the given level would actually be logged by this logger.
        /// </summary>
        /// <param name="level">The level to test</param>
        /// <returns>true if the level will be logged, false otherwise</returns>
        public bool IsLoggable(Level level)
        {
            LevelFilter levelFilter = Filter as LevelFilter;

            if (levelFilter == null)
            {
                return true;
            }

            return levelFilter.Level.Value <= level.Value ? true : false;
        }

        /// <summary>
        /// Log a LogRecord.
        /// </summary>
        /// <param name="record">The LogRecord to be written</param>
        public void Log(LogRecord record)
        {
            Write(record);
        }

        /// <summary>
        /// Log a message, with no arguments.
        /// </summary>
        /// <param name="level">One of the message level identifiers, e.g., SEVERE</param>
        /// <param name="message">The string message</param>
        public void Log(Level level, string message)
        {
            StackFrame stackFrame = new StackFrame(1, true);
            Write(new LogRecord()
            {
                ClassName = Name,
                MethodName = stackFrame.GetMethod().Name,
                LineNumber = stackFrame.GetFileLineNumber().ToString(),
                Level = level,
                Message = message,
                Time = DateTime.Now
            }
            );
        }

        /// <summary>
        /// Log a message, with an array of object arguments.
        /// </summary>
        /// <param name="level">One of the message level identifiers, e.g., SEVERE</param>
        /// <param name="message">The string message</param>
        /// <param name="objs">Array of parameters to the message</param>
        public void Log(Level level, string message, params Param[] objs)
        {
            StackFrame stackFrame = new StackFrame(1, true);
            Write(new LogRecord()
            {
                ClassName = Name,
                MethodName = stackFrame.GetMethod().Name,
                LineNumber = stackFrame.GetFileLineNumber().ToString(),
                Level = level,
                Message = message,
                Time = DateTime.Now,
                Objs = objs
            }
            );
        }

        /// <summary>
        /// Log a message, with associated Exception information.
        /// </summary>
        /// <param name="level">One of the message level identifiers, e.g., SEVERE</param>
        /// <param name="message">The string message</param>
        /// <param name="e">Exception associated with log message</param>
        public void Log(Level level, string message, Exception e)
        {
            StackFrame stackFrame = new StackFrame(1, true);
            Write(new LogRecord()
            {
                ClassName = Name,
                MethodName = stackFrame.GetMethod().Name,
                LineNumber = stackFrame.GetFileLineNumber().ToString(),
                Level = level,
                Message = message,
                Time = DateTime.Now,
                ExceptionMessage = e.Message + "\n" + e.StackTrace
            }
            );
        }

        /// <summary>
        /// Passes the log to the Handler if it passes the Log Filter
        /// </summary>
        /// <param name="record">The LogRecord to be written</param>
        private void Write(LogRecord record)
        {
            if (Filter.IsLoggable(record))
            {
                Handler.Write(record);
            }
        }
    }
}
