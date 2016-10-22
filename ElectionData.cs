﻿namespace P3
{
    class ElectionData
    {
        /*Tostring method
         * override the ToString method to allow ElectionData object to display  there result
         */
        public override string ToString()
        {
            return $"{Office,1}{State,23}{Date,10}{Area,23}{Total,8}{RepublicanVote,9}{Republican,23}{DemocratVote,9}{Democrat,20} ";
        }

        /*ElectionData constructor
         * Class constructor that initialize the attribute of the object
         */
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

        /*Public properties
         */
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