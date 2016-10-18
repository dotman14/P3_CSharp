using System;

namespace P3_oyedotnOyesanmi
{
    public static class Display
    {
        public static void GetMenu()
        {
            Console.WriteLine("------------ Menu Display ------------");
            Console.WriteLine("Option 0) Clear and Load data ");
            Console.WriteLine("Option 1) Add an item");
            Console.WriteLine("Option 2) Modify Dataset");
            Console.WriteLine("Option 3) Search Dataset");
            Console.WriteLine("Option 4) Display Dataset Count");
            Console.WriteLine("Option 5) Exit");
            Console.WriteLine("------------------------------------\n");
        }

        public static void SearchDataOptions()
        {          
            Console.WriteLine("Option 0) Search by County");
            Console.WriteLine("Option 1) Search by Party");
        }
    }
}
