using System;
using System.Linq;
using System.Globalization;

namespace P3_oyedotnOyesanmi
{
    class DataManipulation
    {
        public void Search()
        {
            Display.SearchByOptions();
            Console.WriteLine("Search data by: ");
            var searchBy = Console.ReadKey().KeyChar;
            switch (searchBy)
            {
                case '1':
                    var name = Console.ReadLine();
                    FilterByCandidate(name);
                    break;
                case '2':
                    var office = Console.ReadLine();
                    FilterByOffice(office);
                    break;
                case '3':
                    Console.WriteLine("Enter name of State");
                    var state = Console.ReadLine();
                    FilterByState(state);
                    break;
                case '4':
                    var county = Console.ReadLine();
                    FilterByCounty(county);
                    break;
                default:
                    Console.WriteLine("This option does not exist");
                    break;
            }
        }

        public void FilterByCounty(string county)
        {
            var data = new ElectionDataSet().Data;
            var result = data.Where(results => results.Area == CultureInfo.CurrentCulture.TextInfo.ToTitleCase(county.ToLower()));
            foreach (var get in result)
            {
                Console.WriteLine(get);
            }
        }

        public void FilterByState(string state)
        {
            var data = new ElectionDataSet().Data;
            var result = data.Where(results => results.State == CultureInfo.CurrentCulture.TextInfo.ToTitleCase(state.ToLower()));
            foreach (var get in result)
            {
                Console.WriteLine(get);
            }
        }

        public void FilterByOffice(string office)
        {
            var data = new ElectionDataSet().Data;
            var result = data.Where(results => results.Area == CultureInfo.CurrentCulture.TextInfo.ToTitleCase(office.ToLower()));
            foreach (var get in result)
            {
                Console.WriteLine(get);
            }
        }

        public void FilterByCandidate(string candidate)
        {
            var data = new ElectionDataSet().Data;
            var result = data.Where(results => results.Area == CultureInfo.CurrentCulture.TextInfo.ToTitleCase(candidate.ToLower()));
            foreach (var get in result)
            {
                Console.WriteLine(get);
            }
        }

        public void FilterByYear(string year)
        {
            var data = new ElectionDataSet().Data;
            var result = data.Where(results => results.Area == CultureInfo.CurrentCulture.TextInfo.ToTitleCase(year.ToLower()));
            foreach (var get in result)
            {
                Console.WriteLine(get);
            }
        }
    }
}
