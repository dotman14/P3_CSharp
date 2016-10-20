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
            Console.Write("Search data by: ");
            var searchByVariable = Console.ReadKey().KeyChar;
            switch (searchByVariable)
            {
                case '1':
                    Console.Write("\nName of Office: ");
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

        /*
         * County and State should be unique.
         */

        public void Add(string office, string state, string date, string county, string rVote, string rCand, string dVote, string dCand)
        {
            var result =
                Data.Where(results => results.Area  == CultureInfo.CurrentCulture.TextInfo.ToTitleCase(county.ToLower())).
                     Where(results => results.State == CultureInfo.CurrentCulture.TextInfo.ToTitleCase(state.ToLower()));
            if (!result.Any())
            {
                Data.Add(new ElectionData(office, state, date, county, rVote, rCand, dVote, dCand));
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

        public void SearchByYear(string year)
        {
            var result =
                Data.Where(results => results.Area == CultureInfo.CurrentCulture.TextInfo.ToTitleCase(year.ToLower()));
            foreach (var get in result)
            {
                Console.WriteLine(get);
            }
        }

        public void SearchByCandidate(string candidate)
        {
            var result =
                Data.Where(results =>
                        results.Democrat == CultureInfo.CurrentCulture.TextInfo.ToTitleCase(candidate.ToLower()));
            foreach (var get in result)
            {
                Console.WriteLine(get);
            }
        }     
    }
}
