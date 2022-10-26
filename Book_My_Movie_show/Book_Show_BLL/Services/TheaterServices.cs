using Book_Show_DAL.Repost;
using Book_Show_Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Book_Show_BLL.Services
{
    public class TheaterServices
    {
        ITheaterRepost _theaterRepost;

        public TheaterServices(ITheaterRepost theaterRepost)
        {
            _theaterRepost = theaterRepost;
        }
        public void AddTheater(Theater theater)
        {
            _theaterRepost.AddTheater(theater);
        }
        public void UpdateTheater(Theater theater)
        {
            _theaterRepost.UpdateTheater(theater);
        }
        public void DeleteTheater(int Id)
        {
            _theaterRepost.DeleteTheater(Id);
        }
        public Theater GeTheaterById(int id)
        {
            return _theaterRepost.GetTheaterById(id);
        }
        public IEnumerable<Theater> GetAll()
        {
            return _theaterRepost.GetAll();
        }
    }
}
