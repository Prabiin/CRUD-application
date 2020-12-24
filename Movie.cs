using System;
using System.Data.SqlClient;
using ConsoleTables;
using static System.Console;

namespace MovieProject
{
    class Movie
    {
        private string movieName, director, genre;
        private float rating;
        private int releasedYear;
        private static string query;
        private Movie()
        {
        }
        private Movie(string mName, string dName, string mGenre, int year, float rate)
        {
            movieName = mName;
            director = dName;
            genre = mGenre;
            releasedYear = year;
            rating = rate;
        }
        public static void AddMovieInfo()
        {
            DB.OpenConnection();
            string movieName, director, genre;
            int releasedYear;
            float rating;
            Console.Write("\nEnter movie name: ");
            movieName = Console.ReadLine().ToUpper();
            Console.Write("Enter name of director: ");
            director = Console.ReadLine().ToUpper();
            Console.Write("Enter name of genre: ");
            genre = Console.ReadLine().ToUpper();
            Console.Write("Enter the released year: ");
            jump0:
            try
            {
                releasedYear = int.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("\nInvalid Year!!!...Please re-enter again");
                Console.ResetColor();
                goto jump0;
            }
            jump1:
            Console.Write("Enter the rating (1 - 10): ");
            try
            {
                rating = float.Parse(Console.ReadLine());
            }
            catch(FormatException)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("\nInvalid rating!!!...Please re-enter again");
                Console.ResetColor();
                goto jump1;
            }
            query = "insert into tblMovie(MovieName, MovieDirector, MovieGenre, ReleasedYear, Rating)" +
               "values('" + movieName + "', '" + director + "', '" + genre + "', '" + releasedYear + "', '" + rating + "')";
            
            int i = DB.ExecuteQuery(query);
            if (i > 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("\nOne item inserted in database successfully.\n");
                Console.ResetColor();
            }
            DB.CloseConnection();

        }
       public static void ShowAllMovies()
        {
            DB.OpenConnection();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            var table = new ConsoleTable("ID", "Movie Name", "Director", "Genre", "Released Year", "Rating");
            string sql = "select * from tblMovie";
            SqlDataReader reader = DB.DataReader(sql);
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    string[] val = new string[reader.FieldCount];
                    for (int i = 0; i < reader.FieldCount; i++)
                        val[i] = Convert.ToString(reader.GetValue(i));
                    table.AddRow(val[0], val[1], val[2], val[3], val[4], val[5]);
                }
                table.Write();
                Console.WriteLine();
            }
            Console.ResetColor();
            DB.CloseConnection();
        }
        public static void DeleteMovie(uint Id)
        {
            DB.OpenConnection();
            string sql = "delete from tblMovie where id = '" + Id + "'";
            int i = DB.ExecuteQuery(sql);
            if (i > 0)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine($"\nMovie with ID: {Id} has been deleted successfully.\n");
                    Console.ResetColor();
                }
            else
                {
                    Console.WriteLine("\nThe item not found.");
                }
            DB.CloseConnection();
        }

        public static void UpdateMovie(uint Id)
        {
            DB.OpenConnection();
            jump0:
            ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n             -------What do you want to update in the movie?-------");
            ResetColor();
            ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\t[1] Movie Name\t\t[2] Director Name\t[3] Movie Genre\n\t[4] Released year\t[5] Rating \t\t[6] All\n\t\t\t\t[7] Exit");
            ResetColor();
            Console.Write("\nPlease enter the field you want to upadate: ");
            int ch = Convert.ToInt32(ReadLine());
            switch (ch)
            {
                case 1:
                    Console.Write("\nEnter the new movie name: ");
                    string movieName = Console.ReadLine().ToUpper();
                    query = "update tblMovie set MovieName = '"+ movieName +"' where Id = '"+ Id +"'";
                    int i = DB.ExecuteQuery(query);
                    if (i > 0)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine($"\nMovie with ID: {Id} has been updated successfully.\n");
                        Console.ResetColor();
                    }
                    goto jump0;
                case 2:
                    Console.Write("\nEnter the new director name: ");
                    string director = Console.ReadLine().ToUpper();
                    query = "update tblMovie set MovieDirector = '" + director + "' where Id = '" + Id + "'";
                    i = DB.ExecuteQuery(query);
                    if (i > 0)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine($"\nMovie with ID: {Id} has been updated successfully.\n");
                        Console.ResetColor();
                    }
                    goto jump0;
                case 3:
                    Console.Write("\nEnter the new movie genre: ");
                    string genre = Console.ReadLine().ToUpper();
                    query = "update tblMovie set MovieGenre = '" + genre + "' where Id = '" + Id + "'";
                    i = DB.ExecuteQuery(query);
                    if (i > 0)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine($"\nMovie with ID: {Id} has been updated successfully.\n");
                        Console.ResetColor();
                    }
                    goto jump0;
                case 4:
                    Console.Write("\nEnter the new released year: ");
                    string releasedYear = Console.ReadLine().ToUpper();
                    query = "update tblMovie set ReleasedYear = '" + releasedYear + "' where Id = '" + Id + "'";
                    i = DB.ExecuteQuery(query);
                    if (i > 0)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine($"\nMovie with ID: {Id} has been updated successfully.\n");
                        Console.ResetColor();
                    }
                    goto jump0;
                case 5:
                    Console.Write("\nEnter the new rating: ");
                    string rating = Console.ReadLine().ToUpper();
                    query = "update tblMovie set Rating = '" + rating + "' where Id = '" + Id + "'";
                    i = DB.ExecuteQuery(query);
                    if (i > 0)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine($"\nMovie with ID: {Id} has been updated successfully.\n");
                        Console.ResetColor();
                    }
                    goto jump0;
                case 6:
                    Console.WriteLine("\nPlease enter the following details.");
                    Console.Write("New movie name: ");
                    string newName = Console.ReadLine().ToUpper();
                    Console.Write("New director name: ");
                    string newDirector = Console.ReadLine().ToUpper();
                    Console.Write("New genre: ");
                    string newGenre = Console.ReadLine().ToUpper();
                    Console.Write("New released year: ");
                    string newReleaseYear = Console.ReadLine().ToUpper();
                    Console.Write("New ratinf: ");
                    string newRating = Console.ReadLine().ToUpper();
                    query = "update tblMovie set MovieName = '"+ newName +"', MovieDirector = '"+ newDirector +"', MovieGenre = '"+ newGenre +"', ReleasedYear = '"+ newReleaseYear +"', Rating = '" + newRating + "' where Id = '" + Id + "'";
                    i = DB.ExecuteQuery(query);
                    if (i > 0)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine($"\nMovie with ID: {Id} has been updated successfully.\n");
                        Console.ResetColor();
                    }
                    goto jump0;
                case 7:
                    ForegroundColor = ConsoleColor.Red;
                    WriteLine("\nReturning to main menu...\n");
                    ResetColor();
                    break;
                default:
                    ForegroundColor = ConsoleColor.Red;
                    WriteLine("\nInvalid choice!!!...Please enter valid selection.\n");
                    ResetColor();
                    goto jump0;
            }
            DB.CloseConnection();
        }
    }
}
