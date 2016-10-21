using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using static System.Console;

namespace P3_oyedotnOyesanmi
{
    class ElectionDataSet
    {
        protected List<ElectionData> Data { get; }

        public ElectionDataSet()
        {
            if (Data != null)
                Data.Clear();
            /* This constructor uses chaining.
             * Same could be achieved by:
             * 1. Creating a local ReadCsv object
             * 2. Call Content Property on the object...That returns a list of string arrays 
             * 3. Use LINQ to convert List<string[]> into List<ElectionData>
             */
            Data = new ReadCsv().Content.Select(x => new ElectionData(x[0], x[1], x[2], x[3], Convert.ToInt32(x[4]), Convert.ToInt32(x[5]), x[6], Convert.ToInt32(x[7]), x[8])).ToList();
        }

        protected internal int Count => Data.Count;

        private void Clear() => Data.Clear();

        protected void Add(ElectionData election) => Data.Add(election);

        protected internal void ShowData()
        {
            int count = 0;
            WriteLine("{0,4}{1,11}{2,20}{3,10}{4,15}{5,8}{6,8}{7,16}{8,8}{9,16}", "N-", "Office", "State", "Date", "Area", "Total", "Rep-Vot", "Rep-Candidate", "Dem-Vot", "Dem-Candidate");
            foreach (var i in Data)
            {
                WriteLine("{0,4}{1}", count, i);
                count++;

            }
        }

        public bool CheckUniqueData(string state, string county, string office)
        {
            var result =
                Data.Where(results => results.State == CultureInfo.CurrentCulture.TextInfo.ToTitleCase(state) &&
                                      results.Area == CultureInfo.CurrentCulture.TextInfo.ToTitleCase(county) &&
                                      results.Office == CultureInfo.CurrentCulture.TextInfo.ToTitleCase(office));
            return result.Any();
        }

        public ElectionData GetSingleRow(string state, string county, string office)
        {
            var result =
                Data.First(results => results.State == CultureInfo.CurrentCulture.TextInfo.ToTitleCase(state) &&
                                       results.Area == CultureInfo.CurrentCulture.TextInfo.ToTitleCase(county) &&
                                       results.Office == CultureInfo.CurrentCulture.TextInfo.ToTitleCase(office));
            return result;
        }

        public int GetIndex(string state, string county, string office)
        {
            var index = Data.FindIndex(results => results.State == CultureInfo.CurrentCulture.TextInfo.ToTitleCase(state) &&
                                                  results.Area == CultureInfo.CurrentCulture.TextInfo.ToTitleCase(county) &&
                                                  results.Office == CultureInfo.CurrentCulture.TextInfo.ToTitleCase(office));
            return index;
        }

        public void EditSingleElection(int rVotes, int dVotes, string state, string county, string office)
        {
            var index = GetIndex(state, county, office);
            var beforeUpdate = GetSingleRow(state, county, office);
            var afterUpdate = new ElectionData(
                                                        beforeUpdate.Office,
                                                        beforeUpdate.State,
                                                        beforeUpdate.Date,
                                                        beforeUpdate.Area,
                                                        rVotes + dVotes,
                                                        beforeUpdate.RepublicanVote,
                                                        beforeUpdate.Republican,
                                                        beforeUpdate.DemocratVote,
                                                        beforeUpdate.Democrat);
            Data[index] = afterUpdate;
        }
    }
}
