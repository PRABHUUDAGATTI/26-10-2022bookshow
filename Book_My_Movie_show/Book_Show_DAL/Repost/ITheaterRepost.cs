using Book_Show_Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Book_Show_DAL.Repost
{
    public interface ITheaterRepost
    {
        void AddTheater(Theater theater);
        void UpdateTheater(Theater theater);
        void DeleteTheater(int TheaterId);
        Theater GetTheaterById(int id);
        IEnumerable<Theater> GetAll();
    }
}
