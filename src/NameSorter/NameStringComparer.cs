namespace NameSorter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Compare name by last name, then given name
    /// </summary>
    public class NameStringComparer : IComparer<string>
    {
        private readonly IComparer<string> _baseComparer = StringComparer.InvariantCulture;

        public NameStringComparer() { }

        public NameStringComparer(IComparer<string> baseComparer)
        {
            _baseComparer = baseComparer;
        }
        
        public int Compare(string first, string second)
        {
            // validate arguements
            if (string.IsNullOrWhiteSpace(first)) throw new ArgumentNullException(nameof(first));
            if (string.IsNullOrWhiteSpace(second)) throw new ArgumentNullException(nameof(second));

            var firstSegs = first.Split(' ');
            var secondSegs = second.Split(' ');

            // compare last name
            var lastNameComparison = _baseComparer.Compare(firstSegs.Last(), secondSegs.Last());
            if (lastNameComparison != 0) return lastNameComparison;

            // compare given name
            for (var i = 0; i < firstSegs.Length - 1 && i < secondSegs.Length - 1; i++)
            {
                var giveNameComparison = _baseComparer.Compare(firstSegs[i], secondSegs[i]);
                if (giveNameComparison == 0) continue;
                else return giveNameComparison;
            }

            // same
            return 0;
        }
    }
}
