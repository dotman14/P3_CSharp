using System;
using System.Collections.Generic;
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
                    Console.WriteLine("By Name");
                    break;
                case '2':
                    Console.WriteLine("By Party");
                    break;
                case '3':
                    Console.WriteLine("By State");
                    break;
                case '4':
                    Console.WriteLine("By County");
                    FilterBy("INDIANA");
                    break;
            }
        }

        public void FilterBy(string value)
        {
            var data = new ElectionDataSet().Data;
            var result = data.Where(results => results.State == CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value.ToLower()));
            foreach (var get in result)
            {
                Console.WriteLine(get);
            }
        }
    }
}
