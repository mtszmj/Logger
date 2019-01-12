using System;
using System.Runtime.CompilerServices;

namespace Mtszmj.Logger
{
    /// <summary>
    /// Logging interface
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Flag for turning on and off the logger.
        /// </summary>
        bool Enabled { get; set; }

        /// <summary>
        /// LogLevel to decide which messages should be writen and which should be omited. 
        /// For 0 (LogLevel.Trace) Logger writes everything. Check enum: <see cref="LogLevel"/>.
        /// </summary>
        LogLevel Level { get; set; }

        /// <summary>
        /// Event for message logged. Can be used to get Log Message and show it in a View.
        /// </summary>
        event EventHandler<LogMessageEventArgs> OnMessageLogged;

        /// <summary>
        /// Log message with LogLevel as parameter <see cref="LogLevel"/>.
        /// </summary>
        /// <param name="level">Log level.</param>
        /// <param name="message">Message text.</param>
        /// <param name="callerFilePath">Defaults to path of the cs file.</param>
        /// <param name="callerMemberName">Defaults to calling method name.</param>
        /// <param name="callerLineNumber">Defaults to cs file line number.</param>
        void Log(
            LogLevel level, 
            string message, 
            [CallerFilePath] string callerFilePath = "", 
            [CallerMemberName] string callerMemberName = "", 
            [CallerLineNumber] int callerLineNumber = 0);

        /// <summary>
        /// Log with Critical level <see cref="LogLevel"/>.
        /// </summary>
        /// <param name="message">Message text.</param>
        /// <param name="callerFilePath">Defaults to path of the cs file.</param>
        /// <param name="callerMemberName">Defaults to calling method name.</param>
        /// <param name="callerLineNumber">Defaults to cs file line number.</param>
        void LogCritical(string message, 
            [CallerFilePath] string callerFilePath = "", 
            [CallerMemberName] string callerMemberName = "", 
            [CallerLineNumber] int callerLineNumber = 0);

        /// <summary>
        /// Log with Debug level <see cref="LogLevel"/>.
        /// </summary>
        /// <param name="message">Message text.</param>
        /// <param name="callerFilePath">Defaults to path of the cs file.</param>
        /// <param name="callerMemberName">Defaults to calling method name.</param>
        /// <param name="callerLineNumber">Defaults to cs file line number.</param>
        void LogDebug(
            string message, 
            [CallerFilePath] string callerFilePath = "", 
            [CallerMemberName] string callerMemberName = "", 
            [CallerLineNumber] int callerLineNumber = 0);

        /// <summary>
        /// Log with Error level <see cref="LogLevel"/>.
        /// </summary>
        /// <param name="message">Message text.</param>
        /// <param name="callerFilePath">Defaults to path of the cs file.</param>
        /// <param name="callerMemberName">Defaults to calling method name.</param>
        /// <param name="callerLineNumber">Defaults to cs file line number.</param>
        void LogError(
            string message, 
            [CallerFilePath] string callerFilePath = "", 
            [CallerMemberName] string callerMemberName = "", 
            [CallerLineNumber] int callerLineNumber = 0);

        /// <summary>
        /// Log with LogInfo level <see cref="LogLevel"/>.
        /// </summary>
        /// <param name="message">Message text.</param>
        /// <param name="callerFilePath">Defaults to path of the cs file.</param>
        /// <param name="callerMemberName">Defaults to calling method name.</param>
        /// <param name="callerLineNumber">Defaults to cs file line number.</param>
        void LogInfo(
            string message, 
            [CallerFilePath] string callerFilePath = "", 
            [CallerMemberName] string callerMemberName = "", 
            [CallerLineNumber] int callerLineNumber = 0);

        /// <summary>
        /// Log with Trace level <see cref="LogLevel"/>.
        /// </summary>
        /// <param name="message">Message text.</param>
        /// <param name="callerFilePath">Defaults to path of the cs file.</param>
        /// <param name="callerMemberName">Defaults to calling method name.</param>
        /// <param name="callerLineNumber">Defaults to cs file line number.</param>
        void LogTrace(
            string message, 
            [CallerFilePath] string callerFilePath = "", 
            [CallerMemberName] string callerMemberName = "", 
            [CallerLineNumber] int callerLineNumber = 0);

        /// <summary>
        /// Log with Warning level <see cref="LogLevel"/>.
        /// </summary>
        /// <param name="message">Message text.</param>
        /// <param name="callerFilePath">Defaults to path of the cs file.</param>
        /// <param name="callerMemberName">Defaults to calling method name.</param>
        /// <param name="callerLineNumber">Defaults to cs file line number.</param>
        void LogWarning(
            string message, 
            [CallerFilePath] string callerFilePath = "", 
            [CallerMemberName] string callerMemberName = "", 
            [CallerLineNumber] int callerLineNumber = 0);
    }
}