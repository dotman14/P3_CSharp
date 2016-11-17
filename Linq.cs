using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3
{
    class Linq : ElectionDataSet
    {
        public void LinQueries()
        {
            Display.LinqOptions();

            Console.Write("\nSelect your option: Ex...1: ");
            var searchByVariable = Console.ReadKey().KeyChar;
            Console.WriteLine();
            switch (searchByVariable)
            {
                //case '1':
                //    Console.WriteLine(TotalVotes());
                //    break;
                case '2':
                    TotalRepublicanVotes();
                    break;
                case '3':
                    //Console.WriteLine(TotalDemocraticVotes());
                    TotalDemocraticVotes();
                    break;
                case '4':
                    Display.GetMainHeader();
                    Console.WriteLine(WidestWinningMargin().ToString());
                    break;
                case '5':
                    Display.GetMainHeader();
                    Console.WriteLine(SmallestWinningMargin().ToString());
                    break;
                case '6':
                    TotalVotes();
                    break;
                case '7':
                    TotalVotes();
                    break;
                case '8':
                    TotalVotes();
                    break;
                default:
                    Console.WriteLine("That option does not exist.");
                    break;
            }
        }

        public void TotalRepublicanVotes()
        {
            int year;
            Console.WriteLine("Input the year:");
            year = Convert.ToInt32(Console.ReadLine());
            var name = from c in Data
                       where c.Date.Year == year
                       group c by c.Republican into nm
                       select nm.Key;

            var result = from n in Data
                         where n.Date.Year == year
                         select n;
            if (name.Any())
            {
                int num = result.Sum(r => r.RepublicanVote);

                Console.WriteLine("In {0}, {1} persons voted for", year, num);
                foreach (var s in name)
                    Console.WriteLine(s);
            }
            else
                Console.WriteLine("No Data for the year {0}", year);

        }

        public void TotalDemocraticVotes()
        {
            int year;
            Console.WriteLine("Input the year:");
            year = Convert.ToInt32(Console.ReadLine());
            var name = from c in Data
                where c.Date.Year == year
                group c by c.Democrat into nm
                select nm.Key;
                
            var result = from n in Data
                where n.Date.Year == year
                select n;
            if (name.Any())
            {
                int num = result.Sum(r => r.DemocratVote);

                Console.WriteLine("In {0}, {1} persons voted for", year, num);
                foreach (var s in name)
                    Console.WriteLine(s);
            }
            else 
                Console.WriteLine("No Data for the year {0}", year);
            
        }

        private int TotalVotes()
        {
            var result = Data.Sum(r => r.Total);
            return result;
        }

        /*private int TotalRepublicanVotes()
        {
            var result = Data.Sum(r => r.RepublicanVote);
            return result;
        }

        private int TotalDemocraticVotes()
        {
            var result = Data.Sum(r => r.DemocratVote);
            return result;
        }*/

        private ElectionData WidestWinningMargin()
        {
            var result =
                Data.Select((r, i) => new {value = Math.Abs(r.DemocratVote - r.RepublicanVote), index = i}).
                    OrderByDescending(r => r.value).
                    FirstOrDefault();

            return Data[result.index];
        }

        private ElectionData SmallestWinningMargin()
        {
            var result =
               Data.Select((r, i) => new { value = Math.Abs(r.DemocratVote - r.RepublicanVote), index = i }).
                   OrderBy(r => r.value).
                   FirstOrDefault();

            return Data[result.index];
        }
    }
}
