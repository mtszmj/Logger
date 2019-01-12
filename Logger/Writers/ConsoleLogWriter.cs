using System;

namespace Mtszmj.Logger
{
    /// <summary>
    /// Console writer.
    /// </summary>
    internal class ConsoleLogWriter : ILogWriter
    {
        /// <summary>
        /// Logger info.
        /// </summary>
        string ILogWriter.Info => $"LogWriter of type: {nameof(ConsoleLogWriter)}.";

        /// <summary>
        /// Write log text.
        /// </summary>
        /// <param name="log"></param>
        void ILogWriter.Write(LogMessage log)
        {
            Console.WriteLine(log);
        }
    }
}
