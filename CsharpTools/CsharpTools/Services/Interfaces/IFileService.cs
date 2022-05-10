namespace CsharpTools.Services.Interfaces
{
    public interface IFileService
    {
        /// <summary>
        /// Create a file
        /// </summary>
        /// <param name="path">The full path of the folder that will contain the file (ex: C:\test)</param>
        /// <param name="name">The name of the file (with extention) (ex: test.json)</param>
        /// <returns></returns>
        string CreateFile(string path, string name);

        /// <summary>
        /// Check if one path exit
        /// </summary>
        /// <param name="path">The path of the file that will be checked</param>
        /// <returns>True if path exist else false</returns>
        bool PathExist(string path);

        /// <summary>
        /// Read all content of one file
        /// </summary>
        /// <param name="path">The full path of the file</param>
        /// <returns>The content of each line the file</returns>
        IEnumerable<string> ReadFile(string path);

        /// <summary>
        /// Delete a file
        /// </summary>
        /// <param name="path">The path of the file</param>
        /// <returns>True if success else false</returns>
        bool RemoveFile(string path);

        void AppendContent(string path, string content);
    }
}
