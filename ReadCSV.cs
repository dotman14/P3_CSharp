using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace P3_oyedotnOyesanmi
{
    class ReadCsv
    {
        //Raw election data from online resource.
        private string _content;

        //List of 
        private readonly List<string[]> _list = new List<string[]>();

        //Array of indexs corresponding to the specific election data we want to extract
        private readonly int[] _indexWeNeed = { 0, 1, 2, 4, 6, 7, 8, 10, 11 };

        public List<string[]> Content
        {
            get
            {
                using (var url = new WebClient())
                {
                    _content =
                        url.DownloadString(
                            "https://docs.google.com/spreadsheets/d/1DDhAd98p5RwXqvV53P2YvaujIQEg28HjeXasrCge9Qo/pub?output=csv");
                }

                //Split raw election data into rows
                var electionRow = _content?.Split('\n');

                /* Foreach row, split by commas and insert into a separate array.
                 * For this to work as it should, make sure there are no commas within each data, except comma separating each data.
                 * Good => President, County, Republican, Votes, Democrat, Vote
                 * Bad  => President, County, Rep,ublican, Votes, Democ,rate, Vote
                 */ 
                foreach (var i in electionRow)
                {
                    var contentArr = i?.Split(',');
                    var result = _indexWeNeed.Select(index => contentArr?[index]).ToArray();
                    _list.Add(result);
                }
                return _list;
            }
        }
    }
}