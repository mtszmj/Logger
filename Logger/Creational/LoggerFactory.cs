using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mtszmj.Logger
{
    /// <summary>
    /// Logger Factory for creating basic loggers.
    /// </summary>
    public static class LoggerFactory
    {
        /// <summary>
        /// Create logger with default configuration of given LoggerType.
        /// </summary>
        /// <param name="type">Logger write type.</param>
        /// <returns></returns>
        public static ILogger CreateDefaultLogger(LoggerWriterType type)
        {
            ILogWriter writer;
            switch (type)
            {
                case LoggerWriterType.TextFile:
                    writer = new TextFileLogWriter();
                    break;
                case LoggerWriterType.Console:
                    writer = new ConsoleLogWriter();
                    break;
                case LoggerWriterType.Null:
                    writer = new NullLogWriter();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), $"Value: {(int)type}.");
            }

            return new Logger(writer);
        }

        /// <summary>
        /// Create Logger writing to file.
        /// </summary>
        /// <param name="path">File path. If not specified, it is 'logfile.log'.</param>
        /// <returns></returns>
        public static ILogger CreateTextFileLogger(string path = "logfile.log")
        {
            if(path == null) throw new ArgumentNullException(nameof(path));
            var writer = new TextFileLogWriter(path);
            return new Logger(writer);
        }

        /// <summary>
        /// Create Logger writing to console.
        /// </summary>
        /// <returns></returns>
        public static ILogger CreateConsoleLogger()
        {
            var writer = new ConsoleLogWriter();
            return new Logger(writer);
        }

        /// <summary>
        /// Create Logger without write to any output.
        /// </summary>
        /// <returns></returns>
        public static ILogger CreateLoggerWithoutOutput()
        {
            var writer = new NullLogWriter();
            return new Logger(writer);
        }

        /// <summary>
        /// Create logger with default configuration of given LoggerType.
        /// </summary>
        /// <param name="type">Logger write type.</param>
        /// <returns></returns>
        public static ILogger CreateDefaultLoggerWithStorage(LoggerWriterType type)
        {
            ILogWriter writer;
            switch (type)
            {
                case LoggerWriterType.TextFile:
                    writer = new TextFileLogWriter();
                    break;
                case LoggerWriterType.Console:
                    writer = new ConsoleLogWriter();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), $"Value: {(int)type}.");
            }

            return new LoggerWithStorage(writer);
        }

        /// <summary>
        /// Create Logger writing to file, with internal storage.
        /// </summary>
        /// <param name="path">File path. If not specified, it is 'logfile.log'.</param>
        /// <returns></returns>
        public static ILogger CreateTextFileLoggerWithStorage(string path = "logfile.log")
        {
            if (path == null) throw new ArgumentNullException(nameof(path));
            var writer = new TextFileLogWriter(path);
            return new LoggerWithStorage(writer);
        }

        /// <summary>
        /// Create Logger writing to console with internal storage.
        /// </summary>
        /// <returns></returns>
        public static ILogger CreateConsoleLoggerWithStorage()
        {
            var writer = new ConsoleLogWriter();
            return new LoggerWithStorage(writer);
        }

        /// <summary>
        /// Create Logger without write to any output, with internal storage.
        /// </summary>
        /// <returns></returns>
        public static ILogger CreateLoggerWithoutOutputWithStorage()
        {
            var writer = new NullLogWriter();
            return new Logger(writer);
        }
    }
}
