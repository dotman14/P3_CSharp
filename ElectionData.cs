namespace P3_oyedotnOyesanmi
{
    class ElectionData
    {
        public override string ToString()
        {
            return $"{Office}\t{State}\t{Date}\t{Area}\t{Total}\t{Republican}\t{RepublicanVote}\t{Democrat}\t{DemocratVote} ";
        }

        public ElectionData(
            string office, string state,string date, string county, int total, int rVote, string rCandidate, int dVote, string dCandidate)
        {
            Office = office;
            State = state;
            Date = date;
            Area = county;
            Total = total;
            Republican = rCandidate;
            RepublicanVote = rVote;
            Democrat = dCandidate;
            DemocratVote = dVote;
        }

        public string Date { get; set; }
        public string Republican { get; set; }
        public int RepublicanVote { get; set; }
        public string Democrat { get; set; }
        public int DemocratVote { get; set; }
        public string Area { get; set; }
        public string State { get; set; }
        public string Office { get; set; }
        public int Total { get; set; }
    }
}


//Office -- 0
//State -- 1
//RaceDate -- 2
//Area -- 4
//TotalVotes -- 6
//RepVotes -- 7
//RepCandidate -- 8
//DemVotes -- 10
//DemCandidate -- 11