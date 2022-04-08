using System.Runtime.CompilerServices;

namespace CsharpTools.Services.Interfaces
{
    public interface ILogService
    {
        void Info(string message, [CallerMemberName] string caller = "");
        void Error(Exception exception, [CallerMemberName] string caller = "");
    }
}
