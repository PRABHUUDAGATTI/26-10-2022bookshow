using Book_Show_Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Book_Show_DAL.Repost
{
    public interface IBookShowRepost
    {
        void AddBookShow(BookShow bookShow);
        void UpdateBookShow(BookShow bookShow);
        void DeleteBookShow(int BookShowId);
        BookShow GetBookShowById(int id);
        IEnumerable<BookShow> GetAll();
        IEnumerable<BookShow>  GetBookShowByUserId(int UserId);
    }
}
