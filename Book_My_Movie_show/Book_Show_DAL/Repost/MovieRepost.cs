using Book_Show_Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Book_Show_DAL.Repost
{
    public class MovieRepost:IMovieRepository
    {
        Book_show_db _db;
        public MovieRepost(Book_show_db db)
        {
            _db = db;
        }
        public void AddMovie(Movie movie)
        {
            _db.movies.Add(movie);
            _db.SaveChanges();
        }
        public void DeleteMovie(int MovieId)
        {
            var movie=_db.movies.Find(MovieId);
            _db.movies.Remove(movie);
            _db.SaveChanges();
        }
        public Movie GetMovieById(int MovieId)
        {
            return _db.movies.Find(MovieId);
        }
        public IEnumerable<Movie> GetAll()
        {
            return _db.movies.ToList();
        }
        public void UpdateMovie(Movie movie)
        {
            _db.Entry(movie).State = EntityState.Modified;
            _db.SaveChanges();
        }
    }
}
