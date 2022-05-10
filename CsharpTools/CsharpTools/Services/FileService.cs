using CsharpTools.Services.Interfaces;

namespace CsharpTools.Services
{
    public class FileService : IFileService
    {
        public void AppendContent(string path, string content)
        {
            File.AppendAllText(path, content);
        }

        public string CreateFile(string path, string name)
        {
            var stream = File.Create(path + "\\" + name);
            stream.Close();
            return stream.Name;
        }

        public bool PathExist(string path)
        {
            return new DirectoryInfo(path).Exists;
        }

        public IEnumerable<string> ReadFile(string path)
        {
            return File.ReadAllLines(path);
        }

        public bool RemoveFile(string path)
        {
            try
            {
                File.Delete(path);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
