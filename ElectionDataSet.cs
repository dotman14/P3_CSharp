using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace P3
{
    class ElectionDataSet
    {
        protected List<ElectionData> Data { get; }

        /* ElectionDataSet constructor 
         * This constructor uses chaining.
         * Same could be achieved by:
         * 1. Creating a local ReadCsv object
         * 2. Call Content Property on the object...That returns a list of string arrays 
         * 3. Use LINQ to convert List<string[]> into List<ElectionData>
         */

        protected ElectionDataSet()
        {
            if (Data != null)
                Clear();               //if the list is not empty, clear it
            
            //initialize a new list with the content of the CSV file
            Data = new ReadCsv().CsvContent.Select(x => new ElectionData(x[0], CultureInfo.CurrentCulture.TextInfo.ToTitleCase(x[1].ToLower()), x[2].Substring(0,4), x[3], Convert.ToInt32(x[4]), Convert.ToInt32(x[5]), x[6], Convert.ToInt32(x[7]), x[8])).ToList();
        }

        /*Count method
         * implement default Count() method from List data type
         */
        protected internal int Count => Data.Count;

        /*Clear method
         * implement default Clear() method from List data type
         */
        private void Clear() => Data.Clear();

        /*Add method
         * implement Add() method from DataManipulation class
         */
        protected void Add(ElectionData election) => Data.Add(election);

        /*DisplayAllData method
         * display the content of the List using a foreach loop
         */
        protected internal void DisplayAllData()
        {
            Display.GetMainHeader();                    //display the header
            foreach (var i in Data)
            {                                           //display the row, call the ToString 
                Console.WriteLine("{0}", i);            //method of ElectionData object
            }
        }

        private void DisplaySomeData(List<ElectionData> list)
        {
            foreach (var get in list)
            {
                Console.WriteLine(get);             //display each corresponding year entry found
            }
        }

        /*CheckUniqueData
         * this method allows to check if a data exist in the list. If the data exists
         * it should be unique because the association of the attribute state, area and office
         * is unique.
         * The method return true if a entry as been found or false if not
         */
        protected bool CheckUniqueData(string state, string county, string year, string office)
        {
            var result =
                Data.Where(results => results.State == CultureInfo.CurrentCulture.TextInfo.ToTitleCase(state) &&
                                      results.Area == CultureInfo.CurrentCulture.TextInfo.ToTitleCase(county) &&
                                      results.Office == CultureInfo.CurrentCulture.TextInfo.ToTitleCase(office) &&
                                      results.Date == year);
            return result.Any();
        }

        /*GetSingleRow method
         * this method allows to look for a single entry of the List if it exists in the list. 
         * If the data exist it should be unique because the association of the attribute state, 
         * area and office is unique.
         * The method return an ElectionData object if it exist
         */
        protected ElectionData GetSingleRow(string state, string county, string year, string office)
        {
            var result =
                Data.FirstOrDefault(results =>  results.State == CultureInfo.CurrentCulture.TextInfo.ToTitleCase(state) &&
                                       results.Area == CultureInfo.CurrentCulture.TextInfo.ToTitleCase(county) &&
                                       results.Office == CultureInfo.CurrentCulture.TextInfo.ToTitleCase(office) &&
                                       results.Date == year);
            return result;
        }

        /*GetIndex method
         * this method allows to look for the index of an entry if it exists in the list. 
         * If the data exist it should be unique because the association of the attribute state, 
         * area and office is unique.
         */
        protected int GetIndex(string state, string county, string year, string office)
        {

            var index = Data.FindIndex(results => results.State == CultureInfo.CurrentCulture.TextInfo.ToTitleCase(state) &&
                                                  results.Area == CultureInfo.CurrentCulture.TextInfo.ToTitleCase(county) &&
                                                  results.Office == CultureInfo.CurrentCulture.TextInfo.ToTitleCase(office) &&
                                                  results.Date == year);

            return index;
        }

        /*SearchByCounty method
         * this method allows to search for a specific entry with the corresponding county 
         * searched by the user. The method return a ElectionData object if it exists
         */
        protected void SearchByCounty(string county)
        {
                                                        //search for the corresponding county if it exists
            var result =
                Data.Where(results => results.Area == CultureInfo.CurrentCulture.TextInfo.ToTitleCase(county.ToLower())).ToList();

                                                        //if the county exists
            if (result.Count() != 0)
            {
                DisplaySomeData(result);                //display the county found
            }
            else                                        //if the county doesn't exit 
                Console.WriteLine("\n**No County named {0}**", county);
        }

        /*SearchByState method
         * this method allows to search a subset of entry with the corresponding state 
         * searched by the user. The method return an set ElectionData object if it exists.
         */

        protected void SearchByState(string state)
        {
                                                        //search for the corresponding state
            var result =
                Data.Where(results => results.State == CultureInfo.CurrentCulture.TextInfo.ToTitleCase(state.ToLower())).ToList();
                                            
            if (result.Count() != 0)                    //if the state exist
            {
                DisplaySomeData(result);               //display each corresponding state entry found
            }
            else                                        //if the state doesn't exit  
                Console.WriteLine("\n**No State named {0}**", state);
        }

        /*SearchByState method
         * this method allows to search a subset of entry with the corresponding office 
         * searched by the user. The method return an set ElectionData object if it exists.
         */
        protected void SearchByOffice(string office)
        {                                               //search for the corresponding office
            var result =
                Data.Where(
                    results => results.Office == CultureInfo.CurrentCulture.TextInfo.ToTitleCase(office.ToLower())).ToList();

            if (result.Count() != 0)                    //if the office exist
            {
                DisplaySomeData(result);                //Display correspondidng office found
            }
            else                                        //if the office doesn't exit
                Console.WriteLine("\n**No Office named {0}**", office);
        }

        protected void SearchByYear(string year)
        {                                               //search for the corresponding year
            var result = Data.Where( results => results.Date == year.ToLower()).ToList();

            if (result.Count() != 0)                    //if the year exist
            {
                DisplaySomeData(result);
            }
            else                                        //if the office doesn't exit
                Console.WriteLine("\n**No election held in {0}**", year);
        }
    }
}