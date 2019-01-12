using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mtszmj.Logger
{
    /// <summary>
    /// Extension of base Logger. LoggerWithStorage keeps all logged messages 
    /// in a list (if enabled and with correct level).
    /// </summary>
    internal class LoggerWithStorage : Logger, IStorage
    {
        /// <summary>
        /// Initialize logger with ILogWriter.
        /// </summary>
        /// <param name="writer">Writer for outputing data. Cannot be null.</param>
        internal LoggerWithStorage(ILogWriter writer) 
            : base(writer) { }

        /// <summary>
        /// Initialize logger with ILogWriter, LogLevel and decide if it is turned on.
        /// </summary>
        /// <param name="writer">Writer for outputing data. Cannot be null.</param>
        /// <param name="level">Log level to filter unimportant messages.</param>
        /// <param name="enabled">Flag to decide if Logger should be turned on.</param>
        internal LoggerWithStorage(ILogWriter writer, LogLevel level, bool enabled)
            : base(writer, level, enabled) { }

        protected List<LogMessage> _Messages = new List<LogMessage>();
        /// <summary>
        /// Storage for logged messages.
        /// </summary>
        public IEnumerable<LogMessage> Messages => _Messages;

        protected override void WriteMessage(LogMessage logMsg)
        {
            _Messages.Add(logMsg);
            base.WriteMessage(logMsg);
        }
    }
}
