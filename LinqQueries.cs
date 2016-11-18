/****************************** File Header ******************************\
File Name:    LinqQueries.cs
Project:      US Election Data by County

This class is u

\***************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;

namespace P3
{
    class LinqQueries
    {
        private static readonly ElectionDataSet Elect = new ElectionDataSet();
        private readonly List<ElectionData> data = Elect.Data;

        public void Queries()
        {
            Display.LinqOptions();

            Console.Write("\nSelect LINQ Query option: Ex...1: ");
            var searchByVariable = Console.ReadKey().KeyChar;
            Console.WriteLine();
            switch (searchByVariable)
            {
                case '1':
                    TotalRepublicanVotes();
                    break;
                case '2':
                    TotalDemocraticVotes();
                    break;
                case '3':
                    Display.GetMainHeader();
                    Console.WriteLine(WidestWinningMargin().ToString());
                    break;
                case '4':
                    Display.GetMainHeader();
                    Console.WriteLine(SmallestWinningMargin().ToString());
                    break;
                case '5':
                    VotePercentageState();
                    break;
                case '6':
                    VotePercentageYear();
                    break;
                case '7':
                    Console.WriteLine();
                    VotesPecentageByState();
                    break;
                case '8':
                    SameNameCounty();
                    break;
                //case '9':
                    
                default:
                    Console.WriteLine("That option does not exist.");
                    break;
            }
        }

        /************************************************************************** 
         * Query to retrieve the county with the same name located 
         * in different state
         **************************************************************************/
        private void SameNameCounty()
        {
            var duplicates = data               //find the duplicate county  
                .GroupBy(s => s.Area)
                .Where(s=>s.Count() > 1)
                .SelectMany(grp => grp.Skip(0))
                .OrderBy(s=>s.Area);

            var distinct = duplicates           //find the unique elements
                .GroupBy(p => p.Area)           //from the precedent query
                .Select(group => new {
                    county = group.Key,
                    count = group.Count()
                });

            foreach (var dist in distinct)      //first foreach used to diplay the county name
            {
                Console.WriteLine("{0} can be found in {1} States:",dist.county, dist.count);
                foreach (var dup in duplicates) //second foreach used to display each duplicate of the county
                {
                    if(dist.county == dup.Area)
                        Console.WriteLine("  - {0,8}",dup.State);
                }
            }
        }

        /*************************************************************************
         * Query used to find the percentage of vote for each party
         *************************************************************************/
        private void VotePercentageYear()
        {
            Console.Write("Input the year: ");                  //take the year chosen by the user
            var year = Convert.ToInt32(Console.ReadLine());

            var percentYear = from  c in data               
                              where c.Date.Year == year         //filter the correspondant year
                              group c by c.Date.Year            //group by the seleect year
                              into prYr
                              select new                        //create a new objet with percentage
                              {
                                  year = prYr.Key,
                                  stateDemPer = (Convert.ToDouble(prYr.Sum(c => c.DemocratVote)) / Convert.ToDouble(prYr.Sum(c => c.Total)) * 100),
                                  stateRepPer = (Convert.ToDouble(prYr.Sum(c => c.RepublicanVote)) / Convert.ToDouble(prYr.Sum(c => c.Total)) * 100)
                              };

            if (percentYear.Any())                              //if there is any result
            {
                foreach (var per in percentYear)                //display it
                    Console.WriteLine("{0,6} => Democrate: {1:0.00}%, Republican: {2:0.00}%, Other Votes {3:0.00}%", per.year, per.stateDemPer, per.stateRepPer, 100 - (per.stateDemPer + per.stateRepPer));
            }
            else
                Console.WriteLine("No Data for the year {0}", year);
        }

        /*************************************************************************
         * Query used to find the percentage of vote for 
         * each state for a particular year
         *************************************************************************/
        private void VotePercentageState()
        {
            Console.Write("Input the year: ");                  //take the year chosen by the user
            int year = Convert.ToInt32(Console.ReadLine());

            var percent = from c in data
                          where c.Date.Year == year             //filter by year
                          group c by c.State                    //group by state
                          into pr                               
                          select new                            //create a new object with state name and percentage
                          {
                              stateName = pr.Key,
                              stateDemPer = (Convert.ToDouble(pr.Sum(c => c.DemocratVote)) / Convert.ToDouble(pr.Sum(c => c.Total)) * 100),
                              stateRepPer = (Convert.ToDouble(pr.Sum(c => c.RepublicanVote)) / Convert.ToDouble(pr.Sum(c => c.Total)) * 100)
                          };
            if (percent.Any())                                  //if there is any result
            {
                foreach (var per in percent)                    //display each county
                    Console.WriteLine("{0,20} => Democrate: {1:0.00}%, Republican: {2:0.00}% Others: {3:0.00}%", per.stateName, per.stateDemPer, per.stateRepPer, 100 - (per.stateDemPer + per.stateRepPer));
            }
            else
                Console.WriteLine("No Data for the year {0}", year);
        }

        /*************************************************************************
         * Query used to find the total number of votes for the 
         * republican for a particular year
         *************************************************************************/
        private void TotalRepublicanVotes()
        {
            Console.Write("Input the year: ");                  //take the year chosen by the user
            var year = Convert.ToInt32(Console.ReadLine());

            var name = from  c in data
                       where c.Date.Year == year                //filter by year
                       group c by c.Republican into nm          //group by Republican Candidate name
                       select nm.Key;

            var result = from n in data
                         where n.Date.Year == year
                         select n;
            if (name.Any())                                     //if we have any result
            {
                int num = result.Sum(r => r.RepublicanVote);    //sum the republican votes

                Console.Write("In {0}, {1} people voted for ", year, num);
                foreach (var s in name)
                    Console.WriteLine(s);
            }
            else
                Console.WriteLine("No Data for the year {0}", year);

        }

        /*************************************************************************
         * Query used to find the total number of votes for democrats 
         * for a particaular year
         *************************************************************************/
        private void TotalDemocraticVotes()
        {
            Console.Write("Input the year: ");
            int year = Convert.ToInt32(Console.ReadLine());     //take the year chosen by the user

            var name = from c in data
                       where c.Date.Year == year                //filter by year
                       group c by c.Democrat into nm            //group by Democrat Candidate name
                       select nm.Key;

            var result = from n in data
                         where n.Date.Year == year
                         select n;

            if (name.Any())                                     //if we have any result
            {
                int num = result.Sum(r => r.DemocratVote);      //sum the democrat votes

                Console.Write("In {0}, {1} persons voted for ", year, num);
                foreach (var s in name)
                    Console.WriteLine(s);
            }
            else
                Console.WriteLine("No Data for the year {0}", year);

        }

        /*************************************************************************
         * Query used to find the widdest wining margin
         *************************************************************************/
        private ElectionData WidestWinningMargin()
        {
            var result =
                data.Select((r, i) => new { value = Math.Abs(r.DemocratVote - r.RepublicanVote), index = i }).
                    OrderByDescending(r => r.value).
                    FirstOrDefault();

            return data[result.index];
        }

        /*************************************************************************
         * Query used to find the smallest wining margin
         *************************************************************************/
        private ElectionData SmallestWinningMargin()
        {
            var result =
               data.Select((r, i) => new { value = Math.Abs(r.DemocratVote - r.RepublicanVote), index = i }).
                   OrderBy(r => r.value).
                   FirstOrDefault();

            return data[result.index];
        }

        /*************************************************************************
         * Query used to find the top three vote in each state
         *************************************************************************/
        private void VotesPecentageByState()
        {
            var res = data.GroupBy(r => r.State)
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
                    Console.WriteLine(" - {0}", c);
                }
            }
        }
    }
}