﻿using System;
using System.Collections.Generic;

namespace P3_oyedotnOyesanmi
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            //var response = false;
            var data = new CsvFileReader();


            //Console.WriteLine(data.Content[0].Length);

            var cont = data.Content;
            var len = cont[2].Length;
            List<string[]> list = new List<string[]>(cont);

            //foreach (var t in list)
            //    foreach (var t1 in t)
            //        Console.WriteLine(t1);

            //foreach (var i in list)
            //{
            //    Console.WriteLine(i[2]);
            //}

                for (var ii = 0; ii < len; ii++)
                    Console.WriteLine(list[2][ii]);


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
