using System.Collections.Generic;
using System.Linq;
using static System.Console;

namespace P3_oyedotnOyesanmi
{
    class ElectionDataSet
    {
        public ElectionDataSet()
        {
            if (Data != null)
                Clear();
            /* This constructor uses chaining.
             * Same could be achieved by:
             * 1. Creating a local ReadCsv object
             * 2. Call Content Property on the object...That returns a list of string arrays 
             * 3. Use LINQ to convert List<string[]> into List<ElectionData>
             */
            Data = new ReadCsv().Content.Select(x => new ElectionData(x[0], x[1], x[2], x[3], x[4], x[5], x[6], x[7], x[8])).ToList();
        }

        public List<ElectionData> Data { get; }

        public int Count => Data.Count;

        public void Clear() => Data.Clear();      

        public void Add(ElectionData election) => Data.Add(election);

        public void ShowData()
        {
            foreach (var i in Data)
            {
                WriteLine(i);
            }
        }

    }
}
