using SbLogger.Levels;
using System;

namespace SbLogger
{
    /// <summary>
    /// Message parameters
    /// </summary>
    public struct Param
    {
        public string Name;

        private string valueString;
        public object Value
        {
            get
            {
                return valueString;
            }
            set
            {
                if (value == null)
                {
                    valueString = "null";
                }
                else
                {
                    valueString = value.ToString();
                }
            }
        }
    }

    /// <summary>
    /// LogRecord objects are used to pass logging requests between the logging framework and individual log Handlers.
    /// The LogRecord class is serializable.
    /// </summary>
    [Serializable]
    public class LogRecord
    {
        private string className;

        /// <summary>
        /// The name of the class that issued the logging request.
        /// </summary>
        public string ClassName
        {
            get
            {
                if (className != null)
                {
                    return className;
                }
                return "";
            }
            set
            {
                className = value;
            }
        }

        private string methodName;

        /// <summary>
        /// The name of the method in which the logging request was issued.
        /// </summary>
        public string MethodName
        {
            get
            {
                if (methodName != null)
                {
                    return methodName;
                }
                return "";
            }
            set
            {
                methodName = value;
            }
        }

        private string lineNumer;

        /// <summary>
        /// The line number.
        /// </summary>
        public string LineNumber
        {
            get
            {
                if (lineNumer != null)
                {
                    return lineNumer;
                }
                return "";
            }
            set
            {
                lineNumer = value;
            }
        }

        private string message;

        /// <summary>
        /// The "raw" log message, before localization or formatting.
        /// </summary>
        public string Message
        {
            get
            {
                if (message != null)
                {
                    return message;
                }
                return "";
            }
            set
            {
                message = value;
            }
        }

        private string exceptionMessage;

        /// <summary>
        /// The exception associated with the log record.
        /// </summary>
        public string ExceptionMessage
        {
            get
            {
                if (exceptionMessage != null)
                {
                    return ". Failed with ERROR: " + exceptionMessage;
                }
                return "";
            }
            set
            {
                exceptionMessage = value;
            }
        } 

        private Param[] objs;

        /// <summary>
        /// Array of parameters to the message
        /// </summary>
        public Param[] Objs
        {
            get
            {
                if (objs != null)
                {
                    return objs;
                }
                return null;
            }
            set
            {
                objs = value;
            }
        }

        /// <summary>
        /// The event time.
        /// </summary>
        public DateTime Time { get; set; }

        /// <summary>
        /// The logging message level, for example Level.SEVERE.
        /// </summary>
        public Level Level { get; set; }

        /// <summary>
        /// Default empty constructor
        /// </summary>
        public LogRecord() { }
    }
}
