namespace Mtszmj.Logger
{
    /// <summary>
    /// Log writer interface .
    /// </summary>
    internal interface ILogWriter
    {
        /// <summary>
        /// Write log text.
        /// </summary>
        /// <param name="log"></param>
        void Write(LogMessage log);

        /// <summary>
        /// Logger info.
        /// </summary>
        string Info { get; }
    }
}
