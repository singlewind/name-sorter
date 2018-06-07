namespace NameSorter.Services
{
    using System.IO;

    /// <summary>
    /// Write data to file system
    /// </summary>
    public class FileOutputService : IOutputService
    {
        private readonly string _path;

        public FileOutputService(string path)
        {
            _path = path;
        }

        /// <summary>
        /// Write names to a text file
        /// </summary>
        /// <param name="data">name array</param>
        public void Write(string[] data)
        {
            var fileStream = new FileStream(_path, FileMode.Create);            
            using (var writer = new StreamWriter(fileStream))
            {
                // put carriage return after new line just to unify experience for windows users.
                writer.NewLine = "\r\n";

                foreach (var line in data)
                {
                    writer.WriteLine(line);
                }
            }
        }
    }
}
