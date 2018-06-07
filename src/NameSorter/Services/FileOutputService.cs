namespace NameSorter.Services
{
    using System.IO; 

    public class FileOutputService : IOutputService
    {
        private readonly string _path;
        public FileOutputService(string path)
        {
            _path = path;
        }
        public void Write(string[] data)
        {
            var fileStream = new FileStream(_path, FileMode.Create);            
            using (var writer = new StreamWriter(fileStream))
            {
                foreach (var line in data)
                {
                    writer.WriteLine(line);
                }
            }
        }
    }
}
