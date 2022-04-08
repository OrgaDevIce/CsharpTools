using CsharpTools.Services.Interfaces;

namespace CsharpTools.Services
{
    public class CsvService : ICsvService
    {
        public string CreateAndWrite<T>(IEnumerable<T> content)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IEnumerable<string>> Read(string filePath)
        {
            throw new NotImplementedException();
        }
    }
}
