using System;

namespace P3_oyedotnOyesanmi
{
    public static class Display
    {
        public static void MainMenu()
        {
            Console.WriteLine("------------ Menu Display ------------");
            Console.WriteLine("Option 0) Clear and Load Dataset ");
            Console.WriteLine("Option 1) Add an item to Dataset");
            Console.WriteLine("Option 2) Modify Dataset");
            Console.WriteLine("Option 3) Search Dataset");
            Console.WriteLine("Option 4) Display Dataset Count");
            Console.WriteLine("Option 5) Exit");
            Console.WriteLine("------------------------------------\n");
        }

        public static void SearchByOptions()
        {          
            Console.WriteLine("1) Search by Name");
            Console.WriteLine("2) Search by Party");
            Console.WriteLine("3) Search by State");
            Console.WriteLine("4) Search by County");
        }
    }
}
