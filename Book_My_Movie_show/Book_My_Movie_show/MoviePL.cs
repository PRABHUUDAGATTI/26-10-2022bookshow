using Book_Show_DAL;
using Book_Show_Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Book_My_Movie_show
{
    public class MoviePL
    {
        public void AddMovie()
        {
            MovieDAL movieOperations = new MovieDAL();
            Movie movie = new Movie();
            Console.WriteLine("enter a movie name");
            movie.Name = Console.ReadLine();
            Console.WriteLine("enter a movie Description");
            movie.MovieDesc = Console.ReadLine();
            Console.WriteLine("enter a movie type");
            movie.MovieType = Console.ReadLine();
            string msg = movieOperations.AddMovie(movie);
            Console.WriteLine(msg);

            Menu();
        }
        public void ShowAllMovies()
        {
            MovieDAL movieOperations = new MovieDAL();
            List<Movie> movies = movieOperations.showAllMovies();
            foreach (var item in movies)
            {
                Console.Write("movie id : " + item.Id);
                Console.Write("     movie name : " + item.Name);
                Console.Write("     movie desc : " + item.MovieDesc);
                Console.WriteLine("     movie type : " + item.MovieType);

            }
            Menu();
        }
        public void DeleteShow()
        {
            Console.WriteLine("Enter Movie Id:");
            int MovieId = Convert.ToInt32(Console.ReadLine());
            MovieDAL movieOperations = new MovieDAL();
            Console.WriteLine(movieOperations.RemoveMovie(MovieId));
            Menu();


        }
        public void Menu()
        {
            Console.WriteLine("-------welcom to movie section-------- ");
            Console.WriteLine("1 add ");
            Console.WriteLine("2 showall ");
            Console.WriteLine("3 delete");
            Console.WriteLine("4 update ");
            Console.WriteLine("5 Search ");
            int MovieId = Convert.ToInt32(Console.ReadLine());
            switch (MovieId)
            {
                case 1:
                    AddMovie();
                    break;
                case 2:
                    ShowAllMovies();
                    break;
                case 3:
                    DeleteShow();
                    break;
                case 4:
                    UpadteMovie();
                    break;
                case 5:
                    ShowMovieById();
                    break;
            }
        }
        public void UpadteMovie()
        {
            MovieDAL movieOperations = new MovieDAL();
            Movie movie = new Movie();
            Console.WriteLine("enter a movie id");
            movie.Id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("enter a movie name");
            movie.Name = Console.ReadLine();
            Console.WriteLine("enter a movie Description");
            movie.MovieDesc = Console.ReadLine();
            Console.WriteLine("enter a movie type");
            movie.MovieType = Console.ReadLine();
            Console.WriteLine(movieOperations.UpadteMovie(movie));

            Menu();
        }
        public void ShowMovieById()
        {
            Console.WriteLine("------Search Movie BY Movie ID----");
            Console.Write("Search By Movie Id:");
            Console.Write("Search By Movie name:");
            Console.Write("Search By Movie language:");
            Console.Write("Search By Movie type:");
            int Id = Convert.ToInt32(Console.ReadLine());
            MovieDAL movieOperations = new MovieDAL();

            switch (Id)
            {
                case 1:
                    SearchById();
                    break;
                case 2:
                    SearchByName();
                    break;
            }



            Menu();

        }
        public void SearchMenu()
        {
            Console.WriteLine("-------welcom to search section-------- ");
            Console.WriteLine("1 Search by Id ");
            Console.WriteLine("2 Search by name ");
            Console.WriteLine("3 Search by type");
            Console.WriteLine("4 Search by desc ");
            int M = Convert.ToInt32(Console.ReadLine());
            switch (M)
            {
                case 1:
                    SearchById();
                    break;
                case 2:
                    SearchByName();
                    break;
                case 3:
                    SearchByType();
                    break;
                case 4:
                    SearchByDesc();
                    break;
            }
        }
        public void SearchById()
        {
            Console.Write("Search By Movie id:");
            int MovieId = Convert.ToInt32(Console.ReadLine());
            MovieDAL movieOperations = new MovieDAL();
            Movie movieId = movieOperations.ShowMovieById(MovieId);
            Console.Write("movie id : " + movieId.Id);
            Console.Write("     movie name : " + movieId.Name);
            Console.Write("     movie desc : " + movieId.MovieDesc);
            Console.WriteLine("     movie type : " + movieId.MovieType);
            SearchMenu();
        }
        public void SearchByName()
        {
            Console.Write("Search By Movie Name:");
            string MovieName = Console.ReadLine();
            MovieDAL movieOperations = new MovieDAL();
            List<Movie> movieI = movieOperations.ShowMovieByName(MovieName);
            foreach (var movieId in movieI)
            {
                Console.Write("movie id : " + movieId.Id);
                Console.Write("     movie name : " + movieId.Name);
                Console.Write("     movie desc : " + movieId.MovieDesc);
                Console.WriteLine("     movie type : " + movieId.MovieType);
            }
            SearchMenu();
        }
        public void SearchByType()
        {
            Console.Write("Search By Movie Type:");
            string MovieType = Console.ReadLine();
            MovieDAL movieOperations = new MovieDAL();
            List<Movie> movieI = movieOperations.ShowMovieByType(MovieType);
            foreach (var movieId in movieI)
            {
                Console.Write("movie id : " + movieId.Id);
                Console.Write("     movie name : " + movieId.Name);
                Console.Write("     movie desc : " + movieId.MovieDesc);
                Console.WriteLine("     movie type : " + movieId.MovieType);
            }
            SearchMenu();
        }
        public void SearchByDesc()
        {
            Console.Write("Search By Language");
            string MovieLang = Console.ReadLine();
            MovieDAL movieOperations = new MovieDAL();
            List<Movie> movieI = movieOperations.ShowMovieByDesc(MovieLang);
            foreach (var movieId in movieI)
            {
                Console.Write("movie id : " + movieId.Id);
                Console.Write("     movie name : " + movieId.Name);
                Console.Write("     movie desc : " + movieId.MovieDesc);
                Console.WriteLine("     movie type : " + movieId.MovieType);
            }
            SearchMenu();
        }
    }
}
