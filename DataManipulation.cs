using System;
using System.Linq;
using System.Globalization;

namespace P3_oyedotnOyesanmi
{
    class DataManipulation : ElectionDataSet
    {

        public string Date { get; set; }
        public string Republican { get; set; }
        public int RepublicanVote { get; set; }
        public string Democrat { get; set; }
        public int DemocratVote { get; set; }
        public string Area { get; set; }
        public string State { get; set; }
        public string Office { get; set; }
        public string Total { get; set; }

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
            Display.CountyToModify();
        }

        /*
         * County and State should be unique.
         */

        public void Add()
       {
            bool badInput;
            do {
                badInput = false;
                Console.WriteLine("Input the election office: ");
                Office = Console.ReadLine();
                Console.WriteLine("Input the state name: ");
                State = Console.ReadLine();
                Console.WriteLine("Input the date: ");
                Date = Console.ReadLine();
                Console.WriteLine("Input the county name: ");
                Area = Console.ReadLine();

                Console.WriteLine("Input the number of republican voters: ");
                try {
                    RepublicanVote = Convert.ToInt32(Console.ReadLine());
                } catch (Exception ex) {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Number of voter must be a number");
                    badInput = true;
                    continue;
                }

                Console.WriteLine("Input the Republican Candidate Name: ");
                Republican = Console.ReadLine();

                Console.WriteLine("Input the number of Democrat voters: ");
                try{
                    DemocratVote = Convert.ToInt32(Console.ReadLine());
                } catch (Exception ex) {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Number of voter must be a number");
                    badInput = true;
                    continue;
                }

                Console.WriteLine("Input the Democrat Candidate Name: ");
                Democrat = Console.ReadLine();
            } while (badInput);

            var result =
                Data.Where(results => results.Area  == CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Area.ToLower())).
                     Where(results => results.State == CultureInfo.CurrentCulture.TextInfo.ToTitleCase(State.ToLower()));
            if (!result.Any())
            {
                string repVote = RepublicanVote.ToString();
                string demVote = DemocratVote.ToString();
                int vote = RepublicanVote + DemocratVote;
                ElectionData newElec = new ElectionData(Office, State, Date, Area, vote, RepublicanVote, Republican, DemocratVote, Democrat);
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
