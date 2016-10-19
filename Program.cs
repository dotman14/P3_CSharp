using System;

namespace P3_oyedotnOyesanmi
{
    class MainClass
    {
        public static void Main(string[] args)
        {

          

            var getdata = new ElectionDataSet();
            foreach (var v in getdata.Data)
            {
                Console.WriteLine(v);
            }


            //foreach (var t in list)
            //    foreach (var t1 in t)
            //        Console.WriteLine(t1);


            //var e = new ElectionDataSet();

            //var response = false;

            //while (response == false)
            //{
            //    Display.GetMenu();

            //    Console.Write("Select option: ");
            //    int getChar = Convert.ToInt16(Console.ReadLine());

            //    switch (getChar)
            //    {
            //        case 0:
            //            Console.Write("Option 0\n");
            //            Console.WriteLine(e.GetSize);

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
