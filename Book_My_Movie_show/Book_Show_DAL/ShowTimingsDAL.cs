using Book_Show_Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Book_Show_DAL
{
    public class ShowTimingsDAL
    {
        public class ShowOperations
        {
            Book_show_db db = null;
            public ShowOperations(Book_show_db db)
            {
                this.db = db;
            }

            //Book_show_db db = new Book_show_db();
            public string AddShowTiming(ShowTiming showTiming)
            {
                //db = new Book_show_db();
                db.showTiming.Add(showTiming);
                db.SaveChanges();
                return "added";
            }
            public string UpadteShowTiming(ShowTiming showTiming)
            {
                //db = new Book_show_db();
                db.Entry(showTiming).State = EntityState.Modified;
                db.SaveChanges();
                return "upadated";
            }
            public string RemoveShowTiming(int ShowTimingId)
            {
                ShowTiming ShowTimingObj = db.showTiming.Find(ShowTimingId);
                db.Entry(ShowTimingObj).State = EntityState.Deleted;
                db.SaveChanges();
                return "deleted";
            }
            public List<ShowTiming> showAllShowTiming()
            {
                //db = new Book_show_db();
                List<ShowTiming> showTiming = db.showTiming.ToList();


                return showTiming;
            }
        }
    }
}
