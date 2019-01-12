namespace Mtszmj.Logger
{

    /// <summary>
    /// Level for Logger. According to Level set, the message is either logged or not. 
    /// Levels go as follows: Trace &lt; Debug &lt; Info &lt; Warning &lt; Error &lt; Critical. 
    /// If level is set to Trace, all messages are logged. If level is set to Critical, 
    /// only Critical messages are set.
    /// </summary>
    public enum LogLevel
    {
        /// <summary>
        /// Trace &lt; Debug &lt; Info &lt; Warning &lt; Error &lt; Critical
        /// </summary>
        Trace = 0,
        /// <summary>
        /// Trace &lt; Debug &lt; Info &lt; Warning &lt; Error &lt; Critical
        /// </summary>
        Debug,
        /// <summary>
        /// Trace &lt; Debug &lt; Info &lt; Warning &lt; Error &lt; Critical
        /// </summary>
        Info,
        /// <summary>
        /// Trace &lt; Debug &lt; Info &lt; Warning &lt; Error &lt; Critical
        /// </summary>
        Warning,
        /// <summary>
        /// Trace &lt; Debug &lt; Info &lt; Warning &lt; Error &lt; Critical
        /// </summary>
        Error,
        /// <summary>
        /// Trace &lt; Debug &lt; Info &lt; Warning &lt; Error &lt; Critical
        /// </summary>
        Critical
    }

    /// <summary>
    /// Logger writer type - for choosing where messages are written.
    /// </summary>
    public enum LoggerWriterType
    {
        /// <summary>
        /// Write to text file.
        /// </summary>
        TextFile,
        /// <summary>
        /// Write to console.
        /// </summary>
        Console,
        /// <summary>
        /// Do not write messages anywhere.
        /// </summary>
        Null,
    }
}
