using System;

namespace Mtszmj.Logger
{
    /// <summary>
    /// Arguments sent from ILogger on OnMessageLogged event. <see cref="ILogger.OnMessageLogged"/>
    /// </summary>
    public class LogMessageEventArgs : EventArgs
    {
        /// <summary>
        /// Logged message.
        /// </summary>
        public LogMessage Message { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="LogMessageEventArgs"/>
        /// </summary>
        /// <param name="message"></param>
        public LogMessageEventArgs(LogMessage message)
        {
            Message = message;
        }
    }
}
