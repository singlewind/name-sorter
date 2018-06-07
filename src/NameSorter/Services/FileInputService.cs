namespace NameSorter.Services
{
    using System.Collections.Generic;
    using System.IO;

    public class FileInputService : IInputService
    {
        private readonly string _path;
        public FileInputService(string path)
        {
            _path = path;
        }
        public string[] Read()
        {            
            var fileStream = new FileStream(_path, FileMode.Open);
            var names = new List<string>();
            using (var reader = new StreamReader(fileStream))
            {
                string line = reader.ReadLine();
                if (!string.IsNullOrWhiteSpace(line)) names.Add(line.Trim());
            }
            return names.ToArray();
        }
    }
}
