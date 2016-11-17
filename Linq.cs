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
            var yearString = Console.ReadLine();
            int year;

            bool isValid = int.TryParse(yearString, out year);
            if (isValid == false)
                Console.WriteLine("You choose a wrong option is wrong. Ex. 2");
            if (year < 0)
                Console.WriteLine("Year must be greater than zero.");
            Console.WriteLine();
            switch (year)
            {
                //case '1':
                //    Console.WriteLine(TotalVotes());
                //    break;
                case 2:
                    Console.WriteLine(TotalRepublicanVotes());
                    break;
                case 3:
                    Console.WriteLine(TotalDemocraticVotes());
                    break;
                case 4:
                    Display.GetMainHeader();
                    Console.WriteLine(WidestWinningMargin().ToString());
                    break;
                case 5:
                    Display.GetMainHeader();
                    Console.WriteLine(SmallestWinningMargin().ToString());
                    break;
                case 6:
                    //foreach (var state in VotesPecentageByState())
                    //{
                    //    Console.WriteLine(state.ToString());
                    //    foreach (var results in state)
                    //    {
                    //        Console.WriteLine(" {0}", results);
                    //    }
                    //}
                    VotesPecentageByState();
                    break;
                case 7:
                    TotalVotes();
                    break;
                case 8:
                    TotalVotes();
                    break;
                case 9:
                    TotalVotes();
                    break;
                case 10:
                    TotalVotes();
                    break;
                default:
                    Console.WriteLine("That option does not exist.");
                    break;
            }
        }

        private int TotalVotes()
        {
            var result = Data.Sum(r => r.Total);
            return result;
        }

        private int TotalRepublicanVotes()
        {
            var result = Data.Sum(r => r.RepublicanVote);
            return result;
        }

        private int TotalDemocraticVotes()
        {
            var result = Data.Sum(r => r.DemocratVote);
            return result;
        }

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

        private void VotesPecentageByState()
        {
            var res  = Data.GroupBy(r => r.State)
                           .Select(
                                group => new
                                {
                                    State = group.Key,
                                    Results = group.OrderByDescending(p => p.Total)
                                    .Take(3)
                                })
                           .ToList();


            //var re1s = Data.GroupBy(r => r.State).Select(x => x.OrderByDescending(p => p.Total).Take(3)).ToArray();

            foreach (var x in res)
            {
                Console.WriteLine(x.State);
                foreach (var c in x.Results)
                {
                    Console.WriteLine(c);
                }
            }
        }
    }
}
