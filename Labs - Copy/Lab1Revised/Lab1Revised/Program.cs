// Stephen Aranda
// ITSE 1430
// 9/19/2017
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
                    case 'A':
                        AddMovie();
                        break;

                    case 'l':
                    case 'L':
                        ListMovies();
                        break;

                    case 'q':
                    case 'Q':
                        quit = true;
                        break;

                    case 'r':
                    case 'R':
                        RemoveMovie();
                        break;
                };
            } while (!quit);

        }

        // Display Menu and get input from user
        static char GetInput()
        {
            while (true)
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
                if (input != null && input.Length != 0)
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
            string msg = $"Movie Title = {MovieName}\nStatus = {(MovieOwned ? "[Owned]" : "WishList")}";

            if (MovieName == null)
            {
                Console.WriteLine("No movies available");
                return;
            };

            Console.WriteLine(msg);
            Console.WriteLine($"Description = {MovieDescription}");
            Console.WriteLine($"Length = {MovieLength} min");

        }

        // Add movies to list
        private static void AddMovie()
        {

            bool allowEmpty = true;
            Console.Write("Enter a movie name: ");
            MovieName = Console.ReadLine().Trim();
            if (MovieName == "")
            {
                allowEmpty = false;
                MovieName = ReadString(MovieName, allowEmpty);
            };
            // resetting to true if the if statement was executed
            allowEmpty = true;

            Console.Write("Enter movie length(in minutes)( >= 0): ");
            MovieLength = ReadInt();

            Console.Write("Enter optional movie description: ");
            MovieDescription = Console.ReadLine().Trim();

            if (MovieDescription == null)
                MovieDescription = ReadString(MovieDescription, allowEmpty);

            Console.Write("Is movie owned (Y/N): ");
            MovieOwned = ReadYesNo();
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
                if (Int32.TryParse(input, out var result))
                    return result;

                Console.WriteLine("Enter a valid length");
            } while (true);
        }
        // checks for empty string  
        static string ReadString( string error, bool allowEmpty )
        {
            do
            {
                error = Console.ReadLine().Trim();
                if (String.IsNullOrEmpty(error) && allowEmpty == true)
                    return "";
                else if (!String.IsNullOrEmpty(error))
                    return error;
                else if (String.IsNullOrEmpty(error) && allowEmpty == false)
                    Console.Write("Movie name not inputed. Please enter  movie name: ");

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
                MovieName = null;
                Console.WriteLine("Movie Removed");
                return;
            } else
                Console.WriteLine("Movie not removed");


        }

        // movie info
        static string MovieName;
        static string MovieDescription;
        static int MovieLength;
        static bool MovieOwned;
    }
}