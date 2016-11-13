using System;

namespace P3
{
    public static class Display
    {
        //Main menu display function
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

        //search display function
        public static void SearchByOptions()
        {
            Console.WriteLine("\n1. Office");
            Console.WriteLine("2. State");
            Console.WriteLine("3. County");
            Console.WriteLine("4. Year");
        }

        //Modify display function
        public static void CountyToModify()
        {
            Console.WriteLine("\nYou can modify the following data: ");
            Console.WriteLine("1. County");
            Console.WriteLine("2. State");
        }

        //Display the main header 
        public static void GetMainHeader()
        {
            Console.WriteLine(
                $"\n{"OFFICE",1}{"STATE",26}{"YEAR",8}{"AREA",22}{"TOTAL",10}{"R-VOTES",11}{"R-CANDIDATE",23}{"D-VOTES",11}{"D-CANDIDATE",20}\n{"-----------------------------------------------------------------------------------------------------------------------------------------------",0}");
        }
    }
}
