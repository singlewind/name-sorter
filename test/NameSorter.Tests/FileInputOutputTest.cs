namespace NameSorter.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using NameSorter.Services;

    [TestClass]
    public class FileInputOutputTest
    {
        private readonly string[] _expected = new[] {
                "Marin Alvarez",
                "Adonis Julius Archer",
                "Beau Tristan Bentley",
                "Hunter Uriah Mathew Clarke","" +
                "Leo Gardner",
                "Vaughn Lewis",
                "London Lindsey",
                "Mikayla Lopez",
                "Janet Parsons",
                "Frankie Conner Ritter",
                "Shelby Nathan Yoder"
            };

        [TestMethod]
        public void ReadWriteTest()
        {
            const string path = "unsorted-names-list.txt";

            // write data to file
            var outputService = new FileOutputService(path);
            outputService.Write(_expected);

            // read data from file
            var inputService = new FileInputService(path);
            var data = inputService.Read();

            for (var i = data.Length - 1; i >= 0; i--)
            {
                Assert.AreEqual(_expected[i], data[i]);
            }

        }
    }
}
