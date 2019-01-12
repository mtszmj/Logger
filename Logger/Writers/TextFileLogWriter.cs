using System;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Mtszmj.Logger
{
    /// <summary>
    /// Text file writer.
    /// </summary>
    internal class TextFileLogWriter : ILogWriter
    {
        private string Name;
        
        internal TextFileLogWriter(string name = "logfile.log")
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        /// <summary>
        /// Logger info.
        /// </summary>
        string ILogWriter.Info => $"LogWriter of type: {nameof(TextFileLogWriter)} with path: {Name}.";

        /// <summary>
        /// Write log text.
        /// </summary>
        /// <param name="log"></param>
        void ILogWriter.Write(LogMessage log)
        {
            File.AppendAllText(AppDomain.CurrentDomain.BaseDirectory + Name, log + Environment.NewLine);
        }
    }
}
