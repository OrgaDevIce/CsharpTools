using System.Runtime.CompilerServices;

namespace CsharpTools.Services.Interfaces
{
    public interface ILogService
    {
        /// <summary>
        /// The folder path where logs are created. By default it's the current directory
        /// </summary>
        string DirectoryPath { get; set; }
        void Info(string message, [CallerMemberName] string caller = "");
        void Error(Exception exception, [CallerMemberName] string caller = "");
    }
}
