using System.Collections.Generic;

namespace Mtszmj.Logger
{
    /// <summary>
    /// Interface to access stored messages.
    /// </summary>
    public interface IStorage
    {
        /// <summary>
        /// Logged messages.
        /// </summary>
        IEnumerable<LogMessage> Messages { get; }
    }
}
