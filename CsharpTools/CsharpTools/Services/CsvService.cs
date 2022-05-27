namespace CsharpTools.Services;

public class CsvService
{
    /// <summary>
    /// This method create a .csv file and write the content
    /// </summary>
    /// <typeparam name="T">The type of the content</typeparam>
    /// <param name="content"></param>
    /// <returns>The path of the created file</returns>
    public string CreateAndWrite<T>(IEnumerable<T> content)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// This method allow to read a .csv file
    /// </summary>
    /// <param name="filePath">The full path of the file</param>
    /// <returns>This method return Each row and each colum ( A list of column values)</returns>
    public IEnumerable<IEnumerable<string>> Read(string filePath)
    {
        throw new NotImplementedException();
    }
}

