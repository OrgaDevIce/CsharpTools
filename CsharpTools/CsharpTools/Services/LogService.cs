using CsharpTools.Services.Interfaces;
using System.Runtime.CompilerServices;

namespace CsharpTools.Services
{
    public class LogService : ILogService
    {
        private string _currentLogFileName => $"Logs_{DateTime.Now.ToString("dd-MM")}.log";
        private string _currentLogFileFullPath => $"{DirectoryPath}\\{_currentLogFileName}";
        private string _formattedDate => DateTime.Now.ToString("HH:mm:ss");


        public string DirectoryPath { get; set; }

        public LogService()
        {
            DirectoryPath = Directory.GetCurrentDirectory();

            var directory = new DirectoryInfo(DirectoryPath);

            if (!directory.Exists)
            {
                Directory.CreateDirectory(DirectoryPath);
            }
        }

        public void Error(Exception exception, [CallerMemberName] string caller = "")
        {
            Write(exception.Message, LogType.Error, caller);
        }

        public void Info(string message, [CallerMemberName] string caller = "")
        {
            Write(message, LogType.Info, caller);
        }

        private void Write(string log, LogType logType, string caller)
        {
            try
            {
                var formattedLog = $"{_formattedDate} | {logType} | {caller} | {log} \n";

                Console.ForegroundColor = ConsoleColor.White;
                File.AppendAllText(_currentLogFileFullPath, formattedLog);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        enum LogType
        {
            Error,
            Info
        }
    }
}
