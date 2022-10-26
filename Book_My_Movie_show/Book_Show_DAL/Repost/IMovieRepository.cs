using Book_Show_Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Book_Show_DAL.Repost
{
    public interface IMovieRepository
    {
        void AddMovie(Movie movie);
        void UpdateMovie(Movie movie);  
        void DeleteMovie(int MovieId);
        Movie GetMovieById(int id);
        IEnumerable<Movie> GetAll();
    }
}
