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

                int getResponse = 10;                   //initialize to an invalid value
                Console.Write("Select option: ");
                try {                                   //get the value from the user
                    getResponse = Convert.ToInt32(Console.ReadLine());
                } catch (Exception ex){                 //check the value inputted
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("\n**Wrong option - Must input an number (0-5)**");
                }
                

                switch (getResponse)                    //return the action corresponding to the choice
                {
                    case 0:                             //initializes and shows data
                        Console.Write("Dataset Intitilized\n");
                        manipulate.ShowData();
                        break;
                    case 1:                             //add a new input the data
                        manipulate.Add(); 
                        break;
                    case 2:                             //modify an Row
                        manipulate.Modify();
                        break;
                    case 3:                             //search for an entry
                        manipulate.Search();
                        break;
                    case 4:                             //display the number of entry 
                        Console.Write("Dataset count {0}\n\n", manipulate.Count);
                        break;
                    case 5:                             //exit
                        response = true;
                        break;
                    default:                            //bad input
                        Console.Write("**Wrong option**\n\n");
                        break;
                }
            }
        }
    }
}
