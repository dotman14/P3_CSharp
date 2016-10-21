using System;
using System.Linq;
using System.Globalization;

namespace P3_oyedotnOyesanmi
{
    class DataManipulation : ElectionDataSet
    {
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


        public void Modify()
        {
            Console.Write("\nSelect State: ");
            var state = Console.ReadLine();
            Console.Write("Select County: ");
            var county = Console.ReadLine();
            if (!CheckUniqueData(state, county))
                Console.WriteLine("There's no election data for {0} County, {1}", county, state);
            else
                Console.WriteLine("You can edit data");
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
            int democraticVotes = 0;
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
                int vote = republicanVotes + democraticVotes;
                ElectionData newElec = new ElectionData(office, state, date, area, vote, republicanVotes, republicanCandidate, democraticVotes, democraticCandidate);
                Data.Add(newElec);
                Console.WriteLine("\n Input Added\n");
                Console.WriteLine(newElec.ToString());
            }
            else
            {
                Console.WriteLine("Data already exist");
            }
        }

        public void SearchByCounty(string county)
        {
            var result =
                Data.Where(results => results.Area == CultureInfo.CurrentCulture.TextInfo.ToTitleCase(county.ToLower()));
            foreach (var get in result)
            {
                Console.WriteLine(get);
            }
        }

        public void SearchByState(string state)
        {
            var result =
                Data.Where(results => results.State == CultureInfo.CurrentCulture.TextInfo.ToTitleCase(state.ToLower()));
            foreach (var get in result)
            {
                Console.WriteLine(get);
            }
        }

        public void SearchByOffice(string office)
        {
            var result =
                Data.Where(
                    results => results.Office == CultureInfo.CurrentCulture.TextInfo.ToTitleCase(office.ToLower()));
            foreach (var get in result)
            {
                Console.WriteLine(get);
            }
        }

    }
}
