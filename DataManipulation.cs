using System;
using System.Globalization;
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
            Display.SearchByOptions();
            Console.Write("\nSearch data by: ");
            var searchByVariable = Console.ReadKey().KeyChar;
            switch (searchByVariable)
            {
                case '1':
                    Console.Write("\nType of Election: ");
                    var office = Console.ReadLine();
                    SearchByOffice(office);
                    break;
                case '2':
                    Console.Write("\nName of State: ");
                    var state = Console.ReadLine();
                    SearchByState(state);
                    break;
                case '3':
                    Console.Write("\nName of County: ");
                    var county = Console.ReadLine();
                    SearchByCounty(county);
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


            Console.Write("\nSelect State: ");
            var state = Console.ReadLine();
            Console.Write("Select County: ");
            var county = Console.ReadLine();
            Console.Write("Select Office: ");
            var office = Console.ReadLine();
            if (!CheckUniqueData(state, county, office))
                Console.WriteLine("There's no {0} election data for {1} County, {2}", office, county, state);
            else
            {
                bool badInput;
                do {
                    badInput = false;
                    Console.WriteLine("\nAt this time, you are only allowed to edit number of votes: ");
                    Console.WriteLine(GetSingleRow(state, county, office));
                    try
                    {
                        Console.Write("\nNew Votes for Republican Party: ");
                        newRepublicanVotes = Convert.ToInt32(Console.ReadLine());
                        Console.Write("New Votes for Democratic Party: ");
                        newDemocraticVotes = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("\n{0}",ex.Message);
                        Console.WriteLine("**Number of votes must be of type numeric**");
                        badInput = true;
                    }
                } while (badInput);
         
                EditSingleElection(newRepublicanVotes, newDemocraticVotes, state, county, office);

                Console.WriteLine("\n{0} election data for {1} County, {2} has been edited.", office, county, state);
                Console.WriteLine(GetSingleRow(state, county, office));
            }

        }

        /*
         * County and State should be unique.
         */

        public void Add()
        {
            string office;
            string state;
            string date;
            string area;
            var republicanVotes = 0;
            string republicanCandidate = null;
            var democraticVotes = 0;
            string democraticCandidate = null;

            bool badInput;
            do
            {
                badInput = false;
                Console.Write("Input the election office: ");
                office = Console.ReadLine();

                Console.Write("Input the state name: ");
                state = Console.ReadLine();

                Console.Write("Input the date: ");
                date = Console.ReadLine();

                Console.Write("Input the county name: ");
                area = Console.ReadLine();

                Console.Write("Input the number of republican voters: ");
                try
                {
                    republicanVotes = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Number of voter must be a number");
                    badInput = true;
                    continue;
                }

                Console.Write("Input the Republican Candidate Name: ");
                republicanCandidate = Console.ReadLine();

                Console.Write("Input the number of Democrat voters: ");
                try
                {
                    democraticVotes = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Number of voter must be a number");
                    badInput = true;
                    continue;
                }

                Console.Write("Input the Democrat Candidate Name: ");
                democraticCandidate = Console.ReadLine();
            } while (badInput);

            var result =
                Data.Where(results => area != null && results.Area == CultureInfo.CurrentCulture.TextInfo.ToTitleCase(area.ToLower())).
                     Where(results => state != null && results.State == CultureInfo.CurrentCulture.TextInfo.ToTitleCase(state.ToLower()));
            if (!result.Any())
            {
                var vote = republicanVotes + democraticVotes;
                var newElec = new ElectionData(office, state, date, area, vote, republicanVotes, republicanCandidate, democraticVotes, democraticCandidate);
                Add(newElec);
                Console.WriteLine("\n Input Added\n");
                Console.WriteLine(newElec.ToString());
            }
            else
            {
                Console.WriteLine("Data already exist");
            }
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
                                                rVotes,
                                                beforeUpdate.Republican,
                                                dVotes,
                                                beforeUpdate.Democrat
                                              );
            Data[index] = afterUpdate;
        }
    }
}
