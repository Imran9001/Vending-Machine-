using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vending_Machine
{ 
class Program
{        
        /// This method accepts 1 string parameter and returns a string value.
        /// If the paramter entered is not equal to "Y" or "N" then it will
        /// tell the user to enter again until the paramter is equal to "Y" or "N"
        static string Yesorno(string option)  
        {
            while (option != "Y" && option != "N")
            {
                Console.WriteLine("Please enter only Y or N");
                option = Console.ReadLine().ToUpper();
            }
            return option;
        }
        /// This method returns a double value.
        /// It asks the user how many credits to add. If the value entered is not a number or if a negative number is entered
        /// then it will ask the user to enter again until a postive number is entered.
        static double AdditionalCredits()
        {
            Console.WriteLine("How many credits do you want to add?");
            double addCredits;
            bool isNumberCredits = double.TryParse(Console.ReadLine(), out addCredits);
            while (isNumberCredits == false|| addCredits < 0)
            {
                Console.WriteLine("Please enter a number");
                isNumberCredits = double.TryParse(Console.ReadLine(), out addCredits);
            }
            return addCredits;
        }

        static void Main(string[] args)
    {
        int menuNumber = 3;
        double credits = 0.00;
        while (menuNumber == 3)                                                 /// Whole program part of while loop to allow the user to return to main menu. 
        {                             
            Console.WriteLine("UCLAN Vending Machines LTD");
            Console.WriteLine("Main Menu");
            Console.WriteLine("1. Add credits (current credits = {0})", credits);
            Console.WriteLine("2. Select Product");
            Console.WriteLine("");
            Console.WriteLine("Please enter a number");
            bool isNumber = int.TryParse(Console.ReadLine(), out menuNumber);
            while (menuNumber != 1 && menuNumber != 2 || isNumber == false)        
            {
                Console.WriteLine("Please enter only 1 or 2");
                isNumber = int.TryParse(Console.ReadLine(), out menuNumber);
            }
            if (menuNumber == 1)
            {
                credits = credits + AdditionalCredits();                                         /// Double value returned from this method is added to the double variable credits. 
                Console.WriteLine("Enter 3 to return to main menu or enter anything else to exit.");
                isNumber = int.TryParse(Console.ReadLine(), out menuNumber);
            }
            if (menuNumber == 2)
            {
                string[] products = new string[5] { "Chocolate bar", "Soda can", "Soda Water", "Crisps", "Cookies" };
                int[] list = new int[5] { 1, 2, 3, 4, 5 };
                double[] prices = new double[5] { 0.80, 0.60, 1.25, 0.50, 1.15 };
                Console.WriteLine("PRODUCT SELECTION    [Current Balance = {0} credits]", credits);
                Console.WriteLine();
                Console.WriteLine("Please choose from the following options");
                Console.WriteLine("");
                for (int item = 0; item < products.Length; item++)                                   /// Outputs product selection. 
                {
                    Console.Write("{0}.", list[item]);
                    Console.Write(" {0}", products[item]);
                    Console.Write("     [{0} credits]", prices[item]);
                    Console.WriteLine();

                }
                string productSelection = "Y";
                double subtotal = 0;
                double price;
                while (productSelection == "Y")
                {
                    int choiceArray;
                    bool isNumberChoiceArray = int.TryParse(Console.ReadLine(), out choiceArray);
                    while (isNumberChoiceArray == false || choiceArray > products.Length || choiceArray < 1)  /// Makes sure user can only enter a choice that is part of the product selection.
                    {
                        Console.WriteLine("Please only enter a number that corresponds to an item listed.");
                        isNumberChoiceArray = int.TryParse(Console.ReadLine(), out choiceArray);
                    }
                    int choice = choiceArray - 1;                                                             /// Product array starts from 0 whereas product item numbers start from 1. So 1 is subtracted to get the
                                                                                                              /// choice number that corresponds with the product array. 
                    price = prices[choice];
                    subtotal += price;                                                                          /// Value of variable price is added to subtotal in each iteration of the while loop.
                    Console.WriteLine("You have added {0} to your selection. Your current subtotal is {1} credits. Would you like to add another product? Enter Y for yes and N for no", products[choice], subtotal);
                    productSelection = Console.ReadLine().ToUpper();
                    productSelection = Yesorno(productSelection);                                               /// Passes string productSelection to initalise the parameter in this method.
                                                                                                                /// The value that is returned by this method becomes the new value of productselection.
                    if (productSelection == "Y")
                        Console.WriteLine("Please choose another product");
                }
                Console.WriteLine("Available Balance = {0} credits", credits);
                    Console.WriteLine("Grand total = {0} credits",subtotal);
                    double newBalance = credits - subtotal;
                    if (subtotal > credits)
                    {
                        double requiredCredits = subtotal - credits;
                        Console.WriteLine("You have insufficent credits. You require {0} credits", requiredCredits);
                        Console.WriteLine("Would you like to add more credits? Enter Y for yes and N for no");
                        string moreCredits = Console.ReadLine().ToUpper();
                        moreCredits = Yesorno(moreCredits);                                                         /// Passes string moreCredits to initalise the parameter in this method.
                        if (moreCredits == "Y")
                        {
                            credits = credits + AdditionalCredits();
                            Console.WriteLine("Your new balance is {0} credits", credits);
                            Console.WriteLine("Would you like to continue your order? Enter Y for yes and N for no");
                            string continueOrder = Console.ReadLine().ToUpper();
                            continueOrder = Yesorno(continueOrder);                                                      /// Passes string continueOrder to initalise the parameter in this method.
                            if (continueOrder == "Y")
                            {
                                Console.WriteLine("Available balance = {0} credits", credits);
                                Console.WriteLine("Grand total = {0} credits", subtotal);
                                newBalance = credits - subtotal;
                                Console.WriteLine("Your new balance = {0} credits", newBalance);
                                Console.WriteLine();
                                Console.WriteLine("Thanks for shopping with us");
                                Console.WriteLine("Press anything to exit");
                                Console.ReadLine();
                            }
                            else
                            {
                                Console.WriteLine("Thank you for shopping with us, press anything to exit");
                                Console.ReadLine();
                            }


                        }
                        else
                        {
                            Console.WriteLine("Press 3 to return to main menu or anything else to exit.");     
                            isNumber = int.TryParse(Console.ReadLine(), out menuNumber);
                            Console.ReadLine();

                        }

                    }
                    else
                    {
                        Console.WriteLine("Your new balance = {0} credits", newBalance);                  
                        Console.WriteLine("Thanks for shopping with us, press anything to exit");
                        Console.ReadLine();
                    }
                    
                

            }

        }

    }
}
}
