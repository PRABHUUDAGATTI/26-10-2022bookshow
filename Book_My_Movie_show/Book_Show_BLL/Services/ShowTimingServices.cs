using Book_Show_DAL.Repost;
using Book_Show_Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Book_Show_BLL.Services
{
    public class ShowTimingServices
    {
        IShowTimingsRepost _ShowTimingRepost;

        public ShowTimingServices(IShowTimingsRepost showTimingRepost)
        {
            _ShowTimingRepost = showTimingRepost;
        }
        public void AddShowTiming(ShowTiming showTiming)
        {
            _ShowTimingRepost.AddShowTiming(showTiming);
        }
        public void UpdateShowTiming(ShowTiming showTiming)
        {
            _ShowTimingRepost.UpdateShowTiming(showTiming);
        }
        public void DeleteShowTiming(int Id)
        {
            _ShowTimingRepost.DeleteShowTiming(Id);
        }
        public ShowTiming GeShowTimingById(int id)
        {
            return _ShowTimingRepost.GetShowTimingById(id);
        }
        public IEnumerable<ShowTiming> GetAll()
        {
            return _ShowTimingRepost.GetAll();
        }
        public ShowTiming GetLatone()
        {
            return _ShowTimingRepost.LastOne();
        }
    }
}
