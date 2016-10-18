using System.Collections.Generic;

namespace P3_oyedotnOyesanmi
{
    class ElectionDataSet
    {
        private List<ElectionInfo> _election = new List<ElectionInfo>();
        private List<string> rawElection = new List<string>();

        //public ElectionDataSet()
        //{
        //    rawElection = 
        //}

        public void Insert(ElectionInfo electionInfoObj)
        {
            _election.Add(electionInfoObj);
        }

        public int GetSize
        {
            get { return _election.Count; }
        }

        private void ClearCollection()
        {
            _election.Clear();
        }


    }
}
