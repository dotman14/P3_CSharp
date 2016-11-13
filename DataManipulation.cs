using System;
using System.Linq;

namespace P3
{
    class DataManipulation : ElectionDataSet
    {
        /* Search Method
         * Allow to search for a specific entries using e3 criteria : Office, State or County.
         * Hence the user can search for a specific county, a specific State or a specific 
         * kind of election.
         */
        public void Search()
        {
            Display.SearchByOptions();                          //display the menu
            Console.Write("\nSearch data by: ");
            var searchByVariable = Console.ReadKey().KeyChar;   //get the input of the user

            switch (searchByVariable)                           //switch on th user choice
            {
                case '1':                                       //search by type of election
                    Console.Write("\nType of Election: ");
                    AllTypesOfElections();
                    var office = Console.ReadLine();            //get the type of election from the user
                    Display.GetMainHeader();                    //display the header
                    SearchByOffice(office);                     //search the entries and display them
                    break;
                case '2':                                       //search by State
                    Console.Write("\nName of State: Ex. Indiana");         
                    var state = Console.ReadLine();             //get the state from the user
                    Display.GetMainHeader();                    
                    SearchByState(state);                       //search the entries and display them
                    break;
                case '3':                                       //search by county
                    Console.Write("\nName of County: ");
                    var county = Console.ReadLine();
                    Display.GetMainHeader();
                    SearchByCounty(county);
                    break;
                case '4':                                       //search by year
                    Console.Write("\nYear of Election (Example: 2012) ");
                    var yearString = Console.ReadLine();
                    int year;
                    if(int.TryParse(yearString, out year) &&
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

        /*Modify method
         * to modify the user must input 3 information to retrieve the entry he wants to modify:
         * State, County and kind of election (office). The association of these 3 criteria 
         * will always return a unique result.
         * The user is only allowed to modify the number of votes for democrat and republican.
         */
        public void Modify()
        {
            int newRepublicanVotes = 0, newDemocraticVotes = 0;

            Console.Write("\nSelect State: ");                  //get the input from the user
            var state = Console.ReadLine();

            Console.Write("Select County: ");
            var county = Console.ReadLine();

            Console.Write("Year of Election: ");
            var year = Console.ReadLine();

            Console.Write("Select Office: ");
            var office = Console.ReadLine();

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

        /*Add method
         * the user is allowed to add a new election data. He is then, mandatory to specify 
         * each attribute of a ElectionData object. Special care
         */
        public void Add()
        {
            string office;
            string state;
            string year;
            string area;
            var republicanVotes = 0;
            string republicanCandidate = null;
            var democraticVotes = 0;
            string democraticCandidate = null;

            bool badInput;
            do
            {                               //take the input from the user until we get good inputs
                badInput = false;
                Console.Write("\nElection office: ");
                office = Console.ReadLine();

                Console.Write("State name: ");
                state = Console.ReadLine();

                Console.Write("Year of Election: ");
                year = Console.ReadLine();

                Console.Write("County name: ");
                area = Console.ReadLine();

                Console.Write("Republican votes: ");
                try
                {                                           //check if the input is an positif integer 
                    republicanVotes = Convert.ToInt32(Console.ReadLine());
                    if (republicanVotes < 0)
                        throw new ArgumentOutOfRangeException();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    badInput = true;
                    continue;
                }

                Console.Write("Republican Candidate Name: ");
                republicanCandidate = Console.ReadLine();

                Console.Write("Democrat votes: ");
                try
                {                                           //check if the input is an positif integer
                    democraticVotes = Convert.ToInt32(Console.ReadLine());
                    if (democraticVotes < 0)
                        throw new ArgumentOutOfRangeException();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    badInput = true;
                    continue;
                }

                Console.Write("Democrat Candidate Name: ");
                democraticCandidate = Console.ReadLine();
            } while (badInput);

            //check if there is any duplicate
            var result =
                Data.Where(results => area != null && results.Area == ElectionData.TitleCase(area.ToLower())).
                     Where(results => state != null && results.State == ElectionData.TitleCase(state.ToLower())).
                     Where(results => office != null && results.Office == ElectionData.TitleCase(office.ToLower())).
                     Where(results => year != null && results.Date.Year == Convert.ToInt32(year));

            if (!result.Any())                                  //if there is no duplicate
            {
                var vote = republicanVotes + democraticVotes;   //determine the total votes
                                                                //declare and initialize a new election data objet
                var newElec = new ElectionData(office, state, new DateTime(Convert.ToInt32(year)), area, vote, republicanVotes, republicanCandidate, democraticVotes, democraticCandidate);
                Add(newElec);                                   //add the object to the list
                Console.WriteLine("\n Input Added\n");
                Display.GetMainHeader();
                Console.WriteLine(newElec);                     //display the object added
            }
            else
                Console.WriteLine("Data already exist");        //if duplicate exist
        }

        /*EditSingleElection method
         * this method allow to edit an entry of the List of ElectionData object
         */

        private void EditSingleElection(int rVotes, int dVotes, string state, string county, string year, string office)
        {
            var index = GetIndex(state, county, year, office);    //get the index of the entry to modify 
            if(index < 0)
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
    }
}