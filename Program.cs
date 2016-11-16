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
                    var getResponse = 10;               //initialize to an invalid value
                    Console.Write("Select option: ");
                    try
                    {                                   //throw an exception if the input is invalid
                        getResponse = Convert.ToInt32(Console.ReadLine());
                        if (!(getResponse >= 0 && getResponse <= 5))
                            throw new ArgumentOutOfRangeException();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);  //catch the exception and display the error
                    }

                    switch (getResponse)                //return the action corresponding to the choice
                    {
                        case 0:                         //initializes and shows data
                            manipulate.DisplayAllData();
                            break;
                        case 1:                         //add a new entry
                            manipulate.Add();
                            break;
                        case 2:                         //modify a specific entry
                            manipulate.Modify();
                            break;
                        case 3:                         //search a specific entry
                            manipulate.Search();
                            break;
                        case 4:                         //display the number of entry
                            Console.Write("Dataset count {0}\n\n", manipulate.Count);
                            break;
                        case 5:                         //exit the program
                            response = true;
                            break;
                        case 6:                         //exit the program
                            response = true;
                            break;
                    }
                }
            }
            catch (WebException e)
            {                               //catch error if the online ressource is not available
                Console.WriteLine("{0} while reading your file. Make sure it exist", e.Status);
            }
        }
    }
}