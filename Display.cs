using System;

namespace P3_oyedotnOyesanmi
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

        public static void AddNewData()
        {
            Console.WriteLine("1) Search by Name");
            Console.WriteLine("2) Search by Party");
            Console.WriteLine("3) Search by State");
            Console.WriteLine("4) Search by County");
        }

        public static void CountyToModify()
        {
            Console.WriteLine("\nChoose the State and County you want to modify data");
            Console.WriteLine("1. County");
            Console.WriteLine("2. State");
        }
    }
}
