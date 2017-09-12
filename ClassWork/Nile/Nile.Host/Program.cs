using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nile.Host 
{
    class Program 
    {
        static void Main(string [] args)
        {
            bool quit = false;           
            do
            {
                char choice = GetInput();
                switch (choice)
                {
                    case 'a':
                    case 'A': AddProduct(); break;

                    case 'l':
                    case 'L': ListProduct(); break;

                    case 'q':
                    case 'Q': quit = true; break;
                };
            } while (!quit);

        }

        private static void AddProduct()
        {
            Console.Write("Enter product name: ");
            productName = Console.ReadLine().Trim();

            // Ensure not empty

            Console.Write("Enter price ( > 0): ");
            string price = Console.ReadLine();

            Console.Write("Enter optional description: ");
            productDescription = Console.ReadLine().Trim();

            Console.Write("Is it discontinued (Y/N): ");
            string discontinued = Console.ReadLine().Trim();
        }

        private static void ListProduct()
        {
            throw new NotImplementedException();
        }

        static char GetInput()
        {
            while (true)
            {
                Console.WriteLine("Main Menu");
                Console.WriteLine("".PadLeft(10,'-'));
                Console.WriteLine("A)add Product");
                Console.WriteLine("L)ist Products");
                Console.WriteLine("Q)uit");

                string input = Console.ReadLine().Trim();

                // option 1 = string literal
                // if(input !="")

                // option 2 - string field
                // if (input != String.Empty)

                // option 3 - length              
                if (input != null && input.Length != 0)
                {
                    // string comparison
                    if (String.Compare(input, "A", true) == 0)
                        return 'A';

                    // char comparison
                    char letter = Char.ToUpper(input[0]);
                    if (letter == 'A')
                        return 'A';
                    else if (letter == 'L')
                        return 'L';
                    else if (letter == 'Q')
                        return 'Q';
                }           

                // Error
                Console.WriteLine("Please choose a valid option");
            };

        }

        static void Main2( string[] args )
        {
            int hours = 5;
            hours = 10;

            string name = "John";

            // concat
            name = name + " williams";

            // copy
            name = "Hello";

            bool areEqual = name == "Hello";
            bool areNotEqual = name != "Hello";

            // verbatim string - no escape sequences
            string path = @"C:\Temp\test.txt";

            // option 1
            string names = "John" + " william" + " Murphy" + " Charles" + " Henry";

            // option 2
            StringBuilder builder = new StringBuilder();
            builder.Append("John");
            builder.Append(" william");            
            string names2 = builder.ToString();

            // option 3
            string names3 = String.Concat("John", " william", " Murphy", " Charles", " Henry");

            // string formatting - John worked 10 hours
            string format1 = name + " worked" + hours.ToString() + " hours";

            string format2 = String.Format("{0} worked for {1} hours", name, hours);
            
            // end of last week examples for formatting strings

            // new section
            // option 3 - string interpulation mode - any expression allowed
            string format3 = $"{name} worked for {hours} hours";

        }

        // Product
        static string productName;
        static decimal productPrice;
        static string productDescription;
        static bool productDiscontinued;
        
    }
}
