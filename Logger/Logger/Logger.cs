using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Mtszmj.Logger
{
    /// <summary>
    /// Class for logging purpose. It holds log data in a list and outputs it through ILogWriter interface.
    /// </summary>
    internal class Logger : ILogger
    {
        /// <summary>
        /// Initialize logger with ILogWriter.
        /// </summary>
        /// <param name="writer">Writer for outputing data. Cannot be null.</param>
        internal Logger(ILogWriter writer) : this(writer, LogLevel.Trace, true) { }

        /// <summary>
        /// Initialize logger with ILogWriter, LogLevel and decide if it is turned on.
        /// </summary>
        /// <param name="writer">Writer for outputing data. Cannot be null.</param>
        /// <param name="level">Log level to filter unimportant messages.</param>
        /// <param name="enabled">Flag to decide if Logger should be turned on.</param>
        internal Logger(ILogWriter writer, LogLevel level, bool enabled)
        {
            _Writer = writer ?? throw new ArgumentNullException(nameof(writer));
            _Level = level;
            _Enabled = enabled;
            LogInfo($"{nameof(Logger)} initialized. {writer.Info}");
        }

        /// <summary>
        /// Event for message logged. Can be used to get Log Message and show it in a View.
        /// </summary>
        public event EventHandler<LogMessageEventArgs> OnMessageLogged;

        protected bool _Enabled;
        /// <summary>
        /// Flag for turning on and off the logger.
        /// </summary>
        public virtual bool Enabled
        {
            get => _Enabled;
            set
            {
                if (value)
                {
                    _Enabled = value;
                    LogInfo($"{nameof(Logger)} changing '{nameof(Enabled)}' to {value}");
                }
                else
                {
                    LogInfo($"{nameof(Logger)} changing '{nameof(Enabled)}' to {value}");
                    _Enabled = value;
                }
            }
        }

        protected LogLevel _Level;
        /// <summary>
        /// LogLevel to decide which messages should be writen and which should be omited. 
        /// For 0 (LogLevel.Trace) Logger writes everything. Check enum: <see cref="LogLevel"/>.
        /// </summary>
        public virtual LogLevel Level
        {
            get => _Level;
            set
            {
                _Level = value;
                LogInfo($"{nameof(Logger)} changing '{nameof(LogLevel)}' to {_Level.ToString()}");
            }
        }

        /// <summary>
        /// Logger interface to write logs to.
        /// </summary>
        protected ILogWriter _Writer;

        /// <summary>
        /// Log message with LogLevel as parameter <see cref="LogLevel"/>.
        /// </summary>
        /// <param name="level">Log level.</param>
        /// <param name="message">Message text.</param>
        /// <param name="callerFilePath">Defaults to path of the cs file.</param>
        /// <param name="callerMemberName">Defaults to calling method name.</param>
        /// <param name="callerLineNumber">Defaults to cs file line number.</param>
        public virtual void Log(
            LogLevel level,
            string message,
            [CallerFilePath] string callerFilePath = "",
            [CallerMemberName] string callerMemberName = "",
            [CallerLineNumber] int callerLineNumber = 0
            )
        {
            switch (level)
            {
                case LogLevel.Trace:
                    LogTrace(message, callerFilePath, callerMemberName, callerLineNumber);
                    break;
                case LogLevel.Debug:
                    LogDebug(message, callerFilePath, callerMemberName, callerLineNumber);
                    break;
                case LogLevel.Info:
                    LogInfo(message, callerFilePath, callerMemberName, callerLineNumber);
                    break;
                case LogLevel.Warning:
                    LogWarning(message, callerFilePath, callerMemberName, callerLineNumber);
                    break;
                case LogLevel.Error:
                    LogError(message, callerFilePath, callerMemberName, callerLineNumber);
                    break;
                case LogLevel.Critical:
                    LogCritical(message, callerFilePath, callerMemberName, callerLineNumber);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(level), $"Value: {(int)level}.");
            }
        }

        /// <summary>
        /// Log with Trace level <see cref="LogLevel"/>.
        /// </summary>
        /// <param name="message">Message text.</param>
        /// <param name="callerFilePath">Defaults to path of the cs file.</param>
        /// <param name="callerMemberName">Defaults to calling method name.</param>
        /// <param name="callerLineNumber">Defaults to cs file line number.</param>
        public virtual void LogTrace(
            string message,
            [CallerFilePath] string callerFilePath = "",
            [CallerMemberName] string callerMemberName = "",
            [CallerLineNumber] int callerLineNumber = 0
            )
        {
            if (IsTraceEnabled())
            {
                var logMsg = ConvertToLogMessage(LogLevel.Trace, message, callerFilePath, callerMemberName, callerLineNumber);
                WriteMessage(logMsg);
            }
        }

        /// <summary>
        /// Log with Debug level <see cref="LogLevel"/>.
        /// </summary>
        /// <param name="message">Message text.</param>
        /// <param name="callerFilePath">Defaults to path of the cs file.</param>
        /// <param name="callerMemberName">Defaults to calling method name.</param>
        /// <param name="callerLineNumber">Defaults to cs file line number.</param>
        public virtual void LogDebug(
            string message,
            [CallerFilePath] string callerFilePath = "",
            [CallerMemberName] string callerMemberName = "",
            [CallerLineNumber] int callerLineNumber = 0
            )
        {
            if (IsDebugEnabled())
            {
                var logMsg = ConvertToLogMessage(LogLevel.Debug, message, callerFilePath, callerMemberName, callerLineNumber);
                WriteMessage(logMsg);
            }
        }

        /// <summary>
        /// Log with LogInfo level <see cref="LogLevel"/>.
        /// </summary>
        /// <param name="message">Message text.</param>
        /// <param name="callerFilePath">Defaults to path of the cs file.</param>
        /// <param name="callerMemberName">Defaults to calling method name.</param>
        /// <param name="callerLineNumber">Defaults to cs file line number.</param>
        public virtual void LogInfo(
            string message,
            [CallerFilePath] string callerFilePath = "",
            [CallerMemberName] string callerMemberName = "",
            [CallerLineNumber] int callerLineNumber = 0
            )
        {
            if (IsInfoEnabled())
            {
                var logMsg = ConvertToLogMessage(LogLevel.Info, message, callerFilePath, callerMemberName, callerLineNumber);
                WriteMessage(logMsg);
            }
        }

        /// <summary>
        /// Log with Warning level <see cref="LogLevel"/>.
        /// </summary>
        /// <param name="message">Message text.</param>
        /// <param name="callerFilePath">Defaults to path of the cs file.</param>
        /// <param name="callerMemberName">Defaults to calling method name.</param>
        /// <param name="callerLineNumber">Defaults to cs file line number.</param>
        public virtual void LogWarning(
            string message,
            [CallerFilePath] string callerFilePath = "",
            [CallerMemberName] string callerMemberName = "",
            [CallerLineNumber] int callerLineNumber = 0
            )
        {
            if (IsWarningEnabled())
            {
                var logMsg = ConvertToLogMessage(LogLevel.Warning, message, callerFilePath, callerMemberName, callerLineNumber);
                WriteMessage(logMsg);
            }
        }

        /// <summary>
        /// Log with Error level <see cref="LogLevel"/>.
        /// </summary>
        /// <param name="message">Message text.</param>
        /// <param name="callerFilePath">Defaults to path of the cs file.</param>
        /// <param name="callerMemberName">Defaults to calling method name.</param>
        /// <param name="callerLineNumber">Defaults to cs file line number.</param>
        public void LogError(
            string message,
            [CallerFilePath] string callerFilePath = "",
            [CallerMemberName] string callerMemberName = "",
            [CallerLineNumber] int callerLineNumber = 0
            )
        {
            if (IsErrorEnabled())
            {
                var logMsg = ConvertToLogMessage(LogLevel.Error, message, callerFilePath, callerMemberName, callerLineNumber);
                WriteMessage(logMsg);
            }
        }


        /// <summary>
        /// Log with Critical level <see cref="LogLevel"/>.
        /// </summary>
        /// <param name="message">Message text.</param>
        /// <param name="callerFilePath">Defaults to path of the cs file.</param>
        /// <param name="callerMemberName">Defaults to calling method name.</param>
        /// <param name="callerLineNumber">Defaults to cs file line number.</param>
        public virtual void LogCritical(
            string message,
            [CallerFilePath] string callerFilePath = "",
            [CallerMemberName] string callerMemberName = "",
            [CallerLineNumber] int callerLineNumber = 0
            )
        {
            if (IsCriticalEnabled())
            {
                var logMsg = ConvertToLogMessage(LogLevel.Critical, message, callerFilePath, callerMemberName, callerLineNumber);
                WriteMessage(logMsg);
            }
        }

        protected virtual void WriteMessage(LogMessage logMsg)
        {
            _Writer?.Write(logMsg);
            OnMessageLogged?.Invoke(this, new LogMessageEventArgs(logMsg));
        }

        protected virtual bool IsTraceEnabled() => (Enabled && Level <= LogLevel.Trace);
        protected virtual bool IsDebugEnabled() => (Enabled && Level <= LogLevel.Debug);
        protected virtual bool IsInfoEnabled() => (Enabled && Level <= LogLevel.Info);
        protected virtual bool IsWarningEnabled() => (Enabled && Level <= LogLevel.Warning);
        protected virtual bool IsErrorEnabled() => (Enabled && Level <= LogLevel.Error);
        protected virtual bool IsCriticalEnabled() => (Enabled && Level <= LogLevel.Critical);

        /// <summary>
        /// Merge given parameters into one Log string.
        /// </summary>
        /// <param name="level">Log level</param>
        /// <param name="message">Message text.</param>
        /// <param name="callerFilePath">Path of the cs file.</param>
        /// <param name="callerMemberName">Calling method name.</param>
        /// <param name="callerLineNumber">Cs file line number.</param>
        /// <returns></returns>
        protected virtual LogMessage ConvertToLogMessage(
            LogLevel level,
            string message,
            string callerFilePath = "",
            string callerMemberName = "",
            int callerLineNumber = 0)
        {
            return new LogMessage(level, message, callerFilePath, callerMemberName, callerLineNumber);
        }
    }
}
