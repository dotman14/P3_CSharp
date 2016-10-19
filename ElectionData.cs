namespace P3_oyedotnOyesanmi
{
    class ElectionData
    {
        public override string ToString()
        {
            return $"{Office} {State} {Date} {Area} {Total} {Republican} {RepublicanVote} {Democrat} {DemocratVote} ";
        }

        public ElectionData(
            string office, string state,string date, string county, string total, 
            string rCandidate, string rVote,string dCandidate, string dVote
        )
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
        public string RepublicanVote { get; set; }
        public string Democrat { get; set; }
        public string DemocratVote { get; set; }
        public string Area { get; set; }
        public string State { get; set; }
        public string Office { get; set; }
        public string Total { get; set; }
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