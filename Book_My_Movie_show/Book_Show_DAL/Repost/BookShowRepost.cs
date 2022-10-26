using Book_Show_Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Book_Show_DAL.Repost
{
    public class BookShowRepost:IBookShowRepost
    {
        Book_show_db _db;
        public BookShowRepost(Book_show_db db)
        {
            _db = db;
        }
        public void AddBookShow(BookShow bookShow)
        {
            _db.bookShow.Add(bookShow);
            _db.SaveChanges();
        }
        public void DeleteBookShow(int BookShowId)
        {
            var bookShow = _db.bookShow.Find(BookShowId);
            _db.bookShow.Remove(bookShow);
            _db.SaveChanges();
        }
        public BookShow GetBookShowById(int BookShowId)
        {
            return _db.bookShow.Find(BookShowId);
        }
        public IEnumerable<BookShow> GetBookShowByUserId(int UserId)
        {
            IEnumerable<BookShow> OutShows = null;
            List<BookShow> bookshow=_db.bookShow.Include(obj => obj.UserDetails).Include(obj => obj.ShowTiming).Include(obj => obj.ShowTiming.Movie).Include(obj => obj.ShowTiming.Theater).Include(obj => obj.ShowTiming.Theater.Location).ToList();
            var result=from booked in bookshow
                       where booked.UserId==UserId select booked;
            foreach(var item in result)
            {
                bookshow.Add(item);
            }
            return OutShows;
        }
        public IEnumerable<BookShow> GetAll()
        {
            return _db.bookShow.Include(obj=>obj.UserDetails).ToList();
        }
        public void UpdateBookShow(BookShow bookShow)
        {
            _db.Entry(bookShow).State = EntityState.Modified;
            _db.SaveChanges();
        }
        
    }
}
