// Stephen Aranda
// ITSE 1430
// 9/18/2017
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class Program
    {
        static void Main( string[] args )
        {
            // boolean to quit program
            bool quit = false;

            do
            { 

                char choice = GetInput();
                switch (choice)
                 {
                     case 'a':
                     case 'A': AddMovie(); break;

                     case 'l':
                     case 'L': ListMovies(); break;

                     case 'q':
                     case 'Q': quit = true; break;

                     case 'r':
                     case 'R': RemoveMovie(); break;
                 };
            } while (!quit);

        }

        // Display Menu and get input from user
        static char GetInput()
        {
            while(true)
            {
                // Display Menu
                Console.WriteLine();
                Console.WriteLine("Main Menu");
                Console.WriteLine("".PadLeft(10, '-'));
                Console.WriteLine("L)ist Movies");
                Console.WriteLine("A)dd Movie");
                Console.WriteLine("R)emove Movie");
                Console.WriteLine("Q)uit");

                // collects user input and removes spaces
                // at the beginning and end of user input
                var input = Console.ReadLine().Trim();

                // makes char comparison and changes input to uppercase
                if(input != null && input.Length != 0)
                {
                    // char comparison
                    char letter = Char.ToUpper(input[0]);
                    if (letter == 'L')
                        return 'L';
                    else if (letter == 'A')
                        return 'A';
                    else if (letter == 'R')
                        return 'R';
                    else if (letter == 'Q')
                        return 'Q';
                };
                //error
                Console.WriteLine("Please choose a valid option");
            };
        }

        // Display movie name, description, length and whether or not 
        // it is owned
        private static void ListMovies()
        {
            string msg = $"Movie Title = {s_movieName}\nStatus = {(s_movieOwned ? "[Owned]" : "WishList")}";

           if(s_movieName == null)
            {
                Console.WriteLine("No movies available");
                return;
            };
               
            Console.WriteLine(msg);
            Console.WriteLine(s_movieDescription);
            Console.WriteLine($"Length = {s_movieLength} min");

        }

        // Add movies to list
        private static void AddMovie()
        {
            string validate;
            Console.Write("Enter a movie name: ");
            s_movieName = Console.ReadLine().Trim();
            if (s_movieName == null)
                validate = ReadString(s_movieName, false);
            

            Console.Write("Enter movie length(in minutes)( > 0): ");
            s_movieLength = ReadInt();

            Console.Write("Enter optional movie description: ");
            s_movieDescription = Console.ReadLine().Trim();
            if(s_movieDescription == null)
                validate = ReadString(s_movieDescription, true);

            Console.Write("Is movie owned (Y/N): ");
            s_movieOwned = ReadYesNo();
        }

        /// <summary>Reads a boolean from Console.</summary>
        /// <returns>The boolean value.</returns>
        static bool ReadYesNo()
        {
            do
            {
                string input = Console.ReadLine();

                if (!String.IsNullOrEmpty(input))
                {
                    switch (Char.ToUpper(input[0]))
                    {
                        case 'Y':
                            return true;
                        case 'N':
                            return false;
                    };
                };

                Console.WriteLine("Enter either Y or N");
            } while (true);
        }

        /// <summary>Reads an int from Console.</summary>
        /// <returns>The int value.</returns>
        static int ReadInt()
        {
            do
            {
                var input = Console.ReadLine();

                // int result;
                if ((Int32.TryParse(input, out var testResult)))
                    if (testResult == 0)
                    {
                        // begins a new iteration so correct value can be entered
                        Console.WriteLine("Enter a valid length");
                        continue;
                    }                                                                 
                else if (Int32.TryParse(input, out var result))
                    return result;

                Console.WriteLine("Enter a valid length");
            } while (true);
        }
        // checks for empty string - if movie name entered is null, the user is asked to enter
        // valid input. Optional description is returned blank. 
        static string ReadString( string errorMessage , bool allowEmpty )
        {            
            errorMessage = errorMessage ?? "Enter a valid string";
            

            do
            {
                var input = Console.ReadLine().Trim();
                if (String.IsNullOrEmpty(input) && allowEmpty == false)
                {
                    Console.Write("Movie name not entered. Enter a movie name: ");
                    return Console.ReadLine().Trim();
                }
                else if (String.IsNullOrEmpty(input) && allowEmpty == true)
                    return "";               
                else if (!String.IsNullOrEmpty(input))
                    return input;

                Console.WriteLine(errorMessage);
            } while (true);
        }

        // Remove a movie
        static void RemoveMovie()
        {
            
            Console.Write("Would you like to remove a movie(Y/N): ");            
            var input = Console.ReadLine().Trim();
            char letter = Char.ToUpper(input[0]);
            if (letter == 'Y')
            {
                s_movieName = null;
                Console.WriteLine("Movie Removed");
                return;
            } else
                Console.WriteLine("Movie not removed");

           
        }

        // movie info
        static string s_movieName;
        static string s_movieDescription;
        static int s_movieLength;
        static bool s_movieOwned;
    }
}
