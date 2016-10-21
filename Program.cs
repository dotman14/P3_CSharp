using System;
using System.Net;
namespace P3
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            try
            {
                var manipulate = new DataManipulation();
                var response = false;

                while (response == false)
                {
                    Display.MainMenu();

                    var getResponse = 10; //initialize to an invalid value
                    Console.Write("Select option: ");
                    try
                    {
                        getResponse = Convert.ToInt32(Console.ReadLine());
                        if(!(getResponse >= 0 && getResponse <= 5))
                            throw new ArgumentOutOfRangeException();                       
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    switch (getResponse) //return the action corresponding to the choice
                    {
                        case 0: //initializes and shows data
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
                    }
                }
            }
            catch (WebException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}