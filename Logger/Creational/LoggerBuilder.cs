using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mtszmj.Logger
{
    /// <summary>
    /// Logger Builder for creating loggers.
    /// </summary>
    public class LoggerBuilder
    {
        private LoggerWriterType _Type = LoggerWriterType.Console;
        private ILogWriter _Writer;
        private LogLevel _Level = LogLevel.Trace;
        private bool _Enabled = true;
        private string _Path = null;
        private bool _WithStorage = false;

        /// <summary>
        /// Set Log Writer type <see cref="LoggerWriterType"/>
        /// </summary>
        /// <param name="type">Logger write type</param>
        /// <returns></returns>
        public LoggerBuilder OfType(LoggerWriterType type)
        {
            _Type = type;
            return this;
        }

        /// <summary>
        /// Set Log Writer Path if needed.
        /// </summary>
        /// <param name="path">Path, defaults to 'logfile.log'.</param>
        /// <returns></returns>
        public LoggerBuilder WithPath(string path = "logfile.log")
        {
            if (path == null) throw new ArgumentNullException(nameof(path));
            _Path = path;
            return this;
        }

        /// <summary>
        /// Set starting Log Level (<see cref="LogLevel"/>).
        /// </summary>
        /// <param name="level">Log level.</param>
        /// <returns></returns>
        public LoggerBuilder WithLevel(LogLevel level)
        {
            _Level = level;
            return this;
        }

        /// <summary>
        /// Set if Logger is enabled at the initilization.
        /// </summary>
        /// <returns></returns>
        public LoggerBuilder Enabled()
        {
            _Enabled = true;
            return this;
        }

        /// <summary>
        /// Set if Logger is disabled at the initialization.
        /// </summary>
        /// <returns></returns>
        public LoggerBuilder Disabled()
        {
            _Enabled = false;
            return this;
        }

        /// <summary>
        /// Choose if the logger do not need to store messages logged.
        /// </summary>
        /// <returns></returns>
        public LoggerBuilder WithoutStorage()
        {
            _WithStorage = false;
            return this;
        }

        /// <summary>
        /// Choose if the logger should store internally messages logged.
        /// </summary>
        /// <returns></returns>
        public LoggerBuilder WithStorage()
        {
            _WithStorage = true;
            return this;
        }

        /// <summary>
        /// Create instance of logger with parameters set earlier or defaults.
        /// Defaults:
        /// Logger Writer Type - Console
        /// Logger Level - Trace (everything visible)
        /// Logger enabled
        /// </summary>
        /// <returns></returns>
        public ILogger Build()
        {
            switch (_Type)
            {
                case LoggerWriterType.TextFile:
                    if (_Path != null)
                        _Writer = new TextFileLogWriter(_Path);
                    else
                        _Writer = new TextFileLogWriter();
                    break;
                case LoggerWriterType.Console:
                    _Writer = new ConsoleLogWriter();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(_Type), $"Value: {(int)_Type}.");
            }

            if (_WithStorage)
                return new LoggerWithStorage(_Writer, _Level, _Enabled);
            else
                return new Logger(_Writer, _Level, _Enabled);
        }
    }
}
