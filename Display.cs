using System;

namespace P3
{
    public static class Display
    {
        public static void MainMenu()
        {
            Console.WriteLine("\n--------- Menu Display -----------");
            Console.WriteLine("0. Clear and Load Dataset ");
            Console.WriteLine("1. Add an item to Dataset");
            Console.WriteLine("2. Modify Dataset");
            Console.WriteLine("3. Search Dataset");
            Console.WriteLine("4. Display Dataset Count");
            Console.WriteLine("5. Exit");
            Console.WriteLine("----------------------------------");
        }

        public static void SearchByOptions()
        {
            //Console.WriteLine("");
            Console.WriteLine("\n1. Office");
            Console.WriteLine("2. State");
            Console.WriteLine("3. County");
        }

        public static void CountyToModify()
        {
            Console.WriteLine("\nYou can modify the following data: ");
            Console.WriteLine("1. County");
            Console.WriteLine("2. State");
        }

        public static void GetMainHeader()
        {
            Console.WriteLine("{0,8}{1,20}{2,10}{3,15}{4,8}{5,8}{6,16}{7,8}{8,16}", "Office", "State", "Date", "Area", "Total", "Rep-Vot", "Rep-Candidate", "Dem-Vot", "Dem-Candidate");
        }
    }
}
