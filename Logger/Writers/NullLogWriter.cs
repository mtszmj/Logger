using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mtszmj.Logger
{
    /// <summary>
    /// Null object log writer
    /// </summary>
    internal class NullLogWriter : ILogWriter
    {
        /// <summary>
        /// Logger info.
        /// </summary>
        string ILogWriter.Info => $"LogWriter of type: {nameof(NullLogWriter)}.";

        /// <summary>
        /// Do nothing.
        /// </summary>
        /// <param name="log"></param>
        void ILogWriter.Write(LogMessage log) { }
    }
}
