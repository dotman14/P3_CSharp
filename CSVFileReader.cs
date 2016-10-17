using System.Collections.Generic;
using System.Diagnostics;
using System.Net;

namespace P3_oyedotnOyesanmi
{
    class CsvFileReader
    {
        private string _content;
        public readonly List<string[]> List = new List<string[]>();

        public List<string[]> Content
        {
            get
            {
                using (var url = new WebClient())
                {
                    _content = url.DownloadString("https://docs.google.com/spreadsheets/d/1z9OuJhYPDTsLCVeNzt069ChITXlgKdNwf7Wma7qhfxY/pub?output=csv");
                }

                var urlArr = _content.Split('\n');

                foreach (var i in urlArr)
                {
                    var contentArr = i.Split(',');
                    List.Add(contentArr);
                }

                return List;
            }
        }
    }
}
