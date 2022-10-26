using Book_Show_Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Book_Show_DAL
{
    public class MovieDAL
    {
        

        public class MovieOperations
        {
            Book_show_db db = null;
            public MovieOperations(Book_show_db db)
            {
                this.db = db;
            }

            public string AddMovie(Movie movie)
            {

                db.movies.Add(movie);
                db.SaveChanges();
                return "added";
            }
            public string UpadteMovie(Movie movie)
            {

                db.Entry(movie).State = EntityState.Modified;
                db.SaveChanges();
                return "upadated";
            }
            public string RemoveMovie(int movieId)
            {
                Movie movieObj = db.movies.Find(movieId);
                db.Entry(movieObj).State = EntityState.Deleted;
                db.SaveChanges();
                return "deleted";
            }
            public List<Movie> showAllMovies()
            {

                List<Movie> movies = db.movies.ToList();

                /*  //linq
                  var result=from movies in movieList
                             where movies.MovieType==type
                             orderby movies.Name
                             select new Movie
                             {
                                 Id = movies.Id,
                                 Name = movies.Name
                             };
              List<Movie> movieResult = new List<Movie>();
                  foreach (var item in result)//linqqureyexecution
                  {
                      movieResult.Add(item);
                  }
                  return movieResult;*/
                return movies;
            }
            public Movie ShowMovieById(int MovieId)
            {

                Movie movie = db.movies.Find(MovieId);
                return movie;
            }
            public List<Movie> ShowMovieByName(String type)
            {

                /*Movie movie = db.movies.Find(MovieName);*/
                List<Movie> movieList = db.movies.ToList();
                var result = from movies in movieList
                             where movies.MovieName == type
                             orderby movies.MovieName
                             select movies;

                List<Movie> movieResult = new List<Movie>();
                foreach (var item in result)//linqqureyexecution
                {
                    movieResult.Add(item);
                }
                return movieResult;

            }
            public List<Movie> ShowMovieByType(String type)
            {
                //db = new Book_show_db();
                /*Movie movie = db.movies.Find(MovieName);*/
                List<Movie> movieList = db.movies.ToList();
                var result = from movies in movieList
                             where movies.MovieType == type

                             select movies;

                List<Movie> movieResult = new List<Movie>();
                foreach (var item in result)//linqqureyexecution
                {
                    movieResult.Add(item);
                }
                return movieResult;

            }
            public List<Movie> ShowMovieByDesc(String type)
            {
                //db = new Book_show_db();
                /*Movie movie = db.movies.Find(MovieName);*/
                List<Movie> movieList = db.movies.ToList();
                var result = from movies in movieList
                             where movies.MovieDesc == type

                             select movies;

                List<Movie> movieResult = new List<Movie>();
                foreach (var item in result)//linqqureyexecution
                {
                    movieResult.Add(item);
                }
                return movieResult;

            }
        }
    }
}
