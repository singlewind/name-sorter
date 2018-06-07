namespace NameSorter.Services
{
    using System.Collections.Generic;
    using System.IO;

    /// <summary>
    /// Read data from file system
    /// </summary>
    public class FileInputService : IInputService
    {
        private readonly string _path;

        public FileInputService(string path)
        {
            _path = path;
        }


        /// <summary>
        /// Read names from a text file
        /// </summary>
        /// <returns>name array</returns>
        public string[] Read()
        {            
            var fileStream = new FileStream(_path, FileMode.Open);
            var names = new List<string>();            
            using (var reader = new StreamReader(fileStream))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (!string.IsNullOrWhiteSpace(line)) names.Add(line.Trim());
                }                
            }
            return names.ToArray();
        }
    }
}
