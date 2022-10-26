using Book_Show_DAL.Repost;
using Book_Show_Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Book_Show_BLL.Services
{
    public class MovieServices
    {
        IMovieRepository _movieRepostry;

        public MovieServices(IMovieRepository movieRepostry)
        {
            _movieRepostry = movieRepostry;
        }
        public void AddMovie(Movie movie)
        {
            _movieRepostry.AddMovie(movie);
        }
        public void UpdateMovie(Movie movie)
        {
            _movieRepostry.UpdateMovie(movie);
        }
        public void DeleteMovie(int Id)
        {
            _movieRepostry.DeleteMovie(Id);
        }
        public Movie GeMovieById(int id)
        {
            return _movieRepostry.GetMovieById(id);
        }
        public IEnumerable<Movie> GetAll()
        {
            return _movieRepostry.GetAll();
        }
    }
}
