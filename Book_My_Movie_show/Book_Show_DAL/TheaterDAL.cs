using Book_Show_Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Book_Show_DAL
{
    public class TheaterDAL
    {
        public class ShowOperations
        {
            Book_show_db db = null;
            public ShowOperations(Book_show_db db)
            {
                this.db = db;
            }
            //Book_show_db db = new Book_show_db();
            public string AddTheater(Theater theater)
            {
                //db = new Book_show_db();
                db.theater.Add(theater);
                db.SaveChanges();
                return "added";
            }
            public string UpadteTheater(Theater theater)
            {
                //db = new Book_show_db();
                db.Entry(theater).State = EntityState.Modified;
                db.SaveChanges();
                return "upadated";
            }
            public string RemoveTheater(int TheaterId)
            {
                Theater movieObj = db.theater.Find(TheaterId);
                db.Entry(movieObj).State = EntityState.Deleted;
                db.SaveChanges();
                return "deleted";
            }
            public List<Theater> showAllTheater()
            {
                //db = new Book_show_db();
                List<Theater> Theaters = db.theater.ToList();

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
                return Theaters;
            }
            /* public Movie ShowMovieById(int MovieId)
             {
                 db = new Book_show_db();
                 Movie movie = db.movies.Find(MovieId);
                 return movie;
             }
             public List<Movie> ShowMovieByName(String type)
             {
                 db = new Book_show_db();
                 *//*Movie movie = db.movies.Find(MovieName);*//*
                 List<Movie> movieList = db.movies.ToList();
                 var result = from movies in movieList
                              where movies.Name == type
                              orderby movies.Name
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
                 db = new Book_show_db();
                 *//*Movie movie = db.movies.Find(MovieName);*//*
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
                 db = new Book_show_db();
                 *//*Movie movie = db.movies.Find(MovieName);*//*
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

             }*/

        }

    }
}
