/****************************** File Header ******************************\
File Name:    ElectionDataSet.cs
Project:      US Election Data by County

This class is the main collection of all election data.
Manipulation on election data occur here.
\***************************************************************************/

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace P3
{
    class ElectionDataSet
    {
        public List<ElectionData> Data { get; }

        /* ElectionDataSet constructor 
         * This constructor uses chaining.
         * Same could be achieved by:
         * 1. Creating a local ReadCsv object
         * 2. Call Content Property on the object...That returns a list of string arrays 
         * 3. Use LINQ to convert List<string[]> into List<ElectionData>
         */

        public ElectionDataSet()
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
        public int Count => Data.Count;

        /*Clear method
         * implement default Clear() method from List data type
         */
        private void Clear() => Data.Clear();

        /*Add method
         * implement Add() method from DataManipulation class
         */
        private void Add(ElectionData election) => Data.Add(election);

        /*DisplayAllData method
         * display the content of the List using a foreach loop
         */
         public void DisplayAllData()
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

        private bool CheckUniqueData(string state, string county, int year, string office)
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

        private ElectionData GetSingleRow(string state, string county, int year, string office)
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

        private int GetIndex(string state, string county, int year, string office)
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

        private void SearchByCounty(string county)
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

        private void SearchByState(string state)
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

        private void SearchByOffice(string office)
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

        private void SearchByYear(int year)
        {    //search for the corresponding year
            var result = Data.Where( results => results.Date.Year == year).ToList();

            if (result.Count() != 0) //if the year exist
            {
                DisplaySomeData(result);
            }
            else //if the office doesn't exit 
                Console.WriteLine("\n**No election held in {0}**", year);
        }

        //This method prints out all types of election in the database
        private string AllTypesOfElections()
        {
            var types = Data.Select(r => r.Office).Distinct().ToArray();
            return string.Join("/", types);
        }

        public void Add()
        {
            string office;
            string state;
            string area;
            DateTime dateTime = new DateTime();
            int republicanVotes;
            string republicanCandidate;
            int democraticVotes;
            string democraticCandidate;

            Console.WriteLine("\nEnter details for new election data below\nEnter -- (double hyphen/minus) at anytime to exit\n");

            do
            {
                Console.Write("Election office: "); //get the input from the user
                office = ElectionData.TitleCase(Console.ReadLine());
                if (office == "--")
                    return;
                if (string.IsNullOrEmpty(office))
                    Console.WriteLine("Office Name can not be empty or NULL");
            } while (string.IsNullOrEmpty(office));

            do
            {
                Console.Write("State name: "); //get the input from the user
                state = ElectionData.TitleCase(Console.ReadLine());
                if (state == "--")
                    return;
                if (string.IsNullOrEmpty(state))
                    Console.WriteLine("State Name can not be empty or NULL");
            } while (string.IsNullOrEmpty(state));

            bool isValidDate;
            do
            {
                Console.Write("Year of Election: (YYYYMMDD) ");
                var yearString = Console.ReadLine();
                if (yearString == "--")
                    return;

                DateTime temp;
                isValidDate = DateTime.TryParseExact(yearString, "yyyyMMdd", CultureInfo.InvariantCulture,
                    DateTimeStyles.None, out temp);
                if (isValidDate)
                    dateTime = temp;
                else
                    Console.WriteLine("Date has to be valid, in the format: YYYMMDD");
            } while (isValidDate == false);

            do
            {
                Console.Write("County name: "); //get the input from the user
                area = ElectionData.TitleCase(Console.ReadLine());
                if (area == "--")
                    return;
                if (string.IsNullOrEmpty(area))
                    Console.WriteLine("County Name can not be empty or NULL");
            } while (string.IsNullOrEmpty(area));


            bool isRepVotesValid;
            do
            {
                Console.Write("Republican votes: ");
                var repVoteString = Console.ReadLine();
                if (repVoteString == "--")
                    return;
                isRepVotesValid = int.TryParse(repVoteString, out republicanVotes);
                if (isRepVotesValid == false)
                    Console.WriteLine("Number of votes MUST be an integer. Ex. 1234");
                if (republicanVotes < 0)
                    Console.WriteLine("Number of votes MUST be greater than zero.");

            } while (republicanVotes < 0 || isRepVotesValid == false);


            do
            {
                Console.Write("Republican Candidate Name: "); //get the input from the user
                republicanCandidate = ElectionData.TitleCase(Console.ReadLine());
                if (republicanCandidate == "--")
                    return;
                if (string.IsNullOrEmpty(republicanCandidate))
                    Console.WriteLine("Republican Candidate Name can not be empty or NULL");
            } while (string.IsNullOrEmpty(republicanCandidate));


            bool isDemVotesValid;
            do
            {
                Console.Write("Republican votes: ");
                var demVoteString = Console.ReadLine();
                if (demVoteString == "--")
                    return;
                isDemVotesValid = int.TryParse(demVoteString, out democraticVotes);
                if (isDemVotesValid == false)
                    Console.WriteLine("Number of votes MUST be an integer. Ex. 1234");
                if (republicanVotes < 0)
                    Console.WriteLine("Number of votes MUST be greater than zero.");

            } while (democraticVotes < 0 || isDemVotesValid == false);


            do
            {
                Console.Write("Democrat Candidate Name: "); //get the input from the user
                democraticCandidate = ElectionData.TitleCase(Console.ReadLine());
                if (democraticCandidate == "--")
                    return;
                if (string.IsNullOrEmpty(democraticCandidate))
                    Console.WriteLine("Democrat Candidate Name can not be empty or NULL");
            } while (string.IsNullOrEmpty(democraticCandidate));

            //check if there is any duplicate
            var result =
                Data.Where(results => area != null && results.Area == ElectionData.TitleCase(area.ToLower())).
                     Where(results => state != null && results.State == ElectionData.TitleCase(state.ToLower())).
                     Where(results => office != null && results.Office == ElectionData.TitleCase(office.ToLower())).
                     Where(results => results.Date.Year == dateTime.Year);

            if (!result.Any())                                  //if there is no duplicate
            {
                var vote = republicanVotes + democraticVotes;   //determine the total votes
                                                                //declare and initialize a new election data objet
                var newElec = new ElectionData(office, state, dateTime, area, vote, republicanVotes, republicanCandidate, democraticVotes, democraticCandidate);
                Add(newElec);                                   //add the object to the list
                Console.WriteLine("\n Input Added\n");
                Display.GetMainHeader();
                Console.WriteLine(newElec);                     //display the object added
            }
            else
                Console.WriteLine("Data already exist");        //if duplicate exist
        }

        private void EditSingleElection(int rVotes, int dVotes, string state, string county, int year, string office)
        {
            var index = GetIndex(state, county, year, office);    //get the index of the entry to modify 
            if (index < 0)
            {
                Console.WriteLine("Sorry, we have no data for that election");
                return;
            }
            var beforeUpdate = GetSingleRow(state, county, year, office); //get the row to modify

            //create a new object with the modified data
            var afterUpdate = new ElectionData(
                                                beforeUpdate.Office,
                                                beforeUpdate.State,
                                                beforeUpdate.Date,
                                                beforeUpdate.Area,
                                                rVotes + dVotes,
                                                rVotes,
                                                beforeUpdate.Republican,
                                                dVotes,
                                                beforeUpdate.Democrat
                                              );
            Data[index] = afterUpdate;                      //swap the old data with the modified one
        }

        public void Modify()
        {
            int newRepublicanVotes = 0, newDemocraticVotes = 0;
            string state, county, office;
            int year;
            List<ElectionData> result;

            Console.WriteLine("\nEnter details for new election data below\nEnter -- (double hyphen/minus) at anytime to exit\n");
            do
            {
                Console.Write("Select State: "); //get the input from the user
                state = ElectionData.TitleCase(Console.ReadLine());
                if (state == "--")
                    return;
                result = Data.Where(results => results.State == state).ToList();
                if (!result.Any())
                    Console.WriteLine("Warning: State not in the Data set");
            } while (!result.Any());

            do
            {
                Console.Write("Select County: ");
                county = ElectionData.TitleCase(Console.ReadLine());
                if (county == "--")
                    return;
                result = Data.Where(results => results.State == state && results.Area == county).ToList();
                if (!result.Any())
                    Console.WriteLine("Warning: No county in {0} named {1}", state, county);
            } while (!result.Any());

            do
            {
                Console.Write("Select Office: Ex..{0}: ", AllTypesOfElections());
                office = ElectionData.TitleCase(Console.ReadLine());
                if (office == "--")
                    return;
                result =
                    Data.Where(results => results.Office == office && results.State == state && results.Area == county).
                        ToList();
                if (!result.Any())
                    Console.WriteLine("Warning: We have no {0} election for {1}, {2}", office, county, state);
            } while (!result.Any());

            bool isValid;
            do
            {
                Console.Write("Year of Election: ");
                var yearString = Console.ReadLine();

                if (yearString == "--")
                    return;

                isValid = int.TryParse(yearString, out year);
                if (isValid == false)
                    Console.WriteLine("Year format is wrong. Ex. 2008");
                if (year < 0)
                    Console.WriteLine("Year must be greater than zero.");

                result =
                    Data.Where(results => results.Office == office && results.State == state && results.Area == county && results.Date.Year == year).ToList();
                if (!result.Any())
                    Console.WriteLine("Warning: We have no {0} election for {1}, {2} in {3}", office, county, state, year);

            } while (year < 0 || isValid == false || !result.Any());




            if (!CheckUniqueData(state, county, year, office))        //check if the entry exists
                Console.WriteLine("There's no {0} election data for {1} County, {2}, in {3}", office, county, state, year);
            else
            {                                                   //if the entry exist
                Console.WriteLine("\nAt this time, you are only allowed to edit number of votes: ");
                bool badInput;
                do
                {
                    badInput = false;
                    Display.GetMainHeader();
                    Console.WriteLine(GetSingleRow(state, county, year, office));

                    //display the entry to modify
                    try                                         //user can only modify number of vote
                    {                                           //check user input
                        Console.Write("\nNew Votes for Republican Party: ");
                        newRepublicanVotes = Convert.ToInt32(Console.ReadLine());
                        if (newRepublicanVotes < 0)
                            throw new ArgumentOutOfRangeException();

                        Console.Write("New Votes for Democratic Party: ");
                        newDemocraticVotes = Convert.ToInt32(Console.ReadLine());

                        if (newDemocraticVotes < 0)
                            throw new ArgumentOutOfRangeException();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("\n{0}", ex.Message);
                        badInput = true;
                    }
                } while (badInput);
                //if the input is good, we edit the entry
                EditSingleElection(newRepublicanVotes, newDemocraticVotes, state, county, year, office);

                Console.WriteLine("\n {0} {1} election data for {2} County, {3} has been edited.", year, office, county, state);
                Display.GetMainHeader();
                Console.WriteLine(GetSingleRow(state, county, year, office));
            }
        }

        public void Search()
        {
            Display.SearchByOptions(); //display the menu
            Console.Write("\nSearch data by: ");
            var searchByVariable = Console.ReadKey().KeyChar; //get the input of the user

            switch (searchByVariable) //switch on th user choice
            {
                case '1': //search by type of election
                    Console.Write("\nSelect Office: Ex..(P)residential, (S)enate, (G)overnorship, (H)ouse of Rep: ");
                    var office = Console.ReadLine(); //get the type of election from the user
                    Display.GetMainHeader(); //display the header
                    SearchByOffice(office); //search the entries and display them
                    break;
                case '2': //search by State
                    Console.Write("\nName of State: Ex... Indiana: ");
                    var state = Console.ReadLine(); //get the state from the user
                    Display.GetMainHeader();
                    SearchByState(state); //search the entries and display them
                    break;
                case '3': //search by county
                    Console.Write("\nName of County: ");
                    var county = Console.ReadLine();
                    Display.GetMainHeader();
                    SearchByCounty(county);
                    break;
                case '4': //search by year
                    Console.Write("\nYear of Election: Ex...2012: ");
                    var yearString = Console.ReadLine();
                    int year;
                    if (int.TryParse(yearString, out year) &&
                       year > 0)
                    {
                        Display.GetMainHeader();
                        SearchByYear(year);
                    }
                    else
                        Console.Write("\nYear format is wrong\n");

                    break;
                default:
                    Console.WriteLine("\nThis option does not exist");
                    break;
            }
        }
    }
}