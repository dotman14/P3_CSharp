using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace P3_oyedotnOyesanmi
{
    class ReadCsv
    {
        //Raw election data from online resource.
        private string _content;

        //List of election data array.
        private readonly List<string[]> _list = new List<string[]>();

        /* Array of indexs corresponding to the specific election data we want to extract from CSV
         * Feel free to add or remove index
         */
        private readonly int[] _indexWeNeed = { 0, 1, 2, 4, 6, 7, 8, 10, 11 };

        public List<string[]> Content
        {
            get
            {
                using (var url = new WebClient())
                {
                    _content =
                        url.DownloadString(
                            "https://docs.google.com/spreadsheets/d/1lxMHXZmDD0HUZ6PWjad9sVSw8d063QaOxaBYqecojG0/pub?output=csv");
                }

                //Split raw election data into rows
                var electionRow = _content?.Split('\n');

                /* Foreach row, split by commas and insert into a separate array.
                 * For this to work as it should, make sure there are no commas within each data cell, except comma separating each data.
                 * Good => President, County, Republican, Votes, Democrat, Vote
                 * Bad  => President, County, Rep,ublican, Votes, Democ,rate, Vote
                 */ 
                foreach (var i in electionRow)
                {
                    // First we split each row by comma
                    var contentArr = i?.Split(','); 

                    /* For each row, we get data for the specific index we want.
                     * Then we Add the string array into a List.
                     */
                    var result = _indexWeNeed.Select(j => contentArr?[j]).ToArray(); 
                    _list.Add(result);
                }
                return _list;
            }
        }
    }
}



