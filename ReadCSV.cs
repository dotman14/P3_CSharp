using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace P3
{
    class ReadCsv
    {
        //Raw election data from online resource.
        private string content;

        //List of election data array.
        private readonly List<string[]> list = new List<string[]>();

        /* Array of indexes corresponding to the specific election data we want to extract from CSV
         * Office -- 0, State -- 1, RaceDate -- 2, Area -- 4, TotalVotes -- 6, RepVotes -- 7
         * RepCandidate -- 8, DemVotes -- 10, DemCandidate -- 11
         */
        private readonly int[] indexWeNeed = { 0, 1, 2, 5, 6, 7, 8, 10, 11 };

        public List<string[]> CsvContent
        {
            get
            {
                using (var url = new WebClient())
                    content = url.DownloadString("https://docs.google.com/spreadsheets/d/1SlWCDS02UWqHRvSUJk3mFgcAStpaXLRBqi2ZIA58TFE/pub?output=csv");
               

                /* The method above works just fine, but in case of network issues, download the CSV file from the above URL.
                 * Uncomment the code below and edit path to csv file in your file system, then comment the block of code above.
                 */

                //_content = System.IO.File.ReadAllText(@"C:\Users\Phase3\Documents\Visual Studio 2015\Projects\P3\presidential2008.csv");

                //Split raw election data into rows
                var electionRow = content?.Split('\n');

                /* Foreach row, split by commas and insert into a separate array.
                 * For this to work as it should, make sure there are no commas within each data cell, except comma separating each data.
                 * Good => President, County, Republican, Votes, Democrat, Vote
                 * Bad  => President, County, Rep,ublican, Votes, Democ,rate, Vote
                 */
                foreach (var i in electionRow)
                {
                    // First we split each row by comma
                    var contentArr = i?.Split(',');
                    if (contentArr == null)
                        throw new ArgumentNullException(nameof(contentArr));

                    /* For each row, we get data for the specific index we want.
                     * Then we Add the string array into a List.
                     */
                    var result = indexWeNeed.Select(j => contentArr[j]).ToArray();
                    list.Add(result);
                }
                return list;
            }
        }
    }
}