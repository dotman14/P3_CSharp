using System;

namespace P3_oyedotnOyesanmi
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            var manipulate = new DataManipulation();
            var response = false;            

            while (response == false)
            {
                Display.MainMenu();
                

                Console.Write("Select option: ");
                int getResponse = Convert.ToInt16(Console.ReadLine());

                switch (getResponse)
                {
                    case 0:
                        Console.Write("Dataset Intitilized\n");
                        manipulate.ShowData();

                        break;
                    case 1:
                        manipulate.Add("Senate", "Senate", "Senate", "Senate", 12 ,"Senate", 12, "Senate"); //test data
                        break;
                    case 2:
                        Console.Write("Option 2\n\n ");
                        break;
                    case 3:
                        manipulate.Search();
                        break;
                    case 4:
                        Console.Write("Dataset count {0}\n\n", manipulate.Count);
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
