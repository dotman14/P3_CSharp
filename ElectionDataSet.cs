using System.Collections.Generic;
using System.Linq;

namespace P3_oyedotnOyesanmi
{
    class ElectionDataSet
    {
        public ElectionDataSet()
        {
            Data = new ReadCsv().Content.Select(x => new ElectionData(x[0], x[1], x[2], x[3], x[4], x[5], x[6], x[7], x[8])).ToList();
        }

        public List<ElectionData> Data { get; }

        public int Count => Data.Count;

        public void Clear()
        {
            Data.Clear();
        }

        public void Add(ElectionData election)
        {
            Data.Add(election);
        }
    }
}
