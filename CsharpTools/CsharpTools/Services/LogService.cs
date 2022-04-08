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

        public void Error(Exception exception, [CallerFilePath] string file = "", [CallerMemberName] string method = "", [CallerLineNumber] int line = 0)
        {
            Write(exception.Message, LogType.Error, file, method, line);
        }

        public void Info(string message, [CallerFilePath] string file = "", [CallerMemberName] string method = "", [CallerLineNumber] int line = 0)
        {
            Write(message, LogType.Info, file, method, line);
        }

        private void Write(string log, LogType logType, string file, string method, int line)
        {
            try
            {
                var formattedLog = $"{_formattedDate} | {logType} | {file}/{method} ({line}) | {log} \n";

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
