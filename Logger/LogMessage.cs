using System;

namespace Mtszmj.Logger
{
    /// <summary>
    /// Logged message object.
    /// </summary>
    public class LogMessage
    {
        /// <summary>
        /// Level of the message.
        /// </summary>
        public LogLevel Level { get; }
        /// <summary>
        /// Text of the message.
        /// </summary>
        public string Message { get; }
        /// <summary>
        /// Path to file from which the logger was called.
        /// </summary>
        public string CallerFilePath { get; }
        /// <summary>
        /// Name of the member calling the logger.
        /// </summary>
        public string CallerMemberName { get; }
        /// <summary>
        /// Number of the line where the logger was called.
        /// </summary>
        public int CallerLineNumber { get; }
        /// <summary>
        /// Date and time of the logging.
        /// </summary>
        public DateTime Time { get; }

        /// <summary>
        /// Log message.
        /// </summary>
        /// <param name="level"></param>
        /// <param name="message"></param>
        /// <param name="callerFilePath"></param>
        /// <param name="callerMemberName"></param>
        /// <param name="callerLineNumber"></param>
        public LogMessage(LogLevel level,
            string message,
            string callerFilePath = "",
            string callerMemberName = "",
            int callerLineNumber = 0)
        {
            Level = level;
            Message = message;
            CallerFilePath = callerFilePath;
            CallerMemberName = callerMemberName;
            CallerLineNumber = callerLineNumber;
            Time = DateTime.Now;
        }

        /// <summary>
        /// Convert message to string representation.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"[{Time.ToString("yyyy.MM.dd-HH:mm:ss:ffff")}]\t[{Level}]:\t{Message}" +
                   $"\n\t[{CallerFilePath} | {CallerMemberName} | line: {CallerLineNumber}]";
        }
    }
}
