/****************************** File Header ******************************\
File Name:    Display.cs
Project:      US Election Data by County

This is a static class used across the project to 
display well formatted headers and menu options.

\***************************************************************************/

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
            Console.WriteLine("5. LINQ Queries");
            Console.WriteLine("6. Exit");
            Console.WriteLine("----------------------------------");
        }

        public static void LinqOptions()
        {
            Console.WriteLine("\n1. Total Number of Republican Votes");
            Console.WriteLine("2. Total Number of Democratic Votes");
            Console.WriteLine("3. Biggest winning margin by any Candidate");
            Console.WriteLine("4. Smallest winning margin by any Candidate");
            Console.WriteLine("5. Votes percentage by State");
            Console.WriteLine("6. Votes percentage by Year");
            Console.WriteLine("7. Top 3 total votes in each State");
            Console.WriteLine("8. County with the same name in different State");
            //Console.WriteLine("7. Percentage Voter Increase");
        }

        //search display function
        public static void SearchByOptions()
        {
            Console.WriteLine("\n1. Office");
            Console.WriteLine("2. State");
            Console.WriteLine("3. County");
            Console.WriteLine("4. Year");
        }

        //Display the main header 
        public static void GetMainHeader()
        {
            Console.WriteLine(
                $"\n{"OFFICE",1}{"STATE",26}{"YEAR",8}{"AREA",22}{"TOTAL",10}{"R-VOTES",11}{"R-CANDIDATE",23}{"D-VOTES",11}{"D-CANDIDATE",20}\n{"-----------------------------------------------------------------------------------------------------------------------------------------------",0}");
        }
    }
}
