using System;
using static MovieProject.Movie;
using static System.Console;
using System.Collections.Generic;
using System.Data;

namespace MovieProject
{
    class Program
    {
        static void Main(string[] args)
        {
            ForegroundColor = ConsoleColor.Red;
            WriteLine("         -------Console Movie Application with CRUD Operations-------\n");
            ResetColor();
            jump0:
            ForegroundColor = ConsoleColor.Magenta;
            WriteLine("                             AVAILABLE OPERATIONS");
            ResetColor();
            ForegroundColor = ConsoleColor.Green;
            WriteLine("\t[1] Add movie details\t[2] Show all movies\t[3] Update movie details\n\t[4] Delete movie\t[5] Clear Screen\t[6] Exit");
            ResetColor();
            ForegroundColor = ConsoleColor.DarkYellow;
            Write("\nPlease enter the operation you wish to perform: ");
            ResetColor();
            int ch = Convert.ToInt32(ReadLine());
            switch (ch)
            {
                case 1:
                    AddMovieInfo();
                    goto jump0;
                case 2:
                    ShowAllMovies();
                    goto jump0;
                case 3:
                    ForegroundColor = ConsoleColor.DarkYellow;
                    Write("\nPlease enter the ID of the movie you wish to update: ");
                    ResetColor();
                    jump1:
                    try
                    {
                        uint Id = uint.Parse(ReadLine());
                        UpdateMovie(Id);
                    }
                    catch (FormatException)
                    {
                        WriteLine("\nInvalid ID!!!...Please re-enter again\n");
                        goto jump1;
                    }
                    goto jump0;
                case 4:
                    ForegroundColor = ConsoleColor.DarkYellow;
                    Write("\nPlease enter the ID of the movie you wish to delete: ");
                    ResetColor();
                    jump2:
                    try
                    {
                        uint Id = uint.Parse(ReadLine());
                        DeleteMovie(Id);
                    }
                    catch (FormatException)
                    {
                        ForegroundColor = ConsoleColor.Red;
                        WriteLine("\nInvalid ID!!!...Please re-enter again\n");
                        ResetColor();
                        goto jump2;
                    }
                    goto jump0;
                case 5:
                    Clear();
                    goto jump0;
                case 6:
                    ForegroundColor = ConsoleColor.Red;
                    WriteLine("\nExiting Program...");
                    ResetColor();
                    break;
                default:
                    ForegroundColor = ConsoleColor.Red;
                    WriteLine("\nInvalid choice!!!...Please enter valid selection.\n");
                    ResetColor();
                    goto jump0;
            }
            ReadKey();
        }
    }
}
