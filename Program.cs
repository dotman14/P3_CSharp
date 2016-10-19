using System;

namespace P3_oyedotnOyesanmi
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            var getdata = new ElectionDataSet();
            var manipulate = new DataManipulation();
            var response = false;

            while (response == false)
            {
                Display.MainMenu();

                Console.Write("Select option: ");
                int getChar = Convert.ToInt16(Console.ReadLine());

                switch (getChar)
                {
                    case 0:
                        Console.Write("Option 0\n");
                        getdata.ShowData();

                        break;
                    case 1:
                        Console.Write("Option 1\n\n");
                        break;
                    case 2:
                        Console.Write("Option 2\n\n ");
                        break;
                    case 3:
                        manipulate.Search();
                        break;
                    case 4:
                        Console.Write("Option 4\n\n");
                        break;
                    case 5:
                        response = true;
                        break;
                    default:
                        Console.Write("Wrong option\n\n");
                        break;
                }
            }
        }
    }
}
