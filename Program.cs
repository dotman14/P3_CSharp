﻿using System;

namespace P3_oyedotnOyesanmi
{
    internal class MainClass
    {
        public static void Main(string[] args)
        {
            //var response = false;
            var data = new CsvFileReader();


            Console.WriteLine(data.GetContent()[0].Length);

            //for(var i = 0; i < data.GetContent()[2].Length; i++)
            //    Console.WriteLine(data.GetContent()[2][i]);


            //int getChar;
            //while (response == false)
            //{
            //    Display.GetMenu();

            //    Console.Write("Select option: ");
            //    getChar = Convert.ToInt16(Console.ReadLine());

            //    switch (getChar)
            //    {
            //        case 0:
            //            Console.Write("Option 0\n");
            //            break;
            //        case 1:
            //            Console.Write("Option 1\n\n");
            //            Console.WriteLine(data.GetContent());
            //            break;
            //        case 2:
            //            Console.Write("Option 2\n\n ");
            //            break;
            //        case 3:
            //            Console.Write("Option 3\n\n");
            //            break;
            //        case 4:
            //            Console.Write("Option 4\n\n");
            //            break;
            //        case 5:
            //            response = true;
            //            break;
            //        default:
            //            Console.Write("Wrong option\n\n");
            //            break;
            //    }
            //}
        }
    }
}
