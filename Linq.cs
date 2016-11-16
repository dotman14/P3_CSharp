using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3
{
    class Linq : ElectionDataSet
    {
        public void numberDemocratic()
        {
            int year; 
            Console.WriteLine("Input the year:");
            year = Convert.ToInt32(Console.ReadLine());
            var result = from n in Data
                where n.Date.Year == year
                group n by n.Date.Year
                into demVote
                select new
                {
                    totalDem = demVote.Sum(n => n.DemocratVote)
                };

            Console.WriteLine("In {0}, {1}",year, result);
        }
    }
}
