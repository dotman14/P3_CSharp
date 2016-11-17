/****************************** File Header ******************************\
Module Name:  Display.cs
Project:      US Election Data by County

This is a static class used across the project to 
display well formatted headers and menu options.

\***************************************************************************/

using System;
using System.Globalization;
namespace P3
{
    class ElectionData
    {
        /*Tostring method
         * override the ToString method to allow ElectionData object to display  there result
         */
        public override string ToString() => $"{Office,1}{State,23}{Date.Year,8}{Area,22}{Total,10}{RepublicanVote,11}{Republican,23}{DemocratVote,11}{Democrat,20} ";

        /*ElectionData constructor
         * Class constructor that initialize the attribute of the object
         */
        public ElectionData(
            string office, string state, DateTime date, string county, int total, int rVote, string rCandidate, int dVote, string dCandidate)
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
        public DateTime Date { get; }
        public string Republican { get; }
        public int RepublicanVote { get; }
        public string Democrat { get; }
        public int DemocratVote { get; }
        public string Area { get; }
        public string State { get; }
        public string Office { get; }
        public int Total { get; }
        public static string TitleCase(string str)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(str);
        }
    }
}