using Book_Show_DAL.Repost;
using Book_Show_Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Book_Show_BLL.Services
{
    public class BookShowServices
    {
        IBookShowRepost _BookShowRepost;

        public BookShowServices(IBookShowRepost BookShowRepost)
        {
            _BookShowRepost = BookShowRepost;
        }
        public void AddBookShow(BookShow bookShow)
        {
            _BookShowRepost.AddBookShow(bookShow);
        }
        public void UpdateBookShow(BookShow bookShow)
        {
            _BookShowRepost.UpdateBookShow(bookShow);
        }
        public void DeleteBookShow(int Id)
        {
            _BookShowRepost.DeleteBookShow(Id);
        }
        public BookShow GeBookShowById(int id)
        {
            return _BookShowRepost.GetBookShowById(id);
        }
        public IEnumerable<BookShow> GetAll()
        {
            return _BookShowRepost.GetAll();
        }
        public IEnumerable<BookShow> GetBookShows(int UserId)
        {
            return _BookShowRepost.GetBookShowByUserId(UserId);
        }
    }
}
