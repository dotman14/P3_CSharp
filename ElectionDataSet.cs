/****************************** File Header ******************************\
Module Name:  Display.cs
Project:      US Election Data by County

This is a static class used across the project to 
display well formatted headers and menu options.

\***************************************************************************/

using System;
using System.Collections.Generic;
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
                Clear(); //if the list is not empty, clear it
            
            //initialize a new list with the content of the CSV file
            Data =
                new ReadCsv().CsvContent.Select(
                    x =>
                        new ElectionData(x[0], ElectionData.TitleCase(x[1].ToLower()), 
                                        new DateTime(Convert.ToInt32(x[2].Substring(0, 4)), 
                                                     Convert.ToInt32(x[2].Substring(4, 2)),
                                                     Convert.ToInt32(x[2].Substring(6, 2))), 
                                                     x[3],
                                                     Convert.ToInt32(x[4]), 
                                                     Convert.ToInt32(x[5]), 
                                                     x[6], 
                                                     Convert.ToInt32(x[7]), 
                                                     x[8])).ToList();
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
            Display.GetMainHeader(); //display the header
            foreach (var i in Data)
            {   //display the row, call the ToString 
                Console.WriteLine("{0}", i); //method of ElectionData object
            }
        }

        private void DisplaySomeData(List<ElectionData> list)
        {
            foreach (var get in list)
            {
                Console.WriteLine(get);  //display each corresponding year entry found
            }
        }

        /*CheckUniqueData
         * this method allows to check if a data exist in the list. If the data exists
         * it should be unique because the association of the attribute state, area and office
         * is unique.
         * The method return true if a entry as been found or false if not
         */
        protected bool CheckUniqueData(string state, string county, int year, string office)
        {
            var result =
                Data.Where(results => results.State     == ElectionData.TitleCase(state) &&
                                      results.Area      == ElectionData.TitleCase(county) &&
                                      results.Office    == ElectionData.TitleCase(office) &&
                                      results.Date.Year == year);
            return result.Any();
        }

        /*GetSingleRow method
         * this method allows to look for a single entry of the List if it exists in the list. 
         * If the data exist it should be unique because the association of the attribute state, 
         * area and office is unique.
         * The method return an ElectionData object if it exist
         */
        protected ElectionData GetSingleRow(string state, string county, int year, string office)
        {
            var result =
                Data.FirstOrDefault(results =>  results.State     == ElectionData.TitleCase(state) &&
                                                results.Area      == ElectionData.TitleCase(county) &&
                                                results.Office    == ElectionData.TitleCase(office) &&
                                                results.Date.Year == year);
            return result;
        }

        /*GetIndex method
         * this method allows to look for the index of an entry if it exists in the list. 
         * If the data exist it should be unique because the association of the attribute state, 
         * area and office is unique.
         */
        protected int GetIndex(string state, string county, int year, string office)
        {

            var index = Data.FindIndex(results => results.State     == ElectionData.TitleCase(state) &&
                                                  results.Area      == ElectionData.TitleCase(county) &&
                                                  results.Office    == ElectionData.TitleCase(office) &&
                                                  results.Date.Year == year);

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
                Data.Where(results => results.Area == ElectionData.TitleCase(county.ToLower())).ToList();

               //if the county exists
            if (result.Count() != 0)
            {
                DisplaySomeData(result);//display the county found
            }
            else   //if the county doesn't exit 
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
                Data.Where(results => results.State == ElectionData.TitleCase(state.ToLower())).ToList();
                                            
            if (result.Count() != 0) //if the state exist
            {
                DisplaySomeData(result); //display each corresponding state entry found
            }
            else //if the state doesn't exit  
                Console.WriteLine("\n**No State named {0}**", state);
        }

        /*SearchByState method
         * this method allows to search a subset of entry with the corresponding office 
         * searched by the user. The method return an set ElectionData object if it exists.
         */
        protected void SearchByOffice(string office)
        {                                               
            var result =
                Data.Where(
                    results => results.Office == ElectionData.TitleCase(office.ToLower()) ||
                               results.Office[0] == char.ToUpper(office[0])).ToList();

            if (result.Count() != 0)//if the office exist
            {
                DisplaySomeData(result);//Display correspondidng office found
            }
            else                   //if the office doesn't exit
                Console.WriteLine("\n**No Office named {0}**", office);
        }

        protected void SearchByYear(int year)
        {    //search for the corresponding year
            var result = Data.Where( results => results.Date.Year == year).ToList();

            if (result.Count() != 0) //if the year exist
            {
                DisplaySomeData(result);
            }
            else //if the office doesn't exit 
                Console.WriteLine("\n**No election held in {0}**", year);
        }
        //This method prints out all types of election
        protected string AllTypesOfElections()
        {
            var types = Data.Select(r => r.Office).Distinct().ToArray();
            return string.Join("/", types);
        } 
    }
}