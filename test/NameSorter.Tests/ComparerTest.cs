namespace NameSorter.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using NameSorter;

    [TestClass]
    public class ComparerTest
    {
        [TestMethod]
        public void TestCompare()
        {
            var expected = new[] {
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

            var unsorted = new[] {
                "Janet Parsons",
                "Vaughn Lewis",
                "Adonis Julius Archer",
                "Shelby Nathan Yoder",
                "Marin Alvarez",
                "London Lindsey",
                "Beau Tristan Bentley",
                "Leo Gardner",
                "Hunter Uriah Mathew Clarke",
                "Mikayla Lopez",
                "Frankie Conner Ritter"
            };

            var comparer = new NameStringComparer();
            Array.Sort(unsorted, comparer);
            var sorted = unsorted;

            for (var i = sorted.Length - 1; i >= 0; i--)
            {
                Assert.AreEqual(expected[i], sorted[i]);
            }

        }
    }
}
