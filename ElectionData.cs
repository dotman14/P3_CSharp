namespace P3_oyedotnOyesanmi
{
    class ElectionData
    {
        public override string ToString()
        {
            return $"{Office,8}{State,20}{Date,10}{Area,15}{Total,8}{Republican,8}{RepublicanVote,16}{Democrat,8}{DemocratVote,16} ";
        }

        public ElectionData(
            string office, string state, string date, string county, int total, int rVote, string rCandidate, int dVote, string dCandidate)
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