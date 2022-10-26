using Book_Show_Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Book_Show_DAL.Repost
{
    public class TheaterRepost:ITheaterRepost
    {
        Book_show_db _db;
        public TheaterRepost(Book_show_db db)
        {
            _db = db;
        }
        public void AddTheater(Theater theater)
        {
            _db.theater.Add(theater);
            _db.SaveChanges();
        }
        public void DeleteTheater(int TheaterId)
        {
            var theater = _db.theater.Find(TheaterId);
            _db.theater.Remove(theater);
            _db.SaveChanges();
        }
        public Theater GetTheaterById(int theaterId)
        {
            return _db.theater.Find(theaterId);
        }
        public IEnumerable<Theater> GetAll()
        {
            return _db.theater.Include(obj => obj.Location).ToList();
        }
        public void UpdateTheater(Theater theater)
        {
            _db.Entry(theater).State = EntityState.Modified;
            _db.SaveChanges();
        }
    }
}
