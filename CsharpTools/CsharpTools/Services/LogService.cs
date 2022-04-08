using CsharpTools.Services.Interfaces;
using System.Runtime.CompilerServices;

namespace CsharpTools.Services
{
    public class LogService : ILogService
    {
        private readonly string _directoryPath;
        private string _formattedDate => DateTime.Now.ToString("HH:mm:ss");
        private string _currentLogFileName => $"Logs_{DateTime.Now.ToString("dd-MM")}.log";

        public LogService(string directoryPath)
        {
            _directoryPath = directoryPath;
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
                var logFileFullPath = CheckFile();

                var formattedLog = $"{_formattedDate} | {logType} | {caller} | {log} \n";


                switch (logType)
                {
                    case LogType.Error:
                        Console.ForegroundColor = ConsoleColor.Red;
                        break;
                    case LogType.Info:
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        break;
                    default:
                        break;
                }
                Console.WriteLine(formattedLog);
                Console.ForegroundColor = ConsoleColor.White;
                File.AppendAllText(logFileFullPath, formattedLog);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        /// <summary>
        /// Check if directory and log file exist, else create it
        /// </summary>
        /// <returns></returns>
        private string CheckFile()
        {
            var directory = new DirectoryInfo(_directoryPath);

            // If the directory does not exist we create one 
            if (!directory.Exists)
            {
                Directory.CreateDirectory(_directoryPath);
            }

            // Check if one file already exist

            // Else create one 

            // Return full path of this file

            return $"{_directoryPath}\\{_currentLogFileName}";
        }

        enum LogType
        {
            Error,
            Info
        }
    }
}
