using System;
using System.Collections.Generic;
using System.Net;

namespace P3_oyedotnOyesanmi
{
    internal class CsvFileReader
    {
        private string _content;
        public readonly List<string[]> List = new List<string[]>();

        public List<string[]> GetContent()
        {
            using (var url = new WebClient())
            {
                _content = url.DownloadString("https://docs.google.com/spreadsheets/d/1DDhAd98p5RwXqvV53P2YvaujIQEg28HjeXasrCge9Qo/pub?output=csv");             
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
