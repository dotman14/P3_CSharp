﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace P3_oyedotnOyesanmi
{
    class ElectionDataSet
    {
        protected List<ElectionData> Data { get; }

        public ElectionDataSet()
        {
            if (Data != null)
                Clear();
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
            //int count = 0;
            Display.GetMainHeader();
            foreach (var i in Data)
            {
                Console.WriteLine("{0}", i);
                //count++;

            }
        }

        protected bool CheckUniqueData(string state, string county, string office)
        {
            var result =
                Data.Where(results => results.State == CultureInfo.CurrentCulture.TextInfo.ToTitleCase(state) &&
                                      results.Area == CultureInfo.CurrentCulture.TextInfo.ToTitleCase(county) &&
                                      results.Office == CultureInfo.CurrentCulture.TextInfo.ToTitleCase(office));
            return result.Any();
        }

        protected ElectionData GetSingleRow(string state, string county, string office)
        {
            var result =
                Data.First(results => results.State == CultureInfo.CurrentCulture.TextInfo.ToTitleCase(state) &&
                                       results.Area == CultureInfo.CurrentCulture.TextInfo.ToTitleCase(county) &&
                                       results.Office == CultureInfo.CurrentCulture.TextInfo.ToTitleCase(office));
            return result;
        }

        protected int GetIndex(string state, string county, string office)
        {
            var index = Data.FindIndex(results => results.State == CultureInfo.CurrentCulture.TextInfo.ToTitleCase(state) &&
                                                  results.Area == CultureInfo.CurrentCulture.TextInfo.ToTitleCase(county) &&
                                                  results.Office == CultureInfo.CurrentCulture.TextInfo.ToTitleCase(office));
            return index;
        }

        public void SearchByCounty(string county)
        {
            var result =
                Data.Where(results => results.Area == CultureInfo.CurrentCulture.TextInfo.ToTitleCase(county.ToLower())).ToList();

            if (result.Count() != 0)
            {
                foreach (var get in result)
                {
                    Console.WriteLine(get);
                }
            }
            else
                Console.WriteLine("\n**No County named {0}**", county);
        }

        public void SearchByState(string state)
        {
            var result =
                Data.Where(results => results.State == CultureInfo.CurrentCulture.TextInfo.ToTitleCase(state.ToLower())).ToList();

            if (result.Count() != 0)
            {
                foreach (var get in result)
                {
                    Console.WriteLine(get);
                }
            }
            else
                Console.WriteLine("\n**No State named {0}**", state);


        }

        public void SearchByOffice(string office)
        {
            var result =
                Data.Where(
                    results => results.Office == CultureInfo.CurrentCulture.TextInfo.ToTitleCase(office.ToLower())).ToList();
            if (result.Count() != 0)
            {
                foreach (var get in result)
                {
                    Console.WriteLine(get);
                }
            }
            else
                Console.WriteLine("\n**No Office named {0}**", office);
        }
    }
}
