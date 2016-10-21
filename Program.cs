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

                int getResponse = 10;
                Console.Write("Select option: ");
                try {
                    getResponse = Convert.ToInt32(Console.ReadLine());
                } catch (Exception ex){
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("\n**Wrong option - Must input an number (0-5)**");
                }
                

                switch (getResponse)
                {
                    case 0:
                        Console.Write("Dataset Intitilized\n");
                        manipulate.ShowData();
                        break;
                    case 1:
                        manipulate.Add(); 
                        break;
                    case 2:
                        manipulate.Modify();
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
                        Console.Write("**Wrong option**\n\n");
                        break;
                }
            }
        }
    }
}
