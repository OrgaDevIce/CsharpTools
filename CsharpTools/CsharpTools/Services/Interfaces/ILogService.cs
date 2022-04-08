using System.Runtime.CompilerServices;

namespace CsharpTools.Services.Interfaces
{
    public interface ILogService
    {
        /// <summary>
        /// The folder path where logs are created. By default it's the current directory
        /// </summary>
        string DirectoryPath { get; set; }
        void Info(string message, [CallerFilePath] string file = "", [CallerMemberName] string method = "", [CallerLineNumber] int line = 0);
        void Error(Exception exception, [CallerFilePath] string file = "", [CallerMemberName] string method = "", [CallerLineNumber] int line = 0);
    }
}
